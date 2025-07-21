using Do_An1.Helpers;
using Do_An1.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
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
    public partial class FormChiTietDonThuoc : Form
    {
        private int maHoaDon;

        public FormChiTietDonThuoc(int maHoaDon)
        {
            InitializeComponent();
            this.maHoaDon = maHoaDon;
        }

        private void FormChiTietDonThuoc_Load(object sender, EventArgs e)
        {
            LoadThongTinDonThuoc();
        }

        private void LoadThongTinDonThuoc()
        {
            string queryThongTin = @"
        SELECT hd.MaHoaDon, bn.HoTen, lk.NgayKham
        FROM HoaDon hd
        JOIN BenhNhan bn ON hd.MaBenhNhan = bn.MaBN
        JOIN LichKham lk ON hd.MaLichKham = lk.MaLichKham
        WHERE hd.MaHoaDon = @maHoaDon";

            SqlParameter[] parameters1 = new SqlParameter[]
{
    new SqlParameter("@maHoaDon", maHoaDon)
};
            DataTable dtThongTin = Connect.ExecuteQuery(queryThongTin, parameters1);

            if (dtThongTin.Rows.Count > 0)
            {
                DataRow row = dtThongTin.Rows[0];
                lblMaHoaDon.Text = "Mã HĐ: " + row["MaHoaDon"].ToString();
                lblTenBenhNhan.Text = "Bệnh nhân: " + row["HoTen"].ToString();
                lblNgayKham.Text = "Ngày khám: " + Convert.ToDateTime(row["NgayKham"]).ToString("dd/MM/yyyy");
            }

            string queryThuoc = @"
        SELECT t.TenThuoc, dt.LieuDung, dt.SoLuong, t.DonViTinh, t.DonGiaBan,
               (dt.SoLuong * t.DonGiaBan) AS ThanhTien
        FROM HoaDon hd
        JOIN LichKham lk ON hd.MaLichKham = lk.MaLichKham
        JOIN HoSoKham hsk ON hsk.MaLichKham = lk.MaLichKham
        JOIN DonThuoc dt ON dt.MaHoSo = hsk.MaHoSo
        JOIN Thuoc t ON dt.MaThuoc = t.MaThuoc
        WHERE hd.MaHoaDon = @maHoaDon";

            SqlParameter[] parameters2 = new SqlParameter[]
{
    new SqlParameter("@maHoaDon", maHoaDon)
};
            DataTable dt = Connect.ExecuteQuery(queryThuoc, parameters2);

            dgvChiTietDonThuoc.DataSource = dt;

            decimal tong = 0;
            foreach (DataRow row in dt.Rows)
            {
                tong += Convert.ToDecimal(row["ThanhTien"]);
            }
            lblTongTien.Text = "Tổng tiền thuốc: " + tong.ToString("N0") + " VNĐ";
        }


        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
