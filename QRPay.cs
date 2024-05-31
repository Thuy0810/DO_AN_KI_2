using DO_AN_KI_2.service;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace DO_AN_KI_2
{
    public partial class QRPay : Form
    {
        int TongTien;
        public bool thanhToanThanhCong { get; set; } = false;
        public QRPay(int t)
        {
            InitializeComponent();
            List<BankInfo> list = new List<BankInfo>() {new BankInfo("VietcomBank", 970436, 1032359964),new BankInfo("MBbank", 970422, 0849016512)  };
            cboNH.DataSource= list;
            cboNH.DisplayMember= "Name";
            TongTien = t;
            moneyPay.Text= t.ToString("N0", new CultureInfo("vi-VN")) + " VND";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            BankInfo bankInfo= cboNH.SelectedItem as BankInfo;


            var ApiRequest = new ApiRequest()
            {
                acqId =bankInfo.IdBank,
                accountNo = bankInfo.STKBank,
                accountName = "TO THI THUY",
                amount = TongTien,
                format = "text",
                template = "print"
            };
            var JsonApiRequest= JsonConvert.SerializeObject(ApiRequest);

            var client = new RestClient("https://api.vietqr.io/v2/generate");
            var request = new RestRequest();

            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");
            
            request.AddParameter("application/json", JsonApiRequest, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;

            var data = JsonConvert.DeserializeObject<ApiResponse>(content);

            string base64String = data.data.qrDataURL;

            if (base64String.StartsWith("data:image/png;base64,"))
            {
                base64String = base64String.Substring("data:image/png;base64,".Length);
            }


            var pic = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(pic))
            {
                imgPay.Image = Image.FromStream(ms);
            }
        }
     class BankInfo
        {
            public string Name { get; set; }
            public int IdBank {  get; set; }
            public int STKBank {  get; set; }

            public BankInfo(string name, int idBank, int sTKBank)
            {
                this.Name = name;
                IdBank = idBank;
                STKBank = sTKBank;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            thanhToanThanhCong = true;
            this.Close();
        }
    }
}
