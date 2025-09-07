namespace SelesApp.Screens
{
    partial class FrmAddProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddProduct));
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtProdNotes = new System.Windows.Forms.TextBox();
            this.txtProdQuantity = new System.Windows.Forms.TextBox();
            this.txtProdSellingPrice = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtProdName = new System.Windows.Forms.TextBox();
            this.txtProdParcode = new System.Windows.Forms.TextBox();
            this.txtAddPart = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtProdPurchPrice = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new System.Drawing.Font("Microsoft Uighur", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.PaleGoldenrod;
            label1.Location = new System.Drawing.Point(756, 526);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(117, 38);
            label1.TabIndex = 78;
            label1.Text = "تحديد القسم";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = System.Drawing.Color.Transparent;
            label13.Font = new System.Drawing.Font("Microsoft Uighur", 28F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label13.ForeColor = System.Drawing.Color.SeaShell;
            label13.Location = new System.Drawing.Point(324, 93);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(185, 66);
            label13.TabIndex = 74;
            label13.Text = "إضافة منتج";
            label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = System.Drawing.Color.Transparent;
            label12.Font = new System.Drawing.Font("Microsoft Uighur", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label12.ForeColor = System.Drawing.Color.PaleGoldenrod;
            label12.Location = new System.Drawing.Point(779, 91);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(77, 38);
            label12.TabIndex = 70;
            label12.Text = "الباركود";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = System.Drawing.Color.Transparent;
            label11.Font = new System.Drawing.Font("Microsoft Uighur", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label11.ForeColor = System.Drawing.Color.PaleGoldenrod;
            label11.Location = new System.Drawing.Point(774, 180);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(94, 38);
            label11.TabIndex = 69;
            label11.Text = "سعر البيع";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = System.Drawing.Color.Transparent;
            label10.Font = new System.Drawing.Font("Microsoft Uighur", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.ForeColor = System.Drawing.Color.PaleGoldenrod;
            label10.Location = new System.Drawing.Point(781, 272);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(67, 38);
            label10.TabIndex = 68;
            label10.Text = "الكمية";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = System.Drawing.Color.Transparent;
            label9.Font = new System.Drawing.Font("Microsoft Uighur", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.ForeColor = System.Drawing.Color.PaleGoldenrod;
            label9.Location = new System.Drawing.Point(769, 316);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(93, 38);
            label9.TabIndex = 67;
            label9.Text = "ملاحظات";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = System.Drawing.Color.Transparent;
            label8.Font = new System.Drawing.Font("Microsoft Uighur", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.ForeColor = System.Drawing.Color.PaleGoldenrod;
            label8.Location = new System.Drawing.Point(719, 406);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(113, 38);
            label8.TabIndex = 66;
            label8.Text = "صورة المنتج";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Font = new System.Drawing.Font("Microsoft Uighur", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.ForeColor = System.Drawing.Color.PaleGoldenrod;
            label4.Location = new System.Drawing.Point(769, 137);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(102, 38);
            label4.TabIndex = 64;
            label4.Text = "اسم المنتج";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Font = new System.Drawing.Font("Microsoft Uighur", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.ForeColor = System.Drawing.Color.PaleGoldenrod;
            label2.Location = new System.Drawing.Point(321, 505);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(105, 38);
            label2.TabIndex = 80;
            label2.Text = "إضافة قسم";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Font = new System.Drawing.Font("Microsoft Uighur", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.ForeColor = System.Drawing.Color.PaleGoldenrod;
            label3.Location = new System.Drawing.Point(399, 356);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(57, 38);
            label3.TabIndex = 82;
            label3.Text = "حفظ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Font = new System.Drawing.Font("Microsoft Uighur", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.ForeColor = System.Drawing.Color.PaleGoldenrod;
            label5.Location = new System.Drawing.Point(767, 228);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(104, 38);
            label5.TabIndex = 83;
            label5.Text = "سعر الشراء";
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataMember = "Category";
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(544, 529);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(196, 28);
            this.comboBox1.TabIndex = 77;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Firebrick;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(112, 33);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(165, 43);
            this.button5.TabIndex = 76;
            this.button5.Text = "الشاشة الرئيسية";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Firebrick;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(112, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 48);
            this.button1.TabIndex = 75;
            this.button1.Text = "عرض جميع المنتجات";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtProdNotes
            // 
            this.txtProdNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProdNotes.Location = new System.Drawing.Point(522, 323);
            this.txtProdNotes.Multiline = true;
            this.txtProdNotes.Name = "txtProdNotes";
            this.txtProdNotes.Size = new System.Drawing.Size(236, 27);
            this.txtProdNotes.TabIndex = 73;
            this.txtProdNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProdNotes.UseSystemPasswordChar = true;
            // 
            // txtProdQuantity
            // 
            this.txtProdQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProdQuantity.Location = new System.Drawing.Point(522, 278);
            this.txtProdQuantity.Multiline = true;
            this.txtProdQuantity.Name = "txtProdQuantity";
            this.txtProdQuantity.Size = new System.Drawing.Size(236, 28);
            this.txtProdQuantity.TabIndex = 72;
            this.txtProdQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProdQuantity.UseSystemPasswordChar = true;
            this.txtProdQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProdQuantity_KeyPress);
            // 
            // txtProdSellingPrice
            // 
            this.txtProdSellingPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProdSellingPrice.Location = new System.Drawing.Point(522, 186);
            this.txtProdSellingPrice.Multiline = true;
            this.txtProdSellingPrice.Name = "txtProdSellingPrice";
            this.txtProdSellingPrice.Size = new System.Drawing.Size(236, 28);
            this.txtProdSellingPrice.TabIndex = 71;
            this.txtProdSellingPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProdSellingPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProdPrice_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(577, 363);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(132, 131);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 65;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogin.BackgroundImage")));
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnLogin.Location = new System.Drawing.Point(386, 255);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(86, 95);
            this.btnLogin.TabIndex = 63;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtProdName
            // 
            this.txtProdName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProdName.Location = new System.Drawing.Point(522, 143);
            this.txtProdName.Multiline = true;
            this.txtProdName.Name = "txtProdName";
            this.txtProdName.Size = new System.Drawing.Size(236, 28);
            this.txtProdName.TabIndex = 62;
            this.txtProdName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProdName.UseSystemPasswordChar = true;
            // 
            // txtProdParcode
            // 
            this.txtProdParcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProdParcode.Location = new System.Drawing.Point(522, 97);
            this.txtProdParcode.Multiline = true;
            this.txtProdParcode.Name = "txtProdParcode";
            this.txtProdParcode.Size = new System.Drawing.Size(236, 28);
            this.txtProdParcode.TabIndex = 61;
            this.txtProdParcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProdParcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProdParcode_KeyPress);
            // 
            // txtAddPart
            // 
            this.txtAddPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddPart.Location = new System.Drawing.Point(155, 508);
            this.txtAddPart.Multiline = true;
            this.txtAddPart.Name = "txtAddPart";
            this.txtAddPart.Size = new System.Drawing.Size(157, 28);
            this.txtAddPart.TabIndex = 79;
            this.txtAddPart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAddPart.UseSystemPasswordChar = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Cornsilk;
            this.button2.Location = new System.Drawing.Point(114, 502);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 39);
            this.button2.TabIndex = 81;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtProdPurchPrice
            // 
            this.txtProdPurchPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProdPurchPrice.Location = new System.Drawing.Point(522, 232);
            this.txtProdPurchPrice.Multiline = true;
            this.txtProdPurchPrice.Name = "txtProdPurchPrice";
            this.txtProdPurchPrice.Size = new System.Drawing.Size(236, 28);
            this.txtProdPurchPrice.TabIndex = 84;
            this.txtProdPurchPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmAddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(978, 644);
            this.Controls.Add(this.txtProdPurchPrice);
            this.Controls.Add(label5);
            this.Controls.Add(label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(label2);
            this.Controls.Add(this.txtAddPart);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button1);
            this.Controls.Add(label1);
            this.Controls.Add(label13);
            this.Controls.Add(this.txtProdNotes);
            this.Controls.Add(this.txtProdQuantity);
            this.Controls.Add(this.txtProdSellingPrice);
            this.Controls.Add(label12);
            this.Controls.Add(label11);
            this.Controls.Add(label10);
            this.Controls.Add(label9);
            this.Controls.Add(label8);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(label4);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtProdName);
            this.Controls.Add(this.txtProdParcode);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmAddProduct";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة منتج جديد";
            this.Load += new System.EventHandler(this.FrmAddProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource categoryBindingSource;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtProdNotes;
        private System.Windows.Forms.TextBox txtProdQuantity;
        private System.Windows.Forms.TextBox txtProdSellingPrice;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtProdName;
        private System.Windows.Forms.TextBox txtProdParcode;
        private System.Windows.Forms.TextBox txtAddPart;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtProdPurchPrice;
    }
}