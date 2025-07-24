using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Do_An1.Helpers;
using ClosedXML.Excel;
using System.IO;

namespace Do_An1.QuanTri.Khám
{
    public partial class UcThanhToan : UserControl
    {
        private int pageSize = 10;        // số bản ghi mỗi trang
        private int currentPage = 1;      // trang hiện tại
        private int totalRecords = 0;     // tổng số hóa đơn (dùng để tính tổng trang)
        private int totalPages = 0;

        public UcThanhToan()
        {
            InitializeComponent();
            LoadDanhSachHoaDon();
            if (cmbTrangThai.Items.Count > 0) cmbTrangThai.SelectedIndex = 0;
        }

        private void LoadDanhSachHoaDon()
        {
            string keyword = txtTimKiem.Text.Trim();
            string trangThai = cmbTrangThai.SelectedItem?.ToString() ?? "Tất cả";

            string condition = "";
            if (trangThai == "Đã thanh toán")
                condition += " AND hd.DaThanhToan = 1 ";
            else if (trangThai == "Chưa thanh toán")
                condition += " AND hd.DaThanhToan = 0 ";

            if (!string.IsNullOrEmpty(keyword))
                condition += " AND bn.HoTen LIKE N'%" + keyword + "%'";

            try
            {
                string queryCount = $@"
    SELECT COUNT(*)
    FROM HoaDon hd
    JOIN BenhNhan bn ON hd.MaBenhNhan = bn.MaBN
    WHERE 1=1 {condition}";
                totalRecords = Convert.ToInt32(Connect.ExecuteScalar(queryCount) ?? 0);
                totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                int offset = (currentPage - 1) * pageSize;

                string query = $@"
    SELECT TOP {pageSize} * FROM (
        SELECT ROW_NUMBER() OVER (ORDER BY hd.NgayTao DESC) AS RowNum,
               hd.MaHoaDon, bn.HoTen, hd.NgayTao, hd.TienKham, hd.TienThuoc,
               hd.GiamGia, hd.TongTien, hd.HinhThucThanhToan, hd.DaThanhToan, hd.GhiChu
        FROM HoaDon hd
        JOIN BenhNhan bn ON hd.MaBenhNhan = bn.MaBN
        WHERE 1=1 {condition}
    ) AS temp
    WHERE RowNum > {offset}";

                DataTable dt = Connect.ExecuteQuery(query);
                // Thêm cột hiển thị trạng thái
                if (!dt.Columns.Contains("TrangThaiHienThi"))
                    dt.Columns.Add("TrangThaiHienThi", typeof(string));
                foreach (DataRow row in dt.Rows)
                {
                    row["TrangThaiHienThi"] = Convert.ToBoolean(row["DaThanhToan"]) ? "Đã thanh toán" : "Chưa thanh toán";
                }
                dgvHoaDon.DataSource = dt;
                // Đảm bảo cột hiển thị được ánh xạ đúng
                if (dgvHoaDon.Columns["TrangThaiHienThi"] == null)
                {
                    dgvHoaDon.Columns.Add("TrangThaiHienThi", "Trạng thái");
                    dgvHoaDon.Columns["TrangThaiHienThi"].Width = 100;
                }
                dgvHoaDon.Columns["TrangThaiHienThi"].DataPropertyName = "TrangThaiHienThi";
                lblTrang.Text = $"Trang {currentPage}/{totalPages}";

                // Cập nhật giá trị trên giao diện khi chọn hóa đơn
                if (dgvHoaDon.CurrentRow != null)
                {
                    txtTienKham.Text = (Convert.ToDecimal(dgvHoaDon.CurrentRow.Cells["TienKham"].Value ?? 0)).ToString("N0");
                    txtGiamGia.Text = (Convert.ToDecimal(dgvHoaDon.CurrentRow.Cells["GiamGia"].Value ?? 0)).ToString("N0");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int maHoaDon = Convert.ToInt32(dgvHoaDon.CurrentRow.Cells["MaHoaDon"].Value);
                bool daThanhToan = Convert.ToBoolean(dgvHoaDon.CurrentRow.Cells["DaThanhToan"].Value);

                if (daThanhToan)
                {
                    MessageBox.Show("Hóa đơn này đã được thanh toán trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                decimal tienKham = string.IsNullOrEmpty(txtTienKham.Text) ? 0 : Convert.ToDecimal(txtTienKham.Text.Replace(".", ""));
                decimal giamGia = string.IsNullOrEmpty(txtGiamGia.Text) ? 0 : Convert.ToDecimal(txtGiamGia.Text.Replace(".", ""));
                decimal tienThuoc = Convert.ToDecimal(dgvHoaDon.CurrentRow.Cells["TienThuoc"].Value ?? 0);
                decimal tongTien = (tienKham + tienThuoc) - giamGia;
                if (tongTien < 0) tongTien = 0;

                string query = @"
                    UPDATE HoaDon 
                    SET TienKham = @TienKham, GiamGia = @GiamGia, DaThanhToan = 1 
                    WHERE MaHoaDon = @MaHoaDon";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TienKham", SqlDbType.Decimal) { Value = tienKham },
                    new SqlParameter("@GiamGia", SqlDbType.Decimal) { Value = giamGia },
                    new SqlParameter("@MaHoaDon", SqlDbType.Int) { Value = maHoaDon }
                };

                int rows = Connect.ExecuteNonQuery(query, parameters);
                if (rows > 0)
                {
                    MessageBox.Show($"Thanh toán thành công! Tổng tiền sau giảm giá: {tongTien:N0} VNĐ", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachHoaDon();
                }
                else
                {
                    MessageBox.Show("Thanh toán thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int maHoaDon = Convert.ToInt32(dgvHoaDon.CurrentRow.Cells["MaHoaDon"].Value);
                decimal tienKham = string.IsNullOrEmpty(txtTienKham.Text) ? 0 : Convert.ToDecimal(txtTienKham.Text.Replace(".", ""));
                decimal giamGia = string.IsNullOrEmpty(txtGiamGia.Text) ? 0 : Convert.ToDecimal(txtGiamGia.Text.Replace(".", ""));
                decimal tienThuoc = Convert.ToDecimal(dgvHoaDon.CurrentRow.Cells["TienThuoc"].Value ?? 0);
                decimal tongTien = (tienKham + tienThuoc) - giamGia;
                if (tongTien < 0) tongTien = 0;

                string query = @"
                    UPDATE HoaDon 
                    SET TienKham = @TienKham, GiamGia = @GiamGia 
                    WHERE MaHoaDon = @MaHoaDon";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TienKham", SqlDbType.Decimal) { Value = tienKham },
                    new SqlParameter("@GiamGia", SqlDbType.Decimal) { Value = giamGia },
                    new SqlParameter("@MaHoaDon", SqlDbType.Int) { Value = maHoaDon }
                };

                int rows = Connect.ExecuteNonQuery(query, parameters);
                if (rows > 0)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachHoaDon();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadDanhSachHoaDon();
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int maHoaDon = Convert.ToInt32(dgvHoaDon.CurrentRow.Cells["MaHoaDon"].Value);
                // Giả sử có FormChiTietDonThuoc để xem chi tiết
                FormChiTietDonThuoc form = new FormChiTietDonThuoc(maHoaDon);
                form.ShowDialog();
                LoadDanhSachHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xem chi tiết: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadDanhSachHoaDon();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadDanhSachHoaDon();
            }
        }

        private void cmbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadDanhSachHoaDon();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cmbTrangThai.SelectedIndex = -1;
            currentPage = 1;
            LoadDanhSachHoaDon();
        }

        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Lưu hóa đơn dưới dạng Excel",
                FileName = "HoaDon_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("ChiTietHoaDon");

                        int colIndex = 1;
                        // Ghi header
                        foreach (DataGridViewColumn column in dgvHoaDon.Columns)
                        {
                            if (column is DataGridViewButtonColumn) continue;
                            worksheet.Cell(1, colIndex).Value = column.HeaderText;
                            worksheet.Cell(1, colIndex).Style.Font.Bold = true;
                            worksheet.Cell(1, colIndex).Style.Fill.BackgroundColor = XLColor.LightGray;
                            worksheet.Cell(1, colIndex).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            colIndex++;
                        }

                        // Ghi dữ liệu của dòng được chọn
                        DataGridViewRow selectedRow = dgvHoaDon.CurrentRow;
                        colIndex = 1;
                        for (int j = 0; j < dgvHoaDon.Columns.Count; j++)
                        {
                            if (dgvHoaDon.Columns[j] is DataGridViewButtonColumn) continue;
                            var value = selectedRow.Cells[j].FormattedValue?.ToString();
                            if (dgvHoaDon.Columns[j].Name == "NgayTao" && DateTime.TryParse(value, out DateTime date))
                                worksheet.Cell(2, colIndex).Value = date.ToString("dd/MM/yyyy HH:mm");
                            else if (dgvHoaDon.Columns[j].Name.Contains("Tien") && decimal.TryParse(value, out decimal money))
                                worksheet.Cell(2, colIndex).Style.NumberFormat.Format = "#,##0 VNĐ";
                            else
                                worksheet.Cell(2, colIndex).Value = value;
                            worksheet.Cell(2, colIndex).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            colIndex++;
                        }

                        worksheet.Columns().AdjustToContents();
                        workbook.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Xuất Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}