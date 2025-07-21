using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An1.Models
{
    public class BenhNhan
    {
        public int MaBN { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public char GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string TienSuBenh { get; set; }
        public string NgheNghiep { get; set; }
        public DateTime NgayDangKy { get; set; }
        public bool TrangThai { get; set; }
    }
}
