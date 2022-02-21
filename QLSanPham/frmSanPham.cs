using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSanPham
{
    public partial class frmSanPham : Form
    {
        public static List<DanhMuc> dsdanhmuc = new List<DanhMuc>();
        List<SanPham> dssanpham = new List<SanPham>();
        public frmSanPham()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(LstSanPham.SelectedIndex==-1)
           return;
            SanPham sp = LstSanPham.SelectedItem as SanPham;
            cboDanhMuc.SelectedItem = sp;
            txtMaSanPham.Text = sp.Masp;
            txtnamesp.Text = sp.Tensp;
            txtDonGia.Text = sp.DonGia+ "";
            dtpHanDung.Value = sp.HanDung; 
        }

        private void btnQuanLyDanhMuc_Click(object sender, EventArgs e)
        {
            frmDanhMuc frmdm = new frmDanhMuc();
            frmDanhMuc.ThayDoiTT = false;
            if(frmdm.ShowDialog()==DialogResult.OK)
            {
                HienThiDanhMucLenComBobox();
            }
        }

        private void HienThiDanhMucLenComBobox()
        {
            cboDanhMuc.Items.Clear();
            foreach(DanhMuc dm in dsdanhmuc)
            {
                cboDanhMuc.Items.Add(dm);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (LstSanPham.SelectedIndex == -1)
            {
                MessageBox.Show("Vui long chon san pham can xoa");
                return;
            }

           
            SanPham sp = LstSanPham.SelectedItem as SanPham;
            DialogResult dia = MessageBox.Show("Ban muon xoa[" + sp.Tensp + "]?", 
                "Hoi Xoa", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);
            if (dia == DialogResult.Yes)
            {
                dssanpham.Remove(sp);
                DisplayonListBox();
            }
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
           if(cboDanhMuc.SelectedIndex==-1)
            {
                MessageBox.Show("Vui long Nhap Lua Chon");
                return;
            }
            DanhMuc dm = cboDanhMuc.SelectedItem as DanhMuc;
            SanPham sp = new SanPham();
            sp.Masp = txtMaSanPham.Text;
            sp.Tensp = txtnamesp.Text;
            sp.DonGia = long.Parse(txtDonGia.Text);
            sp.HanDung = dtpHanDung.Value;
            dm.ThemSP(sp);
            dssanpham.Add(sp);
            DisplayonListBox();
            xoakhoangtrangsanpham();
        }
         private void DisplayonListBox()
        {
            LstSanPham.Items.Clear();
            foreach(SanPham sp in dssanpham)
            
                LstSanPham.Items.Add(sp.Tensp);
            
        }
        public void xoakhoangtrangsanpham()
        {
            txtnamesp.Text = "";
            txtMaSanPham.Text = "";
            txtDonGia.Text = "";
   

        }
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            DisplayonListBox();
        }
    }
}
