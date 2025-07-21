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
    public partial class UcLoaiThuoc : UserControl
    {
        public UcLoaiThuoc()
        {
            InitializeComponent();
            LoadDanhSachLoaiThuoc();
            dgvLoaiThuoc.Height = dgvLoaiThuoc.Rows.GetRowsHeight(DataGridViewElementStates.Visible)
                        + dgvLoaiThuoc.ColumnHeadersHeight;
        }

        private int maLoaiDangChon = -1;
        private int pageSize = 5;
        private int currentPage = 1;
        private int totalRecords = 0;
        private int totalPages = 0;

        private void LoadDanhSachLoaiThuoc()
        {
            int offset = (currentPage - 1) * pageSize;

            string countQuery = "SELECT COUNT(*) FROM LoaiThuoc ";
            totalRecords = Convert.ToInt32(Connect.ExecuteScalar(countQuery));
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            string query = @"
        SELECT * FROM LoaiThuoc
        ORDER BY MaLoai
        OFFSET @Offset ROWS
        FETCH NEXT @PageSize ROWS ONLY";

            SqlParameter[] prms = {
        new SqlParameter("@Offset", offset),
        new SqlParameter("@PageSize", pageSize)
    };
            dgvLoaiThuoc.DataSource = Connect.ExecuteQuery(query, prms);
            lblTrang.Text = $"Trang {currentPage}/{totalPages}";
        }


        private void ResetForm()
        {
            maLoaiDangChon = -1;
            txtTenLoai.Clear();
            txtMoTa.Clear();
        }

        private void dgvLoaiThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLoaiThuoc.Rows[e.RowIndex];
                maLoaiDangChon = Convert.ToInt32(row.Cells["MaLoai"].Value);
                txtTenLoai.Text = row.Cells["TenLoai"].Value.ToString();
                txtMoTa.Text = row.Cells["MoTa"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ten = txtTenLoai.Text.Trim();
            string moTa = txtMoTa.Text.Trim();

            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Tên loại thuốc không được để trống!");
                return;
            }

            string sql = "INSERT INTO LoaiThuoc (TenLoai, MoTa) VALUES (@Ten, @MoTa)";
            SqlParameter[] prms = {
        new("@Ten", ten),
        new("@MoTa", moTa)
    };

            try
            {
                Connect.ExecuteNonQuery(sql, prms);
                MessageBox.Show("Thêm thành công!");
                ResetForm();
                LoadDanhSachLoaiThuoc();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // unique constraint
                    MessageBox.Show("Tên loại thuốc đã tồn tại!");
                else
                    MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (maLoaiDangChon == -1)
            {
                MessageBox.Show("Chọn loại thuốc để sửa!");
                return;
            }

            string sql = "UPDATE LoaiThuoc SET TenLoai=@Ten, MoTa=@MoTa WHERE MaLoai=@Ma";
            SqlParameter[] prms = {
        new("@Ten", txtTenLoai.Text.Trim()),
        new("@MoTa", txtMoTa.Text.Trim()),
        new("@Ma", maLoaiDangChon)
    };

            Connect.ExecuteNonQuery(sql, prms);
            MessageBox.Show("Sửa thành công!");
            ResetForm();
            LoadDanhSachLoaiThuoc();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maLoaiDangChon == -1) return;

            DialogResult confirm = MessageBox.Show("Xác nhận xóa?", "Xóa", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    string sql = "DELETE FROM LoaiThuoc WHERE MaLoai=@Ma";
                    Connect.ExecuteNonQuery(sql, new SqlParameter("@Ma", maLoaiDangChon));
                    MessageBox.Show("Đã xóa!");
                    ResetForm();
                    LoadDanhSachLoaiThuoc();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Không thể xóa loại thuốc này vì đang được sử dụng!");
                }
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadDanhSachLoaiThuoc();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int maxPage = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (currentPage < maxPage)
            {
                currentPage++;
                LoadDanhSachLoaiThuoc();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
            LoadDanhSachLoaiThuoc();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            string query = @"SELECT * FROM LoaiThuoc WHERE (TenLoai LIKE @kw)";
            dgvLoaiThuoc.DataSource = Connect.ExecuteQuery(query, new SqlParameter("@kw", "%" + keyword + "%"));
        }
    }
}
