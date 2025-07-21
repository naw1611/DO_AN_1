using System;
using System.Data;
using System.Windows.Forms;
using Do_An1.Helpers;
using Do_An1.Models;
using Do_An1.QuanTri.Danh_mục;
using Microsoft.Data.SqlClient;

namespace Do_An1.QuanTri.Khám
{
    public partial class UcLapPhieu : UserControl
    {
        private int limit = 10;
        private int offset = 0;
        private int totalRecords = 0;

        public UcLapPhieu()
        {
            InitializeComponent();
            LoadBenhNhan();
            LoadBacSi();
            LoadDanhSachLichKham();
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

        private void LoadDanhSachLichKham()
        {
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
                dgvPhieuKham.DataSource = dt != null && dt.Rows.Count > 0 ? dt : new DataTable();
                lblPage.Text = $"Trang {(offset / limit) + 1} / {Math.Ceiling(totalRecords / (double)limit)}";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}\nStackTrace: {ex.StackTrace}");
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LamMoiForm()
        {
            cmbBenhNhan.SelectedIndex = -1;
            cmbBacSi.SelectedIndex = -1;
            dtpNgayKham.Value = DateTime.Now.Date;
            dtpNgayKham.Checked = false;
            cmbTrangThai.SelectedIndex = -1;
            offset = 0; // Reset phân trang
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
            LoadDanhSachLichKham();
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

        private void TraCuuPhieuKham()
        {
            // Đếm tổng số bản ghi
            string countQuery = @"
                SELECT COUNT(*) 
                FROM LichKham lk
                JOIN BenhNhan bn ON lk.MaBN = bn.MaBN
                JOIN BacSi bs ON lk.MaBS = bs.MaBS
                WHERE (lk.MaBS = @MaBS OR @MaBS IS NULL)
                  AND (lk.MaBN = @MaBN OR @MaBN IS NULL)
                  AND (lk.TrangThai = @TrangThai OR @TrangThai IS NULL)
                  AND (lk.NgayKham = @NgayKham OR @NgayKham IS NULL)";
            SqlParameter[] countParams = new SqlParameter[]
            {
                new SqlParameter("@MaBS", (object)cmbBacSi.SelectedValue ?? DBNull.Value),
                new SqlParameter("@MaBN", (object)cmbBenhNhan.SelectedValue ?? DBNull.Value),
                new SqlParameter("@TrangThai", string.IsNullOrEmpty(cmbTrangThai.SelectedItem?.ToString()) ? DBNull.Value : (object)cmbTrangThai.SelectedItem.ToString()),
                new SqlParameter("@NgayKham", dtpNgayKham.Checked ? (object)dtpNgayKham.Value.Date : DBNull.Value)
            };
            totalRecords = (int)Connect.ExecuteScalar(countQuery, countParams);

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

            int? maBS = cmbBacSi.SelectedValue != null ? (int?)cmbBacSi.SelectedValue : null;
            int? maBN = cmbBenhNhan.SelectedValue != null ? (int?)cmbBenhNhan.SelectedValue : null;
            string trangThai = cmbTrangThai.SelectedItem?.ToString();
            DateTime? ngayKham = dtpNgayKham.Checked ? (DateTime?)dtpNgayKham.Value.Date : null;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaBS", (object)maBS ?? DBNull.Value),
                new SqlParameter("@MaBN", (object)maBN ?? DBNull.Value),
                new SqlParameter("@TrangThai", string.IsNullOrEmpty(trangThai) ? DBNull.Value : (object)trangThai),
                new SqlParameter("@NgayKham", ngayKham.HasValue ? (object)ngayKham.Value : DBNull.Value),
                new SqlParameter("@Offset", offset),
                new SqlParameter("@PageSize", limit)
            };

            try
            {
                DataTable dt = Connect.ExecuteQuery(query, parameters);
                dgvPhieuKham.DataSource = dt != null && dt.Rows.Count > 0 ? dt : new DataTable();
                lblPage.Text = $"Trang {(offset / limit) + 1} / {Math.Ceiling(totalRecords / (double)limit)}";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}\nStackTrace: {ex.StackTrace}");
                MessageBox.Show("Lỗi truy vấn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            offset = 0; // Reset phân trang khi tra cứu
            TraCuuPhieuKham();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            new FormThemPhieuKham().ShowDialog();
            LoadDanhSachLichKham();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvPhieuKham.CurrentRow == null) return;
            int maLich = Convert.ToInt32(dgvPhieuKham.CurrentRow.Cells["MaLichKham"].Value);
            new FormSuaPhieuKham(maLich).ShowDialog();
            LoadDanhSachLichKham();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvPhieuKham.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 phiếu khám để xóa!");
                return;
            }

            string maPK = dgvPhieuKham.SelectedRows[0].Cells["MaLichKham"].Value.ToString();

            DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy phiếu khám này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string query = "UPDATE LichKham SET TrangThai = N'Đã hủy' WHERE MaLichKham = @MaLich";
                SqlParameter[] parameters = {
            new SqlParameter("@MaLich", maPK)
        };

                try
                {
                    int affected = Connect.ExecuteNonQuery(query, parameters);
                    if (affected > 0)
                    {
                        MessageBox.Show("Đã hủy phiếu khám thành công!");
                        LoadDanhSachLichKham();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy phiếu khám để hủy!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }

    }
}