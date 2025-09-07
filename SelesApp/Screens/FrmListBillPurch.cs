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
    public partial class FrmListBillPurch : Form
    {
        SelesAppEntities db = new SelesAppEntities();

        public FrmListBillPurch()
        {
            try{
            InitializeComponent();
           
            dataGridView1.DataSource = db.PurchBills.Where(x=>x.id!=1).OrderByDescending(x=>x.id).Select(x => new { x.id, x.DateTime, x.Suppler.Name, x.TotalOfBill, x.Discount, x.TotalAfterDiscount, x.User.UserName, x.Notes }).ToList();
           
            dataGridView1.Columns[0].HeaderText = "رقم الفاتورة";
            dataGridView1.Columns[1].HeaderText = "التاريخ";
            dataGridView1.Columns[2].HeaderText = "إسم المورد";
            dataGridView1.Columns[3].HeaderText = "الإجمالى الكلى";
            dataGridView1.Columns[4].HeaderText = "الخصم";
            dataGridView1.Columns[5].HeaderText = "الاجمالى بعد الخصم";
            dataGridView1.Columns[6].HeaderText = "إسم المستخدم";
            dataGridView1.Columns[7].HeaderText = "ملاحظات";
            ComBoxNameOfCust.DataSource = db.Supplers.Where(x => x.isActive == true).ToList();
            ComBoxNameOfCust.ValueMember = "id";
            ComBoxNameOfCust.DisplayMember = "Name";
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateTime = dateTimePicker1.Value.Date;

                dataGridView1.DataSource = db.PurchBills.Where(x => x.DateTime == dateTime).OrderByDescending(x => x.id).Select(x => new { x.id, x.DateTime, x.Suppler.Name, x.TotalOfBill, x.Discount, x.TotalAfterDiscount, x.User.UserName, x.Notes }).ToList();
                
                dataGridView1.Columns[0].HeaderText = "رقم الفاتورة";
                dataGridView1.Columns[1].HeaderText = "التاريخ";
                dataGridView1.Columns[2].HeaderText = "إسم المورد";
                dataGridView1.Columns[3].HeaderText = "الإجمالى الكلى";
                dataGridView1.Columns[4].HeaderText = "الخصم";
                dataGridView1.Columns[5].HeaderText = "الاجمالى بعد الخصم";
                dataGridView1.Columns[6].HeaderText = "إسم المستخدم";
                dataGridView1.Columns[7].HeaderText = "ملاحظات";
            }
            catch {
                MessageBox.Show("لم يتم التحميل بنجاح");
            }
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
                if (txtNoOfBill.Text != "1")
                {
                    if (txtNoOfBill.Text != "")
                    {
                        int id = int.Parse(txtNoOfBill.Text);
                        var bill = db.PurchBills.SingleOrDefault(x => x.id == id);
                        if (bill != null&&id!=1)
                        {
                            dateTimePicker1.Value = DateTime.Parse(bill.DateTime.ToString());
                            txtNoOfBill.Text = bill.id.ToString();
                            ComBoxNameOfCust.Text = bill.Suppler.Name;
                            txtTotalBill.Text = bill.TotalOfBill.ToString();
                            txtDiscount.Text = bill.Discount.ToString();
                            txtTotalAfterDiscount.Text = bill.TotalAfterDiscount.ToString();
                            dataGridView2.DataSource = bill.PurchBillDetails.Select(x => new { x.ItemName, x.Quantity, x.Price, x.TotalSub }).ToList();
                            dataGridView2.Columns[0].HeaderText = "الصنف";
                            dataGridView2.Columns[1].HeaderText = "العدد";
                            dataGridView2.Columns[2].HeaderText = "السعر";
                            dataGridView2.Columns[3].HeaderText = "الاجمالى الفرعى";
                            dataGridView1.DataSource = db.PurchBills.Where(x => x.id == bill.id).OrderByDescending(x => x.id).Select(x => new { x.id, x.DateTime, x.Suppler.Name, x.TotalOfBill, x.Discount, x.TotalAfterDiscount, x.User.UserName, x.Notes }).ToList();
                           
                            dataGridView1.Columns[0].HeaderText = "رقم الفاتورة";
                            dataGridView1.Columns[1].HeaderText = "التاريخ";
                            dataGridView1.Columns[2].HeaderText = "إسم المورد";
                            dataGridView1.Columns[3].HeaderText = "الإجمالى الكلى";
                            dataGridView1.Columns[4].HeaderText = "الخصم";
                            dataGridView1.Columns[5].HeaderText = "الاجمالى بعد الخصم";
                            dataGridView1.Columns[6].HeaderText = "إسم المستخدم";
                            dataGridView1.Columns[7].HeaderText = "ملاحظات";
                        }
                        else
                            MessageBox.Show("رقم الفاتورة خطأ أدخل رقم صحيح");
                    }
                }
            }
            catch
            {
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

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(openMainForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
            Thread th = new Thread(openPyrchBill);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void openPyrchBill()
        {
            Application.Run(new FrmPyrchBill());
        }

        private void btnSearchForName_Click(object sender, EventArgs e)
        {
            try
            {
                if (ComBoxNameOfCust.Text != "")
                {
                    dataGridView1.DataSource = db.PurchBills.Where(x => x.Suppler.Name.Contains(ComBoxNameOfCust.Text)).OrderByDescending(x => x.id).Select(x => new { x.id, x.DateTime, x.Suppler.Name, x.TotalOfBill, x.Discount, x.TotalAfterDiscount, x.User.UserName, x.Notes }).ToList();
                   
                    dataGridView1.Columns[0].HeaderText = "رقم الفاتورة";
                    dataGridView1.Columns[1].HeaderText = "التاريخ";
                    dataGridView1.Columns[2].HeaderText = "إسم المورد";
                    dataGridView1.Columns[3].HeaderText = "الإجمالى الكلى";
                    dataGridView1.Columns[4].HeaderText = "الخصم";
                    dataGridView1.Columns[5].HeaderText = "الاجمالى بعد الخصم";
                    dataGridView1.Columns[6].HeaderText = "إسم المستخدم";
                    dataGridView1.Columns[7].HeaderText = "ملاحظات";
                }
                else
                    MessageBox.Show("هذا الاسم غير موجود");

            }
            catch
            {
                MessageBox.Show("لم يتم التحميل بنجاح");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var bill = db.PurchBills.SingleOrDefault(x => x.id == id);
                if (bill != null && bill.id != 1)
                {
                    dateTimePicker1.Value = DateTime.Parse(bill.DateTime.ToString());
                    txtNoOfBill.Text = bill.id.ToString();
                    ComBoxNameOfCust.Text = bill.Suppler.Name;
                    txtTotalBill.Text = bill.TotalOfBill.ToString();
                    txtDiscount.Text = bill.Discount.ToString();
                    txtTotalAfterDiscount.Text = bill.TotalAfterDiscount.ToString();
                    dataGridView2.DataSource = bill.PurchBillDetails.Select(x => new { x.ItemName, x.Quantity, x.Price, x.TotalSub }).ToList();
                    dataGridView2.Columns[0].HeaderText = "الصنف";
                    dataGridView2.Columns[1].HeaderText = "العدد";
                    dataGridView2.Columns[2].HeaderText = "السعر";
                    dataGridView2.Columns[3].HeaderText = "الاجمالى الفرعى";
                }
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = db.PurchBills.Where(x => x.id != 1).OrderByDescending(x => x.id).Select(x => new { x.id, x.DateTime, x.Suppler.Name, x.TotalOfBill, x.Discount, x.TotalAfterDiscount, x.User.UserName, x.Notes }).ToList();

                dataGridView1.Columns[0].HeaderText = "رقم الفاتورة";
                dataGridView1.Columns[1].HeaderText = "التاريخ";
                dataGridView1.Columns[2].HeaderText = "إسم المورد";
                dataGridView1.Columns[3].HeaderText = "الإجمالى الكلى";
                dataGridView1.Columns[4].HeaderText = "الخصم";
                dataGridView1.Columns[5].HeaderText = "الاجمالى بعد الخصم";
                dataGridView1.Columns[6].HeaderText = "إسم المستخدم";
                dataGridView1.Columns[7].HeaderText = "ملاحظات";
            }
            catch
            {
                MessageBox.Show("لم يتم التحميل بنجاح");
            }
        }

        private void FrmListBillPurch_Load(object sender, EventArgs e)
        { 
            try
            {
                ComBoxNameOfCust.DataSource = db.Supplers.Where(x => x.isActive == true).ToList();
                ComBoxNameOfCust.ValueMember = "id";
                ComBoxNameOfCust.DisplayMember = "Name";
            }
        catch { }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                var r = MessageBox.Show("هل تريد الحذف", "تأكيد الحذف", MessageBoxButtons.OKCancel);
                if (r == DialogResult.OK)
                {
                    var result = db.PurchBills.Find(int.Parse(txtNoOfBill.Text));
                    var Bill = result.PurchBillDetails.ToList();
                    for (int i = 0; i < Bill.Count; i++)
                        db.PurchBillDetails.Remove(Bill[i]);
                    db.PurchBills.Remove(result);
                    db.SaveChanges();
                    dataGridView1.DataSource = db.PurchBills.Where(x=>x.id!=1).OrderByDescending(x => x.id).Select(x => new { x.id, x.DateTime, x.Suppler.Name, x.TotalOfBill, x.Discount, x.TotalAfterDiscount, x.User.UserName, x.Notes }).ToList();
                    MessageBox.Show("تم الحذف بنجاح");
                }
            }
            catch
            {
                MessageBox.Show("لم يتم الحذف بنجاح");
            }
        }

        private void txtTotalBill_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
