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
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Data.SqlClient;
using ClosedXML.Excel;

namespace Do_An1.QuanTri.Báo_cáo___thống_kê
{
    public partial class UcThongKeHoatDong : UserControl
    {
        public UcThongKeHoatDong()
        {
            InitializeComponent();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            ThongKeHoatDongBacSi(tuNgay, denNgay);
            ThongKeHoatDongNhanVien(tuNgay, denNgay);
        }

        private void ThongKeHoatDongBacSi(DateTime tuNgay, DateTime denNgay)
        {
            string query = @"
    SELECT 
        BS.HoTen AS BacSi, 
        COUNT(NK.MaNhatKy) AS SoHoatDong,
        (SELECT COUNT(LK.MaLichKham) FROM LichKham LK WHERE LK.MaBS = BS.MaBS AND LK.NgayKham BETWEEN @TuNgay AND @DenNgay) AS SoLuotKham
    FROM TaiKhoan TK
    LEFT JOIN NhatKyHeThong NK ON NK.MaTaiKhoan = TK.MaTaiKhoan AND NK.ThoiGian BETWEEN @TuNgay AND @DenNgay
    LEFT JOIN BacSi BS ON BS.MaBS = TK.MaBacSi
    INNER JOIN VaiTro VT ON VT.MaVaiTro = TK.MaVaiTro AND VT.TenVaiTro = N'Bác sĩ'
    WHERE TK.MaBacSi IS NOT NULL
    GROUP BY BS.HoTen, BS.MaBS
    ORDER BY SoHoatDong DESC";

            SqlParameter[] prms = {
        new SqlParameter("@TuNgay", SqlDbType.Date) { Value = tuNgay },
        new SqlParameter("@DenNgay", SqlDbType.Date) { Value = denNgay }
    };

            DataTable dt = Connect.ExecuteQuery(query, prms);
            Console.WriteLine($"Số bản ghi trong DataTable: {dt.Rows.Count}");
            dgvBacSi.DataSource = dt;

            // Tính tổng hoạt động
            int tongHoatDong = dt.AsEnumerable().Sum(row => row.Field<int>("SoHoatDong"));
            lblTongLuotKham.Text = $"Tổng hoạt động: {tongHoatDong}";

            // Đảm bảo DataGridView hiển thị đầy đủ
            dgvBacSi.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvBacSi.ScrollBars = ScrollBars.Both;

            // CLEAR & RESET chart
            chartBacSi.Series.Clear();
            chartBacSi.ChartAreas.Clear();
            chartBacSi.Titles.Clear();

            // Thiết lập ChartArea và tiêu đề
            chartBacSi.Titles.Add($"Số hoạt động của bác sĩ ({tuNgay:dd/MM/yyyy} - {denNgay:dd/MM/yyyy})");
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.IsLabelAutoFit = false;
            chartArea.AxisX.LabelStyle.Angle = -45;
            chartArea.AxisY.Minimum = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chartArea.AxisX.CustomLabels.Add(i - 0.5, i + 0.5, dt.Rows[i]["BacSi"].ToString());
            }
            chartBacSi.ChartAreas.Add(chartArea);

            // Tạo Series cho biểu đồ
            Series series = new Series("Hoạt động")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            // Thêm dữ liệu vào Series
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string tenBacSi = dt.Rows[i]["BacSi"].ToString();
                int soHoatDong = dt.Rows[i]["SoHoatDong"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[i]["SoHoatDong"]);
                series.Points.AddXY(i, soHoatDong);
                Console.WriteLine($"Thêm vào chart: {tenBacSi} - {soHoatDong} hoạt động");
            }

            // Thêm Series vào chart
            chartBacSi.Series.Add(series);

