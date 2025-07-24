namespace Do_An1.QuanTri.Báo_cáo___thống_kê
{
    partial class UcThongKeHoatDong
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            lblThoiGian = new Label();
            dtpTuNgay = new DateTimePicker();
            dtpDenNgay = new DateTimePicker();
            btnThongKe = new FontAwesome.Sharp.IconButton();
            tabPage = new TabControl();
            tabBacSi = new TabPage();
            lblTongLuotKham = new Label();
            chartBacSi = new System.Windows.Forms.DataVisualization.Charting.Chart();
            dgvBacSi = new DataGridView();
            tabNhanVien = new TabPage();
            lblTongHoaDon = new Label();
            chartNhanVien = new System.Windows.Forms.DataVisualization.Charting.Chart();
            dgvNhanVien = new DataGridView();
            btnXuatExcelHoatDong = new FontAwesome.Sharp.IconButton();
            tabPage.SuspendLayout();
            tabBacSi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartBacSi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBacSi).BeginInit();
            tabNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartNhanVien).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            SuspendLayout();
            // 
            // lblThoiGian
            // 
            lblThoiGian.AutoSize = true;
            lblThoiGian.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblThoiGian.Location = new Point(47, 35);
            lblThoiGian.Name = "lblThoiGian";
            lblThoiGian.Size = new Size(159, 20);
            lblThoiGian.TabIndex = 0;
            lblThoiGian.Text = "Chọn khoảng thời gian";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Location = new Point(246, 32);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(200, 23);
            dtpTuNgay.TabIndex = 1;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Location = new Point(491, 32);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(200, 23);
            dtpDenNgay.TabIndex = 2;
            // 
            // btnThongKe
            // 
            btnThongKe.BackColor = Color.Blue;
            btnThongKe.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThongKe.ForeColor = Color.White;
            btnThongKe.IconChar = FontAwesome.Sharp.IconChar.ChartColumn;
            btnThongKe.IconColor = Color.White;
            btnThongKe.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnThongKe.IconSize = 20;
            btnThongKe.ImageAlign = ContentAlignment.MiddleLeft;
            btnThongKe.Location = new Point(759, 29);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(114, 31);
            btnThongKe.TabIndex = 44;
            btnThongKe.Text = "Thống kê";
            btnThongKe.TextAlign = ContentAlignment.MiddleRight;
            btnThongKe.UseVisualStyleBackColor = false;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // tabPage
            // 
            tabPage.Controls.Add(tabBacSi);
            tabPage.Controls.Add(tabNhanVien);
            tabPage.Location = new Point(18, 95);
            tabPage.Name = "tabPage";
            tabPage.SelectedIndex = 0;
            tabPage.Size = new Size(1094, 545);
            tabPage.TabIndex = 45;
            tabPage.Tag = "";
            // 
            // tabBacSi
            // 
            tabBacSi.Controls.Add(lblTongLuotKham);
            tabBacSi.Controls.Add(chartBacSi);
            tabBacSi.Controls.Add(dgvBacSi);
            tabBacSi.Location = new Point(4, 24);
            tabBacSi.Name = "tabBacSi";
            tabBacSi.Padding = new Padding(3);
            tabBacSi.Size = new Size(1086, 517);
            tabBacSi.TabIndex = 0;
            tabBacSi.Text = "Bác sĩ";
            tabBacSi.UseVisualStyleBackColor = true;
            // 
            // lblTongLuotKham
            // 
            lblTongLuotKham.AutoSize = true;
            lblTongLuotKham.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTongLuotKham.Location = new Point(31, 280);
            lblTongLuotKham.Name = "lblTongLuotKham";
            lblTongLuotKham.Size = new Size(63, 25);
            lblTongLuotKham.TabIndex = 50;
            lblTongLuotKham.Text = "label1";
            // 
            // chartBacSi
            // 
            chartArea3.Name = "ChartArea1";
            chartBacSi.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chartBacSi.Legends.Add(legend3);
            chartBacSi.Location = new Point(358, 42);
            chartBacSi.Name = "chartBacSi";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chartBacSi.Series.Add(series3);
            chartBacSi.Size = new Size(636, 344);
            chartBacSi.TabIndex = 1;
            chartBacSi.Text = "chart1";
            // 
            // dgvBacSi
            // 
            dgvBacSi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBacSi.Location = new Point(31, 42);
            dgvBacSi.Name = "dgvBacSi";
            dgvBacSi.Size = new Size(230, 192);
            dgvBacSi.TabIndex = 0;
            // 
            // tabNhanVien
            // 
            tabNhanVien.Controls.Add(lblTongHoaDon);
            tabNhanVien.Controls.Add(chartNhanVien);
            tabNhanVien.Controls.Add(dgvNhanVien);
            tabNhanVien.Location = new Point(4, 24);
            tabNhanVien.Name = "tabNhanVien";
            tabNhanVien.Padding = new Padding(3);
            tabNhanVien.Size = new Size(1086, 517);
            tabNhanVien.TabIndex = 1;
            tabNhanVien.Text = "Nhân viên";
            tabNhanVien.UseVisualStyleBackColor = true;
            // 
            // lblTongHoaDon
            // 
            lblTongHoaDon.AutoSize = true;
            lblTongHoaDon.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTongHoaDon.Location = new Point(32, 298);
            lblTongHoaDon.Name = "lblTongHoaDon";
            lblTongHoaDon.Size = new Size(63, 25);
            lblTongHoaDon.TabIndex = 49;
            lblTongHoaDon.Text = "label1";
            // 
            // chartNhanVien
            // 
            chartArea4.Name = "ChartArea1";
            chartNhanVien.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            chartNhanVien.Legends.Add(legend4);
            chartNhanVien.Location = new Point(326, 46);
            chartNhanVien.Name = "chartNhanVien";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            chartNhanVien.Series.Add(series4);
            chartNhanVien.Size = new Size(731, 344);
            chartNhanVien.TabIndex = 3;
            chartNhanVien.Text = "chart1";
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Location = new Point(32, 46);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.Size = new Size(246, 181);
            dgvNhanVien.TabIndex = 2;
            // 
            // btnXuatExcelHoatDong
            // 
            btnXuatExcelHoatDong.BackColor = Color.Blue;
            btnXuatExcelHoatDong.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXuatExcelHoatDong.ForeColor = Color.White;
            btnXuatExcelHoatDong.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            btnXuatExcelHoatDong.IconColor = Color.White;
            btnXuatExcelHoatDong.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnXuatExcelHoatDong.IconSize = 20;
            btnXuatExcelHoatDong.ImageAlign = ContentAlignment.MiddleLeft;
            btnXuatExcelHoatDong.Location = new Point(955, 29);
            btnXuatExcelHoatDong.Name = "btnXuatExcelHoatDong";
            btnXuatExcelHoatDong.Size = new Size(114, 31);
            btnXuatExcelHoatDong.TabIndex = 48;
            btnXuatExcelHoatDong.Text = "Xuất Excel";
            btnXuatExcelHoatDong.TextAlign = ContentAlignment.MiddleRight;
            btnXuatExcelHoatDong.UseVisualStyleBackColor = false;
            btnXuatExcelHoatDong.Click += btnXuatExcelHoatDong_Click;
            // 
            // UcThongKeHoatDong
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabPage);
            Controls.Add(btnXuatExcelHoatDong);
            Controls.Add(btnThongKe);
            Controls.Add(dtpDenNgay);
            Controls.Add(dtpTuNgay);
            Controls.Add(lblThoiGian);
            Name = "UcThongKeHoatDong";
            Size = new Size(1115, 688);
            tabPage.ResumeLayout(false);
            tabBacSi.ResumeLayout(false);
            tabBacSi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartBacSi).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBacSi).EndInit();
            tabNhanVien.ResumeLayout(false);
            tabNhanVien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartNhanVien).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblThoiGian;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private FontAwesome.Sharp.IconButton btnThongKe;
        private TabControl tabPage;
        private TabPage tabBacSi;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBacSi;
        private DataGridView dgvBacSi;
        private TabPage tabNhanVien;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNhanVien;
        private DataGridView dgvNhanVien;
        private FontAwesome.Sharp.IconButton btnXuatExcelHoatDong;
        private Label lblTongHoaDon;
        private Label lblTongLuotKham;
    }
}
