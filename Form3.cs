using ProjectQLHS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinh
{
    public partial class frmLop : Form
    {
        public frmLop()
        {
            InitializeComponent();
        }

        private void frmQLLop_Load(object sender, EventArgs e)
        {
            HienDSLop();
            HienLopDuocChonLenTextBox();
        }
        private void HienDSLop()
        {
            using (QLHocSinhDataContext db = new QLHocSinhDataContext())
            {
                dgvDSLop.DataSource = from x in db.Lops select new { 
                    x.MaLop,
                    x.TenLop,
                    x.SiSo,
                    x.GVCN
               
                };
                HieuChinhCotDataGridView();
            }
        }
        private void HieuChinhCotDataGridView()
        {
            dgvDSLop.Columns[0].HeaderText = "Mã";
            dgvDSLop.Columns[0].Width = 100;
            dgvDSLop.Columns[1].HeaderText = "Tên";
            dgvDSLop.Columns[1].Width = 100;
            dgvDSLop.Columns[2].HeaderText = "Sỉ số";
            dgvDSLop.Columns[2].Width = 70;
            dgvDSLop.Columns[3].HeaderText = "GVCN";
            dgvDSLop.Columns[3].Width = 150;
        }

        private void HienLopDuocChonLenTextBox()
        {
            if (frmQuanLyHocSinh.chonMenuSuaLop == true)
            {
                QLHocSinhDataContext db = new QLHocSinhDataContext();
                Lop lp = (from l in db.Lops
                          where l.MaLop == frmQuanLyHocSinh.maLopDuocChon
                          select l).FirstOrDefault();
                if (lp != null)
                {
                    txtMaLop.Text = lp.MaLop;
                    txtTenLop.Text = lp.TenLop;
                    numSiSo.Value = (decimal)lp.SiSo;
                    txtGVCN.Text = lp.GVCN;
                }
            }
        }
        // Khởi tạo biến CoThayDoi để kiểm tra người dùng có thay đổi trong form Lớp?
        public static bool CoThayDoi = false;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maLop = txtMaLop.Text;
            using (QLHocSinhDataContext db = new QLHocSinhDataContext())
            {
                Lop lp = (from l in db.Lops
                          where l.MaLop == maLop
                          select l).FirstOrDefault();
                if (lp == null)
                {
                    // Tạo đối tượng lp mới
                    lp = new Lop();
                    db.Lops.InsertOnSubmit(lp);
                }

                lp.MaLop = txtMaLop.Text;
                lp.TenLop = txtTenLop.Text;
                lp.SiSo = (int)numSiSo.Value;
                lp.GVCN = txtGVCN.Text;

                db.SubmitChanges();
                HienDSLop();
                CoThayDoi = true;
                LamMoi();
            }
        }
        private void LamMoi()
        {
            txtMaLop.ResetText();
            txtTenLop.ResetText();
            txtGVCN.ResetText();
            numSiSo.ResetText();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                this.Close();
            }
        }

       
        private void dgvDSLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) //neu khong chon dong nao
            { return; }
            txtMaLop.ReadOnly = true;

        
            
                DataGridViewRow row = dgvDSLop.Rows[e.RowIndex]; //lay dong dang chon

                txtMaLop.Text = row.Cells[0].Value.ToString();
                txtTenLop.Text = row.Cells[1].Value.ToString();
                numSiSo.Value = (int)row.Cells[2].Value;
                txtGVCN.Text = row.Cells[3].Value.ToString();

            
        }
        // Button xoa lop
        private void button1_Click(object sender, EventArgs e)
        {
            
            using (QLHocSinhDataContext db = new QLHocSinhDataContext()) {
                string malop = txtMaLop.Text;
                HocSinh hs = (from x in db.HocSinhs where x.MaLop == malop select x).FirstOrDefault();
                
                if (hs != null)
                {
                    MessageBox.Show("Lop nay khong the xoa vi co hoc sinh"); return;
                }
                Lop lop = (from x in db.Lops where x.MaLop == malop select x).FirstOrDefault();
                db.Lops.DeleteOnSubmit(lop);
                db.SubmitChanges();
                HienDSLop();
                LamMoi();
            }
            
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }
    }
}
