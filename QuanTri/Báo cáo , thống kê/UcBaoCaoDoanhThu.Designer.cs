namespace Do_An1.QuanTri.Báo_cáo___thống_kê
{
    partial class UcBaoCaoDoanhThu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            label2 = new Label();
            btnThongKe = new FontAwesome.Sharp.IconButton();
            cboNam = new ComboBox();
            label1 = new Label();
            label3 = new Label();
            chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            dgvDoanhThu = new DataGridView();
            btnXuatExcel = new FontAwesome.Sharp.IconButton();
            lblTongDoanhThu = new Label();
            ((System.ComponentModel.ISupportInitialize)chartDoanhThu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDoanhThu).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(-145, 109);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 39;
            label2.Text = "Năm";
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
            btnThongKe.Location = new Point(276, 84);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(114, 31);
            btnThongKe.TabIndex = 43;
            btnThongKe.Text = "Thống kê";
            btnThongKe.TextAlign = ContentAlignment.MiddleRight;
            btnThongKe.UseVisualStyleBackColor = false;
            btnThongKe.Click += btnThongKeDoanhThu_Click;
            // 
            // cboNam
            // 
            cboNam.FormattingEnabled = true;
            cboNam.Location = new Point(98, 86);
            cboNam.Name = "cboNam";
            cboNam.Size = new Size(106, 23);
            cboNam.TabIndex = 42;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(29, 89);
            label1.Name = "label1";
            label1.Size = new Size(41, 20);
            label1.TabIndex = 41;
            label1.Text = "Năm";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(302, 45);
            label3.TabIndex = 40;
            label3.Text = "Báo cáo doanh thu";
            // 
            // chartDoanhThu
            // 
            chartArea1.Name = "ChartArea1";
            chartDoanhThu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartDoanhThu.Legends.Add(legend1);
            chartDoanhThu.Location = new Point(260, 153);
            chartDoanhThu.Name = "chartDoanhThu";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartDoanhThu.Series.Add(series1);
            chartDoanhThu.Size = new Size(824, 268);
            chartDoanhThu.TabIndex = 45;
            chartDoanhThu.Text = "chart1";
            // 
            // dgvDoanhThu
            // 
            dgvDoanhThu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDoanhThu.Location = new Point(12, 153);
            dgvDoanhThu.Name = "dgvDoanhThu";
            dgvDoanhThu.Size = new Size(228, 214);
            dgvDoanhThu.TabIndex = 44;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.BackColor = Color.Blue;
            btnXuatExcel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXuatExcel.ForeColor = Color.White;
            btnXuatExcel.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            btnXuatExcel.IconColor = Color.White;
            btnXuatExcel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnXuatExcel.IconSize = 20;
            btnXuatExcel.ImageAlign = ContentAlignment.MiddleLeft;
            btnXuatExcel.Location = new Point(955, 89);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(114, 31);
            btnXuatExcel.TabIndex = 46;
            btnXuatExcel.Text = "Xuất Excel";
            btnXuatExcel.TextAlign = ContentAlignment.MiddleRight;
            btnXuatExcel.UseVisualStyleBackColor = false;
            btnXuatExcel.Click += btnXuatExcelDoanhThu_Click;
            // 
            // lblTongDoanhThu
            // 
            lblTongDoanhThu.AutoSize = true;
            lblTongDoanhThu.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTongDoanhThu.Location = new Point(550, 86);
            lblTongDoanhThu.Name = "lblTongDoanhThu";
            lblTongDoanhThu.Size = new Size(63, 25);
            lblTongDoanhThu.TabIndex = 47;
            lblTongDoanhThu.Text = "label4";
            // 
            // UcBaoCaoDoanhThu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTongDoanhThu);
            Controls.Add(btnXuatExcel);
            Controls.Add(chartDoanhThu);
            Controls.Add(dgvDoanhThu);
            Controls.Add(btnThongKe);
            Controls.Add(cboNam);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "UcBaoCaoDoanhThu";
            Size = new Size(1115, 688);
            ((System.ComponentModel.ISupportInitialize)chartDoanhThu).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDoanhThu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private FontAwesome.Sharp.IconButton btnThongKe;
        private ComboBox cboNam;
        private Label label1;
        private Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private DataGridView dgvDoanhThu;
        private FontAwesome.Sharp.IconButton btnXuatExcel;
        private Label lblTongDoanhThu;
    }
}
