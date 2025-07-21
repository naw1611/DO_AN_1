namespace Do_An1.QuanTri.Khám
{
    partial class UcTraCuuLich
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
            label3 = new Label();
            label2 = new Label();
            dtpDenNgay = new DateTimePicker();
            dtpTuNgay = new DateTimePicker();
            btnLamMoi = new FontAwesome.Sharp.IconButton();
            txtTimKiem = new TextBox();
            label1 = new Label();
            btnTraCuu = new FontAwesome.Sharp.IconButton();
            label7 = new Label();
            cmbTrangThai = new ComboBox();
            panel3 = new Panel();
            btnNext = new Button();
            btnPrev = new Button();
            lblPage = new Label();
            label4 = new Label();
            dgvLichKham = new DataGridView();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLichKham).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(dtpDenNgay);
            panel2.Controls.Add(dtpTuNgay);
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
            panel2.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(670, 77);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 81;
            label3.Text = "*Đến ngày";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(670, 32);
            label2.Name = "label2";
            label2.Size = new Size(68, 20);
            label2.TabIndex = 80;
            label2.Text = "*Từ ngày";
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Location = new Point(770, 75);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(200, 23);
            dtpDenNgay.TabIndex = 79;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Location = new Point(770, 29);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(200, 23);
            dtpTuNgay.TabIndex = 78;
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
            btnLamMoi.Location = new Point(670, 129);
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
            txtTimKiem.Location = new Point(366, 29);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(209, 23);
            txtTimKiem.TabIndex = 72;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(198, 32);
            label1.Name = "label1";
            label1.Size = new Size(145, 20);
            label1.TabIndex = 71;
            label1.Text = "*Nhập tên (BS orBN)";
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
            btnTraCuu.Location = new Point(521, 129);
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
            label7.Location = new Point(262, 79);
            label7.Name = "label7";
            label7.Size = new Size(81, 20);
            label7.TabIndex = 66;
            label7.Text = "*Trạng thái";
            // 
            // cmbTrangThai
            // 
            cmbTrangThai.FormattingEnabled = true;
            cmbTrangThai.Items.AddRange(new object[] { "Tất cả", "Đặt lịch ", "Xác nhận ", "Hoàn tất", "Hủy", "Không đến" });
            cmbTrangThai.Location = new Point(366, 76);
            cmbTrangThai.Name = "cmbTrangThai";
            cmbTrangThai.Size = new Size(209, 23);
            cmbTrangThai.TabIndex = 65;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(btnNext);
            panel3.Controls.Add(btnPrev);
            panel3.Controls.Add(lblPage);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(dgvLichKham);
            panel3.Location = new Point(15, 205);
            panel3.Name = "panel3";
            panel3.Size = new Size(1085, 324);
            panel3.TabIndex = 6;
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
            label4.Size = new Size(195, 21);
            label4.TabIndex = 4;
            label4.Text = "DANH SÁCH LỊCH KHÁM";
            // 
            // dgvLichKham
            // 
            dgvLichKham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLichKham.Location = new Point(69, 54);
            dgvLichKham.Name = "dgvLichKham";
            dgvLichKham.Size = new Size(795, 218);
            dgvLichKham.TabIndex = 3;
            dgvLichKham.CellClick += dgvLichKham_CellClick;
            // 
            // UcTraCuuLich
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel3);
            Controls.Add(panel2);
            Name = "UcTraCuuLich";
            Size = new Size(1115, 688);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLichKham).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private FontAwesome.Sharp.IconButton btnLamMoi;
        private TextBox txtTimKiem;
        private Label label1;
        private FontAwesome.Sharp.IconButton btnTraCuu;
        private Label label7;
        private ComboBox cmbTrangThai;
        private Panel panel3;
        private Button btnNext;
        private Button btnPrev;
        private Label lblPage;
        private Label label4;
        private DataGridView dgvLichKham;
        private Label label3;
        private Label label2;
        private DateTimePicker dtpDenNgay;
        private DateTimePicker dtpTuNgay;
    }
}
