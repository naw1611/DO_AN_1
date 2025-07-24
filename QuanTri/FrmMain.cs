using Do_An1.Helpers;
using Do_An1.Models;
using Do_An1.QuanTri.Báo_cáo___thống_kê;
using Do_An1.QuanTri.Khám;
using Do_An1.QuanTri.Kho_thuốc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An1.QuanTri
{
    public partial class FrmMain : Form
    {
        Dictionary<Panel, System.Windows.Forms.Timer> submenuTimers = new();
        private string? vaiTro;

        public FrmMain(int maTaiKhoan, string vaiTro)
        {
            InitializeComponent();
            this.vaiTro = vaiTro; // Sử dụng vaiTro từ constructor
            lblChaoMung.Text = $"Xin chào, {SessionDangNhap.TenDangNhap} ({SessionDangNhap.VaiTro})";
            ApplyPermission();
        }

        public FrmMain(string? vaiTro)
        {
            InitializeComponent();
            this.vaiTro = vaiTro; // Sử dụng vaiTro từ constructor
            lblChaoMung.Text = $"Xin chào, {SessionDangNhap.TenDangNhap} ({SessionDangNhap.VaiTro})";
            ApplyPermission();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Không cần thay đổi, giữ nguyên logic load
        }

        private void ApplyPermission()
        {
            if (string.IsNullOrEmpty(vaiTro)) vaiTro = SessionDangNhap.VaiTro; // Đồng bộ với Session

            switch (vaiTro)
            {
                case "Quản trị":
                case "Kế toán":
                    // Hiển thị tất cả chức năng cho Quản trị và Kế toán
                    EnableAllControls(true);
                    break;

                case "Nhân viên":
                    // Hiển thị Quản lý danh mục, Quản lý khám, và Quản lý kho thuốc
                    EnableAllControls(false);
                    panelDanhMuc.Visible = true;
                    btnDanhMuc.Enabled = true;
                    btnBenhNhan.Enabled = true;
                    btnLoaiThuoc.Enabled = true;
                    btnThuoc.Enabled = true;

                    panelKham.Visible = true;
                    btnKham.Enabled = true;
                    btnLapPhieuKham.Enabled = true;
                    btnNhanThanhToan.Enabled = true;
                    btnTraCuuLich.Enabled = true;

                    panelKhoThuoc.Visible = true;
                    btnKhoThuoc.Enabled = true;
                    btnKeDonThuoc.Enabled = true;
                    break;

                case "Bác sĩ":
                    // Chỉ hiển thị Quản lý khám với Kê đơn thuốc và Tra cứu lịch khám
                    EnableAllControls(false);
                    panelKham.Visible = true;
                    btnKham.Enabled = true;
                    btnKeDonThuoc.Enabled = true;
                    btnTraCuuLich.Enabled = true;
                    break;

                default:
                    MessageBox.Show("Vai trò không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    break;
            }
        }

        private void EnableAllControls(bool enabled)
        {
            panelSubTaiKhoan.Visible = enabled;
            btnQLTK.Enabled = enabled;
            btnPhanQuyen.Enabled = enabled;
            btnBacSi.Enabled = enabled;
            btnNhanVien.Enabled = enabled;
            btnBenhNhan.Enabled = enabled;

            panelDanhMuc.Visible = enabled;
            btnDanhMuc.Enabled = enabled;
            btnLoaiThuoc.Enabled = enabled;
            btnThuoc.Enabled = enabled;

            panelKham.Visible = enabled;
            btnKham.Enabled = enabled;
            btnLapPhieuKham.Enabled = enabled;
            btnNhanThanhToan.Enabled = enabled;
            btnTraCuuLich.Enabled = enabled;

            panelKhoThuoc.Visible = enabled;
            btnKhoThuoc.Enabled = enabled;
            btnKeDonThuoc.Enabled = enabled;
            btnPhieuNhap.Enabled = enabled;
            btnLapPhieuXuat.Enabled = enabled;

            panelBaoCaoThongKe.Visible = enabled;
            btnBaoCaoThongKe.Enabled = enabled;
            btnThongKeTonKho.Enabled = enabled;
            btnThongKeSoLuot.Enabled = enabled;
            btnBaoCaoDoanhThu.Enabled = enabled;
            btnThongKeHoatDong.Enabled = enabled;
        }

        private void LoadControl(UserControl control)
        {
            panelMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelMain.Controls.Add(control);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SessionDangNhap.Reset();
                this.Close();
                new FormDangNhap().Show();
            }
        }

        private void btnQLTK_Click(object sender, EventArgs e)
        {
            if (vaiTro == "Quản trị" || vaiTro == "Kế toán")
            {
                panelSubTaiKhoan.Visible = !panelSubTaiKhoan.Visible;
                ToggleSubmenuSmooth(panelSubTaiKhoan, 70);
            }
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            if (vaiTro == "Quản trị" || vaiTro == "Kế toán" || vaiTro == "Nhân viên")
            {
                panelDanhMuc.Visible = !panelDanhMuc.Visible;
                ToggleSubmenuSmooth(panelDanhMuc, 175);
            }
        }

        private void btnKham_Click(object sender, EventArgs e)
        {
            if (vaiTro == "Quản trị" || vaiTro == "Kế toán" || vaiTro == "Nhân viên" || vaiTro == "Bác sĩ")
            {
                panelKham.Visible = !panelKham.Visible;
                ToggleSubmenuSmooth(panelKham, 140);
            }
        }

        private void btnKhoThuoc_Click(object sender, EventArgs e)
        {
            if (vaiTro == "Quản trị" || vaiTro == "Kế toán" || vaiTro == "Nhân viên" || vaiTro == "Bác sĩ")
            {
                panelKhoThuoc.Visible = !panelKhoThuoc.Visible;
                ToggleSubmenuSmooth(panelKhoThuoc, 105);
            }
        }

        private void btnBaoCaoThongKe_Click(object sender, EventArgs e)
        {
            if (vaiTro == "Quản trị" || vaiTro == "Kế toán")
            {
                panelBaoCaoThongKe.Visible = !panelBaoCaoThongKe.Visible;
                ToggleSubmenuSmooth(panelBaoCaoThongKe, 150);
            }
        }

        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            if (vaiTro == "Quản trị" || vaiTro == "Kế toán") LoadControl(new UcPhanQuyen());
        }

        private void btnBacSi_Click(object sender, EventArgs e)
        {
            if (vaiTro == "Quản trị" || vaiTro == "Kế toán") LoadControl(new UcBacSi());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            if (vaiTro == "Quản trị" || vaiTro == "Kế toán") LoadControl(new UcNhanVien());
        }

        private void btnBenhNhan_Click(object sender, EventArgs e)
        {
            if (vaiTro == "Quản trị" || vaiTro == "Kế toán" || vaiTro == "Nhân viên") LoadControl(new UcBenhNhan());
        }

        private void btnLoaiThuoc_Click(object sender, EventArgs e)
        {
            if (vaiTro == "Quản trị" || vaiTro == "Kế toán" || vaiTro == "Nhân viên") LoadControl(new UcLoaiThuoc());
        }

        private void btnThuoc_Click(object sender, EventArgs e)
        {
            if (vaiTro == "Quản trị" || vaiTro == "Kế toán" || vaiTro == "Nhân viên") LoadControl(new UcThuoc());
        }

        private void btnLapPhieuKham_Click(object sender, EventArgs e)
        {
            if (vaiTro == "Quản trị" || vaiTro == "Kế toán" || vaiTro == "Nhân viên") LoadControl(new UcLapPhieu());
        }

        private void btnNhanThanhToan_Click(object sender, EventArgs e)
        {
            if (vaiTro == "Quản trị" || vaiTro == "Kế toán" || vaiTro == "Nhân viên") LoadControl(new UcThanhToan());
        }

        private void btnTraCuuLich_Click(object sender, EventArgs e)
        {
            if (vaiTro == "Quản trị" || vaiTro == "Kế toán" || vaiTro == "Nhân viên" || vaiTro == "Bác sĩ") LoadControl(new UcTraCuuLich());
        }

        private void btnKeDonThuoc_Click(object sender, EventArgs e)
        {
            if (vaiTro == "Quản trị" || vaiTro == "Kế toán" || vaiTro == "Nhân viên" || vaiTro == "Bác sĩ") LoadControl(new UcKeDonThuoc());
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            if (vaiTro == "Quản trị" || vaiTro == "Kế toán") LoadControl(new UcLapPhieuNhap());
        }

        private void btnLapPhieuXuat_Click(object sender, EventArgs e)
        {
            if (vaiTro == "Quản trị" || vaiTro == "Kế toán") LoadControl(new UcLapPhieuXuat());
        }

        private void btnThongKeTonKho_Click(object sender, EventArgs e)
        {
            if (vaiTro == "Quản trị" || vaiTro == "Kế toán") LoadControl(new UcThongKeTonKho());
        }

        private void btnThongKeSoLuot_Click(object sender, EventArgs e)
        {
            if (vaiTro == "Quản trị" || vaiTro == "Kế toán") LoadControl(new UcThongKeSoLuotKham());
        }

        private void btnBaoCaoDoanhThu_Click(object sender, EventArgs e)
        {
            if (vaiTro == "Quản trị" || vaiTro == "Kế toán") LoadControl(new UcBaoCaoDoanhThu());
        }

        private void btnThongKeHoatDong_Click(object sender, EventArgs e)
        {
            if (vaiTro == "Quản trị" || vaiTro == "Kế toán") LoadControl(new UcThongKeHoatDong());
        }

        private void ToggleSubmenuSmooth(Panel submenu1, int targetHeight)
        {
            if (!submenuTimers.ContainsKey(submenu1))
            {
                System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
                t.Interval = 10;
                t.Tick += (s, e) =>
                {
                    if (submenu1.Height < targetHeight)
                    {
                        submenu1.Height += 10;
                        if (submenu1.Height >= targetHeight)
                        {
                            submenu1.Height = targetHeight;
                            t.Stop();
                        }
                    }
                    else
                    {
                        submenu1.Height -= 10;
                        if (submenu1.Height <= 0)
                        {
                            submenu1.Height = 0;
                            t.Stop();
                        }
                    }
                };
                submenuTimers[submenu1] = t;
            }
            submenu1.Tag = submenu1.Height == 0 ? "open" : "close";
            submenuTimers[submenu1].Start();
        }
    }
}