using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectQLHS
{
    public partial class frmThongTin : Form
    {
        public frmThongTin()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void frmThongTin_Load(object sender, EventArgs e)
        {
           using (QLHocSinhDataContext db = new QLHocSinhDataContext())
            {
                HocSinh hs = (from x in db.HocSinhs where x.MaHS == frmDangNhap.id select x).FirstOrDefault();
                if (hs != null) {
                    txtMa.Text = hs.MaHS;
                    txtHoLot.Text = hs.HoHS;
                    txtTen.Text = hs.TenHS;
                    txtDiaChi.Text = hs.DiaChi;
                    txtMaLop.Text = hs.MaLop;
                    if (hs.GioiTinh == "Nam") {
                        checkBox2.Checked = false;
                        checkBox1.Checked = true;
                    } 
                    else 
                    { 
                        checkBox2.Checked = true; 
                        checkBox1.Checked = false; 
                    }
                    txtNgaySinh.Text = hs.NgaySinh;

                }

            }
        }
    }
}
