namespace Do_An1.QuanTri.Khám
{
    partial class UcThanhToan
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
            panel2 = new Panel();
            txtGiamGia = new TextBox();
            lblGiamGia = new Label();
            txtTienKham = new TextBox();
            lblTienKham = new Label();
            btnLamMoi = new FontAwesome.Sharp.IconButton();
            txtTimKiem = new TextBox();
            label1 = new Label();
            btnTraCuu = new FontAwesome.Sharp.IconButton();
            label7 = new Label();
            cmbTrangThai = new ComboBox();
            panel1 = new Panel();
            btnCapNhat = new FontAwesome.Sharp.IconButton();
            btnXuatHD = new FontAwesome.Sharp.IconButton();
            btnXemCT = new FontAwesome.Sharp.IconButton();
            btnThanhToan = new FontAwesome.Sharp.IconButton();
            panel3 = new Panel();
            btnNext = new Button();
            btnPrev = new Button();
            lblTrang = new Label();
            label4 = new Label();
            dgvHoaDon = new DataGridView();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(txtGiamGia);
            panel2.Controls.Add(lblGiamGia);
            panel2.Controls.Add(txtTienKham);
            panel2.Controls.Add(lblTienKham);
            panel2.Controls.Add(btnLamMoi);
            panel2.Controls.Add(txtTimKiem);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnTraCuu);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(cmbTrangThai);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1115, 189);
            panel2.TabIndex = 4;
            // 
            // txtGiamGia
            // 
            txtGiamGia.Location = new Point(697, 66);
            txtGiamGia.Name = "txtGiamGia";
            txtGiamGia.Size = new Size(209, 23);
            txtGiamGia.TabIndex = 77;
            // 
            // lblGiamGia
            // 
            lblGiamGia.AutoSize = true;
            lblGiamGia.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGiamGia.Location = new Point(597, 69);
            lblGiamGia.Name = "lblGiamGia";
            lblGiamGia.Size = new Size(75, 20);
            lblGiamGia.TabIndex = 76;
            lblGiamGia.Text = "*Giảm giá";
            // 
            // txtTienKham
            // 
            txtTienKham.Location = new Point(697, 19);
            txtTienKham.Name = "txtTienKham";
            txtTienKham.Size = new Size(209, 23);
            txtTienKham.TabIndex = 75;
            // 
            // lblTienKham
            // 
            lblTienKham.AutoSize = true;
            lblTienKham.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTienKham.Location = new Point(597, 22);
            lblTienKham.Name = "lblTienKham";
            lblTienKham.Size = new Size(83, 20);
            lblTienKham.TabIndex = 74;
            lblTienKham.Text = "*Tiền khám";
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.Blue;
            btnLamMoi.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.IconChar = FontAwesome.Sharp.IconChar.SyncAlt;
            btnLamMoi.IconColor = Color.White;
            btnLamMoi.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLamMoi.IconSize = 20;
            btnLamMoi.ImageAlign = ContentAlignment.MiddleLeft;
            btnLamMoi.Location = new Point(247, 117);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(98, 31);
            btnLamMoi.TabIndex = 73;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.TextAlign = ContentAlignment.MiddleRight;
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(172, 19);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(209, 23);
            txtTimKiem.TabIndex = 72;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(38, 22);
            label1.Name = "label1";
            label1.Size = new Size(111, 20);
            label1.TabIndex = 71;
            label1.Text = "*Tên bệnh nhân";
            // 
            // btnTraCuu
            // 
            btnTraCuu.BackColor = Color.Blue;
            btnTraCuu.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTraCuu.ForeColor = Color.White;
            btnTraCuu.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnTraCuu.IconColor = Color.White;
            btnTraCuu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnTraCuu.IconSize = 20;
            btnTraCuu.ImageAlign = ContentAlignment.MiddleLeft;
            btnTraCuu.Location = new Point(98, 117);
            btnTraCuu.Name = "btnTraCuu";
            btnTraCuu.Size = new Size(98, 31);
            btnTraCuu.TabIndex = 70;
            btnTraCuu.Text = "Tra cứu";
            btnTraCuu.TextAlign = ContentAlignment.MiddleRight;
            btnTraCuu.UseVisualStyleBackColor = false;
            btnTraCuu.Click += btnTraCuu_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(68, 69);
            label7.Name = "label7";
            label7.Size = new Size(81, 20);
            label7.TabIndex = 66;
            label7.Text = "*Trạng thái";
            // 
            // cmbTrangThai
            // 
            cmbTrangThai.FormattingEnabled = true;
            cmbTrangThai.Items.AddRange(new object[] { "Tất cả", "Đã thanh toán", "Chưa thanh toán" });
            cmbTrangThai.Location = new Point(172, 66);
            cmbTrangThai.Name = "cmbTrangThai";
            cmbTrangThai.Size = new Size(209, 23);
            cmbTrangThai.TabIndex = 65;
            cmbTrangThai.SelectedIndexChanged += cmbTrangThai_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnCapNhat);
            panel1.Controls.Add(btnXuatHD);
            panel1.Controls.Add(btnXemCT);
            panel1.Controls.Add(btnThanhToan);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 601);
            panel1.Name = "panel1";
            panel1.Size = new Size(1115, 87);
            panel1.TabIndex = 73;
            // 
            // btnCapNhat
            // 
            btnCapNhat.BackColor = Color.Blue;
            btnCapNhat.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCapNhat.ForeColor = Color.White;
            btnCapNhat.IconChar = FontAwesome.Sharp.IconChar.Upwork;
            btnCapNhat.IconColor = Color.White;
            btnCapNhat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCapNhat.IconSize = 20;
            btnCapNhat.ImageAlign = ContentAlignment.MiddleLeft;
            btnCapNhat.Location = new Point(256, 28);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(109, 31);
            btnCapNhat.TabIndex = 29;
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.TextAlign = ContentAlignment.MiddleRight;
            btnCapNhat.UseVisualStyleBackColor = false;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // btnXuatHD
            // 
            btnXuatHD.BackColor = Color.Blue;
            btnXuatHD.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXuatHD.ForeColor = Color.White;
            btnXuatHD.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            btnXuatHD.IconColor = Color.White;
            btnXuatHD.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnXuatHD.IconSize = 20;
            btnXuatHD.ImageAlign = ContentAlignment.MiddleLeft;
            btnXuatHD.Location = new Point(841, 28);
            btnXuatHD.Name = "btnXuatHD";
            btnXuatHD.Size = new Size(132, 31);
            btnXuatHD.TabIndex = 28;
            btnXuatHD.Text = "Xuất hóa đơn";
            btnXuatHD.TextAlign = ContentAlignment.MiddleRight;
            btnXuatHD.UseVisualStyleBackColor = false;
            btnXuatHD.Click += btnXuatHD_Click;
            // 
            // btnXemCT
            // 
            btnXemCT.BackColor = Color.Blue;
            btnXemCT.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXemCT.ForeColor = Color.White;
            btnXemCT.IconChar = FontAwesome.Sharp.IconChar.Eye;
            btnXemCT.IconColor = Color.White;
            btnXemCT.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnXemCT.IconSize = 20;
            btnXemCT.ImageAlign = ContentAlignment.MiddleLeft;
            btnXemCT.Location = new Point(657, 28);
            btnXemCT.Name = "btnXemCT";
            btnXemCT.Size = new Size(123, 31);
            btnXemCT.TabIndex = 27;
            btnXemCT.Text = "Xem Chi Tiết";
            btnXemCT.TextAlign = ContentAlignment.MiddleRight;
            btnXemCT.UseVisualStyleBackColor = false;
            btnXemCT.Click += btnXemChiTiet_Click;
            // 
            // btnThanhToan
            // 
            btnThanhToan.BackColor = Color.Blue;
            btnThanhToan.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThanhToan.ForeColor = Color.White;
            btnThanhToan.IconChar = FontAwesome.Sharp.IconChar.MoneyBill;
            btnThanhToan.IconColor = Color.White;
            btnThanhToan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnThanhToan.IconSize = 20;
            btnThanhToan.ImageAlign = ContentAlignment.MiddleLeft;
            btnThanhToan.Location = new Point(473, 28);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(109, 31);
            btnThanhToan.TabIndex = 26;
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.TextAlign = ContentAlignment.MiddleRight;
            btnThanhToan.UseVisualStyleBackColor = false;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(btnNext);
            panel3.Controls.Add(btnPrev);
            panel3.Controls.Add(lblTrang);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(dgvHoaDon);
            panel3.Location = new Point(0, 204);
            panel3.Name = "panel3";
            panel3.Size = new Size(1112, 376);
            panel3.TabIndex = 74;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(1042, 313);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(30, 30);
            btnNext.TabIndex = 8;
            btnNext.Text = ">";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(1006, 313);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(30, 30);
            btnPrev.TabIndex = 7;
            btnPrev.Text = "<";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // lblTrang
            // 
            lblTrang.AutoSize = true;
            lblTrang.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTrang.Location = new Point(926, 317);
            lblTrang.Name = "lblTrang";
            lblTrang.Size = new Size(50, 20);
            lblTrang.TabIndex = 6;
            lblTrang.Text = "label1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(69, 20);
            label4.Name = "label4";
            label4.Size = new Size(184, 21);
            label4.TabIndex = 4;
            label4.Text = "DANH SÁCH HÓA ĐƠN";
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Location = new Point(69, 54);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.Size = new Size(967, 239);
            dgvHoaDon.TabIndex = 3;
            // 
            // UcThanhToan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "UcThanhToan";
            Size = new Size(1115, 688);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private FontAwesome.Sharp.IconButton btnTraCuu;
        private Label label7;
        private ComboBox cmbTrangThai;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnXemCT;
        private FontAwesome.Sharp.IconButton btnThanhToan;
        private Panel panel3;
        private Button btnNext;
        private Button btnPrev;
        private Label lblTrang;
        private Label label4;
        private DataGridView dgvHoaDon;
        private TextBox txtTimKiem;
        private Label label1;
        private FontAwesome.Sharp.IconButton btnXuatHD;
        private FontAwesome.Sharp.IconButton btnLamMoi;
        private TextBox txtTienKham;
        private Label lblTienKham;
        private FontAwesome.Sharp.IconButton btnCapNhat;
        private TextBox txtGiamGia;
        private Label lblGiamGia;
    }
}
