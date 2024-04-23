using Sipaa.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DO_AN_KI_2
{
    public partial class Form1 : Form
    {
        Home home;
        AllProduct allProduct;
        Supplier supplier;
        Import import;
        WareHouse wareHouse;
        Category category;
        Customer customer;
        Revenue revenue;
        Bill bill;

        private string conStr = "Data Source=.;Initial Catalog=DO_AN_KI2;Integrated Security=True;Trust Server Certificate=True";
        //khai báo đối tượng kết nối với CSDL
        private SqlConnection mySqlConnection;
        //khai báo đối tượng lớp SqlCommand để truy vấn dữ liệu
        private SqlCommand mySqlCommand;
        public Form1()
        {
            InitializeComponent();
            MdiProp();
        }
       
     

        private void MdiProp()
        {
            this.SetBevel(false);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(232, 234, 237);  
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            label1.Width = guna2Panel2.Width;
            label1.Height = guna2Panel2.Height;
        }

        bool MenuEx = false;
        private void Menu_Timer_Tick(object sender, EventArgs e)
        {
            if (MenuEx == false)
            {
                MenuContainer.Height += 10;
                if (MenuContainer.Height >= 230)
                {
                    Menu_Transiton.Stop();
                    MenuEx = true;
                }
                
            }
            else
            {
                MenuContainer.Height -= 10;
                if (MenuContainer.Height <= 40)
                {
                    Menu_Transiton.Stop();
                    MenuEx = false;
                    MenuContainer.Height += 7;
                }

            }
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            Menu_Transiton.Start();
          
        }

        bool Menu2Ex = false;
        private void Menu2_Transitioon_Tick(object sender, EventArgs e)
        {
            if (Menu2Ex == false)
            {
                Menu2_ConTainer.Height += 10;
                if (Menu2_ConTainer.Height >= 147)
                {
                    Menu2_Transitioon.Stop();
                    Menu2Ex = true;
                }

            }
            else
            {
                Menu2_ConTainer.Height -= 10;
                if (Menu2_ConTainer.Height <= 40)
                {
                    Menu2_Transitioon.Stop();
                    Menu2Ex = false;
                    Menu2_ConTainer.Height += 10;
                    
                }
            }
        }

        private void BtnMenu2_Click(object sender, EventArgs e)
        {
            Menu2_Transitioon.Start();
        }
        bool siderBarEx = true;
        private void SiderBar_Transition_Tick(object sender, EventArgs e)
        {
            if(siderBarEx)
            {
               siderBar.Width -= 10;
                if(siderBar.Width <= 50)
                {
                    siderBarEx=false;
                    SiderBar_Transition.Stop();

                    PnHome.Width = siderBar.Width;
                    btnBill.Width = siderBar.Width;
                    PNCategpry.Width = siderBar.Width;
                    pnCustomer.Width = siderBar.Width;
                    Menu2_ConTainer.Width = siderBar.Width;
                    MenuContainer.Width = siderBar.Width;
                }

            }
            else
            {
                siderBar.Width += 10;
                if (siderBar.Width >= 185)
                {
                    siderBarEx = true;
                    SiderBar_Transition.Stop();

                    PnHome.Width = siderBar.Width;
                    btnBill.Width = siderBar.Width;
                    PNCategpry.Width = siderBar.Width;
                    pnCustomer.Width = siderBar.Width;
                    Menu2_ConTainer.Width = siderBar.Width;
                    MenuContainer.Width = siderBar.Width;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SiderBar_Transition.Start();
            MenuContainer.Height = 40;
            Menu2_ConTainer.Height = 40;
           
        }

        private void PnHome_Click(object sender, EventArgs e)
        {
            if (home == null)
            {
                home = new Home();
                home.FormClosed += Home_FormClosed;
                home.MdiParent = this;
                home.WindowState = FormWindowState.Maximized;
                home.Show();
            }
            else
            {
                home.Activate();
            }
        }
        private void Home_FormClosed(object sender, EventArgs e)
        {
            home = null;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if(allProduct==null)
            {
                allProduct= new AllProduct();
                allProduct.FormClosed += AllProduct_FormClosed;
                allProduct.MdiParent = this;
                allProduct.Dock = DockStyle.Fill;
                allProduct.Show();
               

            }
            else
            {
                allProduct.Activate();
            }
        }
        private void AllProduct_FormClosed(Object sender, EventArgs e)
        {
            allProduct = null;

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if(supplier == null)
            {
                supplier = new Supplier();
                supplier.FormClosed += Supplier_FormClosed;
                supplier.MdiParent = this;
                supplier.Dock = DockStyle.Fill;
                supplier.Show();
               

            }
            else
            {
                supplier.Activate();

            }
        }
       private void Supplier_FormClosed(Object sender, EventArgs e)
        {
            supplier= null;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if(import==null)
            {
                import= new Import();
                import.FormClosed += Import_FormClosed;
                import.MdiParent = this;
                import.Dock = DockStyle.Fill;
                import.Show();
            }
            else
            {
                import.Activate();
            }
        }
        private void Import_FormClosed(Object sender, EventArgs e)
        {
            supplier = null;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (wareHouse == null)
            {
                wareHouse = new WareHouse();
                wareHouse.FormClosed += Warehouse_FormClosed;
                wareHouse.MdiParent = this;
                wareHouse.Dock = DockStyle.Fill;
                wareHouse.Show();
            }
            else
            {
                wareHouse.Activate();
            }
        }
        private void Warehouse_FormClosed(Object sender, EventArgs e)
        {
            wareHouse = null;
        }

        private void PNCategpry_Click(object sender, EventArgs e)
        {
            if (category == null)
            {
                category = new Category();
                category.FormClosed += Category_FormClosed;
                category.MdiParent = this;
                category.Dock = DockStyle.Fill;
                category.Show();
            }
            else
            {
                category.Activate();
            }
        }
        private void Category_FormClosed(Object　sender, EventArgs e)
        {
            category = null;
        }

        private void pnCustomer_Click(object sender, EventArgs e)
        {
            if(customer== null)
            {
                customer= new Customer();
                customer.FormClosed += Customer_FormClosed;
                customer.MdiParent = this;
                customer.Dock = DockStyle.Fill;
                customer.Show();

            }
            else
            {
                customer.Activate();
            }
        }
        private void Customer_FormClosed(Object sender, EventArgs e)
        {
            customer = null;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (revenue==null)
            {
                revenue = new Revenue();
                revenue.FormClosed += Revenue_FormClosed;
                revenue.MdiParent = this;
                revenue.Dock = DockStyle.Fill;
                revenue.Show();
            }
            else
            {
                revenue.Activate();
            }
        }
        private void Revenue_FormClosed(Object sender, EventArgs e)
        {
            category = null;
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            if (bill==null)
            {
                bill= new Bill();
                bill.FormClosed += Bill_FormClosed;
                bill.MdiParent = this;
                bill.Dock = DockStyle.Fill; 
                bill.Show();
            }
            else
            { 
                bill.Activate();
            }
        }
        private void Bill_FormClosed(Object sender, EventArgs e)
        {
            bill = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            home = new Home();
            home.FormClosed += Home_FormClosed;
            home.MdiParent = this;
            home.WindowState = FormWindowState.Maximized;
            home.Show();
        }
    }
}
