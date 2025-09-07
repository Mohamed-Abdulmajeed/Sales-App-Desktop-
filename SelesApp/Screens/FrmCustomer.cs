using DevExpress.XtraEditors.Filtering.Templates;
using SelesApp.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelesApp.Screens
{
    public partial class FrmCustomer : Form
    {

        SelesAppEntities db = new SelesAppEntities();
        string imagePath = "";
        int id;
        public FrmCustomer()
        {
            try
            {
                InitializeComponent();
                dataGridView1.DataSource = db.Customers.Select(x => new { x.id, x.Name, x.Address, x.Phone, x.Company, x.isActive, x.Email, x.Notes }).ToList();
                dataGridView1.Columns[0].HeaderText = "رقم العميل";
                dataGridView1.Columns[1].HeaderText = "اسم العميل";
                dataGridView1.Columns[2].HeaderText = "العنوان";
                dataGridView1.Columns[3].HeaderText = "رقم التليفون";
                dataGridView1.Columns[4].HeaderText = "اسم الشركة او المحل";
                dataGridView1.Columns[5].HeaderText = "نشط |غير نشط";
                dataGridView1.Columns[6].HeaderText = "الايميل";
                dataGridView1.Columns[7].HeaderText = "ملاحظات";
            }
            catch { }
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {

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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = db.Customers.Select(x => new { x.id, x.Name, x.Address, x.Phone, x.Company, x.isActive, x.Email, x.Notes }).ToList();
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPhontToSearch.Text == "")
                    dataGridView1.DataSource = db.Customers.Where(x => x.Name.Contains(txtNameToSearch.Text)).Select(x => new { x.id, x.Name, x.Address, x.Phone, x.Company, x.isActive, x.Email, x.Notes }).ToList();

                else if (txtNameToSearch.Text == "")
                    dataGridView1.DataSource = db.Customers.Where(x => x.Phone.Contains(txtPhontToSearch.Text)).Select(x => new { x.id, x.Name, x.Address, x.Phone, x.Company, x.isActive, x.Email, x.Notes }).ToList();

                else
                    dataGridView1.DataSource = db.Customers.Where(x => x.Phone.Contains(txtPhontToSearch.Text) || x.Name.Contains(txtNameToSearch.Text)).Select(x => new { x.id, x.Name, x.Address, x.Phone, x.Company, x.isActive, x.Email, x.Notes }).ToList();
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCustName.Text == "")
                {
                    MessageBox.Show("برجاء ادخال البيانات المطلوبة");
                }
                else if (db.Customers.Where(x => x.Name == txtCustName.Text).Count() > 0)
                {
                    MessageBox.Show("هذا الاسم موجود مسبقا برجاء ادخال أسم اخر ");
                }
                else
                {
                    var r = MessageBox.Show("هل تريد إضافة هذا العميل ؟", "تأكيد الاضافة", MessageBoxButtons.OKCancel);
                    if (r == DialogResult.OK)
                    {
                        Customer cutomer = new Customer();
                        cutomer.Name = txtCustName.Text;
                        cutomer.Phone = txtCustPhone.Text;
                        cutomer.Email = txtCustEmail.Text;
                        cutomer.Notes = txtCustNotes.Text;
                        cutomer.Address = txtCustAddress.Text;
                        cutomer.Company = txtCustCompany.Text;
                        cutomer.isActive = checkActive.Checked;
                        cutomer.TotalDebt = 0;
                        db.Customers.Add(cutomer);
                        db.SaveChanges();

                        if (imagePath != "")
                        {
                            string newPath = "D:\\Application SelesApp\\Images\\Customers\\" + "Customers " + cutomer.id + ".jpg";
                            File.Copy(imagePath, newPath);
                            cutomer.Image = imagePath;
                            db.SaveChanges();
                        }
                        MessageBox.Show("تم الحفظ بنجاح");

                        txtCustName.Text = "";
                        txtCustPhone.Text = "";
                        txtCustEmail.Text = "";
                        txtCustNotes.Text = "";
                        txtCustAddress.Text = "";
                        txtCustCompany.Text = "";
                        checkActive.Checked = false;
                        pictureBox1.ImageLocation = "";

                        dataGridView1.DataSource = db.Customers.Select(x => new { x.id, x.Name, x.Address, x.Phone, x.Company, x.isActive, x.Email, x.Notes }).ToList();

                    }
                }
            }
            catch
            {
                MessageBox.Show("لم يتم الحفظ بنجاح");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var result = db.Customers.SingleOrDefault(x => x.id == id);
                if (result != null)
                {
                    txtCustAddress.Text = result.Address;
                    txtCustCompany.Text = result.Company;
                    txtCustEmail.Text = result.Email;
                    txtCustName.Text = result.Name;
                    txtCustNotes.Text = result.Notes;
                    txtCustPhone.Text = result.Phone;
                    txtTotalDebt.Text = result.TotalDebt.ToString();
                    dataGridView2.DataSource = result.CustomerDebts.Select(x => new { x.DateTime, x.KindOfOP, x.Amount, x.TotalResult }).ToList();
                    dataGridView2.Columns[0].HeaderText = "التاريخ";
                    dataGridView2.Columns[1].HeaderText = "نوع العملية";
                    dataGridView2.Columns[2].HeaderText = "المبلغ";
                    dataGridView2.Columns[3].HeaderText = "الاجمالى";
                    if (result.isActive == null)
                        result.isActive = false;
                    checkActive.Checked = (bool)result.isActive;
                    try
                    {
                        pictureBox1.ImageLocation = result.Image;
                    }
                    catch
                    {
                        pictureBox1.ImageLocation = null;
                    }
                }
            }
            catch { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                var r = MessageBox.Show("هل تريد التعديل", "تأكيد التعديل", MessageBoxButtons.OKCancel);
                if (db.Customers.Where(x => x.Name == txtCustName.Text && x.id != id).Count() > 0)
                {
                    MessageBox.Show(" لا يمكن التعديل الى هذا الاسم لانه موجود مسبقا");
                }

                else if (r == DialogResult.OK)
                {
                    id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    var customer = db.Customers.SingleOrDefault(x => x.id == id);
                    if (customer.Name != "فاتورة نقدى")
                    {
                        customer.Name = txtCustName.Text;
                        customer.Phone = txtCustPhone.Text;
                        customer.Email = txtCustEmail.Text;
                        customer.Notes = txtCustNotes.Text;
                        customer.Address = txtCustAddress.Text;
                        customer.Company = txtCustCompany.Text;
                        customer.isActive = checkActive.Checked;

                        if (imagePath != "")
                        {
                            string newPath = "D:\\Application SelesApp\\Images\\Customers\\" + "Customers " + customer.id + ".jpg";
                            File.Copy(imagePath, newPath, true);
                            customer.Image = imagePath;
                        }

                        db.SaveChanges();
                        dataGridView1.DataSource = db.Customers.Select(x => new { x.id, x.Name, x.Address, x.Phone, x.Company, x.isActive, x.Email, x.Notes }).ToList();

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
                    var result = db.Customers.Find(id);
                    if (result.Name != "فاتورة نقدى")
                    {
                        db.Customers.Remove(result);
                        db.SaveChanges();
                        dataGridView1.DataSource = db.Customers.Select(x => new { x.id, x.Name, x.Address, x.Phone, x.Company, x.isActive, x.Email, x.Notes }).ToList();
                        MessageBox.Show("تم الحذف بنجاح");
                    }
                }
            }
            catch
            {
                MessageBox.Show("لم يتم الحذف بنجاح");
            }
        }

        private void txtCustPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPhontToSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtMony_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (txtMony.Text != ""&& txtCustName.Text !="فاتورة نقدى")
            {
                var r = MessageBox.Show("هل تريد الاضافة", "تأكيد الاضافة", MessageBoxButtons.OKCancel);
                if (r == DialogResult.OK)
                {
                    string date = DateTime.Now.Date.ToString("yyyy/MM/dd");

                    db.CustomerDebts.Add(
                        new CustomerDebt
                        {
                            DateTime = DateTime.Parse(date),
                            CustomerID = id,
                            KindOfOP = "أعطيت",
                            Amount = decimal.Parse(txtMony.Text),
                            TotalResult = decimal.Parse(txtMony.Text) + decimal.Parse(txtTotalDebt.Text)
                        });
                    var customer = db.Customers.SingleOrDefault(x => x.id == id);
                    customer.TotalDebt = decimal.Parse(txtMony.Text) + decimal.Parse(txtTotalDebt.Text);
                    db.SaveChanges();
                    txtTotalDebt.Text = decimal.Parse(txtMony.Text) + decimal.Parse(txtTotalDebt.Text) + "";
                    MessageBox.Show("تم اضافة المبلغ بنجاح");
                }
            }
            else
                MessageBox.Show("لايمكن الاضافة");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txtMony.Text != "" && txtCustName.Text != "فاتورة نقدى")
            {
                var r = MessageBox.Show("هل تريد الاضافة", "تأكيد الاضافة", MessageBoxButtons.OKCancel);
                if (r == DialogResult.OK)
                {
                    string date = DateTime.Now.ToString("yyyy/MM/dd");
                    db.CustomerDebts.Add(
                        new CustomerDebt
                        {
                            DateTime = DateTime.Parse(date),
                            CustomerID = id,
                            KindOfOP = "أخذت",
                            Amount = decimal.Parse(txtMony.Text),
                            TotalResult = decimal.Parse(txtTotalDebt.Text) - decimal.Parse(txtMony.Text)
                        });
                    var customer = db.Customers.SingleOrDefault(x => x.id == id);
                    customer.TotalDebt = decimal.Parse(txtTotalDebt.Text) - decimal.Parse(txtMony.Text);
                    db.SaveChanges();
                    txtTotalDebt.Text = decimal.Parse(txtTotalDebt.Text) - decimal.Parse(txtMony.Text) + "";
                    MessageBox.Show("تم خصم المبلغ بنجاح");
                }
                
            }
            else
                MessageBox.Show("لايمكن الاضافة");
        }

        private void txtTotalDebt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                ((Form)printPreviewDialog1).StartPosition = FormStartPosition.CenterScreen;
                ((Form)printPreviewDialog1).Height = 650;
                ((Form)printPreviewDialog1).Width = 500;

                if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
            catch
            {
                MessageBox.Show("لم يتم التحميل بنجاح");
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                float marginH = 5;
                float marginW = 2;

                Font font10 = new Font("Arial", 10, FontStyle.Bold);
                Font font12 = new Font("Arial", 12, FontStyle.Bold);
                Font font18 = new Font("Arial", 18, FontStyle.Bold);
                Font font22 = new Font("Arial", 22, FontStyle.Bold);
                var sett = db.Settings.ToList();
                string strNameOfPlace = sett[0].NameOfPill;

                string tt = "";
                if (DateTime.Now.ToString("tt") == "AM") tt = "ص";
                else tt = "م";

                string date = DateTime.Now.Date.ToString("yyyy/MM/dd - hh:mm") + tt;
                string strInvoice = "تقرير معاملات";
                string strDate = "  التاريخ  " + " : " + date;
                string strName = "  اسم العميل  " + " : " + txtCustName.Text;
                SizeF fontSizeDate = e.Graphics.MeasureString(strDate, font10);
                SizeF fontSizeName = e.Graphics.MeasureString(strName, font10);
                SizeF fontSizeInvoice = e.Graphics.MeasureString(strInvoice, font22);
                SizeF fontSizeNameOfPlace = e.Graphics.MeasureString(strNameOfPlace, font18);

                e.Graphics.DrawString(strInvoice, font22, Brushes.Black, (e.PageBounds.Width - fontSizeInvoice.Width - marginW), marginH += 3 );
                e.Graphics.DrawString(strNameOfPlace, font18, Brushes.DarkRed, (e.PageBounds.Width - fontSizeNameOfPlace.Width - marginW), marginH += 5 + fontSizeInvoice.Height);
                e.Graphics.DrawString(strName, font12, Brushes.Black, (e.PageBounds.Width - fontSizeName.Width - marginW), marginH += 3 + fontSizeNameOfPlace.Height);
                e.Graphics.DrawString(strDate, font10, Brushes.Black, (e.PageBounds.Width - fontSizeDate.Width - marginW), marginH += 3 + fontSizeName.Height);
                
                marginH += fontSizeName.Height + 5;

                int yOfRectangle = dataGridView2.Rows.Count * 25 + 25;
               
                e.Graphics.DrawRectangle(Pens.Green, marginW, marginH, e.PageBounds.Width - marginW * 2, yOfRectangle);

                int colHeight = 25;
                int col1Width = 105;
                int col2Width = 50 + col1Width;
                int col3Width = 50 + col2Width;
                int col4Width = 50 + col3Width;

                float marginH2 = marginH + 15;
                e.Graphics.DrawLine(Pens.Green, marginW, marginH += colHeight, e.PageBounds.Width - marginW, marginH);
                e.Graphics.DrawString(" التاريخ ", font10, Brushes.Black, e.PageBounds.Width - marginW + 30 - col1Width, marginH - 18);
                e.Graphics.DrawLine(Pens.Green, e.PageBounds.Width - 2 * marginW - col1Width, marginH - 25, e.PageBounds.Width - 2 * marginW - col1Width, marginH + yOfRectangle - 25);
                e.Graphics.DrawString(" العملية ", font10, Brushes.Black, e.PageBounds.Width - marginW - col2Width, marginH - 18);
                e.Graphics.DrawLine(Pens.Green, e.PageBounds.Width - 2 * marginW - col2Width, marginH - 25, e.PageBounds.Width - 2 * marginW - col2Width, marginH + yOfRectangle - 25);
                e.Graphics.DrawString(" المبلغ ", font10, Brushes.Black, e.PageBounds.Width - marginW - col3Width, marginH - 18);
                e.Graphics.DrawLine(Pens.Green, e.PageBounds.Width - 2 * marginW - col3Width, marginH - 25, e.PageBounds.Width - 2 * marginW - col3Width, marginH + yOfRectangle - 25);
                e.Graphics.DrawString(" الباقى ", font10, Brushes.Black, e.PageBounds.Width - 2 * marginW - col4Width, marginH - 18);

                int range = dataGridView2.Rows.Count;

                for (int x = 0; x < dataGridView2.Rows.Count; x++)
                {
                    DateTime DT = DateTime.Parse(dataGridView2.Rows[x].Cells[0].Value.ToString());
                    string strd = DT.Date.ToString("yyyy/MM/dd");
                    SizeF fontSizeNameOfType = e.Graphics.MeasureString(strd, font10);
                    e.Graphics.DrawString(strd, font10, Brushes.Black, e.PageBounds.Width - fontSizeNameOfType.Width - marginW * 4, marginH + 5);
                    e.Graphics.DrawString(dataGridView2.Rows[x].Cells[1].Value.ToString(), font10, Brushes.Black, e.PageBounds.Width - marginW - col2Width, marginH + 3);
                    e.Graphics.DrawString(dataGridView2.Rows[x].Cells[2].Value.ToString(), font10, Brushes.Black, e.PageBounds.Width - marginW - col3Width, marginH + 3);
                    e.Graphics.DrawString(dataGridView2.Rows[x].Cells[3].Value.ToString(), font10, Brushes.Black, e.PageBounds.Width - marginW - col4Width, marginH + 3);
                    e.Graphics.DrawLine(Pens.Green, marginW, marginH, e.PageBounds.Width - marginW, marginH);
                    marginH += colHeight;
                  
                }
                            
            }
            catch { }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                var r = MessageBox.Show("هل تريد الحذف", "تأكيد الحذف", MessageBoxButtons.OKCancel);
                if (r == DialogResult.OK)
                {
                    var result = db.Customers.Find(id);
                    var cuDebt = result.CustomerDebts.ToList();
                    for (int i = 0; i < cuDebt.Count; i++)
                        db.CustomerDebts.Remove(cuDebt[i]);
                    result.TotalDebt = 0;
                    db.SaveChanges();
                    dataGridView1.DataSource = db.Customers.Select(x => new { x.id, x.Name, x.Address, x.Phone, x.Company, x.isActive, x.Email, x.Notes }).ToList();
                    MessageBox.Show("تم الحذف بنجاح");
                }
            }
            catch
            {
                MessageBox.Show("لم يتم الحذف بنجاح");
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkActive_CheckedChanged(object sender, EventArgs e)
        {
            if (checkActive.CheckState == CheckState.Checked)
                checkActive.Text = "عميل نشط";
            else if (checkActive.CheckState == CheckState.Unchecked)
                checkActive.Text = "عميل غير نشط";
            else
                checkActive.Text = "?";

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = dialog.FileName;
                imagePath = dialog.FileName;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
