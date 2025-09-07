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
    public partial class FrmPyrchBill : Form
    {
        SelesAppEntities db = new SelesAppEntities();
        List<AllProduct> products;
        public FrmPyrchBill()
        {
            InitializeComponent();
            try
            {
                comboBox1.DataSource = db.Supplers.Where(x => x.isActive == true).ToList();
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

        private void FrmPyrchBill_Load(object sender, EventArgs e)
        {
            try
            {

                comboBox1.DataSource = db.Supplers.Where(x => x.isActive == true).ToList();
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
                {try{

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

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text == "")
                txtDiscount.Text = "0";
            if (txtDiscount.Text != "")
            {
                txtTotalAfterDiscount.Text = int.Parse(txtTotalBill.Text) - int.Parse(txtDiscount.Text) + "";
            }
        }

        private void txtBay_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {

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

        private void txtCty_TextChanged(object sender, EventArgs e)
        {
            if (txtCty.Text == "")
                txtCty.Text = "1";
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (int.Parse(txtCty.Text) < 1000)
            {
                txtCty.Text = int.Parse(txtCty.Text) + 1 + "";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtCty.Text) > 1)
            {
                txtCty.Text = int.Parse(txtCty.Text) - 1 + "";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPrice.Text != "")
                {
                    string item = cbxItems.Text;
                    int qty = Convert.ToInt32(txtCty.Text);
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
                                txtTotalBill.Text = Convert.ToInt32(txtTotalBill.Text) + subTotal + "";
                                txtTotalAfterDiscount.Text = int.Parse(txtTotalBill.Text) - int.Parse(txtDiscount.Text) + "";
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
                        txtTotalBill.Text = Convert.ToInt32(txtTotalBill.Text) + subTotal + "";
                        txtTotalAfterDiscount.Text = int.Parse(txtTotalBill.Text) - int.Parse(txtDiscount.Text) + "";
                    }
                    cbxItems.Focus();
                }
                else MessageBox.Show("ادخل السعر");
            }
            catch
            {
                MessageBox.Show("لم يتم الاضافة بنجاح");
            }
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
                        dataGridView1.CurrentRow.Cells[1].Value = txtCty.Text;
                        dataGridView1.CurrentRow.Cells[2].Value = txtPrice.Text;
                        dataGridView1.CurrentRow.Cells[3].Value = int.Parse(txtCty.Text) * int.Parse(txtPrice.Text);
                        txtTotalBill.Text = Convert.ToInt32(txtTotalBill.Text) + (int.Parse(txtCty.Text) * int.Parse(txtPrice.Text) - subBefore) + "";
                        txtTotalAfterDiscount.Text = int.Parse(txtTotalBill.Text) - int.Parse(txtDiscount.Text) + "";
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
                    txtTotalBill.Text = Convert.ToInt32(txtTotalBill.Text) - int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString()) + "";
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                    txtTotalAfterDiscount.Text = int.Parse(txtTotalBill.Text) - int.Parse(txtDiscount.Text) + "";
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
            txtTotalBill.Text = "0";
            txtDiscount.Text = "0";
            txtTotalAfterDiscount.Text = "0";
        }

        private void brnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(comboBox1.SelectedValue.ToString());
                string name = comboBox1.Text;
                var suppler = db.Supplers.SingleOrDefault(x => x.id == id);
                if (int.Parse(comboBox1.SelectedValue.ToString()) != suppler.id)
                {
                    Suppler cust = new Suppler();
                    cust.Name = name;
                    db.Supplers.Add(cust);
                    db.SaveChanges();
                    comboBox1.DataSource = db.Supplers.ToList();
                    comboBox1.Text = name;
                    suppler.id = int.Parse(comboBox1.SelectedValue.ToString());
                }
                var pyrchPill = db.PurchBills.ToList();
                int num = pyrchPill.Count();
                PurchBill PurchBill = new PurchBill()
                {
                    id = pyrchPill[num - 1].id + 1,
                    DateTime = dateTimePicker1.Value.Date,
                    Discount = decimal.Parse(txtDiscount.Text),
                    Notes = txtNotesOfPill.Text,
                    SupplerID = int.Parse(comboBox1.SelectedValue.ToString()),
                    TotalOfBill = decimal.Parse(txtTotalBill.Text),
                    TotalAfterDiscount = decimal.Parse(txtTotalAfterDiscount.Text),
                    UserID = SelesApp.Users.id,
                };
                List<PurchBillDetail> list = new List<PurchBillDetail>();
                var listDetails = db.PurchBillDetails.ToList();
                AllProduct item = new AllProduct();
                int num2 = listDetails.Count();
                int txtNoOfCell = listDetails[num2 - 1].id + 1;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    txtNoOfCell = txtNoOfCell + i;
                    list.Add(new PurchBillDetail
                    {
                        id = txtNoOfCell,
                        Price = decimal.Parse(dataGridView1.Rows[i].Cells["ColPrice"].Value.ToString()),
                        Quantity = int.Parse(dataGridView1.Rows[i].Cells["ColQty"].Value.ToString()),
                        TotalSub = decimal.Parse(dataGridView1.Rows[i].Cells["ColSubTotal"].Value.ToString()),
                        ItemName = dataGridView1.Rows[i].Cells["ColItem"].Value.ToString(),
                    });
                    incrementQuantity( dataGridView1.Rows[i].Cells["ColItem"].Value.ToString(),int.Parse(dataGridView1.Rows[i].Cells["ColQty"].Value.ToString()));
                }
                PurchBill.PurchBillDetails = list;
                db.PurchBills.Add(PurchBill);
                db.SaveChanges();
                MessageBox.Show("تم الحفظ بنجاح");
            }
            catch
            {
                MessageBox.Show("لم يتم الحفظ بنجاح");
            }
        }
        public void incrementQuantity(string Name, int Quantity)
        {
            try
            {
                var result = db.AllProducts.SingleOrDefault(x => x.Name == Name);
                if(result!=null)
                   result.Quantity = result.Quantity + Quantity;
                db.SaveChanges();
            }
            catch { }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

                cbxItems.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtCty.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtPrice.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            }
            catch { }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {
                var product = (AllProduct)listView1.SelectedItems[0].Tag;
                cbxItems.Text = product.Name.ToString();
                txtPrice.Text = product.PurchPrice.ToString();
            }
        }

        private void cbxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var product = db.AllProducts.Where(x => x.Name == cbxItems.Text).ToList();
                txtPrice.Text = product[0].PurchPrice.ToString();
            }
            catch { }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
       
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
