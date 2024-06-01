using DO_AN_KI_2.service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace DO_AN_KI_2
{
    public partial class CreateOrder : Form
    {

        DataServices services = new DataServices();
        public List<ProductModelAdd> listProductModel = new List<ProductModelAdd>();
        private bool ModeNew = true;
        private string employId = Properties.Settings.Default.userID;
        private string employName = Properties.Settings.Default.fullName;
        int totalPriceNum = 0;

        OrderModel model;
        public CreateOrder(bool modeNew = true, OrderModel model = null)
        {

            InitializeComponent();
            this.ModeNew = modeNew;
            this.model = model;
            cboPay.DataSource = new string
                [] { "QR", "Tiền mặt" };

        }

        void fillCustomer()
        {
            string query = "select * from tblCUSTOMER";
            customerSelect.DataSource = services.ShowObjectData(query);
            customerSelect.DisplayMember = "customerName";
            customerSelect.ValueMember = "customerID";
        }

        private void CreateOrder_Load_1(object sender, EventArgs e)
        {

            fillCustomer();

            if (ModeNew)
            {
                employ.Text = employName;
                dateOrder.Text = DateTime.Now.ToString();
                this.ControlBox = false;
            }
            else
            {
                label1.Text = "XEM ĐƠN HÀNG";
                AddCustomer.Visible = false;
                employ.Text = model.employName;
                dateOrder.Text = model.date;
                customerSelect.SelectedValue = model.customer;
                totalPrice.Text = model.totalPrice;
                customerSelect.Enabled = false;
                note.ReadOnly = true;
                AddButton.Visible = false;
                saveButton.Visible = false;
                cboPay.SelectedItem = model.payMethods;

                string query = $"select od.price , od.productID , od.quantity , pr.nameProduct, o.paymentsMethods  from tblORDERDETAIL as od left join tblPRODUCT as pr on od.ProductID = pr.ProductID left join tblORDER o on o.orderID=od.oderID where od.oderID = '{model.OrderID}';";

                DataGridView.DataSource = (DataTable)services.ShowObjectData(query);
                DataGridView.AutoGenerateColumns = false;
                DataGridView.Columns.Clear();

                DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
                col1.DataPropertyName = "ProductID";
                col1.HeaderText = "ID";
                DataGridView.Columns.Add(col1);

                DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
                col2.DataPropertyName = "nameProduct";
                col2.HeaderText = "TÊN";
                DataGridView.Columns.Add(col2);

                DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
                col3.DataPropertyName = "price";
                col3.HeaderText = "GIÁ (VND)";
                DataGridView.Columns.Add(col3);

                DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
                col4.DataPropertyName = "quantity";
                col4.HeaderText = "SỐ LƯỢNG";
                DataGridView.Columns.Add(col4);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            FormSelectProduct formSelectProduct = new FormSelectProduct(modeFormAddProduct.Order);
            formSelectProduct.ShowDialog();
            if (formSelectProduct.productModel != null)
            {
                var index = listProductModel.FindIndex(x => x.id == formSelectProduct.productModel.id);
                if (index != -1)
                {
                    listProductModel[index].quantity += formSelectProduct.productModel.quantity;

                    int rowIndex = -1;
                    foreach (DataGridViewRow row in DataGridView.Rows)
                    {
                        if (row.Cells[0].Value.ToString().Equals(formSelectProduct.productModel.id))
                        {
                            rowIndex = row.Index;
                            break;
                        }
                    }
                    if (rowIndex != 1)
                    {
                        DataGridView.Rows[rowIndex].Cells[3].Value = listProductModel[index].quantity.ToString();
                    }
                }
                else
                {
                    DataGridView.Rows.Add(formSelectProduct.productModel.id, formSelectProduct.productModel.productName, formSelectProduct.productModel.price, formSelectProduct.productModel.quantity);
                    listProductModel.Add(formSelectProduct.productModel);
                }
                totalPriceNum += (formSelectProduct.productModel.price * formSelectProduct.productModel.quantity);
                totalPrice.Text = totalPriceNum.ToString("N0", new CultureInfo("vi-VN")) + " VND";
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (listProductModel.Count == 0)
            {
                message.showWarning("Vui lòng chọn ít nhất một sản phẩm!");
                return;
            }

            Guid id = Guid.NewGuid();
            if (cboPay.SelectedItem == "QR")
            {
                QRPay qRPay = new QRPay(totalPriceNum, id.ToString());
                qRPay.ShowDialog();
                if (!qRPay.thanhToanThanhCong)
                {
                    return;
                }
            }

            if (ModeNew)
            {
                DateTime today = DateTime.Now;
                string iso8601DateTime = today.ToString("yyyy-MM-ddTHH:mm:ss.fff", CultureInfo.InvariantCulture);

                string query = $"insert into tblORDER values( '{id}' , '{iso8601DateTime}' , {customerSelect.SelectedValue} , {totalPriceNum},N'{cboPay.SelectedItem}', @note ,{employId})";
                services.ExecuteQueryWithValue(query, new object[] { note.Text });
                services.OpenDB();
                foreach (var item in listProductModel)
                {
                    string qr = $"insert into tblORDERDETAIL values ('{id}',{item.id},{item.quantity},{item.price})";
                    services.ExecuteQueries(qr);

                    string updateQr = $"update tblPRODUCT set quantity = {item.quantityInWareHouse - item.quantity} where ProductID = {item.id};";
                    services.ExecuteQueries(updateQr);

                    if (item.monthsWarranty > 0)
                    {
                        int years = item.monthsWarranty / 12;
                        int months = item.monthsWarranty % 12;
                        DateTime dateEnd = today.AddYears(years).AddMonths(months);
                        string createBaoHanh = $"insert into tblGUARANTEE values({item.id},'{iso8601DateTime}','{dateEnd.ToString()}',{customerSelect.SelectedValue},{employId})";
                        services.ExecuteQueries(createBaoHanh);
                    }

                }
                services.CloseDB();
                message.showSucess("Thêm thành công");
                DataGridView.Rows.Clear();
                note.Text = "";
                totalPriceNum = 0;
                totalPrice.Text = "0 VND";
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {

                DialogResult dr;
                dr = MessageBox.Show("Chắc chắn xóa dòng đang chọn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;
                {
                    int r = DataGridView.CurrentRow.Index;
                    string productID = DataGridView.Rows[r].Cells[0].Value.ToString();

                    var product = listProductModel.Find(x => x.id == productID);

                    totalPriceNum -= (product.price * product.quantity);
                    totalPrice.Text = totalPriceNum.ToString("N0", new System.Globalization.CultureInfo("vi-VN")) + " VND";

                    listProductModel.Remove(product);
                    DataGridView.Rows.RemoveAt(r);
                }
            }
        }

        private void cboPay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPay.SelectedItem == "Tiền mặt")
            {
                saveButton.Text = "Lưu";
            }
            else if (cboPay.SelectedItem == "QR")
            {
                saveButton.Text = "Tiếp tục";
            }
        }

        private void AddCustomer_Click(object sender, EventArgs e)
        {
            CustomerDetails customerDetails = new CustomerDetails(0, false);
            customerDetails.ShowDialog();
            string query = "select * from tblCUSTOMER";
            customerSelect.DataSource = services.ShowObjectData(query);
        }
    }

    public class OrderModel
    {
        public string OrderID { get; set; }
        public string customer { get; set; }
        public string note { get; set; }
        public string date { get; set; }
        public string employName { get; set; }
        public string totalPrice { get; set; }
        public string payMethods { get; set; }
        public OrderModel(string orderID, string customer, string note, string date, string employName, string totalPrice, string payMethods)
        {
            OrderID = orderID;
            this.customer = customer;
            this.note = note;
            this.date = date;
            this.employName = employName;
            this.totalPrice = totalPrice;
            this.payMethods = payMethods;
        }
    }
}
