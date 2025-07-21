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
    public partial class FormSuaThuoc: Form
    {
        private int maThuoc;

        public FormSuaThuoc(int maThuoc)
        {
            InitializeComponent();
            this.maThuoc = maThuoc;
            LoadDanhMuc();
            LoadThongTin();
        }

        private void LoadDanhMuc()
        {
            string query = "SELECT MaDanhMuc, TenDanhMuc FROM DanhMucThuoc";
            DataTable dt = Connect.ExecuteQuery(query);
            cmbDanhMuc.DataSource = dt;
            cmbDanhMuc.DisplayMember = "TenDanhMuc";
            cmbDanhMuc.ValueMember = "MaDanhMuc";
        }

        private void LoadThongTin()
        {
            string query = "SELECT * FROM Thuoc WHERE MaThuoc = @MaThuoc";
            SqlParameter prm = new SqlParameter("@MaThuoc", maThuoc);
            DataTable dt = Connect.ExecuteQuery(query, prm);
            if (dt.Rows.Count > 0)
            {
                var r = dt.Rows[0];
                txtTen.Text = r["TenThuoc"].ToString();
                txtDVT.Text = r["DonViTinh"].ToString();
                nudGia.Value = Convert.ToDecimal(r["DonGiaBan"]);
                nudSL.Value = Convert.ToDecimal(r["SoLuongTon"]);
                dtpHSD.Value = Convert.ToDateTime(r["HanSuDung"]);
                txtNSX.Text = r["NhaSanXuat"].ToString();
                txtCachDung.Text = r["CachDung"].ToString();
                cmbDanhMuc.SelectedValue = r["MaDanhMuc"];
            }
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
                string query = @"UPDATE Thuoc SET TenThuoc = @TenThuoc, DonViTinh = @DonViTinh, DonGiaBan = @DonGiaBan,
                                    SoLuongTon = @SoLuongTon, HanSuDung = @HanSuDung, NhaSanXuat = @NhaSanXuat,
                                    CachDung = @CachDung, MaDanhMuc = @MaDanhMuc
                                 WHERE MaThuoc = @MaThuoc";

                SqlParameter[] prms = {
                    new SqlParameter("@TenThuoc", txtTen.Text.Trim()),
                    new SqlParameter("@DonViTinh", txtDVT.Text.Trim()),
                    new SqlParameter("@DonGiaBan", nudGia.Value),
                    new SqlParameter("@SoLuongTon", nudSL.Value),
                    new SqlParameter("@HanSuDung", dtpHSD.Value.Date),
                    new SqlParameter("@NhaSanXuat", txtNSX.Text.Trim()),
                    new SqlParameter("@CachDung", txtCachDung.Text.Trim()),
                    new SqlParameter("@MaDanhMuc", cmbDanhMuc.SelectedValue),
                    new SqlParameter("@MaThuoc", maThuoc)
                };
                Connect.ExecuteNonQuery(query, prms);
                MessageBox.Show("Cập nhật thuốc thành công!", "Thông báo");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }
    }
}

