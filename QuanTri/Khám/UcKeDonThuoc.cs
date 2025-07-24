using System;
using System.Data;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Do_An1.Helpers;
using Microsoft.Data.SqlClient;

namespace Do_An1.QuanTri.Khám
{
    public partial class UcKeDonThuoc : UserControl
    {
        private System.Data.DataTable dtThuocKe; // Danh sách thuốc đã thêm
        private int maPhieuKhamDuocChon = -1;
        private int maNV; // Giả định MaNV của nhân viên hiện tại, cần gán giá trị thực tế

        public UcKeDonThuoc()
        {
            InitializeComponent();
            // Gán MaNV (cần thay bằng logic thực tế để lấy từ người dùng hiện tại)
            maNV = 1; // Ví dụ, thay bằng giá trị thực từ session hoặc context
            Load += new EventHandler(UcKeDonThuoc_Load);
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
            dtThuocKe.Columns.Add("GhiChu", typeof(string)); // Thêm cột GhiChu

            if (dgvDonThuoc != null)
            {
                dgvDonThuoc.DataSource = dtThuocKe;
                dgvDonThuoc.Columns["MaThuoc"].Visible = false;
                dgvDonThuoc.Columns["TenThuoc"].HeaderText = "Tên thuốc";
                dgvDonThuoc.Columns["TenThuoc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvDonThuoc.Columns["SoLuong"].HeaderText = "Số lượng";
                dgvDonThuoc.Columns["SoLuong"].Width = 80;
                dgvDonThuoc.Columns["LieuDung"].HeaderText = "Liều dùng";
                dgvDonThuoc.Columns["LieuDung"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvDonThuoc.Columns["Sang"].HeaderText = "Sáng";
                dgvDonThuoc.Columns["Sang"].Width = 50;
                dgvDonThuoc.Columns["Trua"].HeaderText = "Trưa";
                dgvDonThuoc.Columns["Trua"].Width = 50;
                dgvDonThuoc.Columns["Chieu"].HeaderText = "Chiều";
                dgvDonThuoc.Columns["Chieu"].Width = 50;
                dgvDonThuoc.Columns["Toi"].HeaderText = "Tối";
                dgvDonThuoc.Columns["Toi"].Width = 50;
                dgvDonThuoc.Columns["SoNgay"].HeaderText = "Số ngày";
                dgvDonThuoc.Columns["SoNgay"].Width = 70;
                dgvDonThuoc.Columns["GhiChu"].HeaderText = "Ghi chú";
                dgvDonThuoc.Columns["GhiChu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Thêm cột nút Xóa
                if (!dgvDonThuoc.Columns.Contains("Xoa"))
                {
                    DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn();
                    btnXoa.Name = "Xoa";
                    btnXoa.HeaderText = "Xóa";
                    btnXoa.Text = "Xóa";
                    btnXoa.UseColumnTextForButtonValue = true;
                    dgvDonThuoc.Columns.Add(btnXoa);
                }
                dgvDonThuoc.ScrollBars = ScrollBars.Both;
                dgvDonThuoc.AllowUserToAddRows = false;
            }
            else
            {
                MessageBox.Show("DataGridView 'dgvDonThuoc' không được khai báo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadPhieuKhamDaXacNhan();
            LoadThuoc();
        }

        private void LoadThuoc()
        {
            string query = "SELECT MaThuoc, TenThuoc FROM Thuoc WHERE SoLuongTon > 0 AND HanSuDung >= @Today";
            SqlParameter[] prms = { new SqlParameter("@Today", SqlDbType.Date) { Value = DateTime.Today } };
            try
            {
                System.Data.DataTable dt = Connect.ExecuteQuery(query, prms);
                Console.WriteLine($"Loaded {dt.Rows.Count} records for cboThuoc");
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu thuốc hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboThuoc.DataSource = null;
                }
                else
                {
                    cboThuoc.DataSource = dt;
                    cboThuoc.DisplayMember = "TenThuoc";
                    cboThuoc.ValueMember = "MaThuoc";
                    cboThuoc.AutoCompleteMode = AutoCompleteMode.Suggest;
                    cboThuoc.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thuốc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPhieuKhamDaXacNhan()
        {
            string query = @"
        SELECT lk.MaLichKham, bn.HoTen AS TenBenhNhan, bs.HoTen AS TenBS, 
               CONVERT(VARCHAR, lk.NgayKham, 103) AS NgayKham, lk.LyDo
        FROM LichKham lk
        JOIN BenhNhan bn ON lk.MaBN = bn.MaBN
        JOIN BacSi bs ON lk.MaBS = bs.MaBS
        WHERE lk.TrangThai = N'Xác nhận'";

            try
            {
                System.Data.DataTable dt = Connect.ExecuteQuery(query);
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có phiếu khám nào đã xác nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboPhieuKham.DataSource = null;
                    txtMaPhieu.Text = "";
                    txtTenBN.Text = "";
                    txtTenBS.Text = "";
                    txtNgayKham.Text = "";
                    txtLyDo.Text = "";
                    txtMaHoSo.Text = "";
                    txtTrieuChung.Text = "";
                    txtChanDoan.Text = "";
                    txtLoiDan.Text = "";
                    dtpNgayTaiKham.Value = DateTime.Now;
                }
                else
                {
                    cboPhieuKham.DataSource = dt;
                    cboPhieuKham.DisplayMember = "TenBenhNhan";
                    cboPhieuKham.ValueMember = "MaLichKham";
                    Console.WriteLine($"Loaded {dt.Rows.Count} confirmed appointments. First MaLichKham: {dt.Rows[0]["MaLichKham"]}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải phiếu khám đã xác nhận: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboPhieuKham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhieuKham.SelectedValue == null || cboPhieuKham.SelectedValue == DBNull.Value) return;

            try
            {
                int maLK;
                if (cboPhieuKham.SelectedValue is DataRowView rowView)
                {
                    maLK = Convert.ToInt32(rowView["MaLichKham"]);
                }
                else
                {
                    maLK = Convert.ToInt32(cboPhieuKham.SelectedValue);
                }
                DataRowView drv = cboPhieuKham.SelectedItem as DataRowView;

                txtMaPhieu.Text = maLK.ToString();
                txtTenBN.Text = drv["TenBenhNhan"]?.ToString() ?? "";
                txtTenBS.Text = drv["TenBS"]?.ToString() ?? "";
                txtNgayKham.Text = drv["NgayKham"]?.ToString() ?? "";
                txtLyDo.Text = drv["LyDo"]?.ToString() ?? "";
                maPhieuKhamDuocChon = maLK;

                string queryHoSo = "SELECT MaHoSo, TrieuChung, ChanDoan, LoiDan, NgayTaiKham FROM HoSoKham WHERE MaLichKham = @MaLichKham";
                SqlParameter paramHoSo = new SqlParameter("@MaLichKham", SqlDbType.Int) { Value = maLK };
                DataTable dtHoSo = Connect.ExecuteQuery(queryHoSo, paramHoSo);

                if (dtHoSo.Rows.Count > 0)
                {
                    DataRow row = dtHoSo.Rows[0];
                    txtMaHoSo.Text = row["MaHoSo"].ToString();
                    txtTrieuChung.Text = row["TrieuChung"].ToString() ?? "";
                    txtChanDoan.Text = row["ChanDoan"].ToString() ?? "";
                    txtLoiDan.Text = row["LoiDan"].ToString() ?? "";
                    dtpNgayTaiKham.Value = row["NgayTaiKham"] != DBNull.Value ? Convert.ToDateTime(row["NgayTaiKham"]) : DateTime.Now;
                }
                else
                {
                    string queryInsertHoSo = @"
                INSERT INTO HoSoKham (MaLichKham, TrieuChung, ChanDoan, LoiDan, NgayTaiKham, DaThanhToan)
                OUTPUT INSERTED.MaHoSo VALUES (@MaLichKham, '', '', '', NULL, 0)";
                    SqlParameter paramInsert = new SqlParameter("@MaLichKham", SqlDbType.Int) { Value = maLK };
                    int maHoSo = Convert.ToInt32(Connect.ExecuteScalar(queryInsertHoSo, paramInsert));
                    txtMaHoSo.Text = maHoSo.ToString();
                    txtTrieuChung.Text = "";
                    txtChanDoan.Text = "";
                    txtLoiDan.Text = "";
                    dtpNgayTaiKham.Value = DateTime.Now;
                }
                Console.WriteLine($"Selected MaLichKham: {maLK}, MaHoSo: {txtMaHoSo.Text}");
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
                MessageBox.Show("Vui lòng chọn thuốc và nhập số lượng cùng liều dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int maThuoc = Convert.ToInt32(cboThuoc.SelectedValue);
                string tenThuoc = cboThuoc.Text;
                int soLuong = Convert.ToInt32(txtSoLuong.Text);
                string lieuDung = txtLieuDung.Text.Trim();
                int sang = (int)numSang.Value;
                int trua = (int)numTrua.Value;
                int chieu = (int)numChieu.Value;
                int toi = (int)numToi.Value;
                int soNgay = (int)numSoNgay.Value;
                string ghiChu = string.IsNullOrEmpty(txtGhiChuThuoc.Text) ? null : txtGhiChuThuoc.Text.Trim();

                if (soLuong <= 0 || soNgay <= 0)
                {
                    MessageBox.Show("Số lượng và số ngày phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string queryCheck = "SELECT SoLuongTon FROM Thuoc WHERE MaThuoc = @MaThuoc";
                SqlParameter[] prmsCheck = { new SqlParameter("@MaThuoc", SqlDbType.Int) { Value = maThuoc } };
                int soLuongTon = Convert.ToInt32(Connect.ExecuteScalar(queryCheck, prmsCheck));
                if (soLuongTon < soLuong)
                {
                    MessageBox.Show("Số lượng tồn không đủ! Số lượng tồn: " + soLuongTon, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtThuocKe.AsEnumerable().Any(row => row.Field<int>("MaThuoc") == maThuoc))
                {
                    MessageBox.Show("Thuốc này đã được thêm vào danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dtThuocKe.Rows.Add(maThuoc, tenThuoc, soLuong, lieuDung, sang, trua, chieu, toi, soNgay, ghiChu);
                dgvDonThuoc.Refresh();

                ClearThuocFields();
                Console.WriteLine($"Added drug: MaThuoc={maThuoc}, SoLuong={soLuong}");
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập số lượng là số nguyên hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa thuốc này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dtThuocKe.Rows.RemoveAt(e.RowIndex);
                        dgvDonThuoc.Refresh();
                        Console.WriteLine($"Removed row at index {e.RowIndex}");
                    }
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
                            // Lấy hoặc tạo MaHoSo
                            string checkQuery = "SELECT MaHoSo FROM HoSoKham WHERE MaLichKham = @MaLichKham";
                            SqlParameter checkParam = new SqlParameter("@MaLichKham", SqlDbType.Int) { Value = maPhieuKhamDuocChon };
                            object result = Connect.ExecuteScalar(checkQuery, new[] { checkParam }, transaction);
                            int maHoSo = result != DBNull.Value ? Convert.ToInt32(result) : 0;

                            if (maHoSo == 0) // Nếu chưa có, thêm mới
                            {
                                string queryInsertHSK = @"
                            INSERT INTO HoSoKham (MaLichKham, TrieuChung, ChanDoan, LoiDan, NgayTaiKham, DaThanhToan)
                            OUTPUT INSERTED.MaHoSo VALUES (@MaLichKham, @TrieuChung, @ChanDoan, @LoiDan, @NgayTaiKham, 0)";
                                SqlParameter[] paraHSK = {
                            new SqlParameter("@MaLichKham", SqlDbType.Int) { Value = maPhieuKhamDuocChon },
                            new SqlParameter("@TrieuChung", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(txtTrieuChung.Text) ? (object)DBNull.Value : txtTrieuChung.Text },
                            new SqlParameter("@ChanDoan", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(txtChanDoan.Text) ? (object)DBNull.Value : txtChanDoan.Text },
                            new SqlParameter("@LoiDan", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(txtLoiDan.Text) ? (object)DBNull.Value : txtLoiDan.Text },
                            new SqlParameter("@NgayTaiKham", SqlDbType.Date) { Value = dtpNgayTaiKham.Value }
                        };
                                maHoSo = Convert.ToInt32(Connect.ExecuteScalar(queryInsertHSK, paraHSK, transaction));
                                txtMaHoSo.Text = maHoSo.ToString();
                            }
                            else // Cập nhật nếu đã tồn tại
                            {
                                string queryUpdateHSK = @"
                            UPDATE HoSoKham SET TrieuChung = @TrieuChung, ChanDoan = @ChanDoan, LoiDan = @LoiDan, NgayTaiKham = @NgayTaiKham
                            WHERE MaHoSo = @MaHoSo";
                                SqlParameter[] paraUpdate = {
                            new SqlParameter("@MaHoSo", SqlDbType.Int) { Value = maHoSo },
                            new SqlParameter("@TrieuChung", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(txtTrieuChung.Text) ? (object)DBNull.Value : txtTrieuChung.Text },
                            new SqlParameter("@ChanDoan", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(txtChanDoan.Text) ? (object)DBNull.Value : txtChanDoan.Text },
                            new SqlParameter("@LoiDan", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(txtLoiDan.Text) ? (object)DBNull.Value : txtLoiDan.Text },
                            new SqlParameter("@NgayTaiKham", SqlDbType.Date) { Value = dtpNgayTaiKham.Value }
                        };
                                Connect.ExecuteNonQuery(queryUpdateHSK, paraUpdate, transaction);
                            }

                            // Tính tổng tiền thuốc dựa trên DonGiaBan
                            decimal tongTienThuoc = 0;
                            foreach (DataRow row in dtThuocKe.Rows)
                            {
                                int maThuoc = Convert.ToInt32(row["MaThuoc"]);
                                int soLuong = Convert.ToInt32(row["SoLuong"]);
                                string queryDonGia = "SELECT DonGiaBan FROM Thuoc WHERE MaThuoc = @MaThuoc";
                                SqlParameter[] prmsDonGia = { new SqlParameter("@MaThuoc", SqlDbType.Int) { Value = maThuoc } };
                                decimal donGiaBan = Convert.ToDecimal(Connect.ExecuteScalar(queryDonGia, prmsDonGia, transaction) ?? 0);
                                tongTienThuoc += donGiaBan * soLuong;
                            }

                            // Tạo hóa đơn
                            string queryInsertHoaDon = @"
                        INSERT INTO HoaDon (MaLichKham, MaNV, MaBenhNhan, NgayTao, TienKham, TienThuoc, GiamGia, DaThanhToan)
                        OUTPUT INSERTED.MaHoaDon VALUES (
                            @MaLichKham, @MaNV, (SELECT MaBN FROM LichKham WHERE MaLichKham = @MaLichKham), @NgayTao, 0, @TienThuoc, 0, 0)";
                            SqlParameter[] prmsHoaDon = {
                        new SqlParameter("@MaLichKham", SqlDbType.Int) { Value = maPhieuKhamDuocChon },
                        new SqlParameter("@MaNV", SqlDbType.Int) { Value = maNV },
                        new SqlParameter("@NgayTao", SqlDbType.DateTime) { Value = DateTime.Now },
                        new SqlParameter("@TienThuoc", SqlDbType.Decimal) { Value = tongTienThuoc }
                    };
                            int maHoaDon = Convert.ToInt32(Connect.ExecuteScalar(queryInsertHoaDon, prmsHoaDon, transaction));

                            // Lưu danh sách thuốc
                            string insertThuoc = @"
                        INSERT INTO DonThuoc (MaHoSo, MaThuoc, SoLuong, LieuDung, Sang, Trua, Chieu, Toi, SoNgay, GhiChu)
                        VALUES (@MaHoSo, @MaThuoc, @SoLuong, @LieuDung, @Sang, @Trua, @Chieu, @Toi, @SoNgay, @GhiChu)";
                            foreach (DataRow row in dtThuocKe.Rows)
                            {
                                int soLuong = Convert.ToInt32(row["SoLuong"]);
                                int soNgay = Convert.ToInt32(row["SoNgay"]);
                                if (soLuong <= 0 || soNgay <= 0)
                                {
                                    throw new Exception("Số lượng hoặc số ngày không hợp lệ!");
                                }

                                SqlParameter[] p = {
                            new SqlParameter("@MaHoSo", SqlDbType.Int) { Value = maHoSo },
                            new SqlParameter("@MaThuoc", SqlDbType.Int) { Value = row["MaThuoc"] },
                            new SqlParameter("@SoLuong", SqlDbType.Int) { Value = soLuong },
                            new SqlParameter("@LieuDung", SqlDbType.NVarChar) { Value = row["LieuDung"] ?? "" },
                            new SqlParameter("@Sang", SqlDbType.Int) { Value = row["Sang"] },
                            new SqlParameter("@Trua", SqlDbType.Int) { Value = row["Trua"] },
                            new SqlParameter("@Chieu", SqlDbType.Int) { Value = row["Chieu"] },
                            new SqlParameter("@Toi", SqlDbType.Int) { Value = row["Toi"] },
                            new SqlParameter("@SoNgay", SqlDbType.Int) { Value = soNgay },
                            new SqlParameter("@GhiChu", SqlDbType.NVarChar) { Value = row["GhiChu"] ?? (object)DBNull.Value }
                        };
                                Connect.ExecuteNonQuery(insertThuoc, p, transaction);

                                // Cập nhật số lượng tồn kho
                                string updateThuoc = "UPDATE Thuoc SET SoLuongTon = SoLuongTon - @SoLuong WHERE MaThuoc = @MaThuoc";
                                SqlParameter[] prmsUpdate = {
                            new SqlParameter("@SoLuong", SqlDbType.Int) { Value = soLuong },
                            new SqlParameter("@MaThuoc", SqlDbType.Int) { Value = row["MaThuoc"] }
                        };
                                Connect.ExecuteNonQuery(updateThuoc, prmsUpdate, transaction);
                            }

                            transaction.Commit();
                            MessageBox.Show($"Lưu đơn thuốc và hóa đơn (Mã: {maHoaDon}) thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dtThuocKe.Clear();
                            LoadPhieuKhamDaXacNhan();
                            ClearAllFields();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Lỗi khi lưu đơn thuốc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearAllFields()
        {
            txtMaPhieu.Text = "";
            txtTenBN.Text = "";
            txtTenBS.Text = "";
            txtNgayKham.Text = "";
            txtLyDo.Text = "";
            txtMaHoSo.Text = "";
            txtTrieuChung.Text = "";
            txtChanDoan.Text = "";
            txtLoiDan.Text = "";
            dtpNgayTaiKham.Value = DateTime.Now;
            ClearThuocFields();
            maPhieuKhamDuocChon = -1;
        }

        private void ClearThuocFields()
        {
            txtSoLuong.Text = "";
            txtLieuDung.Text = "";
            numSang.Value = 0;
            numTrua.Value = 0;
            numChieu.Value = 0;
            numToi.Value = 0;
            numSoNgay.Value = 7;
            txtGhiChuThuoc.Text = "";
            cboThuoc.SelectedIndex = -1;
        }

        private void btnInDonThuoc_Click(object sender, EventArgs e)
        {
            if (maPhieuKhamDuocChon == -1 || dtThuocKe.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu khám và thêm thuốc trước khi in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrintPage += (s, ev) =>
                {
                    float yPos = ev.MarginBounds.Top;
                    int count = 0;
                    float leftMargin = ev.MarginBounds.Left;
                    float lineHeight = 20;
                    Font printFont = new Font("Arial", 12);
                    Font titleFont = new Font("Arial", 14, FontStyle.Bold);

                    // Tiêu đề
                    ev.Graphics.DrawString("ĐƠN THUỐC", titleFont, Brushes.Black, leftMargin, yPos);
                    yPos += lineHeight * 2;

                    // Thông tin phiếu khám
                    ev.Graphics.DrawString($"Mã phiếu: {txtMaPhieu.Text}", printFont, Brushes.Black, leftMargin, yPos);
                    yPos += lineHeight;
                    ev.Graphics.DrawString($"Bệnh nhân: {txtTenBN.Text}", printFont, Brushes.Black, leftMargin, yPos);
                    yPos += lineHeight;
                    ev.Graphics.DrawString($"Bác sĩ: {txtTenBS.Text}", printFont, Brushes.Black, leftMargin, yPos);
                    yPos += lineHeight;
                    ev.Graphics.DrawString($"Ngày khám: {txtNgayKham.Text}", printFont, Brushes.Black, leftMargin, yPos);
                    yPos += lineHeight;
                    ev.Graphics.DrawString($"Lý do: {txtLyDo.Text}", printFont, Brushes.Black, leftMargin, yPos);
                    yPos += lineHeight * 2;

                    // Thông tin hồ sơ
                    ev.Graphics.DrawString("THÔNG TIN HỒ SƠ KHÁM", titleFont, Brushes.Black, leftMargin, yPos);
                    yPos += lineHeight * 2;
                    ev.Graphics.DrawString($"Mã hồ sơ: {txtMaHoSo.Text}", printFont, Brushes.Black, leftMargin, yPos);
                    yPos += lineHeight;
                    ev.Graphics.DrawString($"Triệu chứng: {txtTrieuChung.Text}", printFont, Brushes.Black, leftMargin, yPos);
                    yPos += lineHeight;
                    ev.Graphics.DrawString($"Chẩn đoán: {txtChanDoan.Text}", printFont, Brushes.Black, leftMargin, yPos);
                    yPos += lineHeight;
                    ev.Graphics.DrawString($"Lời dặn: {txtLoiDan.Text}", printFont, Brushes.Black, leftMargin, yPos);
                    yPos += lineHeight;
                    ev.Graphics.DrawString($"Ngày tái khám: {dtpNgayTaiKham.Value.ToString("dd/MM/yyyy")}", printFont, Brushes.Black, leftMargin, yPos);
                    yPos += lineHeight * 2;

                    // Tiêu đề danh sách thuốc
                    ev.Graphics.DrawString("DANH SÁCH THUỐC", titleFont, Brushes.Black, leftMargin, yPos);
                    yPos += lineHeight * 2;

                    // Vẽ bảng thuốc
                    string[] headers = { "Tên thuốc", "Số lượng", "Liều dùng", "Sáng", "Trưa", "Chiều", "Tối", "Số ngày", "Ghi chú" };
                    float[] widths = { 150, 60, 100, 40, 40, 40, 40, 60, 150 };
                    float xPos = leftMargin;

                    // Vẽ header
                    for (int i = 0; i < headers.Length; i++)
                    {
                        ev.Graphics.DrawRectangle(Pens.Black, xPos, yPos, widths[i], lineHeight);
                        ev.Graphics.DrawString(headers[i], printFont, Brushes.Black, xPos + 2, yPos + 2);
                        xPos += widths[i];
                    }
                    yPos += lineHeight;
                    xPos = leftMargin;

                    // Vẽ dữ liệu thuốc
                    foreach (DataRow row in dtThuocKe.Rows)
                    {
                        if (yPos > ev.MarginBounds.Bottom)
                        {
                            ev.HasMorePages = true;
                            return;
                        }

                        xPos = leftMargin;
                        ev.Graphics.DrawRectangle(Pens.Black, xPos, yPos, widths[0], lineHeight);
                        ev.Graphics.DrawString(row["TenThuoc"].ToString(), printFont, Brushes.Black, xPos + 2, yPos + 2);
                        xPos += widths[0];

                        ev.Graphics.DrawRectangle(Pens.Black, xPos, yPos, widths[1], lineHeight);
                        ev.Graphics.DrawString(row["SoLuong"].ToString(), printFont, Brushes.Black, xPos + 2, yPos + 2);
                        xPos += widths[1];

                        ev.Graphics.DrawRectangle(Pens.Black, xPos, yPos, widths[2], lineHeight);
                        ev.Graphics.DrawString(row["LieuDung"].ToString(), printFont, Brushes.Black, xPos + 2, yPos + 2);
                        xPos += widths[2];

                        ev.Graphics.DrawRectangle(Pens.Black, xPos, yPos, widths[3], lineHeight);
                        ev.Graphics.DrawString(row["Sang"].ToString(), printFont, Brushes.Black, xPos + 2, yPos + 2);
                        xPos += widths[3];

                        ev.Graphics.DrawRectangle(Pens.Black, xPos, yPos, widths[4], lineHeight);
                        ev.Graphics.DrawString(row["Trua"].ToString(), printFont, Brushes.Black, xPos + 2, yPos + 2);
                        xPos += widths[4];

                        ev.Graphics.DrawRectangle(Pens.Black, xPos, yPos, widths[5], lineHeight);
                        ev.Graphics.DrawString(row["Chieu"].ToString(), printFont, Brushes.Black, xPos + 2, yPos + 2);
                        xPos += widths[5];

                        ev.Graphics.DrawRectangle(Pens.Black, xPos, yPos, widths[6], lineHeight);
                        ev.Graphics.DrawString(row["Toi"].ToString(), printFont, Brushes.Black, xPos + 2, yPos + 2);
                        xPos += widths[6];

                        ev.Graphics.DrawRectangle(Pens.Black, xPos, yPos, widths[7], lineHeight);
                        ev.Graphics.DrawString(row["SoNgay"].ToString(), printFont, Brushes.Black, xPos + 2, yPos + 2);
                        xPos += widths[7];

                        ev.Graphics.DrawRectangle(Pens.Black, xPos, yPos, widths[8], lineHeight);
                        ev.Graphics.DrawString(row["GhiChu"]?.ToString() ?? "", printFont, Brushes.Black, xPos + 2, yPos + 2);
                        xPos = leftMargin;
                        yPos += lineHeight;
                    }

                    ev.HasMorePages = false;
                };

                PrintPreviewDialog printPreview = new PrintPreviewDialog
                {
                    Document = printDoc
                };
                printPreview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi in đơn thuốc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}