using SelesApp.DB;
using SelesApp.Screens;
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

namespace SelesApp
{
    public partial class FrmLogin : Form
    {
        SelesAppEntities db = new SelesAppEntities();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void openFormNewUser()
        {
            Application.Run(new FrmAddNewUser());
        }
        void openFormMainForm()
        {
            Application.Run(new FrmMainForm());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var result = db.Users.Where(y => y.UserName == txtUserName.Text && y.Password == txtPassword.Text).ToList();
                if (result.Count() > 0)
                {
                    this.Close();
                    Thread th = new Thread(openFormMainForm);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                    Users.Name = result[0].UserName;
                    Users.id = result[0].id;

                }
                else
                {
                    MessageBox.Show("إسم المستخدم او كلمة المرور غير صحيحة");
                }
            }
            catch { }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
    static class Users
    {
        static public string Name { get; set; }
        static public int id { get; set; }
        static public string NameOfPage { get; set; }


    }
     
}
