namespace Do_An1.QuanTri
{
    partial class UcBacSi
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
            btnNext = new Button();
            btnPrev = new Button();
            lblTrang = new Label();
            label2 = new Label();
            dgvBacSi = new DataGridView();
            panel2 = new Panel();
            label8 = new Label();
            rtbGioiThieu = new RichTextBox();
            txtChuyenKhoa = new TextBox();
            txtBangCap = new TextBox();
            label7 = new Label();
            btnLamMoi = new FontAwesome.Sharp.IconButton();
            label6 = new Label();
            btnXoa = new FontAwesome.Sharp.IconButton();
            btnSua = new FontAwesome.Sharp.IconButton();
            btnThem = new FontAwesome.Sharp.IconButton();
            cbTrangThai = new CheckBox();
            label9 = new Label();
            txtSDT = new TextBox();
            label5 = new Label();
            txtEmail = new TextBox();
            label4 = new Label();
            txtHoTen = new TextBox();
            label3 = new Label();
            panel3 = new Panel();
            btnTimKiem = new FontAwesome.Sharp.IconButton();
            txtTimKiem = new TextBox();
            label11 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBacSi).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnNext);
            panel1.Controls.Add(btnPrev);
            panel1.Controls.Add(lblTrang);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dgvBacSi);
            panel1.Location = new Point(13, 370);
            panel1.Name = "panel1";
            panel1.Size = new Size(1085, 305);
            panel1.TabIndex = 1;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(795, 257);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(30, 30);
            btnNext.TabIndex = 8;
            btnNext.Text = ">";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(749, 257);
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
            lblTrang.Location = new Point(675, 261);
            lblTrang.Name = "lblTrang";
            lblTrang.Size = new Size(50, 20);
            lblTrang.TabIndex = 6;
            lblTrang.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(69, 20);
            label2.Name = "label2";
            label2.Size = new Size(157, 21);
            label2.TabIndex = 4;
            label2.Text = "DANH SÁCH BÁC SĨ";
            // 
            // dgvBacSi
            // 
            dgvBacSi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBacSi.Location = new Point(69, 54);
            dgvBacSi.Name = "dgvBacSi";
            dgvBacSi.Size = new Size(849, 182);
            dgvBacSi.TabIndex = 3;
            dgvBacSi.CellClick += dgvBacSi_CellClick;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label8);
            panel2.Controls.Add(rtbGioiThieu);
            panel2.Controls.Add(txtChuyenKhoa);
            panel2.Controls.Add(txtBangCap);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(btnLamMoi);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(btnXoa);
            panel2.Controls.Add(btnSua);
            panel2.Controls.Add(btnThem);
            panel2.Controls.Add(cbTrangThai);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(txtSDT);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtEmail);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtHoTen);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(13, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(688, 340);
            panel2.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(337, 138);
            label8.Name = "label8";
            label8.Size = new Size(79, 20);
            label8.TabIndex = 27;
            label8.Text = "*Giới thiệu";
            // 
            // rtbGioiThieu
            // 
            rtbGioiThieu.Location = new Point(445, 132);
            rtbGioiThieu.Name = "rtbGioiThieu";
            rtbGioiThieu.Size = new Size(224, 96);
            rtbGioiThieu.TabIndex = 26;
            rtbGioiThieu.Text = "";
            // 
            // txtChuyenKhoa
            // 
            txtChuyenKhoa.Location = new Point(445, 34);
            txtChuyenKhoa.Name = "txtChuyenKhoa";
            txtChuyenKhoa.Size = new Size(224, 23);
            txtChuyenKhoa.TabIndex = 7;
            // 
            // txtBangCap
            // 
            txtBangCap.Location = new Point(91, 86);
            txtBangCap.Name = "txtBangCap";
            txtBangCap.Size = new Size(224, 23);
            txtBangCap.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(337, 36);
            label7.Name = "label7";
            label7.Size = new Size(99, 20);
            label7.TabIndex = 6;
            label7.Text = "*Chuyên khoa";
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
            btnLamMoi.Location = new Point(538, 287);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(98, 31);
            btnLamMoi.TabIndex = 25;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.TextAlign = ContentAlignment.MiddleRight;
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(8, 89);
            label6.Name = "label6";
            label6.Size = new Size(77, 20);
            label6.TabIndex = 6;
            label6.Text = "*Bằng cấp";
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
            btnXoa.Location = new Point(378, 287);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(77, 31);
            btnXoa.TabIndex = 24;
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
            btnSua.Location = new Point(216, 287);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(78, 31);
            btnSua.TabIndex = 23;
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
            btnThem.Location = new Point(61, 287);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(80, 31);
            btnThem.TabIndex = 22;
            btnThem.Text = "Thêm";
            btnThem.TextAlign = ContentAlignment.MiddleRight;
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // cbTrangThai
            // 
            cbTrangThai.AutoSize = true;
            cbTrangThai.Location = new Point(300, 202);
            cbTrangThai.Name = "cbTrangThai";
            cbTrangThai.Size = new Size(15, 14);
            cbTrangThai.TabIndex = 15;
            cbTrangThai.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(199, 197);
            label9.Name = "label9";
            label9.Size = new Size(81, 20);
            label9.TabIndex = 12;
            label9.Text = "*Trạng thái";
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(446, 86);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(224, 23);
            txtSDT.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(337, 89);
            label5.Name = "label5";
            label5.Size = new Size(103, 20);
            label5.TabIndex = 6;
            label5.Text = "*Số điện thoại";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(91, 135);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(224, 23);
            txtEmail.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(13, 138);
            label4.Name = "label4";
            label4.Size = new Size(52, 20);
            label4.TabIndex = 4;
            label4.Text = "*Email";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(91, 33);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(224, 23);
            txtHoTen.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(13, 36);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 2;
            label3.Text = "*Họ tên";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(btnTimKiem);
            panel3.Controls.Add(txtTimKiem);
            panel3.Controls.Add(label11);
            panel3.Location = new Point(718, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(380, 148);
            panel3.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.Blue;
            btnTimKiem.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnTimKiem.IconColor = Color.White;
            btnTimKiem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnTimKiem.IconSize = 20;
            btnTimKiem.ImageAlign = ContentAlignment.MiddleLeft;
            btnTimKiem.Location = new Point(126, 85);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(99, 31);
            btnTimKiem.TabIndex = 8;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.TextAlign = ContentAlignment.MiddleRight;
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(126, 32);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(211, 23);
            txtTimKiem.TabIndex = 7;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(44, 35);
            label11.Name = "label11";
            label11.Size = new Size(76, 20);
            label11.TabIndex = 6;
            label11.Text = "*Tìm kiếm";
            // 
            // UcBacSi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UcBacSi";
            Size = new Size(1115, 688);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBacSi).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnNext;
        private Button btnPrev;
        private Label lblTrang;
        private Label label2;
        private DataGridView dgvBacSi;
        private Panel panel2;
        private FontAwesome.Sharp.IconButton btnLamMoi;
        private FontAwesome.Sharp.IconButton btnXoa;
        private FontAwesome.Sharp.IconButton btnSua;
        private FontAwesome.Sharp.IconButton btnThem;
        private CheckBox cbTrangThai;
        private Label label9;
        private TextBox txtSDT;
        private Label label5;
        private TextBox txtEmail;
        private Label label4;
        private TextBox txtHoTen;
        private Label label3;
        private Label label7;
        private Label label6;
        private RadioButton radNu;
        private Label label8;
        private RichTextBox rtbGioiThieu;
        private TextBox txtChuyenKhoa;
        private TextBox txtBangCap;
        private Panel panel3;
        private FontAwesome.Sharp.IconButton btnTimKiem;
        private Label label11;
        private TextBox txtTimKiem;
    }
}
