namespace Do_An1
{
    partial class FormDangNhap
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnDN = new Button();
            txtMK = new TextBox();
            txtTenTK = new TextBox();
            label3 = new Label();
            label2 = new Label();
            linkLabelQMK = new LinkLabel();
            label1 = new Label();
            panel1.SuspendLayout();

            // 
            // panel1
            // 
            panel1.Controls.Add(btnDN);
            panel1.Controls.Add(txtMK);
            panel1.Controls.Add(txtTenTK);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(linkLabelQMK);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(116, 40);
            panel1.Name = "panel1";
            panel1.Size = new Size(602, 300);
            panel1.TabIndex = 7;
            // 
            // btnDN
            // 
            btnDN.BackColor = Color.FromArgb(255, 128, 0);
            btnDN.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnDN.ForeColor = Color.White;
            btnDN.Location = new Point(183, 251);
            btnDN.Name = "btnDN";
            btnDN.Size = new Size(104, 31);
            btnDN.TabIndex = 13;
            btnDN.Text = "Đăng nhập";
            btnDN.UseVisualStyleBackColor = false;
            btnDN.Click += btnDN_Click;
            // 
            // txtMK
            // 
            txtMK.ForeColor = Color.Gray;
            txtMK.Location = new Point(183, 186);
            txtMK.Name = "txtMK";
            txtMK.PasswordChar = '*';
            txtMK.Size = new Size(328, 23);
            txtMK.TabIndex = 12;
            // 
            // txtTenTK
            // 
            txtTenTK.ForeColor = Color.Gray;
            txtTenTK.Location = new Point(183, 117);
            txtTenTK.Name = "txtTenTK";
            txtTenTK.Size = new Size(328, 23);
            txtTenTK.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(70, 189);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 10;
            label3.Text = "Mật khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(42, 120);
            label2.Name = "label2";
            label2.Size = new Size(103, 20);
            label2.TabIndex = 9;
            label2.Text = "Tên tài khoản";
            // 
            // linkLabelQMK
            // 
            linkLabelQMK.AutoSize = true;
            linkLabelQMK.BackColor = Color.White;
            linkLabelQMK.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabelQMK.Location = new Point(402, 262);
            linkLabelQMK.Name = "linkLabelQMK";
            linkLabelQMK.Size = new Size(109, 20);
            linkLabelQMK.TabIndex = 8;
            linkLabelQMK.TabStop = true;
            linkLabelQMK.Text = "Quên mật khẩu";
            linkLabelQMK.LinkClicked += linkLabelQMK_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(201, 11);
            label1.Name = "label1";
            label1.Size = new Size(184, 45);
            label1.TabIndex = 7;
            label1.Text = "Đăng nhập";
            // 
            // FormDangNhap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 382);
            Controls.Add(panel1);
            Name = "FormDangNhap";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnDN;
        private TextBox txtMK;
        private TextBox txtTenTK;
        private Label label3;
        private Label label2;
        private LinkLabel linkLabelQMK;
        private Label label1;
    }
}
