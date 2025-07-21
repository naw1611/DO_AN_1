using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An1.Models
{
    public class LichKham
    {
        public int MaLichKham { get; set; }
        public int MaBN { get; set; }
        public int MaBS { get; set; }
        public DateTime NgayKham { get; set; }
        public TimeSpan GioKham { get; set; }
        public int ThoiGianDuKien { get; set; }
        public string LyDo { get; set; }
        public string TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
        public string GhiChu { get; set; }
    }
}
