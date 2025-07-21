using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An1.Models
{
    public class NhatKyHeThong
    {
        public int MaNhatKy { get; set; }
        public int? MaTaiKhoan { get; set; }
        public string HanhDong { get; set; }
        public string NoiDung { get; set; }
        public string BangTacDong { get; set; }
        public int MaBanGhi { get; set; }
        public DateTime ThoiGian { get; set; }
        public string DiaChiIP { get; set; }
    }
}
