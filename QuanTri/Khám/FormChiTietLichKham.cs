using Do_An1.Helpers;
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
    public partial class FormChiTietLichKham : Form
    {
        private string _maLichKham;

        public FormChiTietLichKham(string maLichKham)
        {
            InitializeComponent();
            _maLichKham = maLichKham;
            LoadChiTietLichKham();
        }

        private void LoadChiTietLichKham()
        {
            string query = $@"
            SELECT lk.*, bn.HoTen AS TenBenhNhan, bs.HoTen AS TenBacSi
            FROM LichKham lk
            JOIN BenhNhan bn ON lk.MaBN = bn.MaBN
            JOIN BacSi bs ON lk.MaBS = bs.MaBS
            WHERE lk.MaLichKham = '{_maLichKham}'";

            DataTable dt = Connect.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lblMaLichKham.Text = row["MaLichKham"].ToString();
                lblTenBenhNhan.Text = row["TenBenhNhan"].ToString();
                lblTenBacSi.Text = row["TenBacSi"].ToString();
                lblNgayKham.Text = Convert.ToDateTime(row["NgayKham"]).ToString("dd/MM/yyyy");
                lblLyDo.Text = row["LyDo"].ToString();
                lblGhiChu.Text = row["GhiChu"].ToString();
            }

            LoadDonThuoc();
        }

        private void LoadDonThuoc()
        {
            string query = $@"
            SELECT t.TenThuoc, dt.SoLuong, dt.LieuDung, dt.Sang, dt.Trua, dt.Chieu, dt.Toi
            FROM DonThuoc dt
            JOIN HoSoKham hsk ON dt.MaHoSo = hsk.MaHoSo
            JOIN Thuoc t ON dt.MaThuoc = t.MaThuoc
            WHERE hsk.MaLichKham = '{_maLichKham}'";

            dgvDonThuoc.DataSource = Connect.ExecuteQuery(query);
        }
    }

}
