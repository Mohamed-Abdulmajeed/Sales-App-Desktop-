using SelesApp.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelesApp.Screens
{
    public partial class FrmSelesBay : Form
    {
        SelesAppEntities db = new SelesAppEntities();
        List<AllProduct> products;
        int currentIndex = 0;
        string txtNoOfInvoice = "000";
        bool isSaved = false;
        public FrmSelesBay()
        {
            InitializeComponent();
            try
            {
                comboBox1.DataSource = db.Customers.Where(x => x.isActive == true).ToList();
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "Name";
                cbxItems.DataSource = db.AllProducts.ToList();
                cbxItems.ValueMember = "id";
                cbxItems.DisplayMember = "Name";
                products = db.AllProducts.ToList();
                txtPrice.Text = products[0].SellingPrice.ToString();
            }
            catch { }
        }
       
        private void FrmSelesBay_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox1.DataSource = db.Customers.Where(x => x.isActive == true).ToList();
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "Name";
                cbxItems.DataSource = db.AllProducts.ToList();
                cbxItems.ValueMember = "id";
                cbxItems.DisplayMember = "Name";
                products = db.AllProducts.ToList();
                txtPrice.Text = products[0].SellingPrice.ToString();
                for (int i = 0; i < products.Count(); i++)
                {
                    if (products[i].Image != null)
                    {
                        try{
                        imageList1.Images.Add(Image.FromFile(products[i].Image));
                        }
                        catch
                        {
                            Bitmap btm = new Bitmap(100, 100);
                            imageList1.Images.Add(btm);
                        }
                    }
                    else
                    {
                        Bitmap btm = new Bitmap(100, 100);
                        imageList1.Images.Add(btm);
                    }
                    ListViewItem item = new ListViewItem();
                    item.Text = products[i].Name;
                    item.ImageIndex = i;
                    item.Tag = products[i];
                    listView1.Items.Add(item);

                }
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

        private void listView1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    var product = (AllProduct)listView1.SelectedItems[0].Tag;
                    cbxItems.Text = product.Name.ToString();
                    txtPrice.Text = product.SellingPrice.ToString();
                }
            }catch{}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count != 30)
                {
                    if (txtPrice.Text != "")
                    {
                        string item = cbxItems.Text;
                        int qty = Convert.ToInt32(textBox2.Text);
                        int price = Convert.ToInt32(txtPrice.Text);
                        int subTotal = qty * price;
                        object[] row = { item, qty, price, subTotal };
                        bool isfind = false;
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            if (dataGridView1.Rows[i].Cells["ColItem"].Value.ToString() == item)
                            {
                                var r = MessageBox.Show("هذا الصنف موجود مسبقا هل تريد زيادة الكمية؟", "تأكيد التعديل", MessageBoxButtons.OKCancel);

                                if (r == DialogResult.OK)
                                {

                                    dataGridView1.Rows[i].Cells["ColQty"].Value = int.Parse(dataGridView1.Rows[i].Cells["ColQty"].Value.ToString()) + qty;
                                    dataGridView1.Rows[i].Cells["ColSubTotal"].Value = int.Parse(dataGridView1.Rows[i].Cells["ColQty"].Value.ToString()) * int.Parse(dataGridView1.Rows[i].Cells["ColPrice"].Value.ToString());
                                    txtTotalPrice.Text = Convert.ToInt32(txtTotalPrice.Text) + subTotal + "";
                                    txtTotalOfBill.Text = Convert.ToInt32(txtTotalOfBill.Text) + subTotal + "";

                                    txtTotalAfterDiscount.Text = int.Parse(txtTotalOfBill.Text) - int.Parse(txtDiscount.Text) + "";
                                    MessageBox.Show("تم تعديل الكمية بنجاح");
                                    return;
                                }
                                else
                                    isfind = true;
                            }

                        }
                        if (!isfind)
                        {
                            dataGridView1.Rows.Add(row);
                            txtTotalOfBill.Text = Convert.ToInt32(txtTotalOfBill.Text) + subTotal + "";
                            txtTotalPrice.Text = Convert.ToInt32(txtTotalPrice.Text) + subTotal + "";
                            txtTotalAfterDiscount.Text = int.Parse(txtTotalOfBill.Text) - int.Parse(txtDiscount.Text) + "";
                        }
                        cbxItems.Focus();
                    }
                    else MessageBox.Show("ادخل السعر");
                }
                else
                    MessageBox.Show(" لا يمكن اضافة بند لقد وصلت للحد الاقصى");
            }
            catch { MessageBox.Show("لم يتم اضافة البند"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var r = MessageBox.Show("هل تريد التعديل", "تأكيد التعديل", MessageBoxButtons.OKCancel);
                bool isFind = false;
                if (r == DialogResult.OK)
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (dataGridView1.Rows[i].Cells["ColItem"].Value.ToString() == cbxItems.Text && dataGridView1.CurrentRow.Cells[0].Value.ToString() != cbxItems.Text)
                        {
                            MessageBox.Show("لا يمكن التعديل الى هذا الاسم لانة موجود مسبقا");
                            isFind = true;
                        }
                    }
                    if (!isFind)
                    {
                        int subBefore = int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                        dataGridView1.CurrentRow.Cells[0].Value = cbxItems.Text;
                        dataGridView1.CurrentRow.Cells[1].Value = textBox2.Text;
                        dataGridView1.CurrentRow.Cells[2].Value = txtPrice.Text;
                        dataGridView1.CurrentRow.Cells[3].Value = int.Parse(textBox2.Text) * int.Parse(txtPrice.Text);
                        txtTotalPrice.Text = Convert.ToInt32(txtTotalPrice.Text) + (int.Parse(textBox2.Text) * int.Parse(txtPrice.Text) - subBefore) + "";
                        txtTotalOfBill.Text = Convert.ToInt32(txtTotalOfBill.Text) + (int.Parse(textBox2.Text) * int.Parse(txtPrice.Text) - subBefore) + "";

                        txtTotalAfterDiscount.Text = int.Parse(txtTotalOfBill.Text) - int.Parse(txtDiscount.Text) + "";
                        MessageBox.Show("تم التعديل بنجاح");
                    }
                }
            }
            catch
            {
                MessageBox.Show("لم يتم التعديل بنجاح");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var r = MessageBox.Show("هل تريد الحذف", "تأكيد الحذف", MessageBoxButtons.OKCancel);
                if (r == DialogResult.OK)
                {
                    txtTotalPrice.Text = Convert.ToInt32(txtTotalPrice.Text) - int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString()) + "";
                    txtTotalOfBill.Text = Convert.ToInt32(txtTotalOfBill.Text) - int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString()) + "";

                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                    txtTotalAfterDiscount.Text = int.Parse(txtTotalOfBill.Text) - int.Parse(txtDiscount.Text) + "";
                    MessageBox.Show("تم الحذف بنجاح");
                }
            }
            catch
            {
                MessageBox.Show("لم يتم الحذف بنجاح");
            }
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNotesOfPill.Text = "";
            dataGridView1.Rows.Clear();
            txtTotalPrice.Text = "0";
            txtTotalOfBill.Text = "0";

            txtDiscount.Text = "0";
            txtTotalAfterDiscount.Text = "0";
            txtTotalDebt.Text = "0";

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            try
            {

                cbxItems.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtPrice.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            }
            catch { }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTotalPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtTotalAfterDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtTotalAfterPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (isSaved == false)
                {
                    var r = MessageBox.Show("هل تريد حفظ الفاتورة", "تأكيد الحفظ", MessageBoxButtons.OKCancel);
                    if (r == DialogResult.OK)
                    {
                        int id = int.Parse(comboBox1.SelectedValue.ToString());
                        string name = comboBox1.Text;
                        var customer = db.Customers.SingleOrDefault(x => x.id == id);
                        if (int.Parse(comboBox1.SelectedValue.ToString()) != customer.id)
                        {
                            Customer cust = new Customer();
                            cust.Name = name;
                            db.Customers.Add(cust);
                            db.SaveChanges();
                            comboBox1.DataSource = db.Customers.ToList();
                            comboBox1.Text = name;
                            customer.id = int.Parse(comboBox1.SelectedValue.ToString());
                        }
                        var listPill = db.SelesBills.ToList();
                        int num = listPill.Count();

                        txtNoOfInvoice = listPill[num - 1].id + 1 + "";


                        SelesBill selBill = new SelesBill()
                        {

                            id = listPill[num - 1].id + 1,
                            DateTime = dateTimePicker1.Value.Date,
                            Discount = decimal.Parse(txtDiscount.Text),
                            Notes = txtNotesOfPill.Text,
                            CustomerID = customer.id,
                            TotalOfBill = decimal.Parse(txtTotalOfBill.Text),
                            TotalPrice = decimal.Parse(txtTotalPrice.Text),
                            TotalAfterDiscount = decimal.Parse(txtTotalAfterDiscount.Text),
                            UserID = SelesApp.Users.id,
                        };
                        List<SelesBillDetail> list = new List<SelesBillDetail>();

                        var listDetails = db.SelesBillDetails.ToList();
                        AllProduct item = new AllProduct();
                        int num2 = listDetails.Count();
                        int txtNoOfCell = listDetails[num2 - 1].id + 1;


                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            txtNoOfCell = txtNoOfCell + i;

                            list.Add(new SelesBillDetail
                            {
                                id = txtNoOfCell,
                                Price = decimal.Parse(dataGridView1.Rows[i].Cells["ColPrice"].Value.ToString()),
                                Quantity = int.Parse(dataGridView1.Rows[i].Cells["ColQty"].Value.ToString()),

                                TotalSub = decimal.Parse(dataGridView1.Rows[i].Cells["ColSubTotal"].Value.ToString()),
                                ItemName = dataGridView1.Rows[i].Cells["ColItem"].Value.ToString(),
                            });
                            decrementQuantity(dataGridView1.Rows[i].Cells["ColItem"].Value.ToString(), int.Parse(dataGridView1.Rows[i].Cells["ColQty"].Value.ToString()));
                        }


                        selBill.SelesBillDetails = list;
                        db.SelesBills.Add(selBill);
                        db.SaveChanges();


                        MessageBox.Show("تم الحفظ بنجاح");
                        isSaved = true;
                    }
                }
                    ((Form)printPreviewDialog1).StartPosition = FormStartPosition.CenterScreen;
                    ((Form)printPreviewDialog1).Height = 650;
                    ((Form)printPreviewDialog1).Width = 500;

                    if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                    {
                        printDocument1.Print();
                    }
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox2.Text) < 1000)
            {
                textBox2.Text = int.Parse(textBox2.Text) + 1 + "";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox2.Text) > 1)
            {
                textBox2.Text = int.Parse(textBox2.Text) - 1 + "";
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {

            if (txtDiscount.Text == "")
                txtDiscount.Text = "0";
            if (txtDiscount.Text != "")
            {
                txtTotalAfterDiscount.Text = int.Parse(txtTotalOfBill.Text) - int.Parse(txtDiscount.Text) + "";

                txtTotalPrice.Text = int.Parse(txtTotalAfterDiscount.Text) + int.Parse(txtTotalDebt.Text) + "";
            }
        }
        private void txtBay_TextChanged(object sender, EventArgs e)
        {
        }
        private void cbxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var product = db.AllProducts.Where(x => x.Name == cbxItems.Text).ToList();
                txtPrice.Text = product[0].SellingPrice.ToString();
            }
            catch { }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
               if (txtTotalDebt.Text == "")
                    txtTotalDebt.Text = "0";
                if (txtTotalDebt.Text != "")
                {
                    txtTotalAfterDiscount.Text = int.Parse(txtTotalOfBill.Text) - int.Parse(txtDiscount.Text) + "";
                    txtTotalPrice.Text = int.Parse(txtTotalAfterDiscount.Text) + int.Parse(txtTotalDebt.Text) + "";
                }
            }
            catch { }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtCty_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void txtTotalAfterPay_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            try
            {
                int id = int.Parse(comboBox1.SelectedValue.ToString());
                string name = comboBox1.Text;
                var customer = db.Customers.SingleOrDefault(x => x.id == id);
                if (int.Parse(comboBox1.SelectedValue.ToString()) != customer.id)
                  {
                    Customer cust = new Customer();
                    cust.Name = name;
                    db.Customers.Add(cust);
                    db.SaveChanges();
                    comboBox1.DataSource = db.Customers.ToList();
                    comboBox1.Text = name;
                    customer.id = int.Parse(comboBox1.SelectedValue.ToString());
                  }
                var listPill = db.SelesBills.ToList();
                int num = listPill.Count();
                
                    txtNoOfInvoice = listPill[num - 1].id + 1 + "";
                

                SelesBill selBill = new SelesBill()
                {
                    
                    id= listPill[num-1].id + 1,
                    DateTime = dateTimePicker1.Value.Date,
                    Discount = decimal.Parse(txtDiscount.Text),
                    Notes = txtNotesOfPill.Text,
                    CustomerID = customer.id,
                    TotalOfBill = decimal.Parse(txtTotalOfBill.Text),
                    TotalPrice = decimal.Parse(txtTotalPrice.Text),
                    TotalAfterDiscount = decimal.Parse(txtTotalAfterDiscount.Text),
                    UserID = SelesApp.Users.id,
                };
                List<SelesBillDetail> list = new List<SelesBillDetail>();

                var listDetails = db.SelesBillDetails.ToList();
                AllProduct item=new AllProduct();
                int num2 = listDetails.Count();
                int txtNoOfCell = listDetails[num2 - 1].id + 1;


                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    txtNoOfCell = txtNoOfCell + i;

                    list.Add(new SelesBillDetail
                    {
                        id = txtNoOfCell,
                        Price = decimal.Parse(dataGridView1.Rows[i].Cells["ColPrice"].Value.ToString()),
                        Quantity = int.Parse(dataGridView1.Rows[i].Cells["ColQty"].Value.ToString()),
                        
                        TotalSub= decimal.Parse(dataGridView1.Rows[i].Cells["ColSubTotal"].Value.ToString()),
                        ItemName = dataGridView1.Rows[i].Cells["ColItem"].Value.ToString(),
                   });
                    decrementQuantity(dataGridView1.Rows[i].Cells["ColItem"].Value.ToString(), int.Parse(dataGridView1.Rows[i].Cells["ColQty"].Value.ToString()));
                }

                
                selBill.SelesBillDetails = list;
                db.SelesBills.Add(selBill);
                db.SaveChanges();


                MessageBox.Show("تم الحفظ بنجاح");
                isSaved = true;
            }
            catch
            {
                MessageBox.Show("لم يتم الحفظ");
            }
        }
        public void decrementQuantity(string Name, int Quantity)
        {
            try
            {
                var result = db.AllProducts.SingleOrDefault(x => x.Name == Name);
                if(result!=null)
                   result.Quantity = result.Quantity - Quantity;
                db.SaveChanges();
            }
            catch { }
        }
        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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

                string date = DateTime.Now.ToString("yyyy/MM/dd - ") + DateTime.Now.ToString("hh:mm ") + tt;
                string strInvoice = "فاتورة";


                string strNO = "  رقم الفاتورة  " + " : " + txtNoOfInvoice;
                string strDate = "  التاريخ  " + " : " + date;
                string strName = "  اسم العميل  " + " : " + comboBox1.Text;
                SizeF fontSizeNO = e.Graphics.MeasureString(strNO, font12);
                SizeF fontSizeDate = e.Graphics.MeasureString(strDate, font10);
                SizeF fontSizeName = e.Graphics.MeasureString(strName, font10);
                SizeF fontSizeInvoice = e.Graphics.MeasureString(strInvoice, font22);
                SizeF fontSizeNameOfPlace = e.Graphics.MeasureString(strNameOfPlace, font18);
                SizeF fontSizePhone = e.Graphics.MeasureString(strPhone, font12);

                if (currentIndex == 0)
                {
                    e.Graphics.DrawImage(Properties.Resources.logoFatora1, 5, 2, 260, 65);
                    marginH +=2+ fontSizeName.Height ;
                    e.Graphics.DrawString(strNameOfPlace, font18, Brushes.DarkRed, (e.PageBounds.Width - fontSizeNameOfPlace.Width - marginW), marginH += 2 + fontSizeNameOfPlace.Height);
                    marginH += 3;
                    if (strPhone !="")
                        e.Graphics.DrawString(strPhone, font12, Brushes.DarkRed, (e.PageBounds.Width - fontSizePhone.Width - marginW), marginH += 5 + fontSizePhone.Height);

                    e.Graphics.DrawString(strNO, font10, Brushes.Black, (e.PageBounds.Width - fontSizeNO.Width - marginW), marginH += 5 + fontSizeNO.Height);
                    e.Graphics.DrawString(strName, font10, Brushes.Black, (e.PageBounds.Width - fontSizeName.Width - marginW), marginH += 5 + fontSizeName.Height);
                    e.Graphics.DrawString(strDate, font10, Brushes.Black, (e.PageBounds.Width - fontSizeDate.Width - marginW), marginH += 5 + fontSizeDate.Height);
                }
                marginH += fontSizeName.Height + 5;

                int yOfRectangle = dataGridView1.Rows.Count * 25 + 25;

                if (dataGridView1.Rows.Count - currentIndex < 30)
                    yOfRectangle = (dataGridView1.Rows.Count * 25 + 25) - (currentIndex * 25);
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
                e.Graphics.DrawString(" العدد ", font10, Brushes.Black, e.PageBounds.Width - marginW - col2Width-3, marginH - 18);
                e.Graphics.DrawLine(Pens.Green, e.PageBounds.Width - 2 * marginW - col2Width, marginH - 25, e.PageBounds.Width - 2 * marginW - col2Width, marginH + yOfRectangle - 25);
                e.Graphics.DrawString(" السعر ", font10, Brushes.Black, e.PageBounds.Width - marginW - col3Width-3, marginH - 18);
                e.Graphics.DrawLine(Pens.Green, e.PageBounds.Width - 2 * marginW - col3Width, marginH - 25, e.PageBounds.Width - 2 * marginW - col3Width, marginH + yOfRectangle - 25);
                e.Graphics.DrawString(" اجمالى ", font10, Brushes.Black, e.PageBounds.Width - 2 * marginW - col4Width-3, marginH - 18);

                int range = dataGridView1.Rows.Count;

                for (int x = currentIndex; x < dataGridView1.Rows.Count; x++)
                {
                    SizeF fontSizeNameOfType = e.Graphics.MeasureString(dataGridView1.Rows[x].Cells[0].Value.ToString(), font8);
                    e.Graphics.DrawString(dataGridView1.Rows[x].Cells[0].Value.ToString(), font8, Brushes.Black, e.PageBounds.Width - fontSizeNameOfType.Width - marginW * 1, marginH + 5);
                    e.Graphics.DrawString(dataGridView1.Rows[x].Cells[1].Value.ToString(), font8, Brushes.Black, e.PageBounds.Width - marginW - col2Width, marginH + 3);
                    e.Graphics.DrawString(dataGridView1.Rows[x].Cells[2].Value.ToString(), font8, Brushes.Black, e.PageBounds.Width - marginW - col3Width, marginH + 3);
                    e.Graphics.DrawString(dataGridView1.Rows[x].Cells[3].Value.ToString(), font8, Brushes.Black, e.PageBounds.Width - marginW - col4Width, marginH + 3);
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
                string strTotalPill = "  الاجمالى  " + " : " + txtTotalOfBill.Text;
                string strTotal = "  الاجمالى + المستحقات السابقة " + " : " + txtTotalPrice.Text;
                string strAddBack = "  المبالغ المستحقة السابقة  " + " : " + txtTotalDebt.Text;
                string strDiscount = "  الخصم  " + " : " + txtDiscount.Text;
                string strTotalAfterDiscount = "  الاجمالى بعد الخصم  " + " : " + txtTotalAfterDiscount.Text;

                List<string> arr = new List<string> { };
                arr.Add(strTotalPill);
                if (txtDiscount.Text != "0")
                {
                    arr.Add(strDiscount);
                    arr.Add(strTotalAfterDiscount);
                }
                if (txtTotalDebt.Text != "0")
                {
                    arr.Add(strAddBack);
                    arr.Add(strTotal);
                }
               
                
                if (currentIndex >= dataGridView1.Rows.Count)
                {
                    for (int x = 0; x < arr.Count; x++)
                    {
                        SizeF fontSizeNameOfType = e.Graphics.MeasureString(arr[x], font10);
                        e.Graphics.DrawString(arr[x], font10, Brushes.Black, e.PageBounds.Width - fontSizeNameOfType.Width - marginW * 4, marginH + 5);
                        e.Graphics.DrawLine(Pens.Green, marginW, marginH, e.PageBounds.Width - marginW, marginH);

                        marginH += colHeight;
                    }
                    e.Graphics.DrawLine(Pens.Green, marginW, marginH, e.PageBounds.Width - marginW, marginH);
                    currentIndex = 0;
                    isSaved = false;
                }
            }
            catch { }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                textBox2.Text = "1";
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               
                var customer = db.Customers.SingleOrDefault(x=>x.Name==comboBox1.Text);
                if (customer == null)
                    return;
                else if (comboBox1.Text==customer.Name )
                   txtTotalDebt.Text = customer.TotalDebt.ToString();

            }
            catch { }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {

            if (txtTotalOfBill.Text != ""&& comboBox1.Text != "فاتورة نقدى")
            {
                var r = MessageBox.Show("هل تريد الاضافة", "تأكيد الاضافة", MessageBoxButtons.OKCancel);
                if (r == DialogResult.OK)
                {
                    string date = DateTime.Now.ToString("yyyy/MM/dd");
                    var customer = db.Customers.SingleOrDefault(x => x.Name == comboBox1.Text);
                    db.CustomerDebts.Add(
                        new CustomerDebt
                        {
                            DateTime = DateTime.Parse(date),
                            CustomerID = customer.id,
                            KindOfOP = "أعطيت",
                            Amount = decimal.Parse(txtTotalOfBill.Text),
                            TotalResult = decimal.Parse(txtTotalOfBill.Text) + decimal.Parse(txtTotalDebt.Text)
                        });
                    customer.TotalDebt = decimal.Parse(txtTotalOfBill.Text) + decimal.Parse(txtTotalDebt.Text);
                    db.SaveChanges();
                    txtTotalDebt.Text = decimal.Parse(txtTotalOfBill.Text) + decimal.Parse(txtTotalDebt.Text) + "";
                    MessageBox.Show("تم اضافة المبلغ بنجاح");
                }
            }
            else
                MessageBox.Show("لايمكن الاضافة");
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
