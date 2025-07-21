namespace Do_An1.QuanTri.Kho_thuốc
{
    partial class UcLapPhieuXuat
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
            btnTaoMoi = new FontAwesome.Sharp.IconButton();
            txtGhiChu = new TextBox();
            label4 = new Label();
            label3 = new Label();
            cmbNhanVien = new ComboBox();
            label2 = new Label();
            dtpNgayXuat = new DateTimePicker();
            txtMaPhieu = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            btnThem = new FontAwesome.Sharp.IconButton();
            numSoLuong = new NumericUpDown();
            label6 = new Label();
            cmbThuoc = new ComboBox();
            label7 = new Label();
            txtDonGia = new TextBox();
            label8 = new Label();
            panel3 = new Panel();
            label14 = new Label();
            dgvChiTietXuat = new DataGridView();
            panel4 = new Panel();
            btnXuatPX = new FontAwesome.Sharp.IconButton();
            btnLuuPhieuNhap = new FontAwesome.Sharp.IconButton();
            lblTongTien = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietXuat).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnTaoMoi);
            panel1.Controls.Add(txtGhiChu);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cmbNhanVien);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dtpNgayXuat);
            panel1.Controls.Add(txtMaPhieu);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1115, 164);
            panel1.TabIndex = 0;
            // 
            // btnTaoMoi
            // 
            btnTaoMoi.BackColor = Color.Blue;
            btnTaoMoi.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTaoMoi.ForeColor = Color.White;
            btnTaoMoi.IconChar = FontAwesome.Sharp.IconChar.CirclePlus;
            btnTaoMoi.IconColor = Color.White;
            btnTaoMoi.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnTaoMoi.IconSize = 20;
            btnTaoMoi.ImageAlign = ContentAlignment.MiddleLeft;
            btnTaoMoi.Location = new Point(469, 119);
            btnTaoMoi.Name = "btnTaoMoi";
            btnTaoMoi.Size = new Size(137, 31);
            btnTaoMoi.TabIndex = 33;
            btnTaoMoi.Text = "Tạo mới phiếu";
            btnTaoMoi.TextAlign = ContentAlignment.MiddleRight;
            btnTaoMoi.UseVisualStyleBackColor = false;
            btnTaoMoi.Click += btnTaoMoi_Click;
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(694, 80);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(200, 23);
            txtGhiChu.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(566, 83);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 6;
            label4.Text = "Ghi chú";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(562, 31);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 5;
            label3.Text = "Nhân viên xuất";
            // 
            // cmbNhanVien
            // 
            cmbNhanVien.FormattingEnabled = true;
            cmbNhanVien.Location = new Point(694, 27);
            cmbNhanVien.Name = "cmbNhanVien";
            cmbNhanVien.Size = new Size(200, 23);
            cmbNhanVien.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(188, 81);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 3;
            label2.Text = "Ngày xuất";
            // 
            // dtpNgayXuat
            // 
            dtpNgayXuat.Location = new Point(307, 81);
            dtpNgayXuat.Name = "dtpNgayXuat";
            dtpNgayXuat.Size = new Size(200, 23);
            dtpNgayXuat.TabIndex = 2;
            // 
            // txtMaPhieu
            // 
            txtMaPhieu.Location = new Point(307, 27);
            txtMaPhieu.Name = "txtMaPhieu";
            txtMaPhieu.Size = new Size(200, 23);
            txtMaPhieu.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(188, 30);
            label1.Name = "label1";
            label1.Size = new Size(103, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã phiếu xuất";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btnThem);
            panel2.Controls.Add(numSoLuong);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(cmbThuoc);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtDonGia);
            panel2.Controls.Add(label8);
            panel2.Location = new Point(0, 170);
            panel2.Name = "panel2";
            panel2.Size = new Size(1115, 136);
            panel2.TabIndex = 1;
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
            btnThem.Location = new Point(491, 72);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(80, 31);
            btnThem.TabIndex = 32;
            btnThem.Text = "Thêm";
            btnThem.TextAlign = ContentAlignment.MiddleRight;
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThemThuoc_Click;
            // 
            // numSoLuong
            // 
            numSoLuong.Location = new Point(901, 23);
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(120, 23);
            numSoLuong.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(51, 26);
            label6.Name = "label6";
            label6.Size = new Size(49, 20);
            label6.TabIndex = 5;
            label6.Text = "Thuốc";
            // 
            // cmbThuoc
            // 
            cmbThuoc.FormattingEnabled = true;
            cmbThuoc.Location = new Point(125, 23);
            cmbThuoc.Name = "cmbThuoc";
            cmbThuoc.Size = new Size(200, 23);
            cmbThuoc.TabIndex = 4;
            cmbThuoc.SelectedIndexChanged += cmbThuoc_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(759, 26);
            label7.Name = "label7";
            label7.Size = new Size(101, 20);
            label7.TabIndex = 3;
            label7.Text = "Số lượng xuất";
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(514, 23);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(200, 23);
            txtDonGia.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(395, 26);
            label8.Name = "label8";
            label8.Size = new Size(94, 20);
            label8.TabIndex = 0;
            label8.Text = "Đơn giá xuất";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(label14);
            panel3.Controls.Add(dgvChiTietXuat);
            panel3.Location = new Point(0, 312);
            panel3.Name = "panel3";
            panel3.Size = new Size(1085, 272);
            panel3.TabIndex = 7;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(172, 20);
            label14.Name = "label14";
            label14.Size = new Size(202, 21);
            label14.TabIndex = 4;
            label14.Text = "DANH SÁCH PHIẾU XUẤT";
            // 
            // dgvChiTietXuat
            // 
            dgvChiTietXuat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietXuat.Location = new Point(172, 54);
            dgvChiTietXuat.Name = "dgvChiTietXuat";
            dgvChiTietXuat.Size = new Size(692, 184);
            dgvChiTietXuat.TabIndex = 3;
            dgvChiTietXuat.CellContentClick += dgvChiTiet_CellContentClick;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(btnXuatPX);
            panel4.Controls.Add(btnLuuPhieuNhap);
            panel4.Controls.Add(lblTongTien);
            panel4.Location = new Point(172, 590);
            panel4.Name = "panel4";
            panel4.Size = new Size(688, 95);
            panel4.TabIndex = 8;
            // 
            // btnXuatPX
            // 
            btnXuatPX.BackColor = Color.Blue;
            btnXuatPX.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXuatPX.ForeColor = Color.White;
            btnXuatPX.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            btnXuatPX.IconColor = Color.White;
            btnXuatPX.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnXuatPX.IconSize = 20;
            btnXuatPX.ImageAlign = ContentAlignment.MiddleLeft;
            btnXuatPX.Location = new Point(522, 51);
            btnXuatPX.Name = "btnXuatPX";
            btnXuatPX.Size = new Size(145, 31);
            btnXuatPX.TabIndex = 35;
            btnXuatPX.Text = "Xuất phiếu xuất";
            btnXuatPX.TextAlign = ContentAlignment.MiddleRight;
            btnXuatPX.UseVisualStyleBackColor = false;
            btnXuatPX.Click += btnXuatPX_Click;
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
            btnLuuPhieuNhap.Location = new Point(417, 51);
            btnLuuPhieuNhap.Name = "btnLuuPhieuNhap";
            btnLuuPhieuNhap.Size = new Size(80, 31);
            btnLuuPhieuNhap.TabIndex = 33;
            btnLuuPhieuNhap.Text = "Lưu";
            btnLuuPhieuNhap.TextAlign = ContentAlignment.MiddleRight;
            btnLuuPhieuNhap.UseVisualStyleBackColor = false;
            btnLuuPhieuNhap.Click += btnLuu_Click;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTongTien.Location = new Point(42, 17);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(50, 20);
            lblTongTien.TabIndex = 0;
            lblTongTien.Text = "label4";
            // 
            // UcLapPhieuXuat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UcLapPhieuXuat";
            Size = new Size(1115, 688);
            Load += UcLapPhieuXuat_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietXuat).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtMaPhieu;
        private Label label1;
        private TextBox txtGhiChu;
        private Label label4;
        private Label label3;
        private ComboBox cmbNhanVien;
        private Label label2;
        private DateTimePicker dtpNgayXuat;
        private Panel panel2;
        private Label label6;
        private ComboBox cmbThuoc;
        private Label label7;
        private TextBox txtDonGia;
        private Label label8;
        private NumericUpDown numSoLuong;
        private FontAwesome.Sharp.IconButton btnThem;
        private Panel panel3;
        private Label label14;
        private DataGridView dgvChiTietXuat;
        private Panel panel4;
        private Label lblTongTien;
        private FontAwesome.Sharp.IconButton btnLuuPhieuNhap;
        private FontAwesome.Sharp.IconButton btnTaoMoi;
        private FontAwesome.Sharp.IconButton btnXuatPN;
        private FontAwesome.Sharp.IconButton btnXuatPX;
    }
}
