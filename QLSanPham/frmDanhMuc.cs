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
    
    public partial class frmDanhMuc : Form
    {
        public static bool ThayDoiTT = false;
        public frmDanhMuc()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DanhMuc dm = new DanhMuc();
            dm.TenDm = txtTenSP.Text;
            dm.MaDM = txtMaSP.Text;
            frmSanPham.dsdanhmuc.Add(dm);
            ThayDoiTT = true;
            DislayListBox();
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtMaSP.Focus();
            ThayDoiTT = true;
        }
        public void DislayListBox()
        {
            lstDanhMuc.Items.Clear();
            foreach(DanhMuc dm in frmSanPham.dsdanhmuc)
            {
                lstDanhMuc.Items.Add(dm);
            }    
        }

        public void btnXoa_Click(object sender, EventArgs e)
        {
            DanhMuc dm = new DanhMuc();
            if(lstDanhMuc.SelectedIndex!=-1)
            {
                lstDanhMuc.Items.RemoveAt(lstDanhMuc.SelectedIndex);
                ThayDoiTT=true;
            }
        }

        private void lstDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if(lstDanhMuc.SelectedIndex!=-1)
            {
                DanhMuc dm = lstDanhMuc.SelectedItem as DanhMuc;
                txtMaSP.Text = dm.MaDM;
                txtTenSP.Text = dm.TenDm;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
           if(ThayDoiTT==true)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            DislayListBox();
        }
    }
}
