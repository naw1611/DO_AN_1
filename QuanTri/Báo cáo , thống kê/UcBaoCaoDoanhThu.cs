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
using System.Windows.Forms.DataVisualization.Charting;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using Microsoft.Data.SqlClient;
using ClosedXML.Excel;
namespace Do_An1.QuanTri.Báo_cáo___thống_kê
{
    public partial class UcBaoCaoDoanhThu : UserControl
    {
        public UcBaoCaoDoanhThu()
        {
            InitializeComponent();
            LoadComboBoxNam();
        }

        private void LoadComboBoxNam()
        {
            int currentYear = DateTime.Now.Year;
            for (int year = 2022; year <= currentYear; year++)
            {
                cboNam.Items.Add(year);
            }
            cboNam.SelectedIndex = cboNam.Items.Count - 1; // Mặc định năm hiện tại
        }

        private void btnThongKeDoanhThu_Click(object sender, EventArgs e)
        {
            if (cboNam.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn năm cần thống kê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int nam = Convert.ToInt32(cboNam.SelectedItem);
            string query = @"
        WITH Months AS (
            SELECT 1 AS Thang UNION ALL
            SELECT 2 UNION ALL
            SELECT 3 UNION ALL
            SELECT 4 UNION ALL
            SELECT 5 UNION ALL
            SELECT 6 UNION ALL
            SELECT 7 UNION ALL
            SELECT 8 UNION ALL
            SELECT 9 UNION ALL
            SELECT 10 UNION ALL
            SELECT 11 UNION ALL
            SELECT 12
        )
        SELECT m.Thang, ISNULL(SUM(hd.TongTien), 0) AS DoanhThu
        FROM Months m
        LEFT JOIN HoaDon hd ON MONTH(hd.NgayTao) = m.Thang AND YEAR(hd.NgayTao) = @Nam
        GROUP BY m.Thang
        ORDER BY m.Thang";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Nam", SqlDbType.Int) { Value = nam }
            };

            DataTable dt = Connect.ExecuteQuery(query, null, parameters);

            // Đổ dữ liệu vào DataGridView
            dgvDoanhThu.DataSource = dt;

            // Tính tổng doanh thu
            decimal tongDoanhThu = dt.AsEnumerable().Sum(row => row.Field<decimal>("DoanhThu"));
            lblTongDoanhThu.Text = $"Tổng doanh thu: {tongDoanhThu:N0} VNĐ";

            // Hiển thị dữ liệu lên biểu đồ
            VeBieuDoDoanhThu(dt, nam);
        }

        private void VeBieuDoDoanhThu(DataTable dt, int nam)
        {
            chartDoanhThu.Series.Clear();
            chartDoanhThu.Titles.Clear();
            chartDoanhThu.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.IsLabelAutoFit = false;
            chartArea.AxisX.Maximum = 12.5;
            chartArea.AxisX.Minimum = 0.5;
            chartArea.AxisX.LabelStyle.Angle = -45; // Xoay nhãn để tránh chồng lấp
            chartArea.AxisY.Minimum = 0;
            for (int i = 1; i <= 12; i++)
            {
                chartArea.AxisX.CustomLabels.Add(i - 0.5, i + 0.5, $"Tháng {i}");
            }
            chartDoanhThu.ChartAreas.Add(chartArea);

            Series series = new Series("Doanh thu")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                LabelFormat = "{0:N0} VNĐ" // Định dạng tiền tệ
            };

            var dataMap = new Dictionary<int, decimal>();
            for (int i = 1; i <= 12; i++)
            {
                dataMap[i] = 0; // Mặc định 0
            }
            foreach (DataRow row in dt.Rows)
            {
                int thang = Convert.ToInt32(row["Thang"]);
                decimal doanhThu = row["DoanhThu"] != DBNull.Value ? Convert.ToDecimal(row["DoanhThu"]) : 0;
                dataMap[thang] = doanhThu;
            }

            foreach (var item in dataMap)
            {
                series.Points.AddXY(item.Key, item.Value);
                Console.WriteLine($"Thêm điểm: Tháng {item.Key}, Doanh thu: {item.Value}");
            }

            chartDoanhThu.Series.Add(series);
            chartDoanhThu.ChartAreas["MainArea"].AxisX.Title = "Tháng";
            chartDoanhThu.ChartAreas["MainArea"].AxisY.Title = "Doanh thu (VNĐ)";
            chartDoanhThu.Titles.Add($"Thống kê doanh thu - Năm {nam}");
            chartDoanhThu.Width = Math.Max(chartDoanhThu.Width, 600);
            chartDoanhThu.Height = Math.Max(chartDoanhThu.Height, 400);
        }
        private void btnXuatExcelDoanhThu_Click(object sender, EventArgs e)
        {
            if (dgvDoanhThu.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Lưu file thống kê doanh thu",
                FileName = $"ThongKeDoanhThu_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Console.WriteLine($"Đang lưu file: {sfd.FileName}");
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Thống kê doanh thu");

                            // Thêm tiêu đề
                            worksheet.Cell(1, 1).Value = "Thống kê doanh thu theo tháng";
                            worksheet.Cell(1, 1).Style.Font.Bold = true;
                            worksheet.Cell(1, 1).Style.Font.FontSize = 14;
                            worksheet.Range("A1:B1").Merge().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            // Thêm tiêu đề cột
                            worksheet.Cell(3, 1).Value = "Tháng";
                            worksheet.Cell(3, 2).Value = "Doanh thu (VNĐ)";
                            worksheet.Range("A3:B3").Style.Font.Bold = true;
                            worksheet.Range("A3:B3").Style.Fill.BackgroundColor = XLColor.LightGray;
                            worksheet.Range("A3:B3").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                            // Đổ dữ liệu từ DataGridView
                            for (int i = 0; i < dgvDoanhThu.Rows.Count; i++)
                            {
                                // Kiểm tra và lấy giá trị từ cột
                                var thangCell = dgvDoanhThu.Rows[i].Cells["Thang"]?.Value; // Giả định cột "Thang"
                                var doanhThuCell = dgvDoanhThu.Rows[i].Cells["DoanhThu"]?.Value; // Giả định cột "DoanhThu"

                                worksheet.Cell(i + 4, 1).Value = thangCell?.ToString() ?? "";
                                worksheet.Cell(i + 4, 2).Value = doanhThuCell != null ? Convert.ToDecimal(doanhThuCell) : 0;

                                // Định dạng viền cho từng hàng
                                worksheet.Range($"A{i + 4}:B{i + 4}").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            }

                            // Định dạng tiền tệ cho cột "Doanh thu"
                            worksheet.Column(2).Style.NumberFormat.Format = "#,##0";

                            // Tự điều chỉnh độ rộng cột
                            worksheet.Columns().AdjustToContents();

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
                            MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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