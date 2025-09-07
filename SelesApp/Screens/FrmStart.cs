using SelesApp.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelesApp.Screens
{
    public partial class FrmStart : Form
    {
        SelesAppEntities db = new SelesAppEntities();
        string imagePath = "";
        public FrmStart()
        {
            InitializeComponent();
        }
        void openFormMainForm()
        {
            Application.Run(new FrmMainForm());
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = dialog.FileName;
                imagePath = dialog.FileName;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text != "" && txtPassword.Text != "" && txtNameOfPill.Text != "" && txtPassOfApp.Text != "")
                {
                    if (db.Users.Where(x => x.UserName == txtUserName.Text).Count() > 0)
                    {
                        MessageBox.Show("هذا الاسم موجود مسبقا برجاء ادخال أسم اخر ");
                    }

                    else if (imagePath == "")
                    {
                        User obj = new User
                        {
                            UserName = txtUserName.Text,
                            Password = txtPassword.Text,
                        };
                        Setting set = new Setting
                        {
                            NameOfPill = txtNameOfPill.Text,
                            Password = txtPassOfApp.Text,
                            PhoneOfBill = txtPhoneOfPill.Text
                        };
                        db.Settings.Add(set);
                        db.Categories.Add(new Category { Name = "قسم عام" });
                        db.Customers.Add(new Customer { Name = "فاتورة نقدى", isActive = true,TotalDebt = Convert.ToDecimal("0") });
                        db.PurchBills.Add(new PurchBill { id = 1 });
                        db.PurchBillDetails.Add(new PurchBillDetail { id = 1 });
                        db.SelesBills.Add(new SelesBill { id = 1 });
                        db.SelesBillDetails.Add(new SelesBillDetail { id = 1 });
                        db.Supplers.Add(new Suppler { Name = "فاتورة نقدى",isActive=true, TotalDebt = Convert.ToDecimal("0") });

                        db.Users.Add(obj);
                        db.SaveChanges();
                        var result = db.Users.Where(y => y.UserName == txtUserName.Text && y.Password == txtPassword.Text).ToList();
                        SelesApp.Users.Name = txtUserName.Text;
                        SelesApp.Users.id = result[0].id;

                        MessageBox.Show("تم التسجيل بنجاح");

                        this.Close();
                        Thread th = new Thread(openFormMainForm);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                    }
                    else
                    {
                        User obj = new User
                        {
                            UserName = txtUserName.Text,
                            Password = txtPassword.Text,
                            Image = imagePath
                        };
                        Setting set = new Setting
                        {
                            NameOfPill = txtNameOfPill.Text,
                            Password = txtPassOfApp.Text,
                            PhoneOfBill = txtPhoneOfPill.Text
                        };
                        db.Settings.Add(set);
                        db.Categories.Add(new Category { Name = "قسم عام" });
                        db.Customers.Add(new Customer { Name = "فاتورة نقدى", isActive = true, TotalDebt = Convert.ToDecimal("0") });
                        db.PurchBills.Add(new PurchBill { id = 1 });
                        db.PurchBillDetails.Add(new PurchBillDetail { id = 1 });
                        db.SelesBills.Add(new SelesBill { id = 1 });
                        db.SelesBillDetails.Add(new SelesBillDetail { id = 1 });
                        db.Supplers.Add(new Suppler { Name = "فاتورة نقدى", isActive = true, TotalDebt = Convert.ToDecimal("0") });

                        db.Users.Add(obj);
                        db.SaveChanges();
                        string newPath = "D:\\Application SelesApp\\Images\\Users\\" + "User No " + obj.id + ".jpg";
                        File.Copy(imagePath, newPath);
                        obj.Image = imagePath;
                        db.SaveChanges();
                        var result = db.Users.Where(y => y.UserName == txtUserName.Text && y.Password == txtPassword.Text).ToList();
                        SelesApp.Users.Name = txtUserName.Text;
                        SelesApp.Users.id = result[0].id;

                        MessageBox.Show("تم التسجيل بنجاح");

                        this.Close();
                        Thread th = new Thread(openFormMainForm);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                    }
                }

                else
                {
                    MessageBox.Show("Invalid User Name Or Password !!");
                }
            }
            catch { MessageBox.Show("لم يتم التسجيل"); }
        }

        private void FrmStart_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
