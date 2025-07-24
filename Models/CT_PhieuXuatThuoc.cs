using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An1.Models
{
    public class CT_PhieuXuatThuoc
    {
        public int MaCT { get; set; }
        public int MaPhieuXuat { get; set; }
        public int MaThuoc { get; set; }
        public int SoLuongXuat { get; set; }
        public decimal DonGiaXuat { get; set; }

        // Trường tính toán (không cần set)
        public decimal ThanhTien => SoLuongXuat * DonGiaXuat;

        // Quan hệ
        public virtual PhieuXuatThuoc PhieuXuatThuoc { get; set; }
        public virtual Thuoc Thuoc { get; set; }
    }
}