            // Đặt tiêu đề trục
            chartBacSi.ChartAreas["MainArea"].AxisX.Title = "Họ tên bác sĩ";
            chartBacSi.ChartAreas["MainArea"].AxisY.Title = "Số hoạt động";
        }


        private void ThongKeHoatDongNhanVien(DateTime tuNgay, DateTime denNgay)
        {
            string query = @"
    SELECT 
        NV.HoTen AS NhanVien, 
        COUNT(NK.MaNhatKy) AS SoHoatDong,
        (SELECT COUNT(HD.MaHoaDon) FROM HoaDon HD WHERE HD.MaNV = NV.MaNV AND HD.NgayTao BETWEEN @TuNgay AND @DenNgay) AS SoHoaDon
    FROM TaiKhoan TK
    LEFT JOIN NhatKyHeThong NK ON NK.MaTaiKhoan = TK.MaTaiKhoan AND NK.ThoiGian BETWEEN @TuNgay AND @DenNgay
    LEFT JOIN NhanVien NV ON NV.MaNV = TK.MaNhanVien
    INNER JOIN VaiTro VT ON VT.MaVaiTro = TK.MaVaiTro AND VT.TenVaiTro = N'Nhân viên'
    WHERE TK.MaNhanVien IS NOT NULL
    GROUP BY NV.HoTen, NV.MaNV
    ORDER BY SoHoatDong DESC";

            SqlParameter[] prms = {
        new SqlParameter("@TuNgay", SqlDbType.Date) { Value = tuNgay },
        new SqlParameter("@DenNgay", SqlDbType.Date) { Value = denNgay }
    };

            DataTable dt = Connect.ExecuteQuery(query, prms);
            Console.WriteLine($"Số bản ghi trong DataTable: {dt.Rows.Count}");
            dgvNhanVien.DataSource = dt;

            // Tính tổng hoạt động
            int tongHoatDong = dt.AsEnumerable().Sum(row => row.Field<int>("SoHoatDong"));
            lblTongHoaDon.Text = $"Tổng hoạt động: {tongHoatDong}";

            // Đảm bảo DataGridView hiển thị đầy đủ
            dgvNhanVien.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvNhanVien.ScrollBars = ScrollBars.Both;

            // CLEAR & RESET chart
            chartNhanVien.Series.Clear();
            chartNhanVien.ChartAreas.Clear();
            chartNhanVien.Titles.Clear();

            // Thiết lập ChartArea và tiêu đề
            chartNhanVien.Titles.Add($"Số hoạt động của nhân viên ({tuNgay:dd/MM/yyyy} - {denNgay:dd/MM/yyyy})");
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.IsLabelAutoFit = false;
            chartArea.AxisX.LabelStyle.Angle = -45;
            chartArea.AxisY.Minimum = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chartArea.AxisX.CustomLabels.Add(i - 0.5, i + 0.5, dt.Rows[i]["NhanVien"].ToString());
            }
            chartNhanVien.ChartAreas.Add(chartArea);

            // Tạo Series cho biểu đồ
            Series series = new Series("Hoạt động")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            // Thêm dữ liệu vào Series
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string tenNhanVien = dt.Rows[i]["NhanVien"].ToString();
                int soHoatDong = dt.Rows[i]["SoHoatDong"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[i]["SoHoatDong"]);
                series.Points.AddXY(i, soHoatDong);
                Console.WriteLine($"Thêm vào chart: {tenNhanVien} - {soHoatDong} hoạt động");
            }

            // Thêm Series vào chart
            chartNhanVien.Series.Add(series);

            // Đặt tiêu đề trục
            chartNhanVien.ChartAreas["MainArea"].AxisX.Title = "Họ tên nhân viên";
            chartNhanVien.ChartAreas["MainArea"].AxisY.Title = "Số hoạt động";
        }

        private void btnXuatExcelHoatDong_Click(object sender, EventArgs e)
        {
            if (dgvBacSi.Rows.Count == 0 && dgvNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Lưu file thống kê hoạt động",
                FileName = $"ThongKeHoatDong_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Console.WriteLine($"Đang lưu file: {sfd.FileName}");
                        using (var workbook = new XLWorkbook())
                        {
                            // Sheet cho bác sĩ
                            if (dgvBacSi.Rows.Count > 0)
                            {
                                var worksheetBacSi = workbook.Worksheets.Add("Thống kê bác sĩ");

                                // Thêm tiêu đề
                                worksheetBacSi.Cell(1, 1).Value = "Thống kê hoạt động của bác sĩ";
                                worksheetBacSi.Cell(1, 1).Style.Font.Bold = true;
                                worksheetBacSi.Cell(1, 1).Style.Font.FontSize = 14;
                                worksheetBacSi.Range("A1:B1").Merge().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                                // Thêm tiêu đề cột
                                worksheetBacSi.Cell(3, 1).Value = "Họ tên bác sĩ";
                                worksheetBacSi.Cell(3, 2).Value = "Số hoạt động";
                                worksheetBacSi.Range("A3:B3").Style.Font.Bold = true;
                                worksheetBacSi.Range("A3:B3").Style.Fill.BackgroundColor = XLColor.LightGray;
                                worksheetBacSi.Range("A3:B3").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                                // Đổ dữ liệu từ DataGridView
                                for (int i = 0; i < dgvBacSi.Rows.Count; i++)
                                {
                                    var tenBacSi = dgvBacSi.Rows[i].Cells["BacSi"]?.Value;
                                    var soHoatDong = dgvBacSi.Rows[i].Cells["SoHoatDong"]?.Value;

                                    worksheetBacSi.Cell(i + 4, 1).Value = tenBacSi?.ToString() ?? "";
                                    worksheetBacSi.Cell(i + 4, 2).Value = soHoatDong != null ? Convert.ToInt32(soHoatDong) : 0;

                                    worksheetBacSi.Range($"A{i + 4}:B{i + 4}").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                }

                                // Định dạng số
                                worksheetBacSi.Column(2).Style.NumberFormat.Format = "#,##0";

                                // Tự điều chỉnh độ rộng cột
                                worksheetBacSi.Columns().AdjustToContents();
                            }

                            // Sheet cho nhân viên
                            if (dgvNhanVien.Rows.Count > 0)
                            {
                                var worksheetNhanVien = workbook.Worksheets.Add("Thống kê nhân viên");

                                // Thêm tiêu đề
                                worksheetNhanVien.Cell(1, 1).Value = "Thống kê hoạt động của nhân viên";
                                worksheetNhanVien.Cell(1, 1).Style.Font.Bold = true;
                                worksheetNhanVien.Cell(1, 1).Style.Font.FontSize = 14;
                                worksheetNhanVien.Range("A1:B1").Merge().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                                // Thêm tiêu đề cột
                                worksheetNhanVien.Cell(3, 1).Value = "Họ tên nhân viên";
                                worksheetNhanVien.Cell(3, 2).Value = "Số hoạt động";
                                worksheetNhanVien.Range("A3:B3").Style.Font.Bold = true;
                                worksheetNhanVien.Range("A3:B3").Style.Fill.BackgroundColor = XLColor.LightGray;
                                worksheetNhanVien.Range("A3:B3").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                                // Đổ dữ liệu từ DataGridView
                                for (int i = 0; i < dgvNhanVien.Rows.Count; i++)
                                {
                                    var tenNhanVien = dgvNhanVien.Rows[i].Cells["NhanVien"]?.Value;
                                    var soHoatDong = dgvNhanVien.Rows[i].Cells["SoHoatDong"]?.Value;

                                    worksheetNhanVien.Cell(i + 4, 1).Value = tenNhanVien?.ToString() ?? "";
                                    worksheetNhanVien.Cell(i + 4, 2).Value = soHoatDong != null ? Convert.ToInt32(soHoatDong) : 0;

                                    worksheetNhanVien.Range($"A{i + 4}:B{i + 4}").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                }

                                // Định dạng số
                                worksheetNhanVien.Column(2).Style.NumberFormat.Format = "#,##0";

                                // Tự điều chỉnh độ rộng cột
                                worksheetNhanVien.Columns().AdjustToContents();
                            }

                            // Kiểm tra và tạo thư mục nếu chưa tồn tại
                            string directory = Path.GetDirectoryName(sfd.FileName);
                            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                            {
                                Directory.CreateDirectory(directory);
                            }

                            // Kiểm tra file đang mở trước khi lưu
                            if (File.Exists(sfd.FileName))
                            {
                                try
                                {
                                    File.Delete(sfd.FileName); // Xóa file cũ nếu đang tồn tại
                                }
                                catch (IOException)
                                {
                                    MessageBox.Show("File Excel đang được mở. Vui lòng đóng file trước khi lưu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }

                            // Lưu file
                            workbook.SaveAs(sfd.FileName);
                            MessageBox.Show("Xuất Excel thành công với 2 tab!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        MessageBox.Show($"Lỗi quyền truy cập: {ex.Message}\nVui lòng kiểm tra quyền ghi vào thư mục.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"Lỗi I/O: {ex.Message}\nFile có thể đang được sử dụng hoặc thư mục không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine($"StackTrace: {ex.StackTrace}");
                    }
                }
            }
        }
    }
    }
