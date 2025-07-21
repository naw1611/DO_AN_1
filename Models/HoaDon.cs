using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An1.Models
{
    public class HoaDon
    {
        public int MaHoaDon { get; set; }
        public int MaLichKham { get; set; }
        public int MaNV { get; set; }
        public int MaBenhNhan { get; set; }
        public DateTime NgayTao { get; set; }
        public decimal TienKham { get; set; }
        public decimal TienThuoc { get; set; }
        public decimal GiamGia { get; set; }
        public decimal TongTien { get; set; }
        public string HinhThucThanhToan { get; set; }
        public bool DaThanhToan { get; set; }
        public string GhiChu { get; set; }
    }

}
