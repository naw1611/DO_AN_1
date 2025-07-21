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
    public partial class UcLapPhieuXuat : UserControl
    {
        private DataTable dtChiTietXuat;
        public UcLapPhieuXuat()
        {
            InitializeComponent();
        }

        private void UcLapPhieuXuat_Load(object sender, EventArgs e)
        {
            dtpNgayXuat.Value = DateTime.Now;

            LoadComboNhanVien();
            LoadComboThuoc();

            dgvChiTietXuat.Rows.Clear();
            lblTongTien.Text = "0";
            txtMaPhieu.Text = ""; // trống cho đến khi Lưu
        }

        private void LoadComboNhanVien()
        {
            string query = "SELECT MaNV, HoTen FROM NhanVien";
            DataTable dt = Connect.ExecuteQuery(query);
            cmbNhanVien.DataSource = dt;
            cmbNhanVien.DisplayMember = "HoTen";
            cmbNhanVien.ValueMember = "MaNV";
        }

        private void LoadComboThuoc()
        {
            string query = "SELECT MaThuoc, TenThuoc, DonGiaBan FROM Thuoc";
            DataTable dt = Connect.ExecuteQuery(query);
            cmbThuoc.DataSource = dt;
            cmbThuoc.DisplayMember = "TenThuoc";
            cmbThuoc.ValueMember = "MaThuoc";
        }

        private void cmbThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbThuoc.SelectedValue != null)
            {
                DataRowView row = cmbThuoc.SelectedItem as DataRowView;
                if (row != null)
                    txtDonGia.Text = row["DonGiaBan"].ToString();
            }
        }

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbThuoc.SelectedValue == null || numSoLuong.Value <= 0)
                {
                    MessageBox.Show("Vui lòng chọn thuốc và nhập số lượng hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maThuoc = cmbThuoc.SelectedValue.ToString();
                string tenThuoc = ((DataRowView)cmbThuoc.SelectedItem)["TenThuoc"].ToString();
                decimal donGia;
                if (!decimal.TryParse(txtDonGia.Text, out donGia))
                {
                    MessageBox.Show("Đơn giá không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int soLuong = (int)numSoLuong.Value;
                decimal thanhTien = donGia * soLuong;

                // Kiểm tra trùng thuốc trong danh sách
                foreach (DataGridViewRow row in dgvChiTietXuat.Rows)
                {
                    if (row.Cells["MaThuoc"].Value?.ToString() == maThuoc)
                    {
                        MessageBox.Show("Thuốc này đã có trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Kiểm tra và khởi tạo cột nếu cần
                if (dgvChiTietXuat.Columns.Count == 0)
                {
                    dgvChiTietXuat.Columns.Add("MaThuoc", "Mã thuốc");
                    dgvChiTietXuat.Columns.Add("TenThuoc", "Tên thuốc");
                    dgvChiTietXuat.Columns.Add("DonGiaXuat", "Đơn giá");
                    dgvChiTietXuat.Columns.Add("SoLuong", "Số lượng");
                    dgvChiTietXuat.Columns.Add("ThanhTien", "Thành tiền");
                }

                dgvChiTietXuat.Rows.Add(maThuoc, tenThuoc, donGia, soLuong, thanhTien);
                CapNhatTongTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm thuốc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CapNhatTongTien()
        {
            decimal tong = 0;
            foreach (DataGridViewRow row in dgvChiTietXuat.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null)
                    tong += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
            }
            lblTongTien.Text = tong.ToString("N0");
            //lblTongTien.Text = $"Tổng tiền: {tong:#,##0} VNĐ";
        }

        private void dgvChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvChiTietXuat.Columns["btnXoa"].Index && e.RowIndex >= 0)
            {
                dgvChiTietXuat.Rows.RemoveAt(e.RowIndex);
                CapNhatTongTien();
            }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            dtpNgayXuat.Value = DateTime.Now;
            cmbNhanVien.SelectedIndex = 0;
            txtGhiChu.Clear();
            dgvChiTietXuat.Rows.Clear();
            lblTongTien.Text = "0";
            txtMaPhieu.Text = ""; // tạo mới => chưa có mã
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cmbNhanVien.SelectedValue == null || dgvChiTietXuat.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên và thêm ít nhất 1 thuốc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maNV = (int)cmbNhanVien.SelectedValue;
            DateTime ngayXuat = dtpNgayXuat.Value;
            string ghiChu = txtGhiChu.Text.Trim();
            decimal tongTien;

            if (!decimal.TryParse(lblTongTien.Text.Replace(",", ""), out tongTien))
            {
                MessageBox.Show("Tổng tiền không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = Connect.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // 1. Thêm phiếu xuất
                    string insertPhieu = @"
                INSERT INTO PhieuXuatThuoc (NgayXuat, MaNV, GhiChu)
                VALUES (@NgayXuat, @MaNV, @GhiChu);
                SELECT SCOPE_IDENTITY();";

                    SqlCommand cmdPhieu = new SqlCommand(insertPhieu, conn, trans);
                    cmdPhieu.Parameters.AddWithValue("@NgayXuat", ngayXuat);
                    cmdPhieu.Parameters.AddWithValue("@MaNV", maNV);
                    cmdPhieu.Parameters.AddWithValue("@GhiChu", ghiChu);


                    int maPhieu = Convert.ToInt32(cmdPhieu.ExecuteScalar());

                    // 2. Thêm chi tiết phiếu xuất
                    foreach (DataGridViewRow row in dgvChiTietXuat.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string maThuoc = row.Cells["MaThuoc"].Value?.ToString();
                        decimal donGia = Convert.ToDecimal(row.Cells["DonGiaXuat"].Value);
                        int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                        decimal thanhTien = Convert.ToDecimal(row.Cells["ThanhTien"].Value);

                        string insertCT = @"
                    INSERT INTO CT_PhieuXuatThuoc (MaPhieuXuat, MaThuoc, SoLuongXuat,DonGiaXuat )
                    VALUES (@MaPhieuXuat, @MaThuoc, @SoLuongXuat,@DonGiaXuat  );";

                        SqlCommand cmdCT = new SqlCommand(insertCT, conn, trans);
                        cmdCT.Parameters.AddWithValue("@MaPhieuXuat", maPhieu);
                        cmdCT.Parameters.AddWithValue("@MaThuoc", maThuoc);
                        cmdCT.Parameters.AddWithValue("@SoLuongXuat", soLuong);
                        cmdCT.Parameters.AddWithValue("@DonGiaXuat", donGia);
                        cmdCT.ExecuteNonQuery();

                        string capNhatThuoc = "UPDATE Thuoc SET SoLuongTon = SoLuongTon - @SL WHERE MaThuoc = @MaThuoc";
                        Connect.ExecuteNonQuery(capNhatThuoc, new SqlParameter[]
                        {
                new SqlParameter("@SL", soLuong),
                new SqlParameter("@MaThuoc", maThuoc)
                        });
                    }


                    // 3. Commit giao dịch
                    trans.Commit();
                    MessageBox.Show("Lưu phiếu xuất thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaPhieu.Text = maPhieu.ToString();
                }
                catch (Exception ex)
                {
                    // Rollback nếu lỗi
                    trans.Rollback();
                    MessageBox.Show("Lỗi khi lưu phiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXuatPX_Click(object sender, EventArgs e)
        {
            if (dgvChiTietXuat.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Lưu phiếu xuất dưới dạng Excel",
                FileName = "PhieuXuat_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx"
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
                        for (int i = 0; i < dgvChiTietXuat.Columns.Count; i++)
                        {
                            if (dgvChiTietXuat.Columns[i] is DataGridViewButtonColumn) continue;

                            worksheet.Cell(1, colIndex).Value = dgvChiTietXuat.Columns[i].HeaderText;
                            worksheet.Cell(1, colIndex).Style.Font.Bold = true;
                            worksheet.Cell(1, colIndex).Style.Fill.BackgroundColor = XLColor.LightGray;
                            worksheet.Cell(1, colIndex).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            colIndex++;
                        }

                        // Ghi dữ liệu
                        for (int i = 0; i < dgvChiTietXuat.Rows.Count; i++)
                        {
                            colIndex = 1;
                            for (int j = 0; j < dgvChiTietXuat.Columns.Count; j++)
                            {
                                if (dgvChiTietXuat.Columns[j] is DataGridViewButtonColumn) continue;

                                var value = dgvChiTietXuat.Rows[i].Cells[j].FormattedValue?.ToString();
                                worksheet.Cell(i + 2, colIndex).Value = value;
                                worksheet.Cell(i + 2, colIndex).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                colIndex++;
                            }
                        }

                        int tongSoDong = dgvChiTietXuat.Rows.Count + 2;
                        worksheet.Cell(tongSoDong, 1).Value = "Tổng tiền:";
                        worksheet.Cell(tongSoDong, 2).Value = lblTongTien.Text;
                        worksheet.Range(tongSoDong, 1, tongSoDong, 2).Style.Font.Bold = true;
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