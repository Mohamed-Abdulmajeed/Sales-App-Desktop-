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
    public partial class FrmAddProduct : Form
    {
        SelesAppEntities db = new SelesAppEntities();
        string imagePath = "";
        public FrmAddProduct()
        {
           InitializeComponent();

        }

        private void FrmAddProduct_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = db.Categories.ToList();
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "Name";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try {
                if (txtProdName.Text == "" || txtProdPurchPrice.Text == "" || txtProdSellingPrice.Text == "" || txtProdQuantity.Text == "")
                {
                    MessageBox.Show("برجاء ادخال البيانات المطلوبة");
                }
                else if (db.AllProducts.Where(x => x.Name == txtProdName.Text).Count() > 0)
                {
                    MessageBox.Show("هذا الاسم موجود مسبقا برجاء ادخال أسم اخر ");
                }
                else
                {

                    AllProduct product = new AllProduct();
                    product.Name = txtProdName.Text;
                    product.Code = txtProdParcode.Text;
                    product.SellingPrice = int.Parse(txtProdSellingPrice.Text);
                    product.PurchPrice = int.Parse(txtProdPurchPrice.Text);
                    product.Notes = txtProdNotes.Text;
                    product.Quantity = int.Parse(txtProdQuantity.Text);
                    product.CategoryID = comboBox1.SelectedIndex;
                    if (comboBox1.SelectedValue != null)
                        product.CategoryID = int.Parse(comboBox1.SelectedValue.ToString());
                    else if (comboBox1.SelectedText != "")
                    {
                        Category cat = new Category();
                        string text = txtAddPart.Text;
                        cat.Name = txtAddPart.Text;
                        db.Categories.Add(cat);
                        db.SaveChanges();
                        comboBox1.DataSource = db.Categories.ToList();
                        comboBox1.Text = text;
                        product.CategoryID = int.Parse(comboBox1.SelectedValue.ToString());
                    }
                    db.AllProducts.Add(product);
                    db.SaveChanges();

                    if (imagePath != "")
                    {
                        string newPath = "D:\\Application SelesApp\\Images\\Products\\" + "Products " + product.Name + ".jpg";
                        File.Copy(imagePath, newPath);
                        product.Image = imagePath;
                        db.SaveChanges();
                    }
                    MessageBox.Show("تم الحفظ بنجاح");
                                     
                }
            }
            catch
            {
                MessageBox.Show("لم يتم الحفظ ");
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(openFrmProductList);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void openFrmProductList()
        {
            Application.Run(new FrmListProducts());
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

        private void txtProdParcode_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtProdPrice_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtProdQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Category cat = new Category();
            cat.Name = txtAddPart.Text;
            db.Categories.Add(cat);
            db.SaveChanges();
            comboBox1.DataSource = db.Categories.ToList();
            MessageBox.Show("تم الاضافة بنجاح");
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
