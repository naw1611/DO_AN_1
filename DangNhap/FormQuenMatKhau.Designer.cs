namespace Do_An1
{
    partial class FormQuenMatKhau
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
            panel1 = new Panel();
            btnUpdate = new Button();
            txtMK_New = new TextBox();
            label3 = new Label();
            btnCheck = new Button();
            txtTenTK_Forgot = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(txtMK_New);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnCheck);
            panel1.Controls.Add(txtTenTK_Forgot);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(63, 53);
            panel1.Name = "panel1";
            panel1.Size = new Size(660, 312);
            panel1.TabIndex = 0;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.OrangeRed;
            btnUpdate.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(244, 252);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(98, 31);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtMK_New
            // 
            txtMK_New.Location = new Point(244, 205);
            txtMK_New.Name = "txtMK_New";
            txtMK_New.PasswordChar = '*';
            txtMK_New.Size = new Size(336, 23);
            txtMK_New.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(79, 208);
            label3.Name = "label3";
            label3.Size = new Size(148, 20);
            label3.TabIndex = 5;
            label3.Text = "Nhập mật khẩu mới";
            // 
            // btnCheck
            // 
            btnCheck.BackColor = Color.OrangeRed;
            btnCheck.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnCheck.ForeColor = Color.White;
            btnCheck.Location = new Point(244, 148);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(98, 31);
            btnCheck.TabIndex = 4;
            btnCheck.Text = "Kiểm tra";
            btnCheck.UseVisualStyleBackColor = false;
            btnCheck.Click += btnCheck_Click;
            // 
            // txtTenTK_Forgot
            // 
            txtTenTK_Forgot.Location = new Point(244, 101);
            txtTenTK_Forgot.Name = "txtTenTK_Forgot";
            txtTenTK_Forgot.Size = new Size(336, 23);
            txtTenTK_Forgot.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(79, 104);
            label2.Name = "label2";
            label2.Size = new Size(143, 20);
            label2.TabIndex = 2;
            label2.Text = "Nhập tên tài khoản";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(227, 17);
            label1.Name = "label1";
            label1.Size = new Size(261, 40);
            label1.TabIndex = 1;
            label1.Text = "QUÊN MẬT KHẨU";
            // 
            // FormQuenMatKhau
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(833, 417);
            Controls.Add(panel1);
            Name = "FormQuenMatKhau";
            Text = "FormQuenMatKhau";
            Load += FormQuenMatKhau_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtTenTK_Forgot;
        private Label label2;
        private Label label1;
        private Button btnCheck;
        private Button btnUpdate;
        private TextBox txtMK_New;
        private Label label3;
    }
}