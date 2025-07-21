using System;
using System.Data;
using System.Windows.Forms;
using Do_An1.Helpers;
using Microsoft.Data.SqlClient;

namespace Do_An1.QuanTri.Khám
{
    public partial class UcKeDonThuoc : UserControl
    {
        private DataTable dtThuocKe; // Danh sách thuốc đã thêm
        private int maPhieuKhamDuocChon = -1;

        public UcKeDonThuoc()
        {
            InitializeComponent();
        }

        private void LoadPhieuKhamChuaKe()
        {
            string query = @"
                SELECT lk.MaLichKham, bn.HoTen AS TenBN, bs.HoTen AS TenBS, lk.NgayKham, lk.LyDo,
                       CAST(lk.MaLichKham AS NVARCHAR(10)) + ' - ' + bn.HoTen AS DisplayText
                FROM LichKham lk
                JOIN BenhNhan bn ON lk.MaBN = bn.MaBN
                JOIN BacSi bs ON lk.MaBS = bs.MaBS
                WHERE lk.TrangThai = N'Hoàn tất' AND lk.MaLichKham NOT IN (SELECT MaLichKham FROM HoSoKham)
                ORDER BY lk.NgayKham DESC";

            try
            {
                DataTable dt = Connect.ExecuteQuery(query);
                Console.WriteLine($"Loaded {dt.Rows.Count} records for cboPhieuKham");
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có phiếu khám nào chưa kê đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboPhieuKham.DataSource = null;
                }
                else
                {
                    cboPhieuKham.DataSource = dt;
                    cboPhieuKham.DisplayMember = "DisplayText";
                    cboPhieuKham.ValueMember = "MaLichKham";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải phiếu khám: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadThuoc()
        {
            string query = "SELECT MaThuoc, TenThuoc FROM Thuoc";
            try
            {
                DataTable dt = Connect.ExecuteQuery(query);
                Console.WriteLine($"Loaded {dt.Rows.Count} records for cboThuoc");
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu thuốc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboThuoc.DataSource = null;
                }
                else
                {
                    cboThuoc.DataSource = dt;
                    cboThuoc.DisplayMember = "TenThuoc";
                    cboThuoc.ValueMember = "MaThuoc";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thuốc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UcKeDonThuoc_Load(object sender, EventArgs e)
        {
            dtThuocKe = new DataTable();
            dtThuocKe.Columns.Add("MaThuoc", typeof(int));
            dtThuocKe.Columns.Add("TenThuoc", typeof(string));
            dtThuocKe.Columns.Add("SoLuong", typeof(int));
            dtThuocKe.Columns.Add("LieuDung", typeof(string));
            dtThuocKe.Columns.Add("Sang", typeof(int));
            dtThuocKe.Columns.Add("Trua", typeof(int));
            dtThuocKe.Columns.Add("Chieu", typeof(int));
            dtThuocKe.Columns.Add("Toi", typeof(int));
            dtThuocKe.Columns.Add("SoNgay", typeof(int));

            if (dgvDonThuoc != null)
            {
                dgvDonThuoc.DataSource = dtThuocKe;

                if (!dgvDonThuoc.Columns.Contains("Xoa"))
                {
                    DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn();
                    btnXoa.Name = "Xoa";
                    btnXoa.HeaderText = "Xóa";
                    btnXoa.Text = "Xóa";
                    btnXoa.UseColumnTextForButtonValue = true;
                    dgvDonThuoc.Columns.Add(btnXoa);
                }

                dgvDonThuoc.Columns["MaThuoc"].Visible = false;
            }
            else
            {
                MessageBox.Show("DataGridView 'dgvDonThuoc' không được khai báo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadPhieuKhamChuaKe();
            LoadThuoc();
        }

        private void cboPhieuKham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhieuKham.SelectedValue == null || cboPhieuKham.SelectedValue == DBNull.Value) return;

            try
            {
                int maLK = Convert.ToInt32(cboPhieuKham.SelectedValue);
                DataRowView drv = cboPhieuKham.SelectedItem as DataRowView;

                lblMaPhieu.Text = maLK.ToString();
                lblBenhNhan.Text = drv["TenBN"].ToString();
                lblBacSi.Text = drv["TenBS"].ToString();
                lblNgayKham.Text = Convert.ToDateTime(drv["NgayKham"]).ToString("dd/MM/yyyy");
                lblLyDo.Text = drv["LyDo"]?.ToString() ?? "";
                maPhieuKhamDuocChon = maLK;

                // Load thông tin hồ sơ khám từ HoSoKham nếu đã tồn tại
                string queryHoSo = "SELECT TrieuChung, ChanDoan, LoiDan, NgayTaiKham FROM HoSoKham WHERE MaLichKham = @MaLichKham";
                SqlParameter param = new SqlParameter("@MaLichKham", SqlDbType.Int) { Value = maLK };
                DataTable dtHoSo = Connect.ExecuteQuery(queryHoSo, param);

                if (dtHoSo.Rows.Count > 0)
                {
                    DataRow row = dtHoSo.Rows[0];
                    txtTrieuChung.Text = row["TrieuChung"].ToString() ?? "";
                    txtChanDoan.Text = row["ChanDoan"].ToString() ?? "";
                    txtLoiDan.Text = row["LoiDan"].ToString() ?? "";
                    dtpNgayTaiKham.Value = row["NgayTaiKham"] != DBNull.Value ? Convert.ToDateTime(row["NgayTaiKham"]) : DateTime.Now;
                }
                else
                {
                    // Nếu chưa có hồ sơ, xóa nội dung cũ
                    txtTrieuChung.Text = "";
                    txtChanDoan.Text = "";
                    txtLoiDan.Text = "";
                    dtpNgayTaiKham.Value = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chọn phiếu khám: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            if (cboThuoc.SelectedValue == null || string.IsNullOrEmpty(txtSoLuong.Text) || string.IsNullOrEmpty(txtLieuDung.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin thuốc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int maThuoc = Convert.ToInt32(cboThuoc.SelectedValue);
                string tenThuoc = cboThuoc.Text;
                int soLuong = Convert.ToInt32(txtSoLuong.Text);
                string lieuDung = txtLieuDung.Text;
                int sang = (int)numSang.Value;
                int trua = (int)numTrua.Value;
                int chieu = (int)numChieu.Value;
                int toi = (int)numToi.Value;
                int soNgay = (int)numSoNgay.Value;

                if (soLuong <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (soNgay <= 0)
                {
                    MessageBox.Show("Số ngày phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dtThuocKe.Rows.Add(maThuoc, tenThuoc, soLuong, lieuDung, sang, trua, chieu, toi, soNgay);
                txtSoLuong.Clear();
                txtLieuDung.Clear();
                numSang.Value = 0;
                numTrua.Value = 0;
                numChieu.Value = 0;
                numToi.Value = 0;
                numSoNgay.Value = 7;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm thuốc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDonThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dtThuocKe.Rows.Count && e.ColumnIndex == dgvDonThuoc.Columns["Xoa"].Index)
                {
                    dtThuocKe.Rows.RemoveAt(e.RowIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa thuốc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (maPhieuKhamDuocChon == -1 || dtThuocKe.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu khám và thêm thuốc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = Connect.GetConnection())
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Kiểm tra xem MaLichKham đã có trong HoSoKham chưa
                            string checkQuery = "SELECT COUNT(*) FROM HoSoKham WHERE MaLichKham = @MaLichKham";
                            SqlParameter checkParam = new SqlParameter("@MaLichKham", SqlDbType.Int) { Value = maPhieuKhamDuocChon };
                            int count = Convert.ToInt32(Connect.ExecuteScalar(checkQuery, checkParam));

                            int maHoSo;
                            if (count == 0)
                            {
                                // Nếu chưa tồn tại, thêm mới vào HoSoKham
                                string queryInsertHSK = @"
                                    INSERT INTO HoSoKham (MaLichKham, TrieuChung, ChanDoan, LoiDan, NgayTaiKham, DaThanhToan)
                                    OUTPUT INSERTED.MaHoSo VALUES (@MaLichKham, @TrieuChung, @ChanDoan, @LoiDan, @NgayTaiKham, 0)";
                                SqlParameter[] paraHSK = {
                                    new SqlParameter("@MaLichKham", SqlDbType.Int) { Value = maPhieuKhamDuocChon },
                                    new SqlParameter("@TrieuChung", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(txtTrieuChung.Text) ? (object)DBNull.Value : txtTrieuChung.Text },
                                    new SqlParameter("@ChanDoan", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(txtChanDoan.Text) ? (object)DBNull.Value : txtChanDoan.Text },
                                    new SqlParameter("@LoiDan", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(txtLoiDan.Text) ? (object)DBNull.Value : txtLoiDan.Text },
                                    new SqlParameter("@NgayTaiKham", SqlDbType.Date) { Value = dtpNgayTaiKham.Value == null ? (object)DBNull.Value : dtpNgayTaiKham.Value }
                                };
                                maHoSo = Convert.ToInt32(Connect.ExecuteScalar(queryInsertHSK, paraHSK));
                            }
                            else
                            {
                                // Nếu đã tồn tại, lấy MaHoSo hiện tại (có thể cần cập nhật thông tin)
                                string queryGetMaHoSo = "SELECT MaHoSo FROM HoSoKham WHERE MaLichKham = @MaLichKham";
                                maHoSo = Convert.ToInt32(Connect.ExecuteScalar(queryGetMaHoSo, checkParam));
                            }

                            // Lưu danh sách thuốc
                            foreach (DataRow row in dtThuocKe.Rows)
                            {
                                int soLuong = Convert.ToInt32(row["SoLuong"]);
                                int soNgay = Convert.ToInt32(row["SoNgay"]);
                                if (soLuong <= 0 || soNgay <= 0)
                                {
                                    MessageBox.Show("Số lượng hoặc số ngày không hợp lệ trong danh sách thuốc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                string insertThuoc = @"
                                    INSERT INTO DonThuoc (MaHoSo, MaThuoc, SoLuong, LieuDung, Sang, Trua, Chieu, Toi, SoNgay, GhiChu)
                                    VALUES (@MaHoSo, @MaThuoc, @SoLuong, @LieuDung, @Sang, @Trua, @Chieu, @Toi, @SoNgay, @GhiChu)";
                                SqlParameter[] p = {
                                    new SqlParameter("@MaHoSo", SqlDbType.Int) { Value = maHoSo },
                                    new SqlParameter("@MaThuoc", SqlDbType.Int) { Value = row["MaThuoc"] },
                                    new SqlParameter("@SoLuong", SqlDbType.Int) { Value = soLuong },
                                    new SqlParameter("@LieuDung", SqlDbType.NVarChar) { Value = row["LieuDung"] },
                                    new SqlParameter("@Sang", SqlDbType.Int) { Value = row["Sang"] },
                                    new SqlParameter("@Trua", SqlDbType.Int) { Value = row["Trua"] },
                                    new SqlParameter("@Chieu", SqlDbType.Int) { Value = row["Chieu"] },
                                    new SqlParameter("@Toi", SqlDbType.Int) { Value = row["Toi"] },
                                    new SqlParameter("@SoNgay", SqlDbType.Int) { Value = soNgay },
                                    new SqlParameter("@GhiChu", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(txtGhiChuThuoc.Text) ? (object)DBNull.Value : txtGhiChuThuoc.Text }
                                };
                                Connect.ExecuteNonQuery(insertThuoc, p);
                            }

                            transaction.Commit();
                            MessageBox.Show("Lưu đơn thuốc và hồ sơ khám thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dtThuocKe.Clear();
                            LoadPhieuKhamChuaKe(); // Cập nhật lại danh sách phiếu khám
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Lỗi khi lưu đơn thuốc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}