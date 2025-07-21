using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Do_An1.Helpers;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Math;
using Microsoft.Data.SqlClient;

namespace Do_An1.QuanTri.Khám
{
    public partial class UcTraCuuLich : UserControl
    {
        private int limit = 10;
        private int offset = 0;
        private int totalRecords = 0;
        public UcTraCuuLich()
        {
            InitializeComponent();
            LoadDanhSachLichKham();
        }


        private void LoadDanhSachLichKham()
        {
            DataGridViewButtonColumn btnChiTiet = new DataGridViewButtonColumn();
            btnChiTiet.HeaderText = "Chi tiết";
            btnChiTiet.Text = "Chi tiết";
            btnChiTiet.UseColumnTextForButtonValue = true;
            btnChiTiet.Name = "btnChiTiet";
            dgvLichKham.Columns.Add(btnChiTiet);
            // Đếm tổng số bản ghi
            string countQuery = @"SELECT COUNT(*) FROM LichKham lk
                                 JOIN BenhNhan bn ON lk.MaBN = bn.MaBN
                                 JOIN BacSi bs ON lk.MaBS = bs.MaBS";
            totalRecords = (int)Connect.ExecuteScalar(countQuery);

            // Truy vấn phân trang
            string query = @"
                SELECT lk.MaLichKham, bn.HoTen AS TenBenhNhan, bs.HoTen AS TenBacSi, lk.NgayKham, lk.GioKham, 
                       lk.ThoiGianDuKien, lk.LyDo, lk.TrangThai, lk.NgayTao, lk.GhiChu
                FROM LichKham lk
                JOIN BenhNhan bn ON lk.MaBN = bn.MaBN
                JOIN BacSi bs ON lk.MaBS = bs.MaBS
                WHERE (lk.MaBS = @MaBS OR @MaBS IS NULL)
                  AND (lk.MaBN = @MaBN OR @MaBN IS NULL)
                  AND (lk.TrangThai = @TrangThai OR @TrangThai IS NULL)
                  AND (lk.NgayKham = @NgayKham OR @NgayKham IS NULL)
                ORDER BY lk.NgayKham DESC, lk.GioKham
                OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            SqlParameter[] prms = new SqlParameter[]
{
    new SqlParameter("@MaBS", DBNull.Value),
    new SqlParameter("@MaBN", DBNull.Value),
    new SqlParameter("@TrangThai", DBNull.Value),
    new SqlParameter("@NgayKham", DBNull.Value),
    new SqlParameter("@Offset", offset),
    new SqlParameter("@PageSize", limit)
};

            try
            {
                DataTable dt = Connect.ExecuteQuery(query, prms);
                dgvLichKham.DataSource = dt != null && dt.Rows.Count > 0 ? dt : new DataTable();
                lblPage.Text = $"Trang {(offset / limit) + 1} / {Math.Ceiling(totalRecords / (double)limit)}";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}\nStackTrace: {ex.StackTrace}");
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TraCuuLichKham()
        {
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();
            string trangThai = cmbTrangThai.SelectedItem?.ToString();
            DateTime? tuNgay = dtpTuNgay.Checked ? dtpTuNgay.Value.Date : null;
            DateTime? denNgay = dtpDenNgay.Checked ? dtpDenNgay.Value.Date : null;

            string query = @"
        SELECT lk.MaLichKham, bn.HoTen AS TenBenhNhan, bs.HoTen AS TenBacSi,
               lk.NgayKham, lk.GioKham, lk.ThoiGianDuKien,
               lk.LyDo, lk.TrangThai, lk.NgayTao, lk.GhiChu
        FROM LichKham lk
        JOIN BenhNhan bn ON lk.MaBN = bn.MaBN
        JOIN BacSi bs ON lk.MaBS = bs.MaBS
        WHERE (@TrangThai IS NULL OR lk.TrangThai = @TrangThai)
          AND (@TuNgay IS NULL OR lk.NgayKham >= @TuNgay)
          AND (@DenNgay IS NULL OR lk.NgayKham <= @DenNgay)
          AND (
                @TuKhoa IS NULL OR 
                LOWER(bn.HoTen) LIKE '%' + @TuKhoa + '%' OR 
                LOWER(bs.HoTen) LIKE '%' + @TuKhoa + '%'
              )
        ORDER BY lk.NgayKham DESC, lk.GioKham";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@TrangThai", string.IsNullOrEmpty(trangThai) || trangThai == "Tất cả" ? DBNull.Value : (object)trangThai),
        new SqlParameter("@TuNgay", tuNgay.HasValue ? (object)tuNgay : DBNull.Value),
        new SqlParameter("@DenNgay", denNgay.HasValue ? (object)denNgay : DBNull.Value),
        new SqlParameter("@TuKhoa", string.IsNullOrWhiteSpace(tuKhoa) ? DBNull.Value : (object)tuKhoa)
            };

            try
            {
                DataTable dt = Connect.ExecuteQuery(query, parameters);
                dgvLichKham.DataSource = dt ?? new DataTable();
                lblPage.Text = $"Số kết quả: {dt?.Rows.Count ?? 0}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (offset + limit < totalRecords)
            {
                offset += limit;
                LoadDanhSachLichKham();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (offset - limit >= 0)
            {
                offset -= limit;
                LoadDanhSachLichKham();
            }
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            TraCuuLichKham();
        }



        private void dgvLichKham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0
    && e.ColumnIndex >= 0
    && e.ColumnIndex < dgvLichKham.Columns.Count
    && dgvLichKham.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string maLichKham = dgvLichKham.Rows[e.RowIndex].Cells["MaLichKham"].Value.ToString();
                FormChiTietLichKham frm = new FormChiTietLichKham(maLichKham);
                frm.ShowDialog(); 
            }
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            dtpTuNgay.Value = DateTime.Now.Date;
            dtpTuNgay.Checked = false;
            dtpDenNgay.Value = DateTime.Now.Date;
            dtpDenNgay.Checked = false;
            cmbTrangThai.SelectedIndex = -1;
            offset = 0; // Reset phân trang
            LoadDanhSachLichKham();
        }
    }
}

