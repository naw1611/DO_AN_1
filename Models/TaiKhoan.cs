using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An1.Models
{
    public class TaiKhoan
    {
        public int MaTaiKhoan { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; }
        public int? MaNhanVien { get; set; }
        public int? MaBacSi { get; set; }
        public string Email { get; set; }
        public DateTime? LanDangNhapCuoi { get; set; }
        public bool TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
        public int MaVaiTro { get; set; }
    }
}
