using DO_AN_KI_2.service;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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
        Guarantee revenue;
        Bill bill;
        TblUsers tbluser;
        Trademark trademark;
        CreateOrder createOrder;
        DataServices services = new DataServices();

        int role = Int32.Parse(Properties.Settings.Default.role);

        public Form1()
        {
            InitializeComponent();
            MdiProp();
            btnUser.Visible = role != 1 ? false : true;
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




        bool siderBarEx = true;
        private void SiderBar_Transition_Tick(object sender, EventArgs e)
        {
            if (siderBarEx)
            {
                siderBar.Width -= 10;
                if (siderBar.Width <= 65)
                {
                    siderBarEx = false;
                    SiderBar_Transition.Stop();

                    PnHome.Width = 41;
                    btnBill.Width = 41;
                    PNCategpry.Width = 41;
                    pnCustomer.Width = 41;
                    btnRevenue.Width = 41;
                    btnUser.Width = 41;
                    MenuContainer.Width = 42;
                    Menu1.Width = 38;
                    btnTrademark.Width = 41;
                    btnCreateOrder.Width = 41;
                }

            }
            else
            {
                siderBar.Width += 10;
                if (siderBar.Width >= 190)
                {
                    siderBarEx = true;
                    SiderBar_Transition.Stop();
                    Menu1.Width = 168;
                    PnHome.Width = 170;
                    btnBill.Width = 170;
                    PNCategpry.Width = 170;
                    pnCustomer.Width = 170;
                    btnRevenue.Width = 170;
                    MenuContainer.Width = 171;
                    btnUser.Width = 170;
                    btnTrademark.Width = 170;
                    btnCreateOrder.Width = 170;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SiderBar_Transition.Start();
            MenuContainer.Height = 43;



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
                home.load();
                home.Activate();
            }
        }
        private void Home_FormClosed(object sender, EventArgs e)
        {
            home = null;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (allProduct == null)
            {
                allProduct = new AllProduct();
                allProduct.FormClosed += AllProduct_FormClosed;
                allProduct.MdiParent = this;
                allProduct.Dock = DockStyle.Fill;
                allProduct.Show();



            }
            else
            {
                allProduct.Display();
                allProduct.Activate();
            }
        }
        private void AllProduct_FormClosed(Object sender, EventArgs e)
        {
            allProduct = null;

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (supplier == null)
            {
                supplier = new Supplier();
                supplier.FormClosed += Supplier_FormClosed;
                supplier.MdiParent = this;
                supplier.Dock = DockStyle.Fill;
                supplier.Show();
            }
            else
            {
                supplier.DisplaySupplier();
                supplier.Activate();

            }
        }
        private void Supplier_FormClosed(Object sender, EventArgs e)
        {
            supplier = null;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (import == null)
            {
                import = new Import();
                import.FormClosed += Import_FormClosed;
                import.MdiParent = this;
                import.Dock = DockStyle.Fill;
                import.Show();
            }
            else
            {
                import.fetchData();
                import.Activate();
            }
        }
        private void Import_FormClosed(Object sender, EventArgs e)
        {
            import = null;
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
        private void Category_FormClosed(Object sender, EventArgs e)
        {
            category = null;
        }

        private void pnCustomer_Click(object sender, EventArgs e)
        {
            if (customer == null)
            {
                customer = new Customer();
                customer.FormClosed += Customer_FormClosed;
                customer.MdiParent = this;
                customer.Dock = DockStyle.Fill;
                customer.Show();

            }
            else
            {
                customer.DisplayCustomer();
                customer.Activate();
            }
        }
        private void Customer_FormClosed(Object sender, EventArgs e)
        {
            customer = null;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (revenue == null)
            {
                revenue = new Guarantee();
                revenue.FormClosed += Revenue_FormClosed;
                revenue.MdiParent = this;
                revenue.Dock = DockStyle.Fill;
                revenue.Show();
            }
            else
            {
                revenue.fetchData();
                revenue.Activate();
            }
        }
        private void Revenue_FormClosed(Object sender, EventArgs e)
        {
            revenue = null;
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            if (bill == null)
            {
                bill = new Bill();
                bill.FormClosed += Bill_FormClosed;
                bill.MdiParent = this;
                bill.Dock = DockStyle.Fill;
                bill.Show();
            }
            else
            {
                bill.fetchData();
                bill.Activate();
            }
        }

        private void Bill_FormClosed(Object sender, EventArgs e)
        {
            bill = null;
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            if (role != 1)
            {
                message.showWarning("Bạn không có quyền thực hiện chức năng này");
                return;
            }
            if (tbluser == null)
            {
                tbluser = new TblUsers();
                tbluser.FormClosed -= User_FormClosed;
                tbluser.MdiParent = this;
                tbluser.Dock = DockStyle.Fill;
                tbluser.Show();
            }
            else
            {
                tbluser.DisplayUser();
                tbluser.Activate();
            }
        }
        private void User_FormClosed(object sender, EventArgs e)
        {
            tbluser = null;
        }


        private void btnTrademark_Click_1(object sender, EventArgs e)
        {
            if (trademark == null)
            {
                trademark = new Trademark();
                trademark.MdiParent = this;
                trademark.FormClosed -= Trademark_FormClosed;
                trademark.Dock = DockStyle.Fill;
                trademark.Show();

            }
            else
            {
                trademark.Activate();

            }
        }
        private void Trademark_FormClosed(object sender, EventArgs e)
        {
            trademark = null;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //this.ControlBox= false;
            MenuContainer.Height = 43;

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

        void Order_FormClosed(object sender, EventArgs e)
        {
            tbluser = null;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (createOrder == null)
            {
                createOrder = new CreateOrder();
                createOrder.MdiParent = this;
                createOrder.FormClosed -= Order_FormClosed;
                createOrder.Dock = DockStyle.Fill;
                createOrder.Show();
            }
            else
            {
                createOrder.Activate();
            }
        }
    }
}
