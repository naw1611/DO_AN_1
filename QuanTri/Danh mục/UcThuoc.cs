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
using Do_An1.Models;
using Microsoft.Data.SqlClient;
using Do_An1.QuanTri.Danh_mục;
using System.Drawing.Printing;

namespace Do_An1.QuanTri
{
    public partial class UcThuoc : UserControl
    {
        private int limit = 10;
        private int offset = 0;
        private int totalRecords = 0;

        public UcThuoc()
        {
            InitializeComponent();
            LoadDanhMucThuoc();
            LoadThuoc();
            dgvThuoc.Height = dgvThuoc.Rows.GetRowsHeight(DataGridViewElementStates.Visible)
                        + dgvThuoc.ColumnHeadersHeight;
        }

        private void LoadDanhMucThuoc()
        {
            string query = "SELECT MaDanhMuc, TenDanhMuc FROM DanhMucThuoc";
            DataTable dt = Connect.ExecuteQuery(query);

            cmbDanhMuc.DataSource = dt;
            cmbDanhMuc.DisplayMember = "TenDanhMuc";
            cmbDanhMuc.ValueMember = "MaDanhMuc";
        }

        private void LoadThuoc(string keyword = "")
        {
            string countQuery = "SELECT COUNT(*) FROM Thuoc WHERE TenThuoc LIKE @keyword";
            SqlParameter[] countParams = { new SqlParameter("@keyword", "%" + keyword + "%") };
            totalRecords = (int)Connect.ExecuteScalar(countQuery, countParams);

            string query = @"
                SELECT t.MaThuoc, t.TenThuoc, t.DonViTinh, t.DonGiaBan, t.SoLuongTon, t.HanSuDung,
                       t.NhaSanXuat, t.CachDung, dmt.TenDanhMuc
                FROM Thuoc t
                LEFT JOIN DanhMucThuoc dmt ON t.MaDanhMuc = dmt.MaDanhMuc
                WHERE t.TenThuoc LIKE @keyword
                ORDER BY t.MaThuoc
                OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY";

            SqlParameter[] parameters = {
                new SqlParameter("@keyword", "%" + keyword + "%"),
                new SqlParameter("@offset", offset),
                new SqlParameter("@limit", limit)
            };

            DataTable dt = Connect.ExecuteQuery(query, parameters);
            dgvThuoc.DataSource = dt;

            lblPage.Text = $"Trang {(offset / limit) + 1} / {Math.Ceiling(totalRecords / (double)limit)}";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            offset = 0;
            LoadThuoc(txtTimKiem.Text.Trim());
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (offset + limit < totalRecords)
            {
                offset += limit;
                LoadThuoc(txtTimKiem.Text.Trim());
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (offset - limit >= 0)
            {
                offset -= limit;
                LoadThuoc(txtTimKiem.Text.Trim());
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            new FormThemThuoc().ShowDialog();
            LoadThuoc(txtTimKiem.Text.Trim());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvThuoc.CurrentRow == null) return;
            int maThuoc = Convert.ToInt32(dgvThuoc.CurrentRow.Cells["MaThuoc"].Value);
            new FormSuaThuoc(maThuoc).ShowDialog();
            LoadThuoc(txtTimKiem.Text.Trim());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThuoc.CurrentRow == null) return;

            int maThuoc = Convert.ToInt32(dgvThuoc.CurrentRow.Cells["MaThuoc"].Value);
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa thuốc này không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM Thuoc WHERE MaThuoc = @MaThuoc";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaThuoc", maThuoc)
                };
                Connect.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Xóa thành công!", "Thông báo");
                LoadThuoc(txtTimKiem.Text.Trim());
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            offset = 0; 
            LoadThuoc();
        }

        private void cmbLocDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDanhMuc.SelectedIndex < 0 || cmbDanhMuc.SelectedValue == null)
            {
                LoadThuoc();
                return;
            }

            try
            {
                var selectedValue = cmbDanhMuc.SelectedValue;
                int maDanhMuc;

                if (selectedValue is DataRowView rowView)
                {
                    object value = rowView["MaDanhMuc"];
                    if (value == null || value == DBNull.Value)
                    {
                        MessageBox.Show("Giá trị MaDanhMuc không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!int.TryParse(value.ToString(), out maDanhMuc))
                    {
                        MessageBox.Show("Không thể chuyển đổi MaDanhMuc thành số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    if (!int.TryParse(selectedValue.ToString(), out maDanhMuc))
                    {
                        MessageBox.Show("Không thể chuyển đổi giá trị được chọn thành số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                string query = "SELECT MaThuoc, TenThuoc, DonViTinh, DonGiaBan, SoLuongTon, HanSuDung,NhaSanXuat, CachDung  FROM Thuoc WHERE MaDanhMuc = @MaDanhMuc ORDER BY MaThuoc OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
                SqlParameter[] prms = {
            new SqlParameter("@MaDanhMuc", maDanhMuc),
            new SqlParameter("@Offset", offset),
            new SqlParameter("@PageSize", limit)
        };

                DataTable dt = Connect.ExecuteQuery(query, prms);
                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvThuoc.DataSource = dt;
                }
                else
                {
                    dgvThuoc.DataSource = new DataTable();
                    MessageBox.Show("Không tìm thấy dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}