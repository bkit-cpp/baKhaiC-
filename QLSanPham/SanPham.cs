using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSanPham
{
    public class SanPham
    {
        public string Masp { get; set; }
        public string Tensp { get; set; }
        public long DonGia { get; set; }
        public DateTime HanDung { get; set; }
        public DanhMuc Nhom { get; set; }

    }
}
