using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An1.Models
{
    public class HoSoKham
    {
        public int MaHoSo { get; set; }
        public int MaLichKham { get; set; }
        public string TrieuChung { get; set; }
        public string ChanDoan { get; set; }
        public string LoiDan { get; set; }
        public DateTime? NgayTaiKham { get; set; }
        public bool DaThanhToan { get; set; }
    }
}
