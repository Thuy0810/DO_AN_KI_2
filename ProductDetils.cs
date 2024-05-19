using DO_AN_KI_2.service;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace DO_AN_KI_2
{
    public partial class ProductDetils : Form
    {
        
        private int id;
       DataServices dataServices= new DataServices();
        private bool Modeview;
        private bool EditMode;
        private string linkImage { get; set; }
        private string linkOldImage { get; set; }
        public ProductDetils(int id, bool Modeview)
        {
            InitializeComponent();
            dataServices.OpenDB();
            this.id = id;
            showDataCategory();
            showDatTrademark();
            showDataSupplier();
            btnEdit.Visible = Modeview;
            btnSave.Visible = !Modeview;
            setControl(Modeview);
            this.Modeview = Modeview;
            this.EditMode = !Modeview;
         }

        void showDataCategory()
        {
            string query = "select * from tblCATEGORY;";
            using (SqlCommand command = new SqlCommand(query, dataServices.connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    // Đặt DataSource của ComboBox bằng DataTable thay vì toàn bộ DataSet
                    category.DataSource = dataSet.Tables[0]; // Sử dụng chỉ số 0 vì chỉ có một DataTable được trả về từ truy vấn

                    // Đặt ValueMember và DisplayMember cho ComboBox
                    category.ValueMember = "categoryID"; // Đặt tên của cột chứa giá trị
                    category.DisplayMember = "name"; // Đặt tên của cột bạn muốn hiển thị
                }
            }
        }
        void showDataSupplier()
        {
            string query = @"select * from tblSUPPLIER ";
            using (SqlCommand command = new SqlCommand(query, dataServices.connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    supplier.DataSource = dataSet.Tables[0];
                    supplier.ValueMember = "supplierID";
                    supplier.DisplayMember = "supplierName";
                }
            }
        }


        void showDatTrademark()
        {
            string query = @"select * from tblTRADEMARK ";
            using (SqlCommand command = new SqlCommand(query, dataServices.connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataSet datSet = new DataSet();
                    adapter.Fill(datSet);
                    trademark.DataSource = datSet.Tables[0];
                    trademark.ValueMember = "trademarkID";
                    trademark.DisplayMember = "nameT";
                }
            }
        }

        
        private void ProductDetils_Load(object sender, EventArgs e)
        {
           // this.ControlBox=false;
          
            if (Modeview)
            {
                
            string query = "SELECT p.ProductID, p.nameProduct, p.quantity, p.originPrice, p.price, p.noLimit, c.categoryID, s.supplierName, t.trademarkID, s.supplierID, p.status, p.weight, p.description, p.isPhysic, p.img " +
                  "FROM tblPRODUCT p " +
                  "INNER JOIN tblCATEGORY c ON p.categoryID = c.categoryID " +
                  "INNER JOIN tblTRADEMARK t ON p.trademarkID = t.trademarkID " +
                  "INNER JOIN tblSUPPLIER s ON p.supplierID = s.supplierID " +
                  $"WHERE ProductID = {id}";

                dataServices.OpenDB();

                SqlDataReader reader= dataServices.DataReader(query);

                // Đọc dữ liệu từ DataReader
                if (reader.Read())
                {
                    // Lấy thông tin từ cột cụ thể trong truy vấn
                    string namePro = reader["nameProduct"].ToString();
                    int quantityPro = Convert.ToInt32(reader["quantity"].ToString());
                    int originPricePro = Convert.ToInt32(reader["originPrice"].ToString());
                    int picePro = Convert.ToInt32(reader["price"].ToString());
                    string categoryID = reader["categoryID"].ToString();
                    string supplierID = reader["supplierID"].ToString();
                    string trademarkID = reader["trademarkID"].ToString();
                    decimal weightPro =  Convert.ToDecimal(reader["weight"].ToString());
                    string descriptionPro = reader["description"].ToString();
                     linkOldImage = reader["img"].ToString();
                    // Gán thông tin vào các TextBox trên Form B
                    try
                    {
                        if (linkOldImage != null && linkOldImage != string.Empty)
                        {
                            boxPicture.Image = new Bitmap($@"{Directory.GetCurrentDirectory()}\{linkOldImage}");
                        }
                    }
                    catch
                    {

                    }

                    txtNameP.Text = namePro;
                    txtQuantityP.Text = quantityPro.ToString();
                    txtOriginPrice.Text = originPricePro.ToString();
                    txtPrice.Text = picePro.ToString();
                    txtDescription.Text = descriptionPro.ToString();
                    txtWeight.Text = weightPro.ToString();


                    //category.Items.Add(categoryName);
                    category.SelectedValue = categoryID;


                    supplier.SelectedValue = supplierID;


                    trademark.SelectedValue = trademarkID;

                    int active = Convert.ToInt32(reader["status"]);
                    swActive.Checked = (active == 1); // Nếu status là 1 thì bật nút switch, ngược lại tắt

                    int physic = Convert.ToInt32(reader["isPhysic"]);
                    swPhysic.Checked = (physic == 1);

                    int limit = Convert.ToInt32(reader["noLimit"]);
                    swLimit.Checked = (limit == 1);

                    // ...
                }
            
            dataServices.CloseDB();
               
            }
        }
        public  void setControl(bool status)
        {
            txtNameP.ReadOnly = status;
            txtQuantityP.ReadOnly = status;
            txtOriginPrice.ReadOnly = status;
            txtPrice.ReadOnly = status;
            txtDescription.ReadOnly = status;
            txtWeight.ReadOnly = status;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Visible = true;
            setControl(false);
            EditMode = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNameP.Text.Trim().Length == 0)
            {
                MessageBox.Show("Tên sản phẩm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNameP.Focus();
                return;
            }

            if (txtNameP.Text.Trim().Length > 200)
            {
                MessageBox.Show("Tên sản phẩm nhập quá dài (<=50 kí tự)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNameP.Focus();
                return;
            }

             if (txtDescription.Text.Trim().Length > 200)
                {
                    MessageBox.Show("Mô tả nhập quá dài (<=200 kí tự)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescription.Focus();
                    return;
                }
          if(txtQuantityP.Text.Trim().Length ==0)
            {
                MessageBox.Show("Số lượng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantityP.Focus();
                return;
            }
          if(txtOriginPrice.Text.Trim().Length == 0)
            {
                MessageBox.Show("Giá gốc không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
          if(txtPrice.Text.Trim().Length == 0)
            {
                MessageBox.Show("Giá bán không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
          if(boxPicture==null)
            {
                MessageBox.Show("Hình ảnh không được để trống","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (Modeview)
            {
                
                try
                {
                    dataServices.OpenDB();
                    //1. hỏi xác nhận sửa  dữ liệu không?
                    DialogResult dr;
                    dr = MessageBox.Show("Lưu thay đổi?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No) return;

                        // Lấy giá trị từ các điều khiển trên giao diện

                        string nameProduct = txtNameP.Text;
                        string description = txtDescription.Text;
                        decimal weightProduct;
                        decimal.TryParse(txtWeight.Text, out weightProduct);

                        var trademaarkId = trademark.SelectedValue.ToString();
                        var idCategory = category.SelectedValue.ToString();
                        var idSupplier = supplier.SelectedValue.ToString();
                        int status = swActive.Checked ? 1 : 0;
                        int isPhysic1 = swPhysic.Checked ? 1 : 0;
                        int noLimit = swLimit.Checked ? 1 : 0;

                        int originPrice;
                        int.TryParse(txtOriginPrice.Text, out originPrice);
                        int price;
                        int.TryParse(txtPrice.Text, out price);
                        // Sử dụng parameterized query để tránh lỗ hổng SQL injection
                        string query = $"UPDATE tblPRODUCT SET nameProduct = @nameProduct, isPhysic=@isPhysic, originPrice=@originPrice, price=@price, noLimit=@noLimit,img=@img, description=@description, categoryID=@categoryID, trademarkID=@trademarkID, status=@status, supplierID= @supplierID, weight=@weight where ProductID={id}"; // Thay đổi tblCATEGORY thành tên bảng của bạn
                        string linkImageSaveToDb =linkImage != null ? $@"upload\{Path.GetFileName(linkImage)}":linkOldImage;
                   
                    SqlCommand command = new SqlCommand(query, dataServices.connection);


                        // Thêm các tham số và giá trị tương ứng vào câu lệnh SQL

                        command.Parameters.AddWithValue("@nameProduct", nameProduct);
                        command.Parameters.AddWithValue("@description", description);
                        command.Parameters.AddWithValue("@categoryID", idCategory);
                        command.Parameters.AddWithValue("@status", status);
                        command.Parameters.AddWithValue("@weight", weightProduct);
                        command.Parameters.AddWithValue("@trademarkID", trademaarkId);
                        command.Parameters.AddWithValue("@supplierID", idSupplier);
                        command.Parameters.AddWithValue("@isPhysic", isPhysic1);
                        command.Parameters.AddWithValue("@noLimit", noLimit);
                        command.Parameters.AddWithValue("@originPrice", originPrice);
                        command.Parameters.AddWithValue("@price", price);
                        command.Parameters.AddWithValue("@img", linkImageSaveToDb);

                    string currentPath = Directory.GetCurrentDirectory() + "\\upload";
                    if (!Directory.Exists(currentPath))
                    {
                        Directory.CreateDirectory(currentPath);
                    }

                    string newPathImage = $@"{currentPath}\{Path.GetFileName(linkImage)}";
                    string oldPathImage = $@"{Directory.GetCurrentDirectory()}\{linkOldImage}";
                    
                    if (linkImage != null)
                    {
                        if (File.Exists(oldPathImage))
                        {
                            File.Delete(oldPathImage);
                        }
                        File.Copy(linkImage, newPathImage, true);
                    }


                    // Thực thi câu lệnh SQL
                    SqlCommand command1= new SqlCommand(query,dataServices.connection);   
                    command.ExecuteNonQuery();
                    this.Close();

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể lưu thay đổi: {ex}", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //them moi san pham
                try
                {
                    dataServices.OpenDB();
                    DialogResult dialogResult = MessageBox.Show("Chắc chắn thêm mới sản phẩm", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.No) return;

                    string linkImageSaveToDb = $@"upload\{Path.GetFileName(linkImage)}";
                    string queryInsert = "INSERT INTO tblPRODUCT(nameProduct, img, quantity, originPrice, price, description, noLimit, categoryID, trademarkID, isPhysic, weight, status, supplierID) VALUES (@nameProduct, @img, @quantity, @originPrice, @price, @description, @noLimit, @categoryID, @trademarkID, @isPhysic, @weight, @status, @supplierID)";

                    using (SqlCommand command = new SqlCommand(queryInsert, dataServices.connection))
                    {
                        command.Parameters.AddWithValue("@nameProduct", txtNameP.Text);
                        command.Parameters.AddWithValue("@img", linkImageSaveToDb);
                        command.Parameters.AddWithValue("@quantity", txtQuantityP.Text);
                        command.Parameters.AddWithValue("@originPrice", txtOriginPrice.Text);
                        command.Parameters.AddWithValue("@price", txtPrice.Text);
                        command.Parameters.AddWithValue("@description", txtDescription.Text);
                        command.Parameters.AddWithValue("@noLimit", swLimit.Checked);
                        command.Parameters.AddWithValue("@categoryID", category.SelectedValue);
                        command.Parameters.AddWithValue("@trademarkID", trademark.SelectedValue);
                        command.Parameters.AddWithValue("@isPhysic", swPhysic.Checked);
                        command.Parameters.AddWithValue("@weight", txtWeight.Text != "" ? txtWeight.Text : "0");
                        command.Parameters.AddWithValue("@status", swActive.Checked);
                        command.Parameters.AddWithValue("@supplierID", supplier.SelectedValue);

                        string currentPath = Directory.GetCurrentDirectory() + "\\upload";
                        if (!Directory.Exists(currentPath))
                        {
                            Directory.CreateDirectory(currentPath);
                        }

                        string newPathImage = $@"{currentPath}\{Path.GetFileName(linkImage)}";
                        if (File.Exists(newPathImage))
                        {
                            File.Delete(newPathImage);
                        }
                        File.Copy(linkImage, newPathImage, true); // Thêm true để ghi đè nếu file đã tồn tại

                        command.ExecuteNonQuery();
                    }

                    this.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Có lỗi khi lưu sản phẩm: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi khi thực hiện các thao tác với file: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (EditMode)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "image|*.png;*jpg;*.jpeg";
                ofd.Multiselect = false;
                ofd.Title = "Chon hinh anh";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    linkImage = ofd.FileName;
                    if (boxPicture.Image != null)
                    {
                        boxPicture.Image.Dispose();
                    }
                    boxPicture.Image = new Bitmap(linkImage);
                }
            }
            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
