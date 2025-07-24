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
using Microsoft.Data.SqlClient;
using ClosedXML.Excel;

namespace Do_An1.QuanTri.Báo_cáo___thống_kê
{
    public partial class UcThongKeSoLuotKham : UserControl
    {
        public UcThongKeSoLuotKham()
        {
            InitializeComponent();
            LoadComboBoxNam();
        }

        private void LoadComboBoxNam()
        {
            int currentYear = DateTime.Now.Year; // 2025 theo ngày hiện tại (03:18 PM +07, 22/07/2025)
            for (int year = 2022; year <= currentYear; year++)
            {
                cboNam.Items.Add(year);
            }
            cboNam.SelectedIndex = cboNam.Items.Count - 1; // Mặc định chọn năm hiện tại
        }

        private void btnThongKe_Click(object sender, EventArgs e)
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
                SELECT m.Thang, ISNULL(COUNT(lk.NgayKham), 0) AS SoLuotKham
                FROM Months m
                LEFT JOIN LichKham lk ON MONTH(lk.NgayKham) = m.Thang AND YEAR(lk.NgayKham) = @Nam
                GROUP BY m.Thang
                ORDER BY m.Thang";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Nam", SqlDbType.Int) { Value = nam }
            };

            DataTable dt = Connect.ExecuteQuery(query, null, parameters);
            Console.WriteLine($"Số hàng trong dt: {dt.Rows.Count}"); // Debug
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu cho năm này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Tính tổng
            int tongLuotKham = dt.AsEnumerable().Sum(row => row.Field<int>("SoLuotKham"));
            lblTongLuotKham.Text = $"Tổng số lượt khám: {tongLuotKham}";

            dgvThongKe.DataSource = dt;
            VeBieuDo(dt, nam);
        }

        private void VeBieuDo(DataTable dt, int nam)
        {
            chartThongKe.Series.Clear();
            chartThongKe.Titles.Clear();
            chartThongKe.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.AxisX.Interval = 1; // Hiển thị tất cả các tháng
            chartArea.AxisX.IsLabelAutoFit = true; // Tự động điều chỉnh nhãn
            chartArea.AxisX.Maximum = 12.5; // Đảm bảo hiển thị đến Tháng 12
            chartArea.AxisX.Minimum = 0.5;  // Bắt đầu từ giữa cột đầu
            chartArea.AxisX.LabelStyle.Angle = -45; // Xoay nhãn 45 độ để tránh chồng lấp
            chartArea.AxisX.LabelStyle.Interval = 1; // Hiển thị nhãn cho mỗi tháng
            chartArea.AxisY.Minimum = 0;
            chartThongKe.ChartAreas.Add(chartArea);

            Series series = new Series("Số lượt khám")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true // Hiển thị giá trị trên cột
            };


            // Tạo dictionary để đảm bảo 12 tháng
            var dataMap = new Dictionary<int, int>();
            for (int i = 1; i <= 12; i++)
            {
                dataMap[i] = 0; // Mặc định 0
            }
            foreach (DataRow row in dt.Rows)
            {
                int thang = Convert.ToInt32(row["Thang"]);
                int soLuot = row["SoLuotKham"] != DBNull.Value ? Convert.ToInt32(row["SoLuotKham"]) : 0;
                dataMap[thang] = soLuot;
            }

            // Thêm tất cả 12 tháng vào series
            foreach (var item in dataMap)
            {
                series.Points.AddXY(item.Key, item.Value); // Sử dụng số tháng làm giá trị X
                Console.WriteLine($"Thêm điểm: Tháng {item.Key}, Số lượt: {item.Value}"); // Debug
            }
            for (int i = 1; i <= 12; i++)
            {
                Console.WriteLine($"Thêm nhãn: Tháng {i}");
                chartArea.AxisX.CustomLabels.Add(i - 0.5, i + 0.5, $"Tháng {i}");
            }
            chartThongKe.Series.Add(series);
            chartThongKe.ChartAreas["MainArea"].AxisX.Title = "Tháng";
            chartThongKe.ChartAreas["MainArea"].AxisY.Title = "Số lượt khám";
            chartThongKe.Titles.Add($"Thống kê số lượt khám - Năm {nam}");
            chartThongKe.Width = Math.Max(chartThongKe.Width, 800);
            chartThongKe.Height = Math.Max(chartThongKe.Height, 400);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvThongKe.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Lưu file thống kê",
                FileName = $"ThongKeSoLuotKham_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Console.WriteLine($"Đang lưu file: {sfd.FileName}");
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Thống kê lượt khám");

                            // Thêm tiêu đề
                            worksheet.Cell(1, 1).Value = "Thống kê số lượt khám theo tháng";
                            worksheet.Cell(1, 1).Style.Font.Bold = true;
                            worksheet.Cell(1, 1).Style.Font.FontSize = 14;
                            worksheet.Range("A1:B1").Merge().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            // Thêm tiêu đề cột
                            worksheet.Cell(3, 1).Value = "Tháng";
                            worksheet.Cell(3, 2).Value = "Số lượt khám";
                            worksheet.Range("A3:B3").Style.Font.Bold = true;
                            worksheet.Range("A3:B3").Style.Fill.BackgroundColor = XLColor.LightGray;
                            worksheet.Range("A3:B3").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                            // Đổ dữ liệu từ DataGridView
                            for (int i = 0; i < dgvThongKe.Rows.Count; i++)
                            {
                                // Kiểm tra và lấy giá trị từ cột
                                var thangCell = dgvThongKe.Rows[i].Cells["Thang"]?.Value; // Giả định cột "Thang"
                                var soLuotCell = dgvThongKe.Rows[i].Cells["SoLuotKham"]?.Value; // Giả định cột "SoLuotKham"

                                worksheet.Cell(i + 4, 1).Value = thangCell?.ToString() ?? "";
                                worksheet.Cell(i + 4, 2).Value = soLuotCell != null ? Convert.ToInt32(soLuotCell) : 0;

                                // Định dạng viền cho từng hàng
                                worksheet.Range($"A{i + 4}:B{i + 4}").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            }

                            // Định dạng số cho cột "Số lượt khám"
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
