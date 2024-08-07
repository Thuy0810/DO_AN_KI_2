﻿using System;
using System.Data;
using System.Windows.Forms;

namespace DO_AN_KI_2
{
    public partial class Bill : Form
    {
        DataServices services = new DataServices();

        public Bill()
        {
            InitializeComponent();
        }

        public void fetchData()
        {
            string query = "select o.orderID , c.customerName , o.total , o.orderDate , u.fullName , o.customerID ,o.note, o.paymentsMethods from tblORDER as o inner join tblCUSTOMER as c on o.customerID = c.customerID inner join tblUSER as u on u.userID = o.userID;";
            DataTable dataTable = (DataTable)services.ShowObjectData(query);
            dataGridView.Rows.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                dataGridView.Rows.Add((string)row["orderID"], (string)row["customerName"], ((int)row["total"]).ToString("N0", new System.Globalization.CultureInfo("vi-VN")) + " VND", row["orderDate"], (string)row["fullName"], (string)row["paymentsMethods"], Properties.Resources.Delete2, row["customerID"].ToString(), (string)row["note"]);
            }
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            fetchData();
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if a valid row is clicked
            {
                string id = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                string customer = (string)dataGridView.Rows[e.RowIndex].Cells[7].Value;
                string note = dataGridView.Rows[e.RowIndex].Cells[8].Value.ToString();
                string date = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                string employName = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                string totalPrice = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                string payMethods = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();

                OrderModel model = new OrderModel(id, customer, note, date, employName, totalPrice, payMethods);
                CreateOrder createOrder = new CreateOrder(false, model);
                createOrder.ShowDialog();
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.RowIndex >= 0)
            {

                DialogResult dr;
                dr = MessageBox.Show("Chắc chắn xóa dòng đang chọn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;
                {
                    int r = dataGridView.CurrentRow.Index;
                    string ID = dataGridView.Rows[r].Cells[0].Value.ToString();
                    services.OpenDB();
                    string query = $"delete from tblORDER where orderID = '{ID}';";
                    services.ExecuteQueries(query);
                    services.CloseDB();
                    dataGridView.Rows.Clear();
                    fetchData();
                }
            }
        }
    }

}
