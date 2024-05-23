using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DO_AN_KI_2
{
    public partial class Home : Form
    {
        DataServices services = new DataServices();
        public Home()
        {
            InitializeComponent();
            this.Load += new EventHandler(Home_Load_1);
        }

        private void Home_Load_1(object sender, EventArgs e)
        {
            this.ControlBox = false;
            int selectedMonth = DateTime.Now.Month;
            DateTime currentDate = DateTime.Now.Date;
            NumberFormatInfo nfi = new CultureInfo("vi-VN", false).NumberFormat;
            try
            {
                services.OpenDB();


                string query = "SELECT SUM(total) FROM tblORDER WHERE MONTH(orderDate) = @month";
                using (SqlCommand command = new SqlCommand(query, services.connection))
                {

                    command.Parameters.AddWithValue("@month", selectedMonth);

                    // ExecuteScalar trả về cột đầu tiên của hàng đầu tiên trong tập kết quả, hoặc null nếu tập kết quả rỗng
                    object result = command.ExecuteScalar();

                    // Kiểm tra DBNull trước khi chuyển đổi sang decimal
                    decimal totalRevenue = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;


                    label.Text = $"Doanh thu tháng {selectedMonth}: ";
                    totalMonth.Text = totalRevenue.ToString("N0", nfi) + " VND";
                }


                string query1 = "SELECT SUM(total) FROM tblORDER WHERE CONVERT(date, orderDate) = @currentDate";
                using (SqlCommand command = new SqlCommand(query1, services.connection))
                {
                    command.Parameters.AddWithValue("@currentDate", currentDate);

                    // ExecuteScalar trả về cột đầu tiên của hàng đầu tiên trong tập kết quả, hoặc null nếu tập kết quả rỗng
                    object result = command.ExecuteScalar();

                    // Kiểm tra DBNull trước khi chuyển đổi sang decimal
                    decimal totalRevenueDate = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;


                    label3.Text = $" Doanh thu ngày: {currentDate.ToShortDateString()}";
                    totalDate.Text = $" {totalRevenueDate.ToString("N0", nfi)} VND";

                }
                //nhap hang
                string queryTotalImportProduct = "select sum(total) from tblImportProduct WHERE MONTH(dateImport) = @month";
                using (SqlCommand commandTotal = new SqlCommand(queryTotalImportProduct, services.connection))
                {
                    commandTotal.Parameters.AddWithValue("@month", selectedMonth);
                    object result = commandTotal.ExecuteScalar();
                    decimal TotalImport = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
                    totalImportMonth.Text = $"TIền nhập hàng tháng {selectedMonth}: ";
                    totalImMonth.Text = TotalImport.ToString("N0", nfi) + " VND";
                }


                string queryTotalAll = "select sum(total) from tblORDER ";
                using (SqlCommand commandTotalAll = new SqlCommand(queryTotalAll, services.connection))
                {
                    object result = commandTotalAll.ExecuteScalar();
                    decimal TotalALl = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
                    totalAllFull.Text = TotalALl.ToString("N0", nfi) + " VND";
                }

            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
            }
            finally
            {
                // Đảm bảo kết nối được đóng sau khi sử dụng
                services.CloseDB();
            }



            ///
            UpdateTime();
            // Đặt interval của Timer thành 1 giây (1000ms) ban đầu
            timer1.Interval = 1000;

            // Gán sự kiện Tick cho Timer
            timer1.Tick += timer1_Tick;

            // Bắt đầu Timer
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTime();
        }

        private void UpdateTime()
        {
            DateTime now = DateTime.Now;

            // Cập nhật Label với giờ và phút hiện tại
            hours.Text = now.ToString("HH:mm") + " Phút";

            // Tính thời gian còn lại cho đến phút tiếp theo
            int secondsUntilNextMinute = 60 - now.Second;

            // Đặt lại Timer để đồng bộ với phút tiếp theo
            if (secondsUntilNextMinute != timer1.Interval / 1000)
            {
                timer1.Interval = secondsUntilNextMinute * 1000;

                // Đặt lại Interval về 1 giây sau khi đồng bộ
                timer1.Tick -= timer1_Tick;
                timer1.Tick += (s, args) =>
                {
                    timer1.Interval = 1000;
                    timer1_Tick(s, args);
                };
            }
        }

       
    }
}


