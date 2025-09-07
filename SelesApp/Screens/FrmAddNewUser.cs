using DevExpress.Utils;
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
    public partial class FrmAddNewUser : Form
    {
        SelesAppEntities db = new SelesAppEntities();
        string imagePath = ""; 

        public FrmAddNewUser()
        {
            InitializeComponent();
        }

        private void FrmAddNewUser_Load(object sender, EventArgs e)
        {

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
        void openFormMainForm()
        {
            Application.Run(new FrmMainForm());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try {
                if (txtUserName.Text != "" && txtPassword.Text != "")
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

                        db.Users.Add(obj);
                        db.SaveChanges();
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

                        db.Users.Add(obj);
                        db.SaveChanges();
                        string newPath = "D:\\Application SelesApp\\Images\\Users\\" + "User " + obj.id + ".jpg";
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

        private void button5_Click(object sender, EventArgs e)
        {

            this.Close();
            Thread th = new Thread(openMainForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void openMainForm()
        {
            Application.Run(new FrmMainForm());
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
