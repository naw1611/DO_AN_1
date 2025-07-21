namespace Do_An1.QuanTri.Danh_mục
{
    partial class FormThemThuoc
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
            cmbDanhMuc = new ComboBox();
            label7 = new Label();
            label1 = new Label();
            txtTen = new TextBox();
            txtDVT = new TextBox();
            label2 = new Label();
            nudGia = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            nudSL = new NumericUpDown();
            txtNSX = new TextBox();
            label5 = new Label();
            dtpHSD = new DateTimePicker();
            label6 = new Label();
            label8 = new Label();
            txtCachDung = new RichTextBox();
            btnLuu = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)nudGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSL).BeginInit();
            SuspendLayout();
            // 
            // cmbDanhMuc
            // 
            cmbDanhMuc.FormattingEnabled = true;
            cmbDanhMuc.Items.AddRange(new object[] { "Lễ tân", "Kế toán", "Quản lý", "Y tá", "Bảo vệ", "Kỹ thuật viên", "Quản lý kho" });
            cmbDanhMuc.Location = new Point(163, 34);
            cmbDanhMuc.Name = "cmbDanhMuc";
            cmbDanhMuc.Size = new Size(212, 23);
            cmbDanhMuc.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(24, 33);
            label7.Name = "label7";
            label7.Size = new Size(123, 20);
            label7.TabIndex = 16;
            label7.Text = "*Danh mục thuốc";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(52, 80);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 18;
            label1.Text = "*Tên thuốc";
            // 
            // txtTen
            // 
            txtTen.Location = new Point(163, 80);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(212, 23);
            txtTen.TabIndex = 19;
            // 
            // txtDVT
            // 
            txtDVT.Location = new Point(548, 80);
            txtDVT.Name = "txtDVT";
            txtDVT.Size = new Size(202, 23);
            txtDVT.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(437, 80);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 20;
            label2.Text = "*Đơn vị tính";
            // 
            // nudGia
            // 
            nudGia.Location = new Point(163, 126);
            nudGia.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudGia.Name = "nudGia";
            nudGia.Size = new Size(123, 23);
            nudGia.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(52, 129);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 23;
            label3.Text = "*Giá bán";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(437, 126);
            label4.Name = "label4";
            label4.Size = new Size(101, 20);
            label4.TabIndex = 25;
            label4.Text = "*Số lượng tồn";
            // 
            // nudSL
            // 
            nudSL.Location = new Point(548, 126);
            nudSL.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudSL.Name = "nudSL";
            nudSL.Size = new Size(123, 23);
            nudSL.TabIndex = 24;
            // 
            // txtNSX
            // 
            txtNSX.Location = new Point(548, 177);
            txtNSX.Name = "txtNSX";
            txtNSX.Size = new Size(202, 23);
            txtNSX.TabIndex = 27;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(437, 177);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 26;
            label5.Text = "*Nhà sản xuất";
            // 
            // dtpHSD
            // 
            dtpHSD.Location = new Point(163, 173);
            dtpHSD.Name = "dtpHSD";
            dtpHSD.Size = new Size(212, 23);
            dtpHSD.TabIndex = 28;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(32, 173);
            label6.Name = "label6";
            label6.Size = new Size(99, 20);
            label6.TabIndex = 29;
            label6.Text = "*Hạn sử dụng";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(32, 225);
            label8.Name = "label8";
            label8.Size = new Size(85, 20);
            label8.TabIndex = 30;
            label8.Text = "*Cách dùng";
            // 
            // txtCachDung
            // 
            txtCachDung.Location = new Point(163, 226);
            txtCachDung.Name = "txtCachDung";
            txtCachDung.Size = new Size(212, 96);
            txtCachDung.TabIndex = 31;
            txtCachDung.Text = "";
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.Blue;
            btnLuu.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLuu.ForeColor = Color.White;
            btnLuu.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnLuu.IconColor = Color.White;
            btnLuu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLuu.IconSize = 20;
            btnLuu.ImageAlign = ContentAlignment.MiddleLeft;
            btnLuu.Location = new Point(457, 258);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(80, 31);
            btnLuu.TabIndex = 32;
            btnLuu.Text = "Lưu";
            btnLuu.TextAlign = ContentAlignment.MiddleRight;
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // FormThemThuoc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 361);
            Controls.Add(btnLuu);
            Controls.Add(txtCachDung);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(dtpHSD);
            Controls.Add(txtNSX);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(nudSL);
            Controls.Add(label3);
            Controls.Add(nudGia);
            Controls.Add(txtDVT);
            Controls.Add(label2);
            Controls.Add(txtTen);
            Controls.Add(label1);
            Controls.Add(cmbDanhMuc);
            Controls.Add(label7);
            Name = "FormThemThuoc";
            Text = "FormThemThuoc";
            ((System.ComponentModel.ISupportInitialize)nudGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSL).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbDanhMuc;
        private Label label7;
        private Label label1;
        private TextBox txtTen;
        private TextBox txtDVT;
        private Label label2;
        private NumericUpDown nudGia;
        private Label label3;
        private Label label4;
        private NumericUpDown nudSL;
        private TextBox txtNSX;
        private Label label5;
        private DateTimePicker dtpHSD;
        private Label label6;
        private Label label8;
        private RichTextBox txtCachDung;
        private FontAwesome.Sharp.IconButton btnLuu;
    }
}