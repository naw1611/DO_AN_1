namespace Do_An1.QuanTri
{
    partial class UcPhanQuyen
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
            cmbVaiTro = new ComboBox();
            label1 = new Label();
            clbQuyen = new CheckedListBox();
            label2 = new Label();
            txtTimKiem = new TextBox();
            label3 = new Label();
            lblThongBao = new Label();
            btnTaiLai = new FontAwesome.Sharp.IconButton();
            btnLuu = new FontAwesome.Sharp.IconButton();
            btnTimKiem = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // cmbVaiTro
            // 
            cmbVaiTro.FormattingEnabled = true;
            cmbVaiTro.Location = new Point(280, 41);
            cmbVaiTro.Name = "cmbVaiTro";
            cmbVaiTro.Size = new Size(121, 23);
            cmbVaiTro.TabIndex = 2;
            cmbVaiTro.SelectedIndexChanged += cmbVaiTro_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(149, 40);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 3;
            label1.Text = "*Vai trò";
            // 
            // clbQuyen
            // 
            clbQuyen.FormattingEnabled = true;
            clbQuyen.Location = new Point(280, 116);
            clbQuyen.Name = "clbQuyen";
            clbQuyen.Size = new Size(504, 238);
            clbQuyen.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(150, 116);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 5;
            label2.Text = "*Quyền";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(621, 41);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(163, 23);
            txtTimKiem.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(528, 44);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 9;
            label3.Text = "*Tìm kiếm";
            // 
            // lblThongBao
            // 
            lblThongBao.AutoSize = true;
            lblThongBao.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblThongBao.Location = new Point(186, 447);
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Size = new Size(52, 21);
            lblThongBao.TabIndex = 11;
            lblThongBao.Text = "label4";
            // 
            // btnTaiLai
            // 
            btnTaiLai.BackColor = Color.Blue;
            btnTaiLai.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTaiLai.ForeColor = Color.White;
            btnTaiLai.IconChar = FontAwesome.Sharp.IconChar.SyncAlt;
            btnTaiLai.IconColor = Color.White;
            btnTaiLai.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnTaiLai.IconSize = 20;
            btnTaiLai.ImageAlign = ContentAlignment.MiddleLeft;
            btnTaiLai.Location = new Point(701, 385);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new Size(83, 33);
            btnTaiLai.TabIndex = 71;
            btnTaiLai.Text = "Tải lại";
            btnTaiLai.TextAlign = ContentAlignment.MiddleRight;
            btnTaiLai.UseVisualStyleBackColor = false;
            btnTaiLai.Click += btnTaiLai_Click;
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
            btnLuu.Location = new Point(280, 385);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(80, 31);
            btnLuu.TabIndex = 72;
            btnLuu.Text = "Lưu";
            btnLuu.TextAlign = ContentAlignment.MiddleRight;
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
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
            btnTimKiem.Location = new Point(484, 387);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(99, 31);
            btnTimKiem.TabIndex = 73;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.TextAlign = ContentAlignment.MiddleRight;
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // UcPhanQuyen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnTimKiem);
            Controls.Add(btnLuu);
            Controls.Add(btnTaiLai);
            Controls.Add(lblThongBao);
            Controls.Add(label3);
            Controls.Add(txtTimKiem);
            Controls.Add(label2);
            Controls.Add(clbQuyen);
            Controls.Add(label1);
            Controls.Add(cmbVaiTro);
            Name = "UcPhanQuyen";
            Size = new Size(1115, 688);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cmbVaiTro;
        private Label label1;
        private CheckedListBox clbQuyen;
        private Label label2;
        private TextBox txtTimKiem;
        private Label label3;
        private Label lblThongBao;
        private FontAwesome.Sharp.IconButton btnTaiLai;
        private FontAwesome.Sharp.IconButton btnLuu;
        private FontAwesome.Sharp.IconButton btnTimKiem;
    }
}
