using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace DO_AN_KI_2
{
    public partial class QR_Bank : Form
    {
        public QR_Bank()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var webClient = new WebClient();
            var banksJson = webClient.DownloadString("https://api.vietqr.io/v2/banks");
            var lisDataBanks = JsonConvert.DeserializeObject<List<string>>(banksJson);

        }
    }
}
