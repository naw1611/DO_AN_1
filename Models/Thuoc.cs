using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An1.Models
{
    public class Thuoc
    {
        public int MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public string DonViTinh { get; set; }
        public decimal DonGiaBan { get; set; }
        public int SoLuongTon { get; set; }
        public DateTime HanSuDung { get; set; }
        public string NhaSanXuat { get; set; }
        public string CachDung { get; set; }
        public int? MaLoai { get; set; }
        public int? MaDanhMuc { get; set; }
    }
}
