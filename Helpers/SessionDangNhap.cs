using Do_An1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An1.Helpers
{
    public static class SessionDangNhap
    {

        public static int MaTaiKhoan { get; set; }
        public static string TenDangNhap { get; set; }
        public static string VaiTro { get; set; }
        public static int? MaNhanVien { get; set; }
        public static int? MaBacSi { get; set; }
        public static int? MaVaiTro { get; set; }
        public static string TenVaiTro { get; set; }

        public static void Reset()
        {
            MaTaiKhoan = 0;
            TenDangNhap = string.Empty;
            VaiTro = string.Empty;
            MaNhanVien = null;
            MaBacSi = null;
            MaVaiTro = null;
            TenVaiTro = string.Empty;
        }
    }
}
