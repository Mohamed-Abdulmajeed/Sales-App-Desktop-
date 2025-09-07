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
    public partial class FrmListProducts : Form
    {
        SelesAppEntities db = new SelesAppEntities();
        string imagePath = "";
        int id;
        public FrmListProducts()
        {
            InitializeComponent();
            try{
            dataGridView1.DataSource = db.AllProducts.Select(x => new { x.Code, x.Name,x.PurchPrice, x.SellingPrice, x.Quantity, x.CategoryID, x.Notes ,x.id}).ToList();
            dataGridView1.Columns[0].HeaderText = "كود المنتج";
            dataGridView1.Columns[1].HeaderText = "اسم المنتج";
            dataGridView1.Columns[2].HeaderText = "سعر الشراء";
            dataGridView1.Columns[3].HeaderText = "سعر البيع";
            dataGridView1.Columns[4].HeaderText = "الكمية او العدد";
            dataGridView1.Columns[5].HeaderText = "رقم الفئة او النوع";
            dataGridView1.Columns[6].HeaderText = "ملاحظات";
            dataGridView1.Columns[7].HeaderText = "الرقم";

            comboBox1.DataSource = db.Categories.ToList();
            comboBox2.DataSource = db.Categories.ToList();
            string[] itemsData = { "الرقم التسلسلى", "الاسم", "الكود", "السعر", "الكمية", "الفئة" };
            comboBox3.DataSource = itemsData;
            }
            catch { }
        }

        private void FrmListProducts_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = db.Categories.ToList();
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "Name";
            comboBox2.DataSource = db.Categories.ToList();
            comboBox2.ValueMember = "id";
            comboBox2.DisplayMember = "Name";
            string[] itemsData = { "الرقم التسلسلى", "الاسم", "الكود", "السعر", "الكمية", "الفئة" };
            comboBox3.DataSource = itemsData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodeOfProduct.Text == "")
                    dataGridView1.DataSource = db.AllProducts.Where(x => x.Name.Contains(txtNameOfProduct.Text)).Select(x => new { x.Code, x.Name,x.PurchPrice, x.SellingPrice, x.Quantity, x.CategoryID, x.Notes, x.id }).ToList();

                if (txtNameOfProduct.Text == "")
                    dataGridView1.DataSource = db.AllProducts.Where(x => x.Code == txtCodeOfProduct.Text).Select(x => new { x.Code, x.Name,x.PurchPrice, x.SellingPrice, x.Quantity, x.CategoryID, x.Notes, x.id }).ToList();

                else
                    dataGridView1.DataSource = db.AllProducts.Where(x => x.Code == txtCodeOfProduct.Text || x.Name.Contains(txtNameOfProduct.Text)).Select(x => new { x.Code, x.Name,x.PurchPrice, x.SellingPrice, x.Quantity, x.CategoryID, x.Notes, x.id }).ToList();
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {try{
            dataGridView1.DataSource = db.AllProducts.Select(x => new { x.Code, x.Name,x.PurchPrice, x.SellingPrice, x.Quantity, x.CategoryID, x.Notes,x.id }).ToList();
        }
        catch { }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(dataGridView1.CurrentRow.Cells[7].Value.ToString());
                var result = db.AllProducts.SingleOrDefault(x => x.id == id);
                if (result != null)
                {
                    txtProdParcode.Text = result.Code;
                    txtProdName.Text = result.Name;
                    txtProdSellingPrice.Text = result.SellingPrice.ToString();
                    txtProdPurhPrice.Text = result.PurchPrice.ToString();
                    txtProdQuantity.Text = result.Quantity.ToString();
                    txtProdNotes.Text = result.Notes;
                    try
                    {
                        pictureBox1.ImageLocation = result.Image;
                    }
                    catch
                    {
                        pictureBox1.ImageLocation = null;
                    }
                    comboBox1.SelectedValue = result.CategoryID;
                }
            }
            catch { }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var r = MessageBox.Show("هل تريد التعديل", "تأكيد التعديل", MessageBoxButtons.OKCancel);
                if (db.AllProducts.Where(x => x.Name == txtProdName.Text && x.id != id).Count() > 0)
                {
                    MessageBox.Show(" لا يمكن التعديل الى هذا الاسم لانه موجود مسبقا");
                }
                else if (r == DialogResult.OK && dataGridView1.CurrentRow !=null)
                {
                    id = int.Parse(dataGridView1.CurrentRow.Cells[7].Value.ToString());
                    var result = db.AllProducts.SingleOrDefault(x => x.id == id);

                    result.Code = txtProdParcode.Text;
                    result.Name = txtProdName.Text;
                    result.SellingPrice = decimal.Parse(txtProdSellingPrice.Text);
                    result.PurchPrice = decimal.Parse(txtProdPurhPrice.Text);

                    result.Quantity = int.Parse(txtProdQuantity.Text);
                    result.Notes = txtProdNotes.Text;
                    result.CategoryID = int.Parse(comboBox1.SelectedValue.ToString());
                    if (imagePath != "")
                    {
                        string newPath = Environment.CurrentDirectory + "Products_" + result.Name + ".jpg";
                        File.Copy(imagePath, newPath, true);
                        result.Image = newPath;
                    }

                    db.SaveChanges();
                    dataGridView1.DataSource = db.AllProducts.Select(x => new { x.Code, x.Name,x.PurchPrice, x.SellingPrice, x.Quantity, x.CategoryID, x.Notes, x.id }).ToList();

                    MessageBox.Show("تم التعديل بنجاح");
                }
            }
            catch
            {
                MessageBox.Show("لم يتم التعديل بنجاح");
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var r = MessageBox.Show("هل تريد الحذف", "تأكيد الحذف", MessageBoxButtons.OKCancel);
                if (r == DialogResult.OK && dataGridView1.CurrentRow != null)
                {
                    var result = db.AllProducts.Find(id);
                    db.AllProducts.Remove(result);
                    db.SaveChanges();
                    dataGridView1.DataSource = db.AllProducts.Select(x => new { x.Code, x.Name,x.PurchPrice, x.SellingPrice, x.Quantity, x.CategoryID, x.Notes, x.id }).ToList();
                }
            }
            catch
            {
                MessageBox.Show("لم يتم الحذف بنجاح");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Close();
            Thread th = new Thread(openFrmAddPrduct);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void openFrmAddPrduct()
        {
            Application.Run(new FrmAddProduct());
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {try{
             int catid = int.Parse(comboBox2.SelectedValue.ToString());
             dataGridView1.DataSource = db.AllProducts.Where(x => x.CategoryID == catid).Select(x => new { x.Code, x.Name,x.PurchPrice, x.SellingPrice, x.Quantity, x.CategoryID, x.Notes, x.id }).ToList();
        }
        catch { }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {//     "الرقم التسلسلى", "الاسم", "الكود", "السعر", "الكمية", "الفئة" };
            try{
            string name = comboBox3.SelectedValue.ToString();
            if (name == "الرقم التسلسلى")
                dataGridView1.DataSource = db.AllProducts.OrderBy(x => x.id).Select(x => new { x.Code, x.Name,x.PurchPrice, x.SellingPrice, x.Quantity, x.CategoryID, x.Notes, x.id }).ToList();
            else if (name == "الاسم")
                dataGridView1.DataSource = db.AllProducts.OrderBy(x => x.Name).Select(x => new { x.Code, x.Name,x.PurchPrice, x.SellingPrice, x.Quantity, x.CategoryID, x.Notes, x.id }).ToList();
            else if (name == "الكود")
                dataGridView1.DataSource = db.AllProducts.OrderBy(x => x.Code).Select(x => new { x.Code, x.Name,x.PurchPrice, x.SellingPrice, x.Quantity, x.CategoryID, x.Notes, x.id }).ToList();
            else if (name == "السعر")
                dataGridView1.DataSource = db.AllProducts.OrderBy(x => x.SellingPrice).Select(x => new { x.Code, x.Name,x.PurchPrice, x.SellingPrice, x.Quantity, x.CategoryID, x.Notes, x.id }).ToList();
            else if (name == "الكمية")
                dataGridView1.DataSource = db.AllProducts.OrderBy(x => x.Quantity).Select(x => new { x.Code, x.Name,x.PurchPrice, x.SellingPrice, x.Quantity, x.CategoryID, x.Notes, x.id }).ToList();
            else if (name == "الفئة")
                dataGridView1.DataSource = db.AllProducts.OrderBy(x => x.Category.Name).Select(x => new { x.Code, x.Name,x.PurchPrice, x.SellingPrice, x.Quantity, x.CategoryID, x.Notes, x.id }).ToList();

            }
            catch { }
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

        private void txtCodeOfProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
    }
}
