using Do_An1.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An1.QuanTri.Danh_mục
{
    public partial class FormThemThuoc: Form
    {
        public FormThemThuoc()
        {
            InitializeComponent();
            LoadDanhMuc();
        }

        private void LoadDanhMuc()
        {
            string query = "SELECT MaDanhMuc, TenDanhMuc FROM DanhMucThuoc";
            DataTable dt = Connect.ExecuteQuery(query);
            cmbDanhMuc.DataSource = dt;
            cmbDanhMuc.DisplayMember = "TenDanhMuc";
            cmbDanhMuc.ValueMember = "MaDanhMuc";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu
                if (string.IsNullOrWhiteSpace(txtTen.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên thuốc.");
                    txtTen.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDVT.Text))
                {
                    MessageBox.Show("Vui lòng nhập đơn vị tính.");
                    txtDVT.Focus();
                    return;
                }

                if (dtpHSD.Value.Date < DateTime.Now.Date)
                {
                    MessageBox.Show("Hạn sử dụng không được nhỏ hơn ngày hôm nay.");
                    return;
                }

                string query = @"INSERT INTO Thuoc (TenThuoc, DonViTinh, DonGiaBan, SoLuongTon, HanSuDung, NhaSanXuat, CachDung, MaDanhMuc)
                                 VALUES (@TenThuoc, @DonViTinh, @DonGiaBan, @SoLuongTon, @HanSuDung, @NhaSanXuat, @CachDung, @MaDanhMuc)";

                SqlParameter[] prms = {
                    new SqlParameter("@TenThuoc", txtTen.Text.Trim()),
                    new SqlParameter("@DonViTinh", txtDVT.Text.Trim()),
                    new SqlParameter("@DonGiaBan", nudGia.Value),
                    new SqlParameter("@SoLuongTon", nudSL.Value),
                    new SqlParameter("@HanSuDung", dtpHSD.Value.Date),
                    new SqlParameter("@NhaSanXuat", txtNSX.Text.Trim()),
                    new SqlParameter("@CachDung", txtCachDung.Text.Trim()),
                    new SqlParameter("@MaDanhMuc", cmbDanhMuc.SelectedValue)
                };
                Connect.ExecuteNonQuery(query, prms);
                MessageBox.Show("Thêm thuốc thành công!", "Thông báo");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm thuốc: " + ex.Message);
            }
        }
    }
}