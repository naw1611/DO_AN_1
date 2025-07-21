using Do_An1.QuanTri;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using Do_An1.Helpers;
namespace Do_An1
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
            // Đặt nền hình ảnh
            this.BackgroundImage = Image.FromFile("PK.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Cấu hình Panel
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0); // Màu mờ
            panel1.Location = new Point((this.ClientSize.Width - panel1.Width) / 2, (this.ClientSize.Height - panel1.Height) / 2);

        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            string username = txtTenTK.Text.Trim();
            string password = txtMK.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đủ Tên đăng nhập và Mật khẩu!");
                return;
            }

            try
            {
                using (SqlConnection conn = Connect.GetConnection())
                {
                    conn.Open();
                    string sql = @"
                SELECT tk.MaTaiKhoan, tk.VaiTro, tk.MaNhanVien, tk.MaBacSi, tk.MaVaiTro, vt.TenVaiTro
                FROM TaiKhoan tk
                LEFT JOIN VaiTro vt ON tk.MaVaiTro = vt.MaVaiTro
                WHERE tk.TenDangNhap = @TenDangNhap AND tk.MatKhau = @MatKhau AND tk.TrangThai = 1
            ";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@TenDangNhap", username);
                    cmd.Parameters.AddWithValue("@MatKhau", password); // nếu có mã hóa thì thay đổi tại đây

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        SessionDangNhap.MaTaiKhoan = Convert.ToInt32(reader["MaTaiKhoan"]);
                        SessionDangNhap.TenDangNhap = username;
                        SessionDangNhap.VaiTro = reader["VaiTro"].ToString();
                        SessionDangNhap.MaVaiTro = reader["MaVaiTro"] != DBNull.Value ? Convert.ToInt32(reader["MaVaiTro"]) : null;
                        SessionDangNhap.MaNhanVien = reader["MaNhanVien"] != DBNull.Value ? Convert.ToInt32(reader["MaNhanVien"]) : null;
                        SessionDangNhap.MaBacSi = reader["MaBacSi"] != DBNull.Value ? Convert.ToInt32(reader["MaBacSi"]) : null;
                        SessionDangNhap.TenVaiTro = reader["TenVaiTro"].ToString();

                        string vaiTro = reader["VaiTro"].ToString();
                        int maVaiTro = Convert.ToInt32(reader["MaVaiTro"]);

                        MessageBox.Show($"Đăng nhập thành công với vai trò: {vaiTro}", "Thông báo");


                        // Lưu session đăng nhập nếu cần
                        int maTaiKhoan = Convert.ToInt32(reader["MaTaiKhoan"]);
                        string maNV = reader["MaNhanVien"] != DBNull.Value ? reader["MaNhanVien"].ToString() : "";
                        string maBS = reader["MaBacSi"] != DBNull.Value ? reader["MaBacSi"].ToString() : "";

                        this.Hide();

                        // Tuỳ vai trò để mở form phù hợp
                        switch (vaiTro)
                        {
                            case "Quản trị":
                                new FormAdmin(maTaiKhoan, vaiTro).Show();
                                break;
                            //case "Bác sĩ":
                            //    new FormBacSi(maTaiKhoan, maBS).Show();
                            //    break;
                            //case "Nhân viên":
                            //    new FormNhanVien(maTaiKhoan, maNV).Show();
                            //    break;
                            //case "Kế toán":
                            //    new FormKeToan(maTaiKhoan).Show();
                            //    break;
                            default:
                                MessageBox.Show("Không xác định vai trò!", "Lỗi");
                                this.Show();
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Cảnh báo");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi");
            }
        }

        private void linkLabelQMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormQuenMatKhau frm = new FormQuenMatKhau();
            frm.ShowDialog();
        }
    }
}
