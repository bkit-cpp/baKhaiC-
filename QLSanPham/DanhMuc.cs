using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSanPham
{
    public class DanhMuc
    {
        public  Dictionary<string,SanPham> dssp =
            new Dictionary<string,SanPham> ();
      public string MaDM { get; set; }
        public string TenDm { get; set; }
        public void ThemSP(SanPham sp)
        {
            if(this.dssp.ContainsKey(sp.Masp)==false)
            {
                this.dssp.Add(sp.Masp, sp);
                sp.Nhom = this;
            }
        }
        public Dictionary<string,SanPham>SanPhams
        {
            get
            {
                return this.dssp;
            }
            set
            {
                this.dssp = value;
            }
        }
        public override string ToString()
        {
            return this.TenDm;
        }

    }
}
