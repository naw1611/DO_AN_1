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
using Microsoft.Data.SqlClient;

namespace Do_An1.QuanTri
{
    public partial class UcNhanVien : UserControl
    {
        public UcNhanVien()
        {
            InitializeComponent();
            LoadDanhSachNhanVien();
            dgvNhanVien.Height = dgvNhanVien.Rows.GetRowsHeight(DataGridViewElementStates.Visible)
                        + dgvNhanVien.ColumnHeadersHeight;
        }

        private int maNVDangChon = -1;
        private int pageSize = 5;
        private int currentPage = 1;
        private int totalRecords = 0;
        private int totalPages = 0;

        private void LoadDanhSachNhanVien()
        {
            int offset = (currentPage - 1) * pageSize;

            string countQuery = "SELECT COUNT(*) FROM NhanVien WHERE TrangThai = 1";
            totalRecords = Convert.ToInt32(Connect.ExecuteScalar(countQuery));
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            string query = @"
        SELECT * FROM NhanVien
        WHERE TrangThai = 1
        ORDER BY MaNV
        OFFSET @Offset ROWS
        FETCH NEXT @PageSize ROWS ONLY";

            SqlParameter[] prms = {
        new SqlParameter("@Offset", offset),
        new SqlParameter("@PageSize", pageSize)
    };

            dgvNhanVien.DataSource = Connect.ExecuteQuery(query, prms);
            lblTrang.Text = $"Trang {currentPage}/{totalPages}";
        }
        private void ResetForm()
        {
            maNVDangChon = -1;
            txtHoTen.Clear();
            txtEmail.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            cmbChucVu.SelectedIndex = -1;
            dtpNgayVaoLam.Value = DateTime.Now;
            cbTrangThai.Checked = false;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                maNVDangChon = Convert.ToInt32(row.Cells["MaNV"].Value);
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                cmbChucVu.Text = row.Cells["ChucVu"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                dtpNgayVaoLam.Value = Convert.ToDateTime(row.Cells["NgayVaoLam"].Value);
                cbTrangThai.Checked = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            string chucVu = cmbChucVu.Text;
            string email = txtEmail.Text;
            string sdt = txtSDT.Text;
            string diaChi = txtDiaChi.Text;
            DateTime ngayVao = dtpNgayVaoLam.Value;

            string query = @"
            INSERT INTO NhanVien (HoTen, ChucVu, Email, SoDienThoai, DiaChi, NgayVaoLam, TrangThai)
            VALUES (@HoTen, @ChucVu, @Email, @SDT, @DiaChi, @NgayVao, 1)";
            SqlParameter[] prms = {
            new SqlParameter("@HoTen", hoTen),
            new SqlParameter("@ChucVu", chucVu),
            new SqlParameter("@Email", email),
            new SqlParameter("@SDT", sdt),
            new SqlParameter("@DiaChi", diaChi),
            new SqlParameter("@NgayVao", ngayVao)
        };

            Connect.ExecuteNonQuery(query, prms);
            LoadDanhSachNhanVien();
            MessageBox.Show("Thêm nhân viên thành công!");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            string query = @"SELECT * FROM NhanVien WHERE TrangThai = 1 AND (HoTen LIKE @kw OR ChucVu LIKE @kw)";
            dgvNhanVien.DataSource = Connect.ExecuteQuery(query, new SqlParameter("@kw", "%" + keyword + "%"));
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (maNVDangChon == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!");
                return;
            }

            string hoTen = txtHoTen.Text.Trim();
            string chucVu = cmbChucVu.Text.Trim();
            string email = txtEmail.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            DateTime ngayVao = dtpNgayVaoLam.Value;

            string query = @"
        UPDATE NhanVien 
        SET HoTen = @HoTen, ChucVu = @ChucVu, Email = @Email, SoDienThoai = @SDT,
            DiaChi = @DiaChi, NgayVaoLam = @NgayVao
        WHERE MaNV = @MaNV";

            SqlParameter[] prms = {
        new SqlParameter("@HoTen", hoTen),
        new SqlParameter("@ChucVu", chucVu),
        new SqlParameter("@Email", email),
        new SqlParameter("@SDT", sdt),
        new SqlParameter("@DiaChi", diaChi),
        new SqlParameter("@NgayVao", ngayVao),
        new SqlParameter("@MaNV", maNVDangChon)
    };

            Connect.ExecuteNonQuery(query, prms);
            MessageBox.Show("Cập nhật nhân viên thành công!");
            LoadDanhSachNhanVien();
            ResetForm();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maNVDangChon == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!");
                return;
            }

            DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (rs == DialogResult.No) return;

            string query = "UPDATE NhanVien SET TrangThai = 0 WHERE MaNV = @MaNV";
            Connect.ExecuteNonQuery(query, new SqlParameter("@MaNV", maNVDangChon));

            MessageBox.Show("Đã xóa nhân viên!");
            LoadDanhSachNhanVien();
            ResetForm();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
            LoadDanhSachNhanVien();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadDanhSachNhanVien();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadDanhSachNhanVien();
            }
        }
    }

}
