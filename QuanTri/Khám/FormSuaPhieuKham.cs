using Do_An1.Helpers;
using Do_An1.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An1.QuanTri.Khám
{
    public partial class FormSuaPhieuKham : Form
    {
        private int maLich;
        public FormSuaPhieuKham(int maLich)
        {
            this.maLich = maLich;
            InitializeComponent();
            LoadBenhNhan();
            LoadBacSi();
            LoadChiTietPhieuKham();
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
        private void LoadChiTietPhieuKham()
        {
            string query = "SELECT * FROM LichKham WHERE MaLichKham = @MaLich";
            SqlParameter[] para = { new SqlParameter("@MaLich", maLich) };
            DataTable dt = Connect.ExecuteQuery(query, para);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                cmbBenhNhan.SelectedValue = row["MaBN"];
                cmbBacSi.SelectedValue = row["MaBS"];
                dtpNgayKham.Value = Convert.ToDateTime(row["NgayKham"]);
                TimeSpan gioKham = (TimeSpan)row["GioKham"];
                dtpGioKham.Value = DateTime.Today.Add(gioKham);
                nudThoiGian.Value = Convert.ToInt32(row["ThoiGianDuKien"]);
                txtLyDo.Text = row["LyDo"].ToString();
                cmbTrangThai.Text = row["TrangThai"].ToString();
                txtGhiChu.Text = row["GhiChu"].ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"UPDATE LichKham 
                         SET MaBN=@MaBN, MaBS=@MaBS, NgayKham=@NgayKham, GioKham=@GioKham, 
                             ThoiGianDuKien=@ThoiGianDuKien, LyDo=@LyDo, TrangThai=@TrangThai, GhiChu=@GhiChu
                         WHERE MaLichKham = @MaLichKham";

                SqlParameter[] prms = {
            new SqlParameter("@MaBN", cmbBenhNhan.SelectedValue),
            new SqlParameter("@MaBS", cmbBacSi.SelectedValue),
            new SqlParameter("@NgayKham", dtpNgayKham.Value.Date),
            new SqlParameter("@GioKham", new TimeSpan(dtpGioKham.Value.Hour, dtpGioKham.Value.Minute, 0)),
            new SqlParameter("@ThoiGianDuKien", nudThoiGian.Value),
            new SqlParameter("@LyDo", txtLyDo.Text.Trim()),
            new SqlParameter("@TrangThai", cmbTrangThai.SelectedItem),
            new SqlParameter("@GhiChu", txtGhiChu.Text.Trim()),
            new SqlParameter("@MaLichKham", maLich) 
        };

                Connect.ExecuteNonQuery(query, prms);
                MessageBox.Show("Đã sửa phiếu khám!", "Thông báo");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

    }
}
