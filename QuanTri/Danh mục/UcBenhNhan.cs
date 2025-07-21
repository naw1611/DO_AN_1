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
using System.Drawing.Printing;

namespace Do_An1.QuanTri
{
    public partial class UcBenhNhan : UserControl
    {
        public UcBenhNhan()
        {
            InitializeComponent();
            LoadDanhSachBenhNhan();
            dgvBenhNhan.Height = dgvBenhNhan.Rows.GetRowsHeight(DataGridViewElementStates.Visible)
                        + dgvBenhNhan.ColumnHeadersHeight;
        }

        private int maBenhNhanDangChon = -1;
        private int pageSize = 5;
        private int currentPage = 1;
        private int totalRecords = 0;
        private int totalPages = 0;

        private void LoadDanhSachBenhNhan()
        {
            int offset = (currentPage - 1) * pageSize;

            string countQuery = "SELECT COUNT(*) FROM BenhNhan WHERE TrangThai = 1";
            totalRecords = Convert.ToInt32(Connect.ExecuteScalar(countQuery));
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            string query = @"
        SELECT * FROM BenhNhan
        WHERE TrangThai = 1
        ORDER BY MaBN
        OFFSET @Offset ROWS
        FETCH NEXT @PageSize ROWS ONLY";

            SqlParameter[] prms = {
        new SqlParameter("@Offset", offset),
        new SqlParameter("@PageSize", pageSize)
    };
            dgvBenhNhan.DataSource = Connect.ExecuteQuery(query, prms);
            lblTrang.Text = $"Trang {currentPage}/{totalPages}";
        }

        private void ResetForm()
        {
            maBenhNhanDangChon = -1;
            txtHoTen.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtNgheNghiep.Clear();
            rtbTienSu.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            dtpNgayDangKy.Value = DateTime.Now;
            cboGioiTinh.SelectedIndex = 0;
            cbTrangThai.Checked = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql = @"
        INSERT INTO BenhNhan (HoTen, NgaySinh, GioiTinh, SoDienThoai, Email, DiaChi, TienSuBenh, NgheNghiep ,NgayDangKy)
        VALUES (@HoTen, @NgaySinh, @GioiTinh, @SDT, @Email, @DiaChi, @TienSu, @Nghe , @NgayDangKy)";

            SqlParameter[] prms = {
        new("@HoTen", txtHoTen.Text.Trim()),
        new("@NgaySinh", dtpNgaySinh.Value),
        new("@GioiTinh", cboGioiTinh.SelectedItem.ToString() == "Nam" ? "M" : "F"),
        new("@SDT", txtSDT.Text.Trim()),
        new("@Email", txtEmail.Text.Trim()),
        new("@DiaChi", txtDiaChi.Text.Trim()),
        new("@TienSu", rtbTienSu.Text.Trim()),
        new("@Nghe", txtNgheNghiep.Text.Trim()),
        new("@NgayDangKy", dtpNgayDangKy.Value)
    };

            Connect.ExecuteNonQuery(sql, prms);
            MessageBox.Show("Thêm thành công!");
            ResetForm();
            LoadDanhSachBenhNhan();
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (maBenhNhanDangChon == -1)
            {
                MessageBox.Show("Chọn bệnh nhân để sửa!");
                return;
            }

            string sql = @"
        UPDATE BenhNhan
        SET HoTen=@HoTen, NgaySinh=@NgaySinh, GioiTinh=@GioiTinh,
            SoDienThoai=@SDT, Email=@Email, DiaChi=@DiaChi, TienSuBenh=@TienSu, NgheNghiep=@Nghe , NgayDangKy=@NgayDangKy
        WHERE MaBN=@MaBN";

            SqlParameter[] prms = {
        new("@HoTen", txtHoTen.Text.Trim()),
        new("@NgaySinh", dtpNgaySinh.Value),
        new("@GioiTinh", cboGioiTinh.Text == "Nam" ? "M" : "F"),
        new("@SDT", txtSDT.Text.Trim()),
        new("@Email", txtEmail.Text.Trim()),
        new("@DiaChi", txtDiaChi.Text.Trim()),
        new("@TienSu", rtbTienSu.Text.Trim()),
        new("@Nghe", txtNgheNghiep.Text.Trim()),
        new("@NgayDangKy", dtpNgayDangKy.Value),
        new("@MaBN", maBenhNhanDangChon)
    };

            Connect.ExecuteNonQuery(sql, prms);
            MessageBox.Show("Sửa thành công!");
            ResetForm();
            LoadDanhSachBenhNhan();
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maBenhNhanDangChon == -1) return;

            DialogResult confirm = MessageBox.Show("Xác nhận xóa?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                string sql = "UPDATE BenhNhan SET TrangThai = 0 WHERE MaBN = @MaBN";
                Connect.ExecuteNonQuery(sql, new SqlParameter("@MaBN", maBenhNhanDangChon));
                MessageBox.Show("Đã xóa bệnh nhân.");
                ResetForm();
                LoadDanhSachBenhNhan();
            }
        }


        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
            LoadDanhSachBenhNhan();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            string query = @"SELECT * FROM BenhNhan WHERE TrangThai = 1 AND (HoTen LIKE @kw OR SoDienThoai LIKE @kw)";
            dgvBenhNhan.DataSource = Connect.ExecuteQuery(query, new SqlParameter("@kw", "%" + keyword + "%"));
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadDanhSachBenhNhan();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int maxPage = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (currentPage < maxPage)
            {
                currentPage++;
                LoadDanhSachBenhNhan();
            }
        }

        private void dgvBenhNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBenhNhan.Rows[e.RowIndex];
                maBenhNhanDangChon = Convert.ToInt32(row.Cells["MaBN"].Value);
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                cboGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
                txtSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                rtbTienSu.Text = row.Cells["TienSuBenh"].Value.ToString();
                txtNgheNghiep.Text = row.Cells["NgheNghiep"].Value.ToString();
                dtpNgayDangKy.Value = Convert.ToDateTime(row.Cells["NgayDangKy"].Value);
                cbTrangThai.Checked = true;
            }
        }

    }
}
