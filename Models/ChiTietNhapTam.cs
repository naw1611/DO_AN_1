using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An1.Models
{
    public class ChiTietNhapTam
    {
        public int MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public int SoLuongNhap { get; set; }
        public decimal DonGiaNhap { get; set; }
        public decimal ThanhTien => SoLuongNhap * DonGiaNhap;
    }

}
