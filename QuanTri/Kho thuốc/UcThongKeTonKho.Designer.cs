namespace Do_An1.QuanTri.Kho_thuốc
{
    partial class UcThongKeTonKho
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
            chkSoLuongThap = new CheckBox();
            chkCanhBaoHetHan = new CheckBox();
            btnLoc = new FontAwesome.Sharp.IconButton();
            label2 = new Label();
            cboDanhMuc = new ComboBox();
            label1 = new Label();
            cboLoaiThuoc = new ComboBox();
            panel2 = new Panel();
            btnXuatExcel = new FontAwesome.Sharp.IconButton();
            btnNext = new Button();
            btnPrev = new Button();
            lblPage = new Label();
            label4 = new Label();
            dgvTonKho = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTonKho).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(chkSoLuongThap);
            panel1.Controls.Add(chkCanhBaoHetHan);
            panel1.Controls.Add(btnLoc);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cboDanhMuc);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cboLoaiThuoc);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1109, 141);
            panel1.TabIndex = 0;
            // 
            // chkSoLuongThap
            // 
            chkSoLuongThap.AutoSize = true;
            chkSoLuongThap.Location = new Point(507, 84);
            chkSoLuongThap.Name = "chkSoLuongThap";
            chkSoLuongThap.Size = new Size(100, 19);
            chkSoLuongThap.TabIndex = 73;
            chkSoLuongThap.Text = "Số lượng thấp";
            chkSoLuongThap.UseVisualStyleBackColor = true;
            // 
            // chkCanhBaoHetHan
            // 
            chkCanhBaoHetHan.AutoSize = true;
            chkCanhBaoHetHan.Location = new Point(277, 84);
            chkCanhBaoHetHan.Name = "chkCanhBaoHetHan";
            chkCanhBaoHetHan.Size = new Size(120, 19);
            chkCanhBaoHetHan.TabIndex = 72;
            chkCanhBaoHetHan.Text = "Cảnh báo hết hạn";
            chkCanhBaoHetHan.UseVisualStyleBackColor = true;
            // 
            // btnLoc
            // 
            btnLoc.BackColor = Color.Blue;
            btnLoc.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLoc.ForeColor = Color.White;
            btnLoc.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnLoc.IconColor = Color.White;
            btnLoc.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLoc.IconSize = 20;
            btnLoc.ImageAlign = ContentAlignment.MiddleLeft;
            btnLoc.Location = new Point(884, 18);
            btnLoc.Name = "btnLoc";
            btnLoc.Size = new Size(77, 31);
            btnLoc.TabIndex = 71;
            btnLoc.Text = "Lọc";
            btnLoc.TextAlign = ContentAlignment.MiddleRight;
            btnLoc.UseVisualStyleBackColor = false;
            btnLoc.Click += btnLoc_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(507, 22);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 3;
            label2.Text = "Danh mục";
            // 
            // cboDanhMuc
            // 
            cboDanhMuc.FormattingEnabled = true;
            cboDanhMuc.Location = new Point(600, 22);
            cboDanhMuc.Name = "cboDanhMuc";
            cboDanhMuc.Size = new Size(214, 23);
            cboDanhMuc.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(173, 23);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 1;
            label1.Text = "Loại thuốc";
            // 
            // cboLoaiThuoc
            // 
            cboLoaiThuoc.FormattingEnabled = true;
            cboLoaiThuoc.Location = new Point(266, 23);
            cboLoaiThuoc.Name = "cboLoaiThuoc";
            cboLoaiThuoc.Size = new Size(209, 23);
            cboLoaiThuoc.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btnXuatExcel);
            panel2.Controls.Add(btnNext);
            panel2.Controls.Add(btnPrev);
            panel2.Controls.Add(lblPage);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(dgvTonKho);
            panel2.Location = new Point(3, 170);
            panel2.Name = "panel2";
            panel2.Size = new Size(1109, 381);
            panel2.TabIndex = 1;
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
            btnXuatExcel.Location = new Point(926, 328);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(114, 31);
            btnXuatExcel.TabIndex = 36;
            btnXuatExcel.Text = "Xuất Excel";
            btnXuatExcel.TextAlign = ContentAlignment.MiddleRight;
            btnXuatExcel.UseVisualStyleBackColor = false;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(1022, 267);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(30, 30);
            btnNext.TabIndex = 13;
            btnNext.Text = ">";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(986, 267);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(30, 30);
            btnPrev.TabIndex = 12;
            btnPrev.Text = "<";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // lblPage
            // 
            lblPage.AutoSize = true;
            lblPage.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPage.Location = new Point(906, 271);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(50, 20);
            lblPage.TabIndex = 11;
            lblPage.Text = "label1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(56, 39);
            label4.Name = "label4";
            label4.Size = new Size(239, 21);
            label4.TabIndex = 10;
            label4.Text = "DANH SÁCH THUỐC TỒN KHO";
            // 
            // dgvTonKho
            // 
            dgvTonKho.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTonKho.Location = new Point(56, 73);
            dgvTonKho.Name = "dgvTonKho";
            dgvTonKho.Size = new Size(777, 218);
            dgvTonKho.TabIndex = 9;
            // 
            // UcThongKeTonKho
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UcThongKeTonKho";
            Size = new Size(1115, 688);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTonKho).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private ComboBox cboLoaiThuoc;
        private Label label2;
        private ComboBox cboDanhMuc;
        private CheckBox chkSoLuongThap;
        private CheckBox chkCanhBaoHetHan;
        private FontAwesome.Sharp.IconButton btnLoc;
        private Panel panel2;
        private Button btnNext;
        private Button btnPrev;
        private Label lblPage;
        private Label label4;
        private DataGridView dgvTonKho;
        private FontAwesome.Sharp.IconButton btnXuatExcel;
    }
}
