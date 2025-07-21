using Do_An1.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An1.QuanTri.Khám
{
    public partial class FormThemPhieuKham : Form
    {
        public FormThemPhieuKham()
        {
            InitializeComponent();
            LoadBenhNhan();
            LoadBacSi();
        }
        private void LoadBenhNhan()
        {
            string query = "SELECT MaBN, HoTen FROM BenhNhan WHERE TrangThai = 1";
            cmbBenhNhan.DataSource = Connect.ExecuteQuery(query);
            cmbBenhNhan.DisplayMember = "HoTen";
            cmbBenhNhan.ValueMember = "MaBN";
            cmbBenhNhan.SelectedIndex = -1; // Không chọn mục nào ban đầu
        }

        private void LoadBacSi()
        {
            string query = "SELECT MaBS, HoTen FROM BacSi WHERE TrangThai = 1";
            DataTable dt = Connect.ExecuteQuery(query);
            cmbBacSi.DataSource = dt;
            cmbBacSi.DisplayMember = "HoTen";
            cmbBacSi.ValueMember = "MaBS";
            cmbBacSi.SelectedIndex = -1; // Không chọn mục nào ban đầu
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"INSERT INTO LichKham (MaBN, MaBS, NgayKham, GioKham, ThoiGianDuKien, LyDo, TrangThai, GhiChu)
                         VALUES (@MaBN, @MaBS, @NgayKham, @GioKham, @ThoiGianDuKien, @LyDo, @TrangThai, @GhiChu)";

                using (SqlConnection conn = Connect.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaBN", Convert.ToInt32(cmbBenhNhan.SelectedValue));
                    cmd.Parameters.AddWithValue("@MaBS", Convert.ToInt32(cmbBacSi.SelectedValue));
                    cmd.Parameters.AddWithValue("@NgayKham", dtpNgayKham.Value.Date);
                    cmd.Parameters.AddWithValue("@GioKham", new TimeSpan(dtpGioKham.Value.Hour, dtpGioKham.Value.Minute, 0));
                    cmd.Parameters.AddWithValue("@ThoiGianDuKien", nudThoiGian.Value);
                    cmd.Parameters.AddWithValue("@LyDo", txtLyDo.Text.Trim());
                    cmd.Parameters.AddWithValue("@TrangThai", cmbTrangThai.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Đã lập phiếu khám!", "Thông báo");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


    }
}
