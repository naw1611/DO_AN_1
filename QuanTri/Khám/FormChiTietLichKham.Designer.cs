namespace Do_An1.QuanTri.Khám
{
    partial class FormChiTietLichKham
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
            lblMaLichKham = new Label();
            lblTenBenhNhan = new Label();
            lblTenBacSi = new Label();
            lblNgayKham = new Label();
            lblLyDo = new Label();
            lblGhiChu = new Label();
            dgvDonThuoc = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDonThuoc).BeginInit();
            SuspendLayout();
            // 
            // lblMaLichKham
            // 
            lblMaLichKham.AutoSize = true;
            lblMaLichKham.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaLichKham.Location = new Point(101, 46);
            lblMaLichKham.Name = "lblMaLichKham";
            lblMaLichKham.Size = new Size(50, 20);
            lblMaLichKham.TabIndex = 0;
            lblMaLichKham.Text = "label1";
            // 
            // lblTenBenhNhan
            // 
            lblTenBenhNhan.AutoSize = true;
            lblTenBenhNhan.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenBenhNhan.Location = new Point(101, 112);
            lblTenBenhNhan.Name = "lblTenBenhNhan";
            lblTenBenhNhan.Size = new Size(50, 20);
            lblTenBenhNhan.TabIndex = 1;
            lblTenBenhNhan.Text = "label2";
            // 
            // lblTenBacSi
            // 
            lblTenBacSi.AutoSize = true;
            lblTenBacSi.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenBacSi.Location = new Point(333, 46);
            lblTenBacSi.Name = "lblTenBacSi";
            lblTenBacSi.Size = new Size(50, 20);
            lblTenBacSi.TabIndex = 2;
            lblTenBacSi.Text = "label3";
            // 
            // lblNgayKham
            // 
            lblNgayKham.AutoSize = true;
            lblNgayKham.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNgayKham.Location = new Point(333, 112);
            lblNgayKham.Name = "lblNgayKham";
            lblNgayKham.Size = new Size(50, 20);
            lblNgayKham.TabIndex = 3;
            lblNgayKham.Text = "label4";
            // 
            // lblLyDo
            // 
            lblLyDo.AutoSize = true;
            lblLyDo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLyDo.Location = new Point(606, 46);
            lblLyDo.Name = "lblLyDo";
            lblLyDo.Size = new Size(50, 20);
            lblLyDo.TabIndex = 4;
            lblLyDo.Text = "label5";
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGhiChu.Location = new Point(606, 112);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(50, 20);
            lblGhiChu.TabIndex = 5;
            lblGhiChu.Text = "label6";
            // 
            // dgvDonThuoc
            // 
            dgvDonThuoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDonThuoc.Location = new Point(101, 219);
            dgvDonThuoc.Name = "dgvDonThuoc";
            dgvDonThuoc.Size = new Size(555, 150);
            dgvDonThuoc.TabIndex = 6;
            // 
            // FormChiTietLichKham
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvDonThuoc);
            Controls.Add(lblGhiChu);
            Controls.Add(lblLyDo);
            Controls.Add(lblNgayKham);
            Controls.Add(lblTenBacSi);
            Controls.Add(lblTenBenhNhan);
            Controls.Add(lblMaLichKham);
            Name = "FormChiTietLichKham";
            Text = "FormChiTietLichKham";
            ((System.ComponentModel.ISupportInitialize)dgvDonThuoc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaLichKham;
        private Label lblTenBenhNhan;
        private Label lblTenBacSi;
        private Label lblNgayKham;
        private Label lblLyDo;
        private Label lblGhiChu;
        private DataGridView dgvDonThuoc;
    }
}