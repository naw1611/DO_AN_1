using Do_An1.Helpers;
using Do_An1.Models;
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
    public partial class FormAdmin : Form
    {
        Dictionary<Panel, System.Windows.Forms.Timer> submenuTimers = new();
        public FormAdmin()
        {
        }

        public FormAdmin(int maTaiKhoan, string vaiTro)
        {
            InitializeComponent();
            lblChaoMung.Text = $"Xin chào, {SessionDangNhap.TenDangNhap} ({SessionDangNhap.VaiTro})";

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
                new FormDangNhap().Show();
                this.Close();
            }
        }

        private void btnQLTK_Click(object sender, EventArgs e)
        {
            panelSubTaiKhoan.Visible = !panelSubTaiKhoan.Visible;
            ToggleSubmenuSmooth(panelSubTaiKhoan, 70);
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



        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            panelDanhMuc.Visible = !panelDanhMuc.Visible;
            ToggleSubmenuSmooth(panelDanhMuc, 175);
        }

        private void btnKham_Click(object sender, EventArgs e)
        {
            panelKham.Visible = !panelKham.Visible;
            ToggleSubmenuSmooth(panelKham, 140);
        }

        private void btnKhoThuoc_Click(object sender, EventArgs e)
        {
            panelKhoThuoc.Visible = !panelKhoThuoc.Visible;
            ToggleSubmenuSmooth(panelKhoThuoc, 105);
        }

        private void btnBaoCaoThongKe_Click(object sender, EventArgs e)
        {
            panelBaoCaoThongKe.Visible = !panelBaoCaoThongKe.Visible;
            ToggleSubmenuSmooth(panelBaoCaoThongKe, 150);
        }

        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            LoadControl(new UcPhanQuyen());
        }

        private void btnBacSi_Click(object sender, EventArgs e)
        {
            LoadControl(new UcBacSi());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            LoadControl(new UcNhanVien());
        }

        private void btnBenhNhan_Click(object sender, EventArgs e)
        {
            LoadControl(new UcBenhNhan());
        }

        private void btnLoaiThuoc_Click(object sender, EventArgs e)
        {
            LoadControl(new UcLoaiThuoc());
        }

        private void btnThuoc_Click(object sender, EventArgs e)
        {
            LoadControl(new UcThuoc());
        }

        private void btnLapPhieuKham_Click(object sender, EventArgs e)
        {
            LoadControl(new UcLapPhieu());
        }

        private void btnNhanThanhToan_Click(object sender, EventArgs e)
        {
            LoadControl(new UcThanhToan());
        }

        private void btnTraCuuLich_Click(object sender, EventArgs e)
        {
            LoadControl(new UcTraCuuLich());
        }

        private void btnKeDonThuoc_Click(object sender, EventArgs e)
        {
            LoadControl(new UcKeDonThuoc());
        }


        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            LoadControl(new UcLapPhieuNhap());
        }

        private void btnLapPhieuXuat_Click(object sender, EventArgs e)
        {
            LoadControl(new UcLapPhieuXuat());
        }
    }
}
