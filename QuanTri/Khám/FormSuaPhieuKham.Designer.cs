namespace Do_An1.QuanTri.Khám
{
    partial class FormSuaPhieuKham
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
            label8 = new Label();
            txtGhiChu = new TextBox();
            label7 = new Label();
            cmbTrangThai = new ComboBox();
            label6 = new Label();
            txtLyDo = new TextBox();
            label5 = new Label();
            nudThoiGian = new NumericUpDown();
            label4 = new Label();
            dtpGioKham = new DateTimePicker();
            label3 = new Label();
            cmbBacSi = new ComboBox();
            dtpNgayKham = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            cmbBenhNhan = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)nudThoiGian).BeginInit();
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
            btnLuu.Location = new Point(169, 287);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(80, 31);
            btnLuu.TabIndex = 67;
            btnLuu.Text = "Lưu";
            btnLuu.TextAlign = ContentAlignment.MiddleRight;
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(430, 207);
            label8.Name = "label8";
            label8.Size = new Size(64, 20);
            label8.TabIndex = 66;
            label8.Text = "*Ghi chú";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(511, 207);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(209, 23);
            txtGhiChu.TabIndex = 65;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(65, 210);
            label7.Name = "label7";
            label7.Size = new Size(81, 20);
            label7.TabIndex = 64;
            label7.Text = "*Trạng thái";
            // 
            // cmbTrangThai
            // 
            cmbTrangThai.FormattingEnabled = true;
            cmbTrangThai.Items.AddRange(new object[] { "Đặt lịch", "Xác nhận", "Hoàn tất", "Hủy", "Không đến" });
            cmbTrangThai.Location = new Point(169, 207);
            cmbTrangThai.Name = "cmbTrangThai";
            cmbTrangThai.Size = new Size(209, 23);
            cmbTrangThai.TabIndex = 63;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(441, 151);
            label6.Name = "label6";
            label6.Size = new Size(50, 20);
            label6.TabIndex = 62;
            label6.Text = "*Lý do";
            // 
            // txtLyDo
            // 
            txtLyDo.Location = new Point(511, 153);
            txtLyDo.Name = "txtLyDo";
            txtLyDo.Size = new Size(209, 23);
            txtLyDo.TabIndex = 61;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(65, 156);
            label5.Name = "label5";
            label5.Size = new Size(130, 20);
            label5.TabIndex = 60;
            label5.Text = "*Thời gian dự kiến";
            // 
            // nudThoiGian
            // 
            nudThoiGian.Location = new Point(210, 153);
            nudThoiGian.Name = "nudThoiGian";
            nudThoiGian.Size = new Size(120, 23);
            nudThoiGian.TabIndex = 59;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(416, 103);
            label4.Name = "label4";
            label4.Size = new Size(78, 20);
            label4.TabIndex = 58;
            label4.Text = "*Giờ khám";
            // 
            // dtpGioKham
            // 
            dtpGioKham.CustomFormat = "HH:mm ";
            dtpGioKham.Format = DateTimePickerFormat.Custom;
            dtpGioKham.Location = new Point(511, 103);
            dtpGioKham.Name = "dtpGioKham";
            dtpGioKham.ShowUpDown = true;
            dtpGioKham.Size = new Size(89, 23);
            dtpGioKham.TabIndex = 57;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(65, 103);
            label3.Name = "label3";
            label3.Size = new Size(90, 20);
            label3.TabIndex = 56;
            label3.Text = "*Ngày khám";
            // 
            // cmbBacSi
            // 
            cmbBacSi.FormattingEnabled = true;
            cmbBacSi.Location = new Point(511, 43);
            cmbBacSi.Name = "cmbBacSi";
            cmbBacSi.Size = new Size(209, 23);
            cmbBacSi.TabIndex = 55;
            // 
            // dtpNgayKham
            // 
            dtpNgayKham.Location = new Point(169, 103);
            dtpNgayKham.Name = "dtpNgayKham";
            dtpNgayKham.Size = new Size(209, 23);
            dtpNgayKham.TabIndex = 54;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(441, 46);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 53;
            label2.Text = "*Bác sĩ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(65, 46);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 52;
            label1.Text = "*Bệnh nhân";
            // 
            // cmbBenhNhan
            // 
            cmbBenhNhan.FormattingEnabled = true;
            cmbBenhNhan.Location = new Point(169, 43);
            cmbBenhNhan.Name = "cmbBenhNhan";
            cmbBenhNhan.Size = new Size(209, 23);
            cmbBenhNhan.TabIndex = 51;
            // 
            // FormSuaPhieuKham
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 361);
            Controls.Add(btnLuu);
            Controls.Add(label8);
            Controls.Add(txtGhiChu);
            Controls.Add(label7);
            Controls.Add(cmbTrangThai);
            Controls.Add(label6);
            Controls.Add(txtLyDo);
            Controls.Add(label5);
            Controls.Add(nudThoiGian);
            Controls.Add(label4);
            Controls.Add(dtpGioKham);
            Controls.Add(label3);
            Controls.Add(cmbBacSi);
            Controls.Add(dtpNgayKham);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbBenhNhan);
            Name = "FormSuaPhieuKham";
            Text = "FormSuaPhieuKham";
            ((System.ComponentModel.ISupportInitialize)nudThoiGian).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnLuu;
        private Label label8;
        private TextBox txtGhiChu;
        private Label label7;
        private ComboBox cmbTrangThai;
        private Label label6;
        private TextBox txtLyDo;
        private Label label5;
        private NumericUpDown nudThoiGian;
        private Label label4;
        private DateTimePicker dtpGioKham;
        private Label label3;
        private ComboBox cmbBacSi;
        private DateTimePicker dtpNgayKham;
        private Label label2;
        private Label label1;
        private ComboBox cmbBenhNhan;
    }
}