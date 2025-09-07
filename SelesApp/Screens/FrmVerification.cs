using SelesApp.DB;
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
    public partial class FrmVerification : Form
    {
        SelesAppEntities db = new SelesAppEntities();
        public FrmVerification()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (db.Settings.Where(x => x.Password == txtPassword.Text).Count() > 0)
                {
                    if (Users.NameOfPage == "openFormNewUser")
                    {
                        this.Close();
                        Thread th = new Thread(openFormNewUser);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                    }
                    else if (Users.NameOfPage == "openProductList")
                    {
                        this.Close();
                        Thread th = new Thread(openProductList);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                    }
                    else if (Users.NameOfPage == "openFrmCustomer")
                    {
                        this.Close();
                        Thread th = new Thread(openFrmCustomer);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                    }
                    else if (Users.NameOfPage == "openFrmSupplier")
                    {
                        this.Close();
                        Thread th = new Thread(openFrmSupplier);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                    }
                    else if (Users.NameOfPage == "openFrmSelesBay")
                    {
                        this.Close();
                        Thread th = new Thread(openFrmSelesBay);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                    }
                    else if (Users.NameOfPage == "openFrmInquireBill")
                    {
                        this.Close();
                        Thread th = new Thread(openFrmInquireBill);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                    }
                    else if (Users.NameOfPage == "openFormAddProduct")
                    {
                        this.Close();
                        Thread th = new Thread(openFormAddProduct);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                    }
                    else if (Users.NameOfPage == "openFormListPurch")
                    {
                        this.Close();
                        Thread th = new Thread(openFormListPurch);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                    }
                    else if (Users.NameOfPage == "openFormAddPurchBill")
                    {
                        this.Close();
                        Thread th = new Thread(openFormAddPurchBill);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                    }
                    else if (Users.NameOfPage == "openFormReports")
                    {
                        this.Close();
                        Thread th = new Thread(openFormReports);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                    }
                    else if (Users.NameOfPage == "openFormListAllUsers")
                    {
                        this.Close();
                        Thread th = new Thread(openFormListAllUsers);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                    }
                }
                else
                {

                    this.Close();
                    Thread th = new Thread(openMainForm);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }
            }
            catch { }
            
        }
       void openMainForm()
        {
            Application.Run(new FrmMainForm());
        }
       void openFormNewUser()
       {
           Application.Run(new FrmAddNewUser());
       }
       void openProductList()
       {
           Application.Run(new FrmListProducts());
       }
       void openFrmCustomer()
       {
           Application.Run(new FrmCustomer());
       }
       void openFrmSupplier()
       {
           Application.Run(new FrmSuppliers());
       }
       void openFrmSelesBay()
       {
           Application.Run(new FrmSelesBay());
       }
       void openFrmInquireBill()
       {
           Application.Run(new FrmListBill());
       }
       void openFormAddProduct()
       {
           Application.Run(new FrmAddProduct());
       }
       void openFormListPurch()
       {
           Application.Run(new FrmListBillPurch());
       }
       void openFormAddPurchBill()
       {
           Application.Run(new FrmPyrchBill());
       }
       void openFormReports()
       {
           Application.Run(new FrmReports());
       }
       void openFormListAllUsers()
       {
           Application.Run(new FrmListAllUsers());
       }
       private void FrmVerification_Load(object sender, EventArgs e)
       {

       }

       private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
       {
           if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
           {
               e.Handled = true;
           }
       }

       private void txtPassword_TextChanged(object sender, EventArgs e)
       {

       }

       private void txtPassword_MouseEnter(object sender, EventArgs e)
       {
     
       } 
    }
}
