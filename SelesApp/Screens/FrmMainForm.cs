using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelesApp.Screens
{
    public partial class FrmMainForm : Form
    {
        public FrmMainForm()
        {
            InitializeComponent();
            lblUser.Text = " أهلا "+SelesApp.Users.Name ;
        }

        private void FrmMainForm_Load(object sender, EventArgs e)
        {

        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users.NameOfPage = "openFormNewUser";

            this.Close();
            Thread th = new Thread(openFrmVerification);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            Users.NameOfPage = "openProductList";

            this.Close();
            Thread th = new Thread(openFrmVerification);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
       
        private void listProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users.NameOfPage = "openProductList";

            this.Close();
            Thread th = new Thread(openFrmVerification);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Users.NameOfPage = "openFrmCustomer";

            this.Close();
            Thread th = new Thread(openFrmVerification);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Users.NameOfPage = "openFrmSupplier";

            this.Close();
            Thread th = new Thread(openFrmVerification);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
       

        private void العملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users.NameOfPage = "openFrmCustomer";

            this.Close();
            Thread th = new Thread(openFrmVerification);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void الموردينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users.NameOfPage = "openFrmSupplier";

            this.Close();
            Thread th = new Thread(openFrmVerification);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Close();
            Thread th = new Thread(openFrmSelesBay);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void openFrmSelesBay()
        {
            Application.Run(new FrmSelesBay());
        }

        private void فاتورةمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(openFrmSelesBay);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Users.NameOfPage = "openFrmInquireBill";
            
            this.Close();
            Thread th = new Thread(openFrmVerification);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void openFrmVerification()
        {
            Application.Run(new FrmVerification());
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users.NameOfPage = "openFormAddProduct";

            this.Close();
            Thread th = new Thread(openFrmVerification);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
       

        private void managementProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users.NameOfPage = "openProductList";

            this.Close();
            Thread th = new Thread(openFrmVerification);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Users.NameOfPage = "openFormListPurch";

            this.Close();
            Thread th = new Thread(openFrmVerification);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
       
        private void استعلامعنفواتيرمشترياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users.NameOfPage = "openFormListPurch";

            this.Close();
            Thread th = new Thread(openFrmVerification);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void استعلامعنفواتيرمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users.NameOfPage = "openFrmInquireBill";

            this.Close();
            Thread th = new Thread(openFrmVerification);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Users.NameOfPage = "openFormAddPurchBill";


            this.Close();
            Thread th = new Thread(openFrmVerification);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
       

        private void فاتورةمشترياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users.NameOfPage = "openFormAddPurchBill";

            this.Close();
            Thread th = new Thread(openFrmVerification);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Users.NameOfPage = "openFormReports";

            this.Close();
            Thread th = new Thread(openFrmVerification);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
       

        private void تقاريرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users.NameOfPage = "openFormReports";

            this.Close();
            Thread th = new Thread(openFrmVerification);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void حذفحسابToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users.NameOfPage = "openFormListAllUsers";

            this.Close();
            Thread th = new Thread(openFrmVerification);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
