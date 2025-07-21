namespace Do_An1.QuanTri.Danh_mục
{
    partial class FormSuaThuoc
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
            btnLuu = new FontAwesome.Sharp.IconButton();
            txtCachDung = new RichTextBox();
            label8 = new Label();
            label6 = new Label();
            dtpHSD = new DateTimePicker();
            txtNSX = new TextBox();
            label5 = new Label();
            label4 = new Label();
            nudSL = new NumericUpDown();
            label3 = new Label();
            nudGia = new NumericUpDown();
            txtDVT = new TextBox();
            label2 = new Label();
            txtTen = new TextBox();
            label1 = new Label();
            cmbDanhMuc = new ComboBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudSL).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudGia).BeginInit();
            SuspendLayout();
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
            btnLuu.Location = new Point(462, 261);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(80, 31);
            btnLuu.TabIndex = 49;
            btnLuu.Text = "Lưu";
            btnLuu.TextAlign = ContentAlignment.MiddleRight;
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // txtCachDung
            // 
            txtCachDung.Location = new Point(168, 229);
            txtCachDung.Name = "txtCachDung";
            txtCachDung.Size = new Size(212, 96);
            txtCachDung.TabIndex = 48;
            txtCachDung.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(37, 228);
            label8.Name = "label8";
            label8.Size = new Size(85, 20);
            label8.TabIndex = 47;
            label8.Text = "*Cách dùng";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(37, 176);
            label6.Name = "label6";
            label6.Size = new Size(99, 20);
            label6.TabIndex = 46;
            label6.Text = "*Hạn sử dụng";
            // 
            // dtpHSD
            // 
            dtpHSD.Location = new Point(168, 176);
            dtpHSD.Name = "dtpHSD";
            dtpHSD.Size = new Size(212, 23);
            dtpHSD.TabIndex = 45;
            // 
            // txtNSX
            // 
            txtNSX.Location = new Point(553, 180);
            txtNSX.Name = "txtNSX";
            txtNSX.Size = new Size(202, 23);
            txtNSX.TabIndex = 44;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(442, 180);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 43;
            label5.Text = "*Nhà sản xuất";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(442, 129);
            label4.Name = "label4";
            label4.Size = new Size(101, 20);
            label4.TabIndex = 42;
            label4.Text = "*Số lượng tồn";
            // 
            // nudSL
            // 
            nudSL.Location = new Point(553, 129);
            nudSL.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudSL.Name = "nudSL";
            nudSL.Size = new Size(123, 23);
            nudSL.TabIndex = 41;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(57, 132);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 40;
            label3.Text = "*Giá bán";
            // 
            // nudGia
            // 
            nudGia.Location = new Point(168, 129);
            nudGia.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudGia.Name = "nudGia";
            nudGia.Size = new Size(123, 23);
            nudGia.TabIndex = 39;
            // 
            // txtDVT
            // 
            txtDVT.Location = new Point(553, 83);
            txtDVT.Name = "txtDVT";
            txtDVT.Size = new Size(202, 23);
            txtDVT.TabIndex = 38;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(442, 83);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 37;
            label2.Text = "*Đơn vị tính";
            // 
            // txtTen
            // 
            txtTen.Location = new Point(168, 83);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(212, 23);
            txtTen.TabIndex = 36;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(57, 83);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 35;
            label1.Text = "*Tên thuốc";
            // 
            // cmbDanhMuc
            // 
            cmbDanhMuc.FormattingEnabled = true;
            cmbDanhMuc.Items.AddRange(new object[] { "Lễ tân", "Kế toán", "Quản lý", "Y tá", "Bảo vệ", "Kỹ thuật viên", "Quản lý kho" });
            cmbDanhMuc.Location = new Point(168, 37);
            cmbDanhMuc.Name = "cmbDanhMuc";
            cmbDanhMuc.Size = new Size(212, 23);
            cmbDanhMuc.TabIndex = 34;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(29, 36);
            label7.Name = "label7";
            label7.Size = new Size(123, 20);
            label7.TabIndex = 33;
            label7.Text = "*Danh mục thuốc";
            // 
            // FormSuaThuoc
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
            Name = "FormSuaThuoc";
            Text = "FormSuaThuoc";
            ((System.ComponentModel.ISupportInitialize)nudSL).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudGia).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnLuu;
        private RichTextBox txtCachDung;
        private Label label8;
        private Label label6;
        private DateTimePicker dtpHSD;
        private TextBox txtNSX;
        private Label label5;
        private Label label4;
        private NumericUpDown nudSL;
        private Label label3;
        private NumericUpDown nudGia;
        private TextBox txtDVT;
        private Label label2;
        private TextBox txtTen;
        private Label label1;
        private ComboBox cmbDanhMuc;
        private Label label7;
    }
}