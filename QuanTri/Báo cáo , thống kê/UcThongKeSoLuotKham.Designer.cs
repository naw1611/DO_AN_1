namespace Do_An1.QuanTri.Báo_cáo___thống_kê
{
    partial class UcThongKeSoLuotKham
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
            label1 = new Label();
            label2 = new Label();
            cboNam = new ComboBox();
            btnThongKe = new FontAwesome.Sharp.IconButton();
            dgvThongKe = new DataGridView();
            chartThongKe = new System.Windows.Forms.DataVisualization.Charting.Chart();
            btnXuatExcel = new FontAwesome.Sharp.IconButton();
            lblTongLuotKham = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvThongKe).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartThongKe).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(497, 45);
            label1.TabIndex = 0;
            label1.Text = "Thống kê lượt khám theo tháng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(28, 93);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 1;
            label2.Text = "Năm";
            // 
            // cboNam
            // 
            cboNam.FormattingEnabled = true;
            cboNam.Location = new Point(97, 90);
            cboNam.Name = "cboNam";
            cboNam.Size = new Size(106, 23);
            cboNam.TabIndex = 2;
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
            btnThongKe.Location = new Point(275, 88);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(114, 31);
            btnThongKe.TabIndex = 37;
            btnThongKe.Text = "Thống kê";
            btnThongKe.TextAlign = ContentAlignment.MiddleRight;
            btnThongKe.UseVisualStyleBackColor = false;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // dgvThongKe
            // 
            dgvThongKe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThongKe.Location = new Point(12, 135);
            dgvThongKe.Name = "dgvThongKe";
            dgvThongKe.Size = new Size(228, 214);
            dgvThongKe.TabIndex = 38;
            // 
            // chartThongKe
            // 
            chartArea3.Name = "ChartArea1";
            chartThongKe.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chartThongKe.Legends.Add(legend3);
            chartThongKe.Location = new Point(260, 135);
            chartThongKe.Name = "chartThongKe";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chartThongKe.Series.Add(series3);
            chartThongKe.Size = new Size(809, 268);
            chartThongKe.TabIndex = 39;
            chartThongKe.Text = "chart1";
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
            btnXuatExcel.Location = new Point(944, 82);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(114, 31);
            btnXuatExcel.TabIndex = 47;
            btnXuatExcel.Text = "Xuất Excel";
            btnXuatExcel.TextAlign = ContentAlignment.MiddleRight;
            btnXuatExcel.UseVisualStyleBackColor = false;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // lblTongLuotKham
            // 
            lblTongLuotKham.AutoSize = true;
            lblTongLuotKham.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTongLuotKham.Location = new Point(538, 94);
            lblTongLuotKham.Name = "lblTongLuotKham";
            lblTongLuotKham.Size = new Size(63, 25);
            lblTongLuotKham.TabIndex = 48;
            lblTongLuotKham.Text = "label3";
            // 
            // UcThongKeSoLuotKham
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTongLuotKham);
            Controls.Add(btnXuatExcel);
            Controls.Add(chartThongKe);
            Controls.Add(dgvThongKe);
            Controls.Add(btnThongKe);
            Controls.Add(cboNam);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UcThongKeSoLuotKham";
            Size = new Size(1115, 688);
            ((System.ComponentModel.ISupportInitialize)dgvThongKe).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartThongKe).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cboNam;
        private FontAwesome.Sharp.IconButton btnThongKe;
        private DataGridView dgvThongKe;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartThongKe;
        private FontAwesome.Sharp.IconButton btnXuatExcel;
        private Label lblTongLuotKham;
    }
}
