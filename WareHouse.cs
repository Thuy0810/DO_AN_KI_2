using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;

namespace DO_AN_KI_2
{
    public partial class WareHouse : Form
    {
        public WareHouse()
        {
            InitializeComponent();
        }

        private void WareHouse_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            createQrCode();
        }


        async void createQrCode()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.vietqr.io/v2/generate");
            request.Headers.Add("x-client-id", "<CLIENT_ID_HERE>");
            request.Headers.Add("x-api-key", "<API_KEY_HERE>");
            request.Headers.Add("Cookie", "connect.sid=s%3AJa0G3lzhIbvqi2Gid8tIc7DRNTnqT58-.8ofu1hA6gLCknZ7PRXrUPZ3vKbfDOdZrqBmK5K3BAsE");
            InfoBank info = new InfoBank("Thanh toán mã đơn hàng asdga", 10000);
            var jsonString = JsonConvert.SerializeObject(info);
            var content = new StringContent(jsonString, null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string res = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<QrRespone>(res);

            string base64String = resp.data.qrDataURL;

            if (base64String.StartsWith("data:image/png;base64,"))
            {
                base64String = base64String.Substring("data:image/png;base64,".Length);
            }


            var pic = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(pic))
            {
                guna2PictureBox1.Image = Image.FromStream(ms);
            }

        }


    }
    class InfoBank
    {
        public string accountNo { get; set; } = "8410123132004";
        public string accountName { get; set; } = "Nguyen Dinh Tuan";
        public string acqId { get; set; } = "970422";
        public string addInfo { get; set; }
        public int amount { get; set; }
        public string template { get; set; } = "print";

        public InfoBank(string addInfo, int amount)
        {
            this.addInfo = addInfo;
            this.amount = amount;
        }
    }


    public class Data
    {
        public string qrCode { get; set; }
        public string qrDataURL { get; set; }
    }

    public class QrRespone
    {
        public string code { get; set; }
        public string desc { get; set; }
        public Data data { get; set; }
    }
}
