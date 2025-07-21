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
    public partial class UcBacSi : UserControl
    {
        public UcBacSi()
        {
            InitializeComponent();
            LoadDanhSachBacSi();
            dgvBacSi.Height = dgvBacSi.Rows.GetRowsHeight(DataGridViewElementStates.Visible)
                        + dgvBacSi.ColumnHeadersHeight;
        }

        private int maBSDangChon = -1;
        private int pageSize = 5;
        private int currentPage = 1;
        private int totalRecords = 0;
        private int totalPages = 0;

        private void LoadDanhSachBacSi()
        {
            int offset = (currentPage - 1) * pageSize;

            string countQuery = "SELECT COUNT(*) FROM BacSi WHERE TrangThai = 1";
            totalRecords = Convert.ToInt32(Connect.ExecuteScalar(countQuery));
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            string query = @"
        SELECT * FROM BacSi
        WHERE TrangThai = 1
        ORDER BY MaBS
        OFFSET @Offset ROWS
        FETCH NEXT @PageSize ROWS ONLY";

            SqlParameter[] prms = {
        new SqlParameter("@Offset", offset),
        new SqlParameter("@PageSize", pageSize)
    };

            dgvBacSi.DataSource = Connect.ExecuteQuery(query,prms);
            lblTrang.Text = $"Trang {currentPage}/{totalPages}";
        }

        private void ResetForm()
        {
            maBSDangChon = -1;
            txtHoTen.Clear();
            txtChuyenKhoa.Clear();
            txtBangCap.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            rtbGioiThieu.Clear();
            cbTrangThai.Checked = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = @"
        INSERT INTO BacSi (HoTen, ChuyenKhoa, BangCap, SoDienThoai, Email, GioiThieu, TrangThai)
        VALUES (@HoTen, @ChuyenKhoa, @BangCap, @SDT, @Email, @GioiThieu, 1)";

            SqlParameter[] prms = {
        new SqlParameter("@HoTen", txtHoTen.Text.Trim()),
        new SqlParameter("@ChuyenKhoa", txtChuyenKhoa.Text.Trim()),
        new SqlParameter("@BangCap", txtBangCap.Text.Trim()),
        new SqlParameter("@SDT", txtSDT.Text.Trim()),
        new SqlParameter("@Email", txtEmail.Text.Trim()),
        new SqlParameter("@GioiThieu", rtbGioiThieu.Text.Trim())
    };

            Connect.ExecuteNonQuery(query, prms);
            MessageBox.Show("Thêm bác sĩ thành công!");
            LoadDanhSachBacSi();
            ResetForm();
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (maBSDangChon == -1)
            {
                MessageBox.Show("Vui lòng chọn bác sĩ để sửa!");
                return;
            }

            string query = @"
        UPDATE BacSi SET HoTen = @HoTen, ChuyenKhoa = @ChuyenKhoa, BangCap = @BangCap,
                         SoDienThoai = @SDT, Email = @Email, GioiThieu = @GioiThieu
        WHERE MaBS = @MaBS";

            SqlParameter[] prms = {
        new SqlParameter("@HoTen", txtHoTen.Text.Trim()),
        new SqlParameter("@ChuyenKhoa", txtChuyenKhoa.Text.Trim()),
        new SqlParameter("@BangCap", txtBangCap.Text.Trim()),
        new SqlParameter("@SDT", txtSDT.Text.Trim()),
        new SqlParameter("@Email", txtEmail.Text.Trim()),
        new SqlParameter("@GioiThieu", rtbGioiThieu.Text.Trim()),
        new SqlParameter("@MaBS", maBSDangChon)
    };

            Connect.ExecuteNonQuery(query, prms);
            MessageBox.Show("Cập nhật thành công!");
            LoadDanhSachBacSi();
            ResetForm();
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maBSDangChon == -1)
            {
                MessageBox.Show("Vui lòng chọn bác sĩ để xóa!");
                return;
            }

            DialogResult confirm = MessageBox.Show("Xác nhận xóa bác sĩ này?", "Cảnh báo", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                string query = "UPDATE BacSi SET TrangThai = 0 WHERE MaBS = @MaBS";
                Connect.ExecuteNonQuery(query, new SqlParameter("@MaBS", maBSDangChon));
                MessageBox.Show("Đã xóa bác sĩ!");
                LoadDanhSachBacSi();
                ResetForm();
            }
        }


        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
            LoadDanhSachBacSi();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            string query = @"SELECT * FROM BacSi WHERE TrangThai = 1 AND (HoTen LIKE @kw OR ChuyenKhoa LIKE @kw OR BangCap LIKE @kw)";
            dgvBacSi.DataSource = Connect.ExecuteQuery(query, new SqlParameter("@kw", "%" + keyword + "%"));
        }

        private void dgvBacSi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBacSi.Rows[e.RowIndex];
                maBSDangChon = Convert.ToInt32(row.Cells["MaBS"].Value);
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtChuyenKhoa.Text = row.Cells["ChuyenKhoa"].Value.ToString();
                txtBangCap.Text = row.Cells["BangCap"].Value.ToString();
                txtSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                rtbGioiThieu.Text = row.Cells["GioiThieu"].Value.ToString();
                cbTrangThai.Checked = true;
            }
        }


        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadDanhSachBacSi();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int maxPage = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (currentPage < maxPage)
            {
                currentPage++;
                LoadDanhSachBacSi();
            }
        }

    }
}
