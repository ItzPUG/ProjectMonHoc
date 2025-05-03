using QuanLyHocSinh;
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
    public partial class frmHeThong : Form
    {
        public frmHeThong()
        {
            InitializeComponent();
        }

        private void thoátỨngDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dg == DialogResult.OK)
            {
                this.Close();
            }
        }

     

        //form này để hiển thị cả 2 form hệ thống và lớp(là hiển thị song song)
        private void lớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLop f = new frmLop();
            f.MdiParent = this;
            f.Show();
        }
        //form này để ẩn form hệ thống và out luôn
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangNhap d = new frmDangNhap();
            d.ShowDialog();
            this.Close();
        }
        
        private void hocSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyHocSinh fr = new frmQuanLyHocSinh();
            fr.MdiParent = this;
            fr.Show();

        }

        private void lopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLop l = new frmLop();
            l.MdiParent = this;
            l.Show();
        }

        
    }
}
