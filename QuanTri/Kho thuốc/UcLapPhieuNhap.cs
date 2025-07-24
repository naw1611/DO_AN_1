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
using Do_An1.Models;
using ClosedXML.Excel;

namespace Do_An1.QuanTri.Kho_thuốc
{
    public partial class UcLapPhieuNhap : UserControl
    {
        private DataTable dtNhapTam;
        private decimal tongTien = 0;

        public object CurrentUser { get; private set; }

        public UcLapPhieuNhap()
        {
            InitializeComponent();
        }

        private void UcLapPhieuNhap_Load(object sender, EventArgs e)
        {
            try
            {
                dtNhapTam = new DataTable();
                dtNhapTam.Columns.Add("MaThuoc", typeof(int));
                dtNhapTam.Columns.Add("TenThuoc", typeof(string));
                dtNhapTam.Columns.Add("SoLuong", typeof(int));
                dtNhapTam.Columns.Add("DonGia", typeof(decimal));
                dtNhapTam.Columns.Add("ThanhTien", typeof(decimal));

                if (dgvChiTietNhap == null)
                {
                    MessageBox.Show("DataGridView 'dgvChiTietNhap' không được khai báo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dgvChiTietNhap.DataSource = dtNhapTam;
                LoadThuocToComboBox();
                CapNhatTongTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadThuocToComboBox()
        {
            try
            {
                string query = "SELECT MaThuoc, TenThuoc FROM Thuoc";
                DataTable dt = Connect.ExecuteQuery(query);
                Console.WriteLine($"Loaded {dt.Rows.Count} records for cboThuoc");
                if (dt.Rows.Count == 0)
                    MessageBox.Show("Không có dữ liệu thuốc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboThuoc.DataSource = dt;
                cboThuoc.DisplayMember = "TenThuoc";
                cboThuoc.ValueMember = "MaThuoc";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thuốc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboThuoc.SelectedValue == null ||
                !int.TryParse(txtSoLuongNhap.Text, out int soLuong) ||
                !decimal.TryParse(txtDonGiaNhap.Text, out decimal donGia) || soLuong <= 0 || donGia <= 0)
            {
                MessageBox.Show("Dữ liệu không hợp lệ!");
                return;
            }

            int maThuoc = (int)cboThuoc.SelectedValue;
            if (dtNhapTam.AsEnumerable().Any(r => r.Field<int>("MaThuoc") == maThuoc))
            {
                MessageBox.Show("Thuốc đã được thêm trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string tenThuoc = cboThuoc.Text;
                decimal thanhTien = soLuong * donGia;

                dtNhapTam.Rows.Add(maThuoc, tenThuoc, soLuong, donGia, thanhTien);
                CapNhatTongTien();

                txtSoLuongNhap.Clear();
                txtDonGiaNhap.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm thuốc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CapNhatTongTien()
        {
            tongTien = dtNhapTam.AsEnumerable().Sum(row => row.Field<decimal>("ThanhTien"));
            lblTongTien.Text = $"Tổng tiền: {tongTien:#,##0} VNĐ";
        }

        private void btnLuuPhieuNhap_Click(object sender, EventArgs e)
        {
            if (dtNhapTam.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu nhập!");
                return;
            }

            int maNV;
            if (CurrentUser is NhanVien nv)
                maNV = nv.MaNV;
            else
                maNV = 10;

            try
            {
                string insertPhieu = @"INSERT INTO PhieuNhapThuoc (NgayNhap, MaNV, GhiChu, TrangThai, TongTien)
            VALUES (GETDATE(), @MaNV, @GhiChu, N'Đã nhập', @TongTien);
            SELECT SCOPE_IDENTITY();";

                string ghiChu = "Phiếu nhập từ hệ thống";
                object result = Connect.ExecuteScalar(insertPhieu,
                    new SqlParameter("@MaNV", maNV),
                    new SqlParameter("@GhiChu", ghiChu),
                    new SqlParameter("@TongTien", tongTien));

                if (result == null || result == DBNull.Value)
                    throw new Exception("Không thể tạo phiếu nhập!");

                int maPhieuMoi = Convert.ToInt32(result);

                foreach (DataRow row in dtNhapTam.Rows)
                {
                    int maThuoc = (int)row["MaThuoc"];
                    int soLuong = (int)row["SoLuong"];
                    decimal donGia = (decimal)row["DonGia"];

                    string insertChiTiet = @"INSERT INTO CT_PhieuNhap (MaPhieuNhap, MaThuoc, SoLuongNhap, DonGiaNhap)
                VALUES (@MaPhieuNhap, @MaThuoc, @SoLuong, @DonGia)";
                    Connect.ExecuteNonQuery(insertChiTiet, new SqlParameter[]
                    {
                new SqlParameter("@MaPhieuNhap", maPhieuMoi),
                new SqlParameter("@MaThuoc", maThuoc),
                new SqlParameter("@SoLuong", soLuong),
                new SqlParameter("@DonGia", donGia)
                    });

                    string capNhatThuoc = "UPDATE Thuoc SET SoLuongTon = SoLuongTon + @SL WHERE MaThuoc = @MaThuoc";
                    Connect.ExecuteNonQuery(capNhatThuoc, new SqlParameter[]
                    {
                new SqlParameter("@SL", soLuong),
                new SqlParameter("@MaThuoc", maThuoc)
                    });

                    string insertLS = @"INSERT INTO LichSuNhapThuoc (MaThuoc, SoLuongThayDoi, LoaiThayDoi, NgayThayDoi, MaNV, GhiChu)
                VALUES (@MaThuoc, @SoLuong, N'Nhập kho', GETDATE(), @MaNV, @GhiChu)";
                    Connect.ExecuteNonQuery(insertLS, new SqlParameter[]
                    {
                new SqlParameter("@MaThuoc", maThuoc),
                new SqlParameter("@SoLuong", soLuong),
                new SqlParameter("@MaNV", maNV),
                new SqlParameter("@GhiChu", ghiChu)
                    });
                }

                MessageBox.Show("Lưu phiếu nhập thành công!");
                dtNhapTam.Clear(); 
                CapNhatTongTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu phiếu nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            try
            {
                dtNhapTam.Clear();
                CapNhatTongTien();
                if (txtSoLuongNhap != null) txtSoLuongNhap.Clear();
                if (txtDonGiaNhap != null) txtDonGiaNhap.Clear();
                if (cboThuoc != null) cboThuoc.SelectedIndex = cboThuoc.Items.Count > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hủy: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatPN_Click(object sender, EventArgs e)
        {
            if (dgvChiTietNhap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Lưu phiếu nhập dưới dạng Excel",
                FileName = "PhieuNhap_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("DanhSachPhieuNhap");

                        int colIndex = 1;
                        // Ghi header, bỏ cột Button (nếu có)
                        for (int i = 0; i < dgvChiTietNhap.Columns.Count; i++)
                        {
                            if (dgvChiTietNhap.Columns[i] is DataGridViewButtonColumn) continue;

                            worksheet.Cell(1, colIndex).Value = dgvChiTietNhap.Columns[i].HeaderText;
                            worksheet.Cell(1, colIndex).Style.Font.Bold = true;
                            worksheet.Cell(1, colIndex).Style.Fill.BackgroundColor = XLColor.LightGray;
                            worksheet.Cell(1, colIndex).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            colIndex++;
                        }

                        // Ghi dữ liệu
                        for (int i = 0; i < dgvChiTietNhap.Rows.Count; i++)
                        {
                            colIndex = 1;
                            for (int j = 0; j < dgvChiTietNhap.Columns.Count; j++)
                            {
                                if (dgvChiTietNhap.Columns[j] is DataGridViewButtonColumn) continue;

                                var value = dgvChiTietNhap.Rows[i].Cells[j].FormattedValue?.ToString();
                                worksheet.Cell(i + 2, colIndex).Value = value;
                                worksheet.Cell(i + 2, colIndex).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                colIndex++;
                            }
                        }

                        int tongSoDong = dgvChiTietNhap.Rows.Count + 2;
                        worksheet.Cell(tongSoDong, 1).Value = "";
                        worksheet.Cell(tongSoDong, 2).Value = lblTongTien.Text;
                        worksheet.Range(tongSoDong, 1 , tongSoDong , 2).Style.Font.Bold = true;
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

