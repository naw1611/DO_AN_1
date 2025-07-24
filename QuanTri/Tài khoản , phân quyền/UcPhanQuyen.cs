using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Do_An1.Helpers;

namespace Do_An1.QuanTri
{
    public partial class UcPhanQuyen : UserControl
    {

        public UcPhanQuyen()
        {
            InitializeComponent();
            LoadVaiTro(); // Gọi hàm để load vai trò khi UC được khởi tạo
        }

        // Load danh sách vai trò vào ComboBox
        private void LoadVaiTro()
        {
            string query = "SELECT MaVaiTro, TenVaiTro FROM VaiTro"; // Truy vấn lấy danh sách vai trò
            DataTable dt = Connect.ExecuteQuery(query);

            cmbVaiTro.DataSource = dt;
            cmbVaiTro.DisplayMember = "TenVaiTro"; // Hiển thị tên vai trò
            cmbVaiTro.ValueMember = "MaVaiTro"; // Lấy mã vai trò
            cmbVaiTro.SelectedIndex = -1;
        }

        // Khi vai trò thay đổi, load quyền tương ứng
        private void cmbVaiTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadQuyen(); // Gọi hàm để load quyền của vai trò đã chọn
        }

        // Load danh sách quyền vào CheckedListBox
        private void LoadQuyen()
        {
            clbQuyen.Items.Clear();

            // Kiểm tra giá trị hợp lệ
            if (cmbVaiTro.SelectedValue == null || cmbVaiTro.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn vai trò!", "Thông báo");
                return;
            }

            try
            {
                if (!int.TryParse(cmbVaiTro.SelectedValue.ToString(), out int maVaiTro))
                {
                    MessageBox.Show("Mã vai trò không hợp lệ!", "Lỗi");
                    return;
                }

                // Truy vấn tất cả quyền
                string allQuyenQuery = "SELECT MaQuyen, TenQuyen FROM Quyen";
                DataTable dtAll = Connect.ExecuteQuery(allQuyenQuery);

                // Truy vấn các quyền đã được cấp
                string quyenDuocCapQuery = "SELECT MaQuyen FROM VaiTro_Quyen WHERE MaVaiTro = @MaVaiTro";
                DataTable dtChecked = Connect.ExecuteQuery(quyenDuocCapQuery, new SqlParameter("@MaVaiTro", maVaiTro));

                // Chuyển danh sách quyền đã cấp sang list để kiểm tra nhanh
                var dsQuyenDaCap = dtChecked.AsEnumerable().Select(r => (int)r["MaQuyen"]).ToList();

                foreach (DataRow row in dtAll.Rows)
                {
                    string tenQuyen = row["TenQuyen"].ToString();
                    int maQuyen = Convert.ToInt32(row["MaQuyen"]);
                    bool checkedItem = dsQuyenDaCap.Contains(maQuyen);

                    clbQuyen.Items.Add(new ListItem(tenQuyen, maQuyen), checkedItem);
                }

                lblThongBao.Text = $"Vai trò này có {clbQuyen.CheckedItems.Count} quyền.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải quyền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Lưu quyền vào cơ sở dữ liệu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cmbVaiTro.SelectedValue == null) return;
            int maVaiTro = Convert.ToInt32(cmbVaiTro.SelectedValue);

            // Xóa hết quyền cũ của vai trò này
            string deleteQuery = "DELETE FROM VaiTro_Quyen WHERE MaVaiTro = @MaVaiTro";
            Connect.ExecuteNonQuery(deleteQuery, new SqlParameter("@MaVaiTro", maVaiTro));

            // Thêm các quyền mới đang được check vào bảng VaiTro_Quyen
            foreach (ListItem item in clbQuyen.CheckedItems)
            {
                string insertQuery = "INSERT INTO VaiTro_Quyen (MaVaiTro, MaQuyen) VALUES (@MaVaiTro, @MaQuyen)";
                SqlParameter[] parameters = {
                new SqlParameter("@MaVaiTro", maVaiTro),
                new SqlParameter("@MaQuyen", item.Value)
            };
                Connect.ExecuteNonQuery(insertQuery, parameters);
            }

            MessageBox.Show("Cập nhật phân quyền thành công!", "Thông báo");
        }

        // Tải lại quyền khi nhấn "Tải lại"
        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadQuyen(); // Gọi lại hàm load quyền
        }

        // Lớp ListItem dùng để hiển thị tên quyền và lưu mã quyền
        private class ListItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public ListItem(string text, int value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString() => Text;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                // Nếu không nhập gì, thì load lại toàn bộ quyền
                LoadQuyen();
                return;
            }

            if (cmbVaiTro.SelectedValue == null) return;

            int maVaiTro = Convert.ToInt32(cmbVaiTro.SelectedValue);

            // Truy vấn quyền khớp từ khóa
            string timQuyenQuery = "SELECT MaQuyen, TenQuyen FROM Quyen WHERE TenQuyen LIKE @kw OR MoTa LIKE @kw";
            string quyenDuocCapQuery = "SELECT MaQuyen FROM VaiTro_Quyen WHERE MaVaiTro = @MaVaiTro";

            DataTable dtAll = Connect.ExecuteQuery(timQuyenQuery, new SqlParameter("@kw", "%" + tuKhoa + "%"));
            DataTable dtChecked = Connect.ExecuteQuery(quyenDuocCapQuery, new SqlParameter("@MaVaiTro", maVaiTro));

            clbQuyen.Items.Clear();

            foreach (DataRow row in dtAll.Rows)
            {
                string tenQuyen = row["TenQuyen"].ToString();
                int maQuyen = (int)row["MaQuyen"];
                bool checkedItem = dtChecked.AsEnumerable().Any(x => (int)x["MaQuyen"] == maQuyen);

                clbQuyen.Items.Add(new ListItem(tenQuyen, maQuyen), checkedItem);
            }
        }

        
    }
}
