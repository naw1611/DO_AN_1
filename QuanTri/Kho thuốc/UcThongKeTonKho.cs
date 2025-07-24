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
using ClosedXML.Excel;

namespace Do_An1.QuanTri.Kho_thuốc
{
    public partial class UcThongKeTonKho : UserControl
    {
        private int pageSize = 10;
        private int currentPage = 1;
        private int totalRecords = 0;
        private int totalPages = 0;
        private DataTable currentData;

        public UcThongKeTonKho()
        {
            InitializeComponent();
            LoadComboBoxLoaiThuoc();
            LoadComboBoxDanhMuc();
            LoadDuLieuThuoc();
        }

        private void LoadComboBoxLoaiThuoc()
        {
            string query = "SELECT MaLoai, TenLoai FROM LoaiThuoc";
            DataTable dt = Connect.ExecuteQuery(query);

            cboLoaiThuoc.DataSource = dt;
            cboLoaiThuoc.DisplayMember = "TenLoai";
            cboLoaiThuoc.ValueMember = "MaLoai";
            cboLoaiThuoc.SelectedIndex = -1;
        }

        private void LoadComboBoxDanhMuc()
        {
            string query = "SELECT MaDanhMuc, TenDanhMuc FROM DanhMucThuoc";
            DataTable dt = Connect.ExecuteQuery(query);

            cboDanhMuc.DataSource = dt;
            cboDanhMuc.DisplayMember = "TenDanhMuc";
            cboDanhMuc.ValueMember = "MaDanhMuc";
            cboDanhMuc.SelectedIndex = -1;
        }

        private void LoadDuLieuThuoc()
        {
            string query = @"SELECT T.MaThuoc, T.TenThuoc, LT.TenLoai, DM.TenDanhMuc, T.HanSuDung, T.SoLuongTon, T.DonViTinh
                     FROM Thuoc T
                     JOIN LoaiThuoc LT ON T.MaLoai = LT.MaLoai
                     JOIN DanhMucThuoc DM ON T.MaDanhMuc = DM.MaDanhMuc
                     WHERE 1 = 1";

            List<SqlParameter> parameters = new List<SqlParameter>();

            if (cboLoaiThuoc.SelectedIndex > 0)
            {
                query += " AND LT.MaLoai = @MaLoai";
                parameters.Add(new SqlParameter("@MaLoai", cboLoaiThuoc.SelectedValue));
            }

            if (cboDanhMuc.SelectedIndex > 0)
            {
                query += " AND DM.MaDanhMuc = @MaDanhMuc";
                parameters.Add(new SqlParameter("@MaDanhMuc", cboDanhMuc.SelectedValue));
            }

            if (chkCanhBaoHetHan.Checked)
            {
                query += " AND DATEDIFF(DAY, GETDATE(), T.HanSuDung) <= 30";
            }

            if (chkSoLuongThap.Checked)
            {
                query += " AND T.SoLuongTon < 10";
            }

            // Lấy dữ liệu gốc
            currentData = Connect.ExecuteQuery(query, parameters.ToArray());

            // Tính phân trang
            totalRecords = currentData.Rows.Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            ShowPage(currentPage);
        }

        private void ShowPage(int page)
        {
            if (currentData == null) return;

            currentPage = page;
            int start = (page - 1) * pageSize;
            int end = Math.Min(start + pageSize, totalRecords);

            DataTable pageTable = currentData.Clone();
            for (int i = start; i < end; i++)
            {
                pageTable.ImportRow(currentData.Rows[i]);
            }

            dgvTonKho.DataSource = pageTable;
            lblPage.Text = $"Trang {currentPage}/{totalPages}";
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                ShowPage(--currentPage);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                ShowPage(++currentPage);
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadDuLieuThuoc();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvTonKho.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Lưu danh sách dưới dạng Excel",
                FileName = "DSThuocTon_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("DanhSachThuocTonKho");

                        int colIndex = 1;
                        // Ghi header, bỏ cột Button (nếu có)
                        for (int i = 0; i < dgvTonKho.Columns.Count; i++)
                        {
                            if (dgvTonKho.Columns[i] is DataGridViewButtonColumn) continue;

                            worksheet.Cell(1, colIndex).Value = dgvTonKho.Columns[i].HeaderText;
                            worksheet.Cell(1, colIndex).Style.Font.Bold = true;
                            worksheet.Cell(1, colIndex).Style.Fill.BackgroundColor = XLColor.LightGray;
                            worksheet.Cell(1, colIndex).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            colIndex++;
                        }

                        // Ghi dữ liệu
                        for (int i = 0; i < dgvTonKho.Rows.Count; i++)
                        {
                            colIndex = 1;
                            for (int j = 0; j < dgvTonKho.Columns.Count; j++)
                            {
                                if (dgvTonKho.Columns[j] is DataGridViewButtonColumn) continue;

                                var value = dgvTonKho.Rows[i].Cells[j].FormattedValue?.ToString();
                                worksheet.Cell(i + 2, colIndex).Value = value;
                                worksheet.Cell(i + 2, colIndex).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                colIndex++;
                            }
                        }

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