namespace Do_An1.QuanTri.Khám
{
    partial class UcLapPhieu
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
            btnTraCuu = new FontAwesome.Sharp.IconButton();
            btnLamMoi = new FontAwesome.Sharp.IconButton();
            label3 = new Label();
            dtpNgayKham = new DateTimePicker();
            label7 = new Label();
            cmbTrangThai = new ComboBox();
            cmbBacSi = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            cmbBenhNhan = new ComboBox();
            panel3 = new Panel();
            btnNext = new Button();
            btnPrev = new Button();
            lblPage = new Label();
            label4 = new Label();
            dgvPhieuKham = new DataGridView();
            panel1 = new Panel();
            btnXoa = new FontAwesome.Sharp.IconButton();
            btnSua = new FontAwesome.Sharp.IconButton();
            btnThem = new FontAwesome.Sharp.IconButton();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhieuKham).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btnTraCuu);
            panel2.Controls.Add(btnLamMoi);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(dtpNgayKham);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(cmbTrangThai);
            panel2.Controls.Add(cmbBacSi);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(cmbBenhNhan);
            panel2.Location = new Point(225, 24);
            panel2.Name = "panel2";
            panel2.Size = new Size(694, 189);
            panel2.TabIndex = 3;
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
            btnTraCuu.Location = new Point(218, 136);
            btnTraCuu.Name = "btnTraCuu";
            btnTraCuu.Size = new Size(98, 31);
            btnTraCuu.TabIndex = 70;
            btnTraCuu.Text = "Tra cứu";
            btnTraCuu.TextAlign = ContentAlignment.MiddleRight;
            btnTraCuu.UseVisualStyleBackColor = false;
            btnTraCuu.Click += btnTraCuu_Click;
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
            btnLamMoi.Location = new Point(371, 136);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(98, 31);
            btnLamMoi.TabIndex = 69;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.TextAlign = ContentAlignment.MiddleRight;
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(356, 86);
            label3.Name = "label3";
            label3.Size = new Size(90, 20);
            label3.TabIndex = 68;
            label3.Text = "*Ngày khám";
            // 
            // dtpNgayKham
            // 
            dtpNgayKham.Location = new Point(463, 86);
            dtpNgayKham.Name = "dtpNgayKham";
            dtpNgayKham.Size = new Size(209, 23);
            dtpNgayKham.TabIndex = 67;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(20, 90);
            label7.Name = "label7";
            label7.Size = new Size(81, 20);
            label7.TabIndex = 66;
            label7.Text = "*Trạng thái";
            // 
            // cmbTrangThai
            // 
            cmbTrangThai.FormattingEnabled = true;
            cmbTrangThai.Items.AddRange(new object[] { "Đặt lịch", "Xác nhận", "Hoàn tất", "Hủy", "Không đến" });
            cmbTrangThai.Location = new Point(124, 87);
            cmbTrangThai.Name = "cmbTrangThai";
            cmbTrangThai.Size = new Size(209, 23);
            cmbTrangThai.TabIndex = 65;
            // 
            // cmbBacSi
            // 
            cmbBacSi.FormattingEnabled = true;
            cmbBacSi.Location = new Point(463, 21);
            cmbBacSi.Name = "cmbBacSi";
            cmbBacSi.Size = new Size(209, 23);
            cmbBacSi.TabIndex = 59;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(393, 24);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 58;
            label2.Text = "*Bác sĩ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(17, 24);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 57;
            label1.Text = "*Bệnh nhân";
            // 
            // cmbBenhNhan
            // 
            cmbBenhNhan.FormattingEnabled = true;
            cmbBenhNhan.Location = new Point(121, 21);
            cmbBenhNhan.Name = "cmbBenhNhan";
            cmbBenhNhan.Size = new Size(209, 23);
            cmbBenhNhan.TabIndex = 56;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(btnNext);
            panel3.Controls.Add(btnPrev);
            panel3.Controls.Add(lblPage);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(dgvPhieuKham);
            panel3.Location = new Point(15, 239);
            panel3.Name = "panel3";
            panel3.Size = new Size(1085, 324);
            panel3.TabIndex = 4;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(1035, 248);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(30, 30);
            btnNext.TabIndex = 8;
            btnNext.Text = ">";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(999, 248);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(30, 30);
            btnPrev.TabIndex = 7;
            btnPrev.Text = "<";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // lblPage
            // 
            lblPage.AutoSize = true;
            lblPage.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPage.Location = new Point(919, 252);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(50, 20);
            lblPage.TabIndex = 6;
            lblPage.Text = "label1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(69, 20);
            label4.Name = "label4";
            label4.Size = new Size(208, 21);
            label4.TabIndex = 4;
            label4.Text = "DANH SÁCH PHIẾU KHÁM";
            // 
            // dgvPhieuKham
            // 
            dgvPhieuKham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhieuKham.Location = new Point(69, 54);
            dgvPhieuKham.Name = "dgvPhieuKham";
            dgvPhieuKham.Size = new Size(795, 218);
            dgvPhieuKham.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(btnThem);
            panel1.Location = new Point(298, 585);
            panel1.Name = "panel1";
            panel1.Size = new Size(531, 87);
            panel1.TabIndex = 5;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Red;
            btnXoa.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXoa.ForeColor = Color.White;
            btnXoa.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnXoa.IconColor = Color.White;
            btnXoa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnXoa.IconSize = 20;
            btnXoa.ImageAlign = ContentAlignment.MiddleLeft;
            btnXoa.Location = new Point(364, 33);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(77, 31);
            btnXoa.TabIndex = 28;
            btnXoa.Text = "Xóa";
            btnXoa.TextAlign = ContentAlignment.MiddleRight;
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.Blue;
            btnSua.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSua.ForeColor = Color.White;
            btnSua.IconChar = FontAwesome.Sharp.IconChar.Edit;
            btnSua.IconColor = Color.White;
            btnSua.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSua.IconSize = 20;
            btnSua.ImageAlign = ContentAlignment.MiddleLeft;
            btnSua.Location = new Point(202, 33);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(78, 31);
            btnSua.TabIndex = 27;
            btnSua.Text = "Sửa";
            btnSua.TextAlign = ContentAlignment.MiddleRight;
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
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
            btnThem.Location = new Point(47, 33);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(80, 31);
            btnThem.TabIndex = 26;
            btnThem.Text = "Thêm";
            btnThem.TextAlign = ContentAlignment.MiddleRight;
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // UcLapPhieu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Name = "UcLapPhieu";
            Size = new Size(1115, 688);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhieuKham).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private ComboBox cmbBacSi;
        private Label label2;
        private Label label1;
        private ComboBox cmbBenhNhan;
        private Label label7;
        private ComboBox cmbTrangThai;
        private Label label3;
        private DateTimePicker dtpNgayKham;
        private Panel panel3;
        private Button btnNext;
        private Button btnPrev;
        private Label lblPage;
        private Label label4;
        private DataGridView dgvPhieuKham;
        private FontAwesome.Sharp.IconButton btnTraCuu;
        private FontAwesome.Sharp.IconButton btnLamMoi;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnXoa;
        private FontAwesome.Sharp.IconButton btnSua;
        private FontAwesome.Sharp.IconButton btnThem;
    }
}
