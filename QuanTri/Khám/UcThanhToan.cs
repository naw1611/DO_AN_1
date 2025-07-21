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

            string queryCount = $@"
        SELECT COUNT(*)
        FROM HoaDon hd
        JOIN BenhNhan bn ON hd.MaBenhNhan = bn.MaBN
        WHERE 1=1 {condition}";
            totalRecords = (int)Connect.ExecuteScalar(queryCount);
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            int offset = (currentPage - 1) * pageSize;

            string query = $@"
        SELECT TOP {pageSize} * FROM (
            SELECT ROW_NUMBER() OVER (ORDER BY hd.NgayTao DESC) AS RowNum,
                   hd.MaHoaDon, bn.HoTen, hd.NgayTao, hd.TienKham, hd.TienThuoc,
                   hd.GiamGia, hd.TongTien,hd.HinhThucThanhToan, hd.DaThanhToan, hd.GhiChu
            FROM HoaDon hd
            JOIN BenhNhan bn ON hd.MaBenhNhan = bn.MaBN
            WHERE 1=1 {condition}
        ) AS temp
        WHERE RowNum > {offset}";

            dgvHoaDon.DataSource = Connect.ExecuteQuery(query);
            lblTrang.Text = $"Trang {currentPage}/{totalPages}";
        }



        private void btnTraCuu_Click(object sender, EventArgs e)
        {

            LoadDanhSachHoaDon();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maHoaDon = Convert.ToInt32(dgvHoaDon.CurrentRow.Cells["MaHoaDon"].Value);
            bool daThanhToan = Convert.ToBoolean(dgvHoaDon.CurrentRow.Cells["DaThanhToan"].Value);

            if (daThanhToan)
            {
                MessageBox.Show("Hóa đơn này đã được thanh toán trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn thanh toán hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            string query = "UPDATE HoaDon SET DaThanhToan = 1 WHERE MaHoaDon = @maHoaDon";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@maHoaDon", maHoaDon)
            };

            int rows = Connect.ExecuteNonQuery(query, parameters);
            if (rows > 0)
            {
                MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachHoaDon();
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xem chi tiết!", "Thông báo");
                return;
            }

            int maHoaDon = Convert.ToInt32(dgvHoaDon.CurrentRow.Cells["MaHoaDon"].Value);
            FormChiTietDonThuoc form = new FormChiTietDonThuoc(maHoaDon);
            form.ShowDialog();
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
            LoadDanhSachHoaDon();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cmbTrangThai.SelectedIndex = -1;
            LoadDanhSachHoaDon();
        }

        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        var worksheet = workbook.Worksheets.Add("DanhSachHoaDon");

                        int colIndex = 1;
                        // Ghi header, bỏ cột Button (nếu có)
                        for (int i = 0; i < dgvHoaDon.Columns.Count; i++)
                        {
                            if (dgvHoaDon.Columns[i] is DataGridViewButtonColumn) continue;

                            worksheet.Cell(1, colIndex).Value = dgvHoaDon.Columns[i].HeaderText;
                            worksheet.Cell(1, colIndex).Style.Font.Bold = true;
                            worksheet.Cell(1, colIndex).Style.Fill.BackgroundColor = XLColor.LightGray;
                            worksheet.Cell(1, colIndex).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            colIndex++;
                        }

                        // Ghi dữ liệu
                        for (int i = 0; i < dgvHoaDon.Rows.Count; i++)
                        {
                            colIndex = 1;
                            for (int j = 0; j < dgvHoaDon.Columns.Count; j++)
                            {
                                if (dgvHoaDon.Columns[j] is DataGridViewButtonColumn) continue;

                                var value = dgvHoaDon.Rows[i].Cells[j].FormattedValue?.ToString();
                                worksheet.Cell(i + 2, colIndex).Value = value;
                                worksheet.Cell(i + 2, colIndex).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                colIndex++;
                            }
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

