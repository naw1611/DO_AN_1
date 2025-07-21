using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An1.Models
{
    public class PhieuNhapThuoc
    {
        public int MaPhieuNhap { get; set; }
        public DateTime NgayNhap { get; set; }
        public int MaNV { get; set; }
        public string GhiChu { get; set; }
        public string TrangThai { get; set; }
        public decimal TongTien { get; set; }
    }
}
