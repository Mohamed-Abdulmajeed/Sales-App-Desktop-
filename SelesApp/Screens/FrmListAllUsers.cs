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
    public partial class FrmListAllUsers : Form
    {
        SelesAppEntities db = new SelesAppEntities();
        public FrmListAllUsers()
        {
            try{
            InitializeComponent();
            dataGridView1.DataSource = db.Users.Select(x => new { x.id, x.UserName }).ToList();
            dataGridView1.Columns[0].HeaderText = "رقم المستخدم";
            dataGridView1.Columns[1].HeaderText = "اسم المستخدم";
            }
            catch { }
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

        private void FrmListAllUsers_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var result = db.Settings.SingleOrDefault(x => x.Password == txtPassword.Text);

                if (result.Password == txtPassword.Text && textBox1.Text == textBox2.Text && textBox1.Text != "")
                {
                    using (var context = new SelesAppEntities())
                    {
                        var std = context.Settings.First<Setting>();
                        std.Password = textBox1.Text;
                        if (txtNameOfBill.Text != "")
                            std.NameOfPill = txtNameOfBill.Text;
                        if (txtNoOfPhone.Text != "")
                            std.PhoneOfBill = txtNoOfPhone.Text;
                        context.SaveChanges();
                    }
                    MessageBox.Show("تم تغيير كلمة المرور بنجاح");

                }
                else if (result.Password != txtPassword.Text)
                {
                    MessageBox.Show("كلمة المرور خطأ !!");
 
                }
                else if (textBox1.Text != textBox2.Text)
                {
                    MessageBox.Show("تأكيد كلمة المرور خطأ");

                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show(" كلمة المرور غير صالح");

                }
            }
            catch
            {
                MessageBox.Show("لم يتم تغيير كلمة المرور بنجاح");
            }
       }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try{
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = db.Users.SingleOrDefault(x => x.id == id);
                try{
            pictureBox1.ImageLocation = result.Image;
                }
                catch
                {
                    pictureBox1.ImageLocation = null;
                }
            }
            catch { }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
