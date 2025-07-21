using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An1.Models
{
    public class LichSuNhapThuoc
    {
        public int MaLichSu { get; set; }
        public int MaThuoc { get; set; }
        public int SoLuongThayDoi { get; set; }
        public string LoaiThayDoi { get; set; }
        public DateTime NgayThayDoi { get; set; }
        public int MaNV { get; set; }
        public string GhiChu { get; set; }
    }
}
