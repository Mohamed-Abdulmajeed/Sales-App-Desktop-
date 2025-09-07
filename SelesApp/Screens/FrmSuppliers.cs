using DevExpress.ClipboardSource.SpreadsheetML;
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
    public partial class FrmSuppliers : Form
    {
        SelesAppEntities db = new SelesAppEntities();
        string imagePath = "";
        int id;
        public FrmSuppliers()
        {
            try
            {
                InitializeComponent();
                dataGridView1.DataSource = db.Supplers.Select(x => new { x.id, x.Name, x.Address, x.Phone, x.Company, x.isActive, x.Email, x.Notes }).ToList();
                dataGridView1.Columns[0].HeaderText = "رقم المورد";
                dataGridView1.Columns[1].HeaderText = "اسم المورد";
                dataGridView1.Columns[2].HeaderText = "العنوان";
                dataGridView1.Columns[3].HeaderText = "رقم التليفون";
                dataGridView1.Columns[4].HeaderText = "اسم الشركة او المحل";
                dataGridView1.Columns[5].HeaderText = "نشط |غير نشط";
                dataGridView1.Columns[6].HeaderText = "الايميل";
                dataGridView1.Columns[7].HeaderText = "ملاحظات";
            }
            catch { }
        }

        private void FrmSuppliers_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSuppName.Text == "")
                {
                    MessageBox.Show("برجاء ادخال البيانات المطلوبة");
                }
                else if (db.Supplers.Where(x => x.Name == txtSuppName.Text).Count() > 0)
                {
                    MessageBox.Show("هذا الاسم موجود مسبقا برجاء ادخال أسم اخر ");
                }
                else
                {
                    var r = MessageBox.Show("هل تريد إضافة هذا المورد ؟", "تأكيد الاضافة", MessageBoxButtons.OKCancel);
                    if (r == DialogResult.OK)
                    {
                        Suppler supp = new Suppler();
                        supp.Name = txtSuppName.Text;
                        supp.Phone = txtSuppPhone.Text;
                        supp.Email = txtSuppEmail.Text;
                        supp.Notes = txtSuppNotes.Text;
                        supp.Address = txtSuppAddress.Text;
                        supp.Company = txtSuppCompany.Text;
                        supp.isActive = checkActive.Checked;
                        db.Supplers.Add(supp);
                        db.SaveChanges();

                        if (imagePath != "")
                        {
                            string newPath = "D:\\Application SelesApp\\Images\\Suppliers\\" + "SuppliersNo " + supp.id + ".jpg";
                            File.Copy(imagePath, newPath);
                            supp.Image = imagePath;
                            db.SaveChanges();
                        }
                        MessageBox.Show("تم الحفظ بنجاح");

                        txtSuppName.Text = "";
                        txtSuppPhone.Text = "";
                        txtSuppEmail.Text = "";
                        txtSuppNotes.Text = "";
                        txtSuppAddress.Text = "";
                        txtSuppCompany.Text = "";
                        checkActive.Checked = true;
                        pictureBox1.ImageLocation = "";

                        dataGridView1.DataSource = db.Supplers.Select(x => new { x.id, x.Name, x.Address, x.Phone, x.Company, x.isActive, x.Email, x.Notes }).ToList();
                    }
                }
            }
            catch
            {
                MessageBox.Show("لم يتم الحفظ بنجاح");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                var r = MessageBox.Show("هل تريد التعديل", "تأكيد التعديل", MessageBoxButtons.OKCancel);
                if (db.Supplers.Where(x => x.Name == txtSuppName.Text && x.id != id).Count() > 0)
                {
                    MessageBox.Show(" لا يمكن التعديل الى هذا الاسم لانه موجود مسبقا");
                }

                else if (r == DialogResult.OK)
                {
                    id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    var supp = db.Supplers.SingleOrDefault(x => x.id == id);
                    if (supp.Name != "فاتورة نقدى")
                    {
                        supp.Name = txtSuppName.Text;
                        supp.Phone = txtSuppPhone.Text;
                        supp.Email = txtSuppEmail.Text;
                        supp.Notes = txtSuppNotes.Text;
                        supp.Address = txtSuppAddress.Text;
                        supp.Company = txtSuppCompany.Text;
                        supp.isActive = checkActive.Checked;

                        if (imagePath != "")
                        {
                            string newPath = "D:\\Application SelesApp\\Images\\Suppliers\\" + "Suppliers " + supp.id + ".jpg";
                            File.Copy(imagePath, newPath, true);
                            supp.Image = imagePath;
                        }

                        db.SaveChanges();
                        dataGridView1.DataSource = db.Supplers.Select(x => new { x.id, x.Name, x.Address, x.Phone, x.Company, x.isActive, x.Email, x.Notes }).ToList();

                        MessageBox.Show("تم التعديل بنجاح");
                    }
                }
            }
            catch
            {
                MessageBox.Show("لم يتم التعديل بنجاح");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                var r = MessageBox.Show("هل تريد الحذف", "تأكيد الحذف", MessageBoxButtons.OKCancel);
                if (r == DialogResult.OK)
                {
                    var result = db.Supplers.Find(id);
                    if (result.Name != "فاتورة نقدى")
                    {
                        db.Supplers.Remove(result);
                        db.SaveChanges();
                        dataGridView1.DataSource = db.Supplers.Select(x => new { x.id, x.Name, x.Address, x.Phone, x.Company, x.isActive, x.Email, x.Notes }).ToList();
                        MessageBox.Show("تم الحذف بنجاح");
                    }
                }
            }
            catch
            {
                MessageBox.Show("لم يتم الحذف بنجاح");
            }
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var result = db.Supplers.SingleOrDefault(x => x.id == id);
                if (result != null)
                {
                    txtSuppAddress.Text = result.Address;
                    txtSuppCompany.Text = result.Company;
                    txtSuppEmail.Text = result.Email;
                    txtSuppName.Text = result.Name;
                    txtSuppNotes.Text = result.Notes;
                    txtSuppPhone.Text = result.Phone;
                    if (result.isActive == null)
                        result.isActive = false;
                    checkActive.Checked = (bool)result.isActive;
                    try
                    {
                        pictureBox1.ImageLocation = result.Image;
                    }
                    catch
                    {
                    }
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPhontToSearch.Text == "")
                    dataGridView1.DataSource = db.Supplers.Where(x => x.Name.Contains(txtNameToSearch.Text)).Select(x => new { x.id, x.Name, x.Address, x.Phone, x.Company, x.isActive, x.Email, x.Notes }).ToList();

                else if (txtNameToSearch.Text == "")
                    dataGridView1.DataSource = db.Supplers.Where(x => x.Phone.Contains(txtPhontToSearch.Text)).Select(x => new { x.id, x.Name, x.Address, x.Phone, x.Company, x.isActive, x.Email, x.Notes }).ToList();

                else
                    dataGridView1.DataSource = db.Supplers.Where(x => x.Phone.Contains(txtPhontToSearch.Text) || x.Name.Contains(txtNameToSearch.Text)).Select(x => new { x.id, x.Name, x.Address, x.Phone, x.Company, x.isActive, x.Email, x.Notes }).ToList();
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {try{
            dataGridView1.DataSource = db.Supplers.Select(x => new { x.id, x.Name, x.Address, x.Phone, x.Company, x.isActive, x.Email, x.Notes }).ToList();
        }
        catch { }
        }

        private void txtPhontToSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSuppPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void checkActive_CheckedChanged(object sender, EventArgs e)
        {
            if (checkActive.CheckState == CheckState.Checked)
                checkActive.Text = "مورد نشط";
            else if (checkActive.CheckState == CheckState.Unchecked)
                checkActive.Text = "مورد غير نشط";
            else
                checkActive.Text = "?";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
