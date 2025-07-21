namespace Do_An1.QuanTri.Khám
{
    partial class FormChiTietDonThuoc
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
            dgvChiTietDonThuoc = new DataGridView();
            btnDong = new Button();
            lblMaHoaDon = new Label();
            lblTenBenhNhan = new Label();
            lblNgayKham = new Label();
            lblTongTien = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietDonThuoc).BeginInit();
            SuspendLayout();
            // 
            // dgvChiTietDonThuoc
            // 
            dgvChiTietDonThuoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietDonThuoc.Location = new Point(28, 214);
            dgvChiTietDonThuoc.Name = "dgvChiTietDonThuoc";
            dgvChiTietDonThuoc.Size = new Size(641, 150);
            dgvChiTietDonThuoc.TabIndex = 0;
            // 
            // btnDong
            // 
            btnDong.Location = new Point(589, 392);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(80, 28);
            btnDong.TabIndex = 1;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += btnDong_Click;
            // 
            // lblMaHoaDon
            // 
            lblMaHoaDon.AutoSize = true;
            lblMaHoaDon.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaHoaDon.Location = new Point(28, 55);
            lblMaHoaDon.Name = "lblMaHoaDon";
            lblMaHoaDon.Size = new Size(50, 20);
            lblMaHoaDon.TabIndex = 2;
            lblMaHoaDon.Text = "label1";
            // 
            // lblTenBenhNhan
            // 
            lblTenBenhNhan.AutoSize = true;
            lblTenBenhNhan.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenBenhNhan.Location = new Point(28, 125);
            lblTenBenhNhan.Name = "lblTenBenhNhan";
            lblTenBenhNhan.Size = new Size(50, 20);
            lblTenBenhNhan.TabIndex = 3;
            lblTenBenhNhan.Text = "label2";
            // 
            // lblNgayKham
            // 
            lblNgayKham.AutoSize = true;
            lblNgayKham.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNgayKham.Location = new Point(464, 55);
            lblNgayKham.Name = "lblNgayKham";
            lblNgayKham.Size = new Size(50, 20);
            lblNgayKham.TabIndex = 4;
            lblNgayKham.Text = "label3";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTongTien.Location = new Point(464, 125);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(50, 20);
            lblTongTien.TabIndex = 5;
            lblTongTien.Text = "label4";
            // 
            // FormChiTietDonThuoc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTongTien);
            Controls.Add(lblNgayKham);
            Controls.Add(lblTenBenhNhan);
            Controls.Add(lblMaHoaDon);
            Controls.Add(btnDong);
            Controls.Add(dgvChiTietDonThuoc);
            Name = "FormChiTietDonThuoc";
            Text = "FormChiTietDonThuoc";
            Load += FormChiTietDonThuoc_Load;
            ((System.ComponentModel.ISupportInitialize)dgvChiTietDonThuoc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvChiTietDonThuoc;
        private Button btnDong;
        private Label lblMaHoaDon;
        private Label lblTenBenhNhan;
        private Label lblNgayKham;
        private Label lblTongTien;
    }
}