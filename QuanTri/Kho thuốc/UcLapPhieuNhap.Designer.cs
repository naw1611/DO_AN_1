namespace Do_An1.QuanTri.Kho_thuốc
{
    partial class UcLapPhieuNhap
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnThem = new FontAwesome.Sharp.IconButton();
            txtDonGiaNhap = new TextBox();
            label3 = new Label();
            txtSoLuongNhap = new TextBox();
            label2 = new Label();
            label1 = new Label();
            cboThuoc = new ComboBox();
            panel3 = new Panel();
            label14 = new Label();
            dgvChiTietNhap = new DataGridView();
            panel2 = new Panel();
            lblTongTien = new Label();
            panel4 = new Panel();
            btnXuatPN = new FontAwesome.Sharp.IconButton();
            btnHuy = new FontAwesome.Sharp.IconButton();
            btnLuuPhieuNhap = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).BeginInit();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnThem);
            panel1.Controls.Add(txtDonGiaNhap);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtSoLuongNhap);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cboThuoc);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1115, 110);
            panel1.TabIndex = 0;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.Blue;
            btnThem.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThem.ForeColor = Color.White;
            btnThem.IconChar = FontAwesome.Sharp.IconChar.CirclePlus;
            btnThem.IconColor = Color.White;
            btnThem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnThem.IconSize = 20;
            btnThem.ImageAlign = ContentAlignment.MiddleLeft;
            btnThem.Location = new Point(527, 64);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(80, 31);
            btnThem.TabIndex = 31;
            btnThem.Text = "Thêm";
            btnThem.TextAlign = ContentAlignment.MiddleRight;
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // txtDonGiaNhap
            // 
            txtDonGiaNhap.Location = new Point(894, 15);
            txtDonGiaNhap.Name = "txtDonGiaNhap";
            txtDonGiaNhap.Size = new Size(177, 23);
            txtDonGiaNhap.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(763, 18);
            label3.Name = "label3";
            label3.Size = new Size(105, 20);
            label3.TabIndex = 4;
            label3.Text = "*Đơn giá nhập";
            // 
            // txtSoLuongNhap
            // 
            txtSoLuongNhap.Location = new Point(527, 15);
            txtSoLuongNhap.Name = "txtSoLuongNhap";
            txtSoLuongNhap.Size = new Size(177, 23);
            txtSoLuongNhap.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(396, 18);
            label2.Name = "label2";
            label2.Size = new Size(112, 20);
            label2.TabIndex = 2;
            label2.Text = "*Số lượng nhập";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(70, 18);
            label1.Name = "label1";
            label1.Size = new Size(90, 20);
            label1.TabIndex = 1;
            label1.Text = "*Chọn thuốc";
            // 
            // cboThuoc
            // 
            cboThuoc.FormattingEnabled = true;
            cboThuoc.Location = new Point(176, 15);
            cboThuoc.Name = "cboThuoc";
            cboThuoc.Size = new Size(161, 23);
            cboThuoc.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(label14);
            panel3.Controls.Add(dgvChiTietNhap);
            panel3.Location = new Point(15, 128);
            panel3.Name = "panel3";
            panel3.Size = new Size(1085, 272);
            panel3.TabIndex = 6;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(172, 20);
            label14.Name = "label14";
            label14.Size = new Size(206, 21);
            label14.TabIndex = 4;
            label14.Text = "DANH SÁCH PHIẾU NHẬP";
            // 
            // dgvChiTietNhap
            // 
            dgvChiTietNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietNhap.Location = new Point(172, 54);
            dgvChiTietNhap.Name = "dgvChiTietNhap";
            dgvChiTietNhap.Size = new Size(583, 184);
            dgvChiTietNhap.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(lblTongTien);
            panel2.Location = new Point(84, 423);
            panel2.Name = "panel2";
            panel2.Size = new Size(445, 87);
            panel2.TabIndex = 7;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTongTien.Location = new Point(50, 30);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(50, 20);
            lblTongTien.TabIndex = 0;
            lblTongTien.Text = "label4";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(btnXuatPN);
            panel4.Controls.Add(btnHuy);
            panel4.Controls.Add(btnLuuPhieuNhap);
            panel4.Location = new Point(84, 546);
            panel4.Name = "panel4";
            panel4.Size = new Size(843, 100);
            panel4.TabIndex = 8;
            // 
            // btnXuatPN
            // 
            btnXuatPN.BackColor = Color.Blue;
            btnXuatPN.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXuatPN.ForeColor = Color.White;
            btnXuatPN.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            btnXuatPN.IconColor = Color.White;
            btnXuatPN.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnXuatPN.IconSize = 20;
            btnXuatPN.ImageAlign = ContentAlignment.MiddleLeft;
            btnXuatPN.Location = new Point(568, 35);
            btnXuatPN.Name = "btnXuatPN";
            btnXuatPN.Size = new Size(145, 31);
            btnXuatPN.TabIndex = 34;
            btnXuatPN.Text = "Xuất phiếu nhập";
            btnXuatPN.TextAlign = ContentAlignment.MiddleRight;
            btnXuatPN.UseVisualStyleBackColor = false;
            btnXuatPN.Click += btnXuatPN_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.Red;
            btnHuy.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHuy.ForeColor = Color.White;
            btnHuy.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnHuy.IconColor = Color.White;
            btnHuy.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnHuy.IconSize = 20;
            btnHuy.ImageAlign = ContentAlignment.MiddleLeft;
            btnHuy.Location = new Point(393, 35);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(77, 31);
            btnHuy.TabIndex = 33;
            btnHuy.Text = "Hủy";
            btnHuy.TextAlign = ContentAlignment.MiddleRight;
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnLuuPhieuNhap
            // 
            btnLuuPhieuNhap.BackColor = Color.Blue;
            btnLuuPhieuNhap.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLuuPhieuNhap.ForeColor = Color.White;
            btnLuuPhieuNhap.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnLuuPhieuNhap.IconColor = Color.White;
            btnLuuPhieuNhap.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLuuPhieuNhap.IconSize = 20;
            btnLuuPhieuNhap.ImageAlign = ContentAlignment.MiddleLeft;
            btnLuuPhieuNhap.Location = new Point(173, 35);
            btnLuuPhieuNhap.Name = "btnLuuPhieuNhap";
            btnLuuPhieuNhap.Size = new Size(80, 31);
            btnLuuPhieuNhap.TabIndex = 32;
            btnLuuPhieuNhap.Text = "Lưu";
            btnLuuPhieuNhap.TextAlign = ContentAlignment.MiddleRight;
            btnLuuPhieuNhap.UseVisualStyleBackColor = false;
            btnLuuPhieuNhap.Click += btnLuuPhieuNhap_Click;
            // 
            // UcLapPhieuNhap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "UcLapPhieuNhap";
            Size = new Size(1115, 688);
            Load += UcLapPhieuNhap_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtDonGiaNhap;
        private Label label3;
        private TextBox txtSoLuongNhap;
        private Label label2;
        private Label label1;
        private ComboBox cboThuoc;
        private FontAwesome.Sharp.IconButton btnThem;
        private Panel panel3;
        private Label label14;
        private DataGridView dgvChiTietNhap;
        private Panel panel2;
        private Label lblTongTien;
        private Panel panel4;
        private FontAwesome.Sharp.IconButton btnLuuPhieuNhap;
        private FontAwesome.Sharp.IconButton btnHuy;
        private FontAwesome.Sharp.IconButton btnXuatPN;
    }
}
