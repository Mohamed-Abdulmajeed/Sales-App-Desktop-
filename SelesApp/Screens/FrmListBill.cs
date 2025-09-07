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
    public partial class FrmListBill : Form
    {
        SelesAppEntities db = new SelesAppEntities();
        int currentIndex = 0;

        public FrmListBill()
        {
            try{
            InitializeComponent();
            dataGridView1.DataSource = db.SelesBills.Where(x => x.id != 1).OrderByDescending(x => x.id).Select(x => new { x.id, x.DateTime, x.Customer.Name, x.TotalOfBill, x.Discount, x.TotalAfterDiscount,x.TotalPrice, x.User.UserName, x.Notes }).ToList();
            dataGridView1.Columns[0].HeaderText = "رقم الفاتورة";
            dataGridView1.Columns[1].HeaderText = "التاريخ";
            dataGridView1.Columns[2].HeaderText = "إسم العميل";
            dataGridView1.Columns[3].HeaderText = "الإجمالى الكلى للفاتورة";
            dataGridView1.Columns[4].HeaderText = "الخصم";
            dataGridView1.Columns[5].HeaderText = "الاجمالى بعد الخصم";
            dataGridView1.Columns[6].HeaderText = "الاجمالى الكلى";
            dataGridView1.Columns[7].HeaderText = "إسم المستخدم";
            dataGridView1.Columns[8].HeaderText = "ملاحظات";
            ComBoxNameOfCust.DataSource = db.Customers.Where(x => x.isActive == true).ToList();
            ComBoxNameOfCust.ValueMember = "id";
            ComBoxNameOfCust.DisplayMember = "Name";
            }
            catch { }
        }
       
        private void FrmListBill_Load(object sender, EventArgs e)
        {
            ComBoxNameOfCust.DataSource = db.Customers.Where(x => x.isActive == true).ToList();
            ComBoxNameOfCust.ValueMember = "id";
            ComBoxNameOfCust.DisplayMember = "Name";
        }

        private void txtNoOfBill_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSearchForNo_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNoOfBill.Text != "" && txtNoOfBill.Text != "1")
                {
                    int id = int.Parse(txtNoOfBill.Text);
                    var bill = db.SelesBills.SingleOrDefault(x => x.id == id);
                    if (bill != null&&id!=1)
                    {
                        dateTimePicker1.Value = DateTime.Parse(bill.DateTime.ToString());
                        txtNoOfBill.Text = bill.id.ToString();
                        ComBoxNameOfCust.Text = bill.Customer.Name;
                        txtTotalOfBill.Text = bill.TotalOfBill.ToString();
                        txtDiscount.Text = bill.Discount.ToString();
                        txtTotalAfterDiscount.Text = bill.TotalAfterDiscount.ToString();
                        dataGridView2.DataSource = bill.SelesBillDetails.Select(x => new { x.ItemName, x.Quantity, x.Price, x.TotalSub }).ToList();
                        dataGridView2.Columns[0].HeaderText = "الصنف";
                        dataGridView2.Columns[1].HeaderText = "العدد";
                        dataGridView2.Columns[2].HeaderText = "السعر";
                        dataGridView2.Columns[3].HeaderText = "الاجمالى الفرعى";
                        dataGridView1.DataSource = db.SelesBills.Where(x => x.id==bill.id).OrderByDescending(x => x.id).Select(x => new { x.id, x.DateTime, x.Customer.Name, x.TotalOfBill, x.Discount, x.TotalAfterDiscount,x.TotalPrice, x.User.UserName, x.Notes }).ToList();
                       
                        dataGridView1.Columns[0].HeaderText = "رقم الفاتورة";
                        dataGridView1.Columns[1].HeaderText = "التاريخ";
                        dataGridView1.Columns[2].HeaderText = "إسم العميل";
                        dataGridView1.Columns[3].HeaderText = "الإجمالى الكلى للفاتورة";
                        dataGridView1.Columns[4].HeaderText = "الخصم";
                        dataGridView1.Columns[5].HeaderText = "الاجمالى بعد الخصم";
                        dataGridView1.Columns[6].HeaderText = "الاجمالى الكلى";
                        dataGridView1.Columns[7].HeaderText = "إسم المستخدم";
                        dataGridView1.Columns[8].HeaderText = "ملاحظات";
                    }
                    else
                        MessageBox.Show("رقم الفاتورة خطأ أدخل رقم صحيح");
                }
            }
            catch {
                MessageBox.Show("لم يتم التحميل بنجاح");
            }
        }

        private void txtTotalOfBill_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtTotalAfterDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(openSelesBay);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void openSelesBay()
        {
            Application.Run(new FrmSelesBay());
        }

        private void btnSearchForName_Click(object sender, EventArgs e)
        {
            try
            {
                if (ComBoxNameOfCust.Text != "")
                {
                    dataGridView1.DataSource = db.SelesBills.Where(x => x.Customer.Name.Contains(ComBoxNameOfCust.Text)).OrderByDescending(x => x.id).Select(x => new { x.id, x.DateTime, x.Customer.Name, x.TotalOfBill, x.Discount, x.TotalAfterDiscount,x.TotalPrice, x.User.UserName, x.Notes }).ToList();
                   
                    dataGridView1.Columns[0].HeaderText = "رقم الفاتورة";
                    dataGridView1.Columns[1].HeaderText = "التاريخ";
                    dataGridView1.Columns[2].HeaderText = "إسم العميل";
                    dataGridView1.Columns[3].HeaderText = "الإجمالى الكلى للفاتورة";
                    dataGridView1.Columns[4].HeaderText = "الخصم";
                    dataGridView1.Columns[5].HeaderText = "الاجمالى بعد الخصم";
                    dataGridView1.Columns[6].HeaderText = "الإجمالى الكلى";
                    dataGridView1.Columns[7].HeaderText = "إسم المستخدم";
                    dataGridView1.Columns[8].HeaderText = "ملاحظات";
                }
                else
                    MessageBox.Show("هذا الاسم غير موجود");

            }
            catch {
                MessageBox.Show("لم يتم التحميل بنجاح");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var bill = db.SelesBills.SingleOrDefault(x => x.id == id);
                if (bill != null && id!=1)
                { 
                dateTimePicker1.Value = DateTime.Parse(bill.DateTime.ToString());
                txtNoOfBill.Text = bill.id.ToString();
                ComBoxNameOfCust.Text = bill.Customer.Name;
                txtTotalOfBill.Text = bill.TotalOfBill.ToString();
                txtDiscount.Text = bill.Discount.ToString();
                txtTotalAfterDiscount.Text = bill.TotalAfterDiscount.ToString();
                dataGridView2.DataSource = bill.SelesBillDetails.Where(x => x.id != 1).OrderByDescending(x => x.id).Select(x => new { x.ItemName, x.Quantity, x.Price, x.TotalSub }).ToList();
                dataGridView2.Columns[0].HeaderText = "الصنف";
                dataGridView2.Columns[1].HeaderText = "العدد";
                dataGridView2.Columns[2].HeaderText = "السعر";
                dataGridView2.Columns[3].HeaderText = "الاجمالى الفرعى";
            }
            }
            catch { }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateTime = dateTimePicker1.Value.Date;
                dataGridView1.DataSource = db.SelesBills.Where(x => x.DateTime == dateTime).OrderByDescending(x => x.id).Select(x => new { x.id, x.DateTime, x.Customer.Name, x.TotalOfBill, x.Discount, x.TotalAfterDiscount,x.TotalPrice,x.User.UserName, x.Notes }).ToList();
             
                dataGridView1.Columns[0].HeaderText = "رقم الفاتورة";
                dataGridView1.Columns[1].HeaderText = "التاريخ";
                dataGridView1.Columns[2].HeaderText = "إسم العميل";
                dataGridView1.Columns[3].HeaderText = " الإجمالى الكلى للفاتورة";
                dataGridView1.Columns[4].HeaderText = "الخصم";
                dataGridView1.Columns[5].HeaderText = "الاجمالى بعد الخصم";
                dataGridView1.Columns[6].HeaderText = "الإجمالى الكلى";
                dataGridView1.Columns[7].HeaderText = "إسم المستخدم";
                dataGridView1.Columns[8].HeaderText = "ملاحظات";
            }
            catch {
                MessageBox.Show("لم يتم التحميل بنجاح");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = db.SelesBills.Where(x => x.id != 1).OrderByDescending(x => x.id).Select(x => new { x.id, x.DateTime, x.Customer.Name, x.TotalOfBill, x.Discount, x.TotalAfterDiscount,x.TotalPrice, x.User.UserName, x.Notes }).ToList();
                
                dataGridView1.Columns[0].HeaderText = "رقم الفاتورة";
                dataGridView1.Columns[1].HeaderText = "التاريخ";
                dataGridView1.Columns[2].HeaderText = "إسم العميل";
                dataGridView1.Columns[3].HeaderText = " الإجمالى الكلى للفاتورة";
                dataGridView1.Columns[4].HeaderText = "الخصم";
                dataGridView1.Columns[5].HeaderText = "الاجمالى بعد الخصم";
                dataGridView1.Columns[6].HeaderText = "الإجمالى الكلى";
                dataGridView1.Columns[7].HeaderText = "إسم المستخدم";
                dataGridView1.Columns[8].HeaderText = "ملاحظات";
            }
            catch
            {
                MessageBox.Show("لم يتم التحميل بنجاح");
            }
        }

        private void ComBoxNameOfCust_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                float marginH = 2;
                float marginW = 2;
                Font font8  = new Font("Arial", 8, FontStyle.Bold);
                Font font10 = new Font("Arial", 10, FontStyle.Bold);
                Font font12 = new Font("Arial", 12, FontStyle.Bold);
                Font font18 = new Font("Arial", 18, FontStyle.Bold);
                Font font22 = new Font("Arial", 22, FontStyle.Bold);

                var strn = db.Settings.ToList();
                string strNameOfPlace = strn[0].NameOfPill;
                string strPhone = strn[0].PhoneOfBill;

                string tt = "";
                if (DateTime.Now.ToString("tt") == "AM") tt = "ص";
                else tt = "م";

                string date = dateTimePicker1.Value.Date.ToString("yyyy/MM/dd - ") + dateTimePicker1.Value.Date.ToString("hh:mm ") + tt;
                string strInvoice = "فاتورة";

                string strNO = "  رقم الفاتورة  " + " : " + txtNoOfBill.Text;
                string strDate = "  التاريخ  " + " : " + date;
                string strName = "  اسم العميل  " + " : " + ComBoxNameOfCust.Text;
                SizeF fontSizeNO = e.Graphics.MeasureString(strNO, font12);
                SizeF fontSizeDate = e.Graphics.MeasureString(strDate, font10);
                SizeF fontSizeName = e.Graphics.MeasureString(strName, font10);
                SizeF fontSizeInvoice = e.Graphics.MeasureString(strInvoice, font22);
                SizeF fontSizeNameOfPlace = e.Graphics.MeasureString(strNameOfPlace, font18);
                SizeF fontSizePhone = e.Graphics.MeasureString(strPhone, font12);

                if (currentIndex == 0)
                {
                    e.Graphics.DrawImage(Properties.Resources.logoFatora1, 5, 2, 260, 65);
                    marginH += fontSizeName.Height ;
                    e.Graphics.DrawString(strNameOfPlace, font18, Brushes.DarkRed, (e.PageBounds.Width - fontSizeNameOfPlace.Width - marginW), marginH+= fontSizeInvoice.Height);
                    marginH += 3;
                    if (strPhone != "")
                        e.Graphics.DrawString(strPhone, font12, Brushes.DarkRed, (e.PageBounds.Width - fontSizePhone.Width - marginW), marginH += 5 + fontSizePhone.Height);

                    e.Graphics.DrawString(strNO, font10, Brushes.Black, (e.PageBounds.Width - fontSizeNO.Width - marginW), marginH += 5 + fontSizeNO.Height);
                    e.Graphics.DrawString(strName, font10, Brushes.Black, (e.PageBounds.Width - fontSizeName.Width - marginW), marginH += 5 + fontSizeName.Height);
                    e.Graphics.DrawString(strDate, font10, Brushes.Black, (e.PageBounds.Width - fontSizeDate.Width - marginW), marginH += 5 + fontSizeDate.Height);
                }
                marginH += fontSizeName.Height + 5;

                int yOfRectangle = dataGridView2.Rows.Count * 25 + 25;

                if (dataGridView2.Rows.Count - currentIndex < 30)
                    yOfRectangle = (dataGridView2.Rows.Count * 25 + 25) - (currentIndex * 25);
                else
                    yOfRectangle = 30 * 25 + 25;
                e.Graphics.DrawRectangle(Pens.Green, marginW, marginH, e.PageBounds.Width - marginW * 2, yOfRectangle);

                int colHeight = 25;
                int col1Width = 170;
                int col2Width = 30 + col1Width;
                int col3Width = 37 + col2Width;
                int col4Width = 38 + col3Width;

                float marginH2 = marginH + 15;
                e.Graphics.DrawLine(Pens.Green, marginW, marginH += colHeight, e.PageBounds.Width - marginW, marginH);
                e.Graphics.DrawString(" الصنف ", font10, Brushes.Black, e.PageBounds.Width - marginW + 70 - col1Width, marginH - 18);
                e.Graphics.DrawLine(Pens.Green, e.PageBounds.Width - 2 * marginW - col1Width, marginH - 25, e.PageBounds.Width - 2 * marginW - col1Width, marginH + yOfRectangle - 25);
                e.Graphics.DrawString(" العدد ", font10, Brushes.Black, e.PageBounds.Width - marginW - col2Width - 3, marginH - 18);
                e.Graphics.DrawLine(Pens.Green, e.PageBounds.Width - 2 * marginW - col2Width, marginH - 25, e.PageBounds.Width - 2 * marginW - col2Width, marginH + yOfRectangle - 25);
                e.Graphics.DrawString(" السعر ", font10, Brushes.Black, e.PageBounds.Width - marginW - col3Width - 3, marginH - 18);
                e.Graphics.DrawLine(Pens.Green, e.PageBounds.Width - 2 * marginW - col3Width, marginH - 25, e.PageBounds.Width - 2 * marginW - col3Width, marginH + yOfRectangle - 25);
                e.Graphics.DrawString(" اجمالى ", font10, Brushes.Black, e.PageBounds.Width - 2 * marginW - col4Width - 3, marginH - 18);

                int range = dataGridView2.Rows.Count;

                for (int x = currentIndex; x < dataGridView2.Rows.Count; x++)
                {
                    SizeF fontSizeNameOfType = e.Graphics.MeasureString(dataGridView2.Rows[x].Cells[0].Value.ToString(), font8);
                    e.Graphics.DrawString(dataGridView2.Rows[x].Cells[0].Value.ToString(), font8, Brushes.Black, e.PageBounds.Width - fontSizeNameOfType.Width - marginW * 1, marginH + 5);
                    e.Graphics.DrawString(dataGridView2.Rows[x].Cells[1].Value.ToString(), font8, Brushes.Black, e.PageBounds.Width - marginW - col2Width, marginH + 3);
                    e.Graphics.DrawString(dataGridView2.Rows[x].Cells[2].Value.ToString(), font8, Brushes.Black, e.PageBounds.Width - marginW - col3Width, marginH + 3);
                    e.Graphics.DrawString(dataGridView2.Rows[x].Cells[3].Value.ToString(), font8, Brushes.Black, e.PageBounds.Width - marginW - col4Width, marginH + 3);
                    e.Graphics.DrawLine(Pens.Green, marginW, marginH, e.PageBounds.Width - marginW, marginH);
                    currentIndex++;
                    marginH += colHeight;
                    if (currentIndex == 30)
                        break;
                    if (currentIndex == 30)
                        break;
                    if (currentIndex == 30)
                        break;

                }

                string strTotal = "  الاجمالى الكلى للفاتورة " + " : " + txtTotalOfBill.Text;

                string strDiscount = "  الخصم  " + " : " + txtDiscount.Text;
                string strTotalAfterDiscount = "  الاجمالى بعد الخصم  " + " : " + txtTotalAfterDiscount.Text;

                string[] arr = { strTotal, strDiscount, strTotalAfterDiscount };
                if (currentIndex >= dataGridView2.Rows.Count)
                {
                    for (int x = 0; x < arr.Length; x++)
                    {
                        SizeF fontSizeNameOfType = e.Graphics.MeasureString(arr[x], font10);
                        e.Graphics.DrawString(arr[x], font10, Brushes.Black, e.PageBounds.Width - fontSizeNameOfType.Width - marginW * 4, marginH + 5);
                        e.Graphics.DrawLine(Pens.Green, marginW, marginH, e.PageBounds.Width - marginW, marginH);

                        marginH += colHeight;
                    }
                    e.Graphics.DrawLine(Pens.Green, marginW, marginH, e.PageBounds.Width - marginW, marginH);
                    currentIndex = 0;
                }
            }
            catch { }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void customerBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                var r = MessageBox.Show("هل تريد الحذف", "تأكيد الحذف", MessageBoxButtons.OKCancel);
                if (r == DialogResult.OK && txtNoOfBill.Text!="1")
                {
                    var result = db.SelesBills.Find(int.Parse(txtNoOfBill.Text));
                   
                    var Bill = result.SelesBillDetails.ToList();
                    for (int i = 0; i < Bill.Count; i++)
                        db.SelesBillDetails.Remove(Bill[i]);
                    db.SelesBills.Remove(result);
                    db.SaveChanges();
                    dataGridView1.DataSource = db.SelesBills.Where(x => x.id != 1).OrderByDescending(x => x.id).Select(x => new { x.id, x.DateTime, x.Customer.Name, x.TotalOfBill, x.Discount, x.TotalAfterDiscount, x.TotalPrice, x.User.UserName, x.Notes }).ToList();
                    MessageBox.Show("تم الحذف بنجاح");
                }
            }
            catch
            {
                MessageBox.Show("لم يتم الحذف بنجاح");
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
