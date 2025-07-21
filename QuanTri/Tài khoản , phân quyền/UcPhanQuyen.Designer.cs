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
            btnLuu = new Button();
            btnTaiLai = new Button();
            txtTimKiem = new TextBox();
            label3 = new Label();
            btnTimKiem = new Button();
            lblThongBao = new Label();
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
            // btnLuu
            // 
            btnLuu.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLuu.Location = new Point(280, 384);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(75, 32);
            btnLuu.TabIndex = 6;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnTaiLai
            // 
            btnTaiLai.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTaiLai.Location = new Point(709, 384);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new Size(75, 32);
            btnTaiLai.TabIndex = 7;
            btnTaiLai.Text = "Tải lại";
            btnTaiLai.UseVisualStyleBackColor = true;
            btnTaiLai.Click += btnTaiLai_Click;
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
            // btnTimKiem
            // 
            btnTimKiem.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTimKiem.Location = new Point(489, 384);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(88, 32);
            btnTimKiem.TabIndex = 10;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
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
            // UcPhanQuyen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblThongBao);
            Controls.Add(btnTimKiem);
            Controls.Add(label3);
            Controls.Add(txtTimKiem);
            Controls.Add(btnTaiLai);
            Controls.Add(btnLuu);
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
        private Button btnLuu;
        private Button btnTaiLai;
        private TextBox txtTimKiem;
        private Label label3;
        private Button btnTimKiem;
        private Label lblThongBao;
    }
}
