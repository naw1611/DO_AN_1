using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An1.Models
{
    public class PhieuXuatThuoc
    {
        public int MaPhieuXuat { get; set; }
        public DateTime NgayXuat { get; set; } = DateTime.Now;
        public int MaNV { get; set; }
        public string GhiChu { get; set; }

        // Quan hệ
        public virtual NhanVien NhanVien { get; set; }  // FK đến bảng NhanVien
        public virtual ICollection<CT_PhieuXuatThuoc> ChiTietPhieuXuat { get; set; }
    }

}
