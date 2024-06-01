using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace DO_AN_KI_2
{
    public partial class Home : Form
    {
        DataServices services = new DataServices();
        string fullName = Properties.Settings.Default.fullName;
        public Home()
        {
            InitializeComponent();
            this.Load += new EventHandler(Home_Load_1);
            label1.Text = $"XIN CHÀO: {fullName.ToUpper()}";
        }

        public void load()
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


                    object result = command.ExecuteScalar();


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

                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
            }
            finally
            {

                services.CloseDB();
            }

        }

        private void Home_Load_1(object sender, EventArgs e)
        {

            load();

            UpdateTime();

            timer1.Interval = 1000;


            timer1.Tick += timer1_Tick;


            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTime();
        }

        private void UpdateTime()
        {
            DateTime now = DateTime.Now;


            hours.Text = now.ToString("HH:mm") + " Phút";


            int secondsUntilNextMinute = 60 - now.Second;

            if (secondsUntilNextMinute != timer1.Interval / 1000)
            {
                timer1.Interval = secondsUntilNextMinute * 1000;

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


