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
    public partial class frmQuanLyHocSinh : Form
    {
       
        public static bool ChonMenuSuaLop = false;
        public static string malopDuocChon = "";
        public frmQuanLyHocSinh()
        {
            InitializeComponent();

        }

      
        bool kiemtraListBox = false; // bien ktra du lieu tai len listBox
        public void HienHS()
        {
            using (QLHocSinhDataContext db = new QLHocSinhDataContext())
            {
                dgvDSHocSinh.DataSource = null;
                var hs = (from x in db.HocSinhs select new
                {
                    x.MaHS,
                    x.HoHS,
                    x.TenHS,
                    x.GioiTinh,
                    x.NgaySinh,
                    x.DiaChi,
                    x.MaLop
                }
                    
                    );
                dgvDSHocSinh.DataSource = hs;
            }
        }
      
        public void HienThiLopLenListBox()
        {
            using (QLHocSinhDataContext db = new QLHocSinhDataContext())
            {
                lstDSLop.DataSource = null;
                lstDSLop.DataSource = db.Lops;
                lstDSLop.ValueMember = "MaLop";
                lstDSLop.DisplayMember = "TenLop";
            }
            kiemtraListBox = true;
        }

        public static string maLopDuocChon = "";
        private void lstDSLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kiemtraListBox == false) //neu chua tai xong  dlieu len listbox
                return;
            if (lstDSLop.SelectedValue == null) //neu chua chon dtuong lop
                return;

            maLopDuocChon = lstDSLop.SelectedValue.ToString();
            //lay ma lop dc chon
            HienThiDSHocSinhTheoLop(maLopDuocChon);
        }

        //ham lau ds sinh vien theolop dc chon
        //Hiem thi danh sach sv len dgvDSHocSinh
        void HienThiDSHocSinhTheoLop(string maLop)
        {
            using (QLHocSinhDataContext db = new QLHocSinhDataContext())
            {
                var query = from hs in db.HocSinhs
                            where hs.MaLop == maLop
                            select new
                            {
                                Mã = hs.MaHS,
                                Họ_lót = hs.HoHS,
                                Tên = hs.TenHS,
                                Giới_tính = hs.GioiTinh,
                                Ngày_sinh = hs.NgaySinh,
                                Địa_chỉ = hs.DiaChi,
                                Mã_lớp = hs.MaLop
                            };
                dgvDSHocSinh.DataSource = null;
                dgvDSHocSinh.DataSource = query;
            }
        }

        private void dgvDSHocSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) //neu khong chon dong nao
                return;

            DataGridViewRow row = dgvDSHocSinh.Rows[e.RowIndex]; //lay dong dang chon

            txtMa.Text = row.Cells[0].Value.ToString();
            txtHoLot.Text = row.Cells[1].Value.ToString();
            txtTen.Text = row.Cells[2].Value.ToString();
            if (row.Cells[3].Value.Equals(radNam.Text))
                radNam.Checked = true;
            else
                radNu.Checked = true;
            txtNgaySinh.Text = row.Cells[4].Value.ToString();
            txtDiaChi.Text = row.Cells[5].Value.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            using (QLHocSinhDataContext db = new QLHocSinhDataContext())
            {
                string maHS = txtMa.Text;
                HocSinh hs = (from x in db.HocSinhs
                              where x.MaHS == maHS
                              select x).FirstOrDefault();
                TaiKhoan tk =( from x in db.TaiKhoans where x.Username == maHS select x).FirstOrDefault();
                if (hs == null)
                {
                    //Them moi hoc dinh vi ma sv chua ton tai
                    hs = new HocSinh();
                    tk = new TaiKhoan();
                    db.HocSinhs.InsertOnSubmit(hs);
                    db.TaiKhoans.InsertOnSubmit(tk);
                }

                //Them hoac sua thong tin hoc sinh
                hs.MaHS = txtMa.Text;
                hs.HoHS = txtHoLot.Text;
                hs.TenHS = txtTen.Text;
                if (radNam.Checked == true)
                    hs.GioiTinh = radNam.Text;
                else
                    hs.GioiTinh = radNu.Text;
                hs.NgaySinh = txtNgaySinh.Text;
                hs.DiaChi = txtDiaChi.Text;
                hs.MaLop = lstDSLop.SelectedValue.ToString();

                tk.Username = maHS;
                tk.Password = maHS;
                db.SubmitChanges();
                HienThiDSHocSinhTheoLop(hs.MaLop);
                HienHS();
                
                LamMoi();
            }
        }
        private void LamMoi()
        {
            txtMa.Clear();
            txtHoLot.ResetText();
            txtTen.Text = "";
            radNam.Checked = true;
            txtNgaySinh.Text = "";
            txtDiaChi.ResetText();
        }
        private void btnTiep_Click(object sender, EventArgs e)
        {
            LamMoi();
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (QLHocSinhDataContext db = new QLHocSinhDataContext())
            {
                string maHS = txtMa.Text;
                HocSinh hs = (from x in db.HocSinhs
                              where x.MaHS == maHS
                              select x).FirstOrDefault();
                TaiKhoan tk = (from x in db.TaiKhoans where x.Username == maHS select x).FirstOrDefault();
                
                if (hs != null)
                {
                    try
                    {
                        DialogResult dg = MessageBox.Show("Bạn có muốn xoa khong ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (dg == DialogResult.OK)
                        {
                            db.HocSinhs.DeleteOnSubmit(hs);
                            db.TaiKhoans.DeleteOnSubmit(tk);
                            db.SubmitChanges();
                            HienHS();
                            HienThiDSHocSinhTheoLop(hs.MaLop);
                            LamMoi();
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void lstDSLop_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (kiemtraListBox == false)
                return;
            if (lstDSLop.SelectedValue == null)
                return;
            malopDuocChon = lstDSLop.SelectedValue.ToString();
            HienThiDSHocSinhTheoLop(malopDuocChon);
        }

        public static bool chonMenuSuaLop = false;

        private void xóaLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string maLop = lstDSLop.SelectedValue.ToString();

            using (QLHocSinhDataContext db = new QLHocSinhDataContext())
            {
                Lop lp = (from l in db.Lops
                          where l.MaLop == maLop
                          select l).FirstOrDefault();

                if (lp.HocSinhs.Count > 0)
                    MessageBox.Show(lp.TenLop + " có " + lp.HocSinhs.Count
                                      + " học sinh, không được phép xóa", "THÔNG BÁO");
                else
                {
                    if (MessageBox.Show("Bạn muốn xóa?", "THÔNG BÁO",
                                   MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        db.Lops.DeleteOnSubmit(lp);
                        db.SubmitChanges();
                        HienThiLopLenListBox();
                    }
                }
            }
        }
        public static bool CoThayDoi = false;
        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Đóng form và trả về OK hoặc Cancel

            DialogResult dg = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                this.Close();
            }

            //frmQuanLyHocSinh.chonMenuSuaLop = false;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            //sử dụng thuộc tính RowFilter để tìm kiếm theo tên "Name"
            //  string rowFilter = string.Format("{0} like '{1}'", "Name", "*" + txtTimKiem.Text + "*");
            //  (dgvDSHocSinh.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            string thongTin = txtTimKiem.Text.Trim();
            if (thongTin == "")
            {
                MessageBox.Show("Ban Phai Nhap Ten");
                return;
            }
            else
            {
                using (QLHocSinhDataContext db = new QLHocSinhDataContext())
                {
                    var DSHocSinh = (from hs in db.HocSinhs
                                     where hs.TenHS.Contains(thongTin)
                                     select new
                                     {
                                         hs.MaHS,
                                         hs.HoHS,
                                         hs.TenHS,
                                         hs.GioiTinh,
                                         hs.NgaySinh,
                                         hs.DiaChi,
                                         hs.MaLop
                                     });

                    if (DSHocSinh != null)
                    {
                        dgvDSHocSinh.DataSource = null;
                        dgvDSHocSinh.DataSource = DSHocSinh;
                        
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Ten hoc sinh ban muon tim khong ton tai","Thong bao");
                    }

                }


            }
        }
    

        private void frmQuanLyHocSinh_Load(object sender, EventArgs e)
        {
            HienThiLopLenListBox();
            HienHS();
        }

        private string MaHS; 

        private void dgvDSHocSinh_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                txtMa.ReadOnly = true;
                btnXoa.Enabled = true;
               // btnSua.Enabled = true;
                DataGridViewRow row = dgvDSHocSinh.Rows[e.RowIndex];
                txtMa.Text = row.Cells[0].Value.ToString();
                MaHS = txtMa.Text.Trim();
                txtHoLot.Text = row.Cells[1].Value.ToString();
                txtTen.Text = row.Cells[2].Value.ToString();
                //Ô thứ 2 là tên lớp
                
                if (row.Cells[3].Value.ToString() == "Nam")
                    radNam.Checked = true;
                else
                    radNu.Checked = true;
                txtNgaySinh.Text = row.Cells[4].Value.ToString();
                txtDiaChi.Text = row.Cells[5].Value.ToString();

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (QLHocSinhDataContext db = new QLHocSinhDataContext())
            {
                HocSinh hs = (from x in db.HocSinhs where x.MaHS == txtMa.Text select x).FirstOrDefault();
                if ( hs != null)
                {
                   
                    hs.HoHS = txtHoLot.Text.Trim();
                    hs.TenHS = txtTen.Text.Trim();
                    hs.NgaySinh = txtNgaySinh.Text;
                    if (radNam.Checked)
                        hs.GioiTinh = radNam.Text;
                    else
                        hs.GioiTinh = radNu.Text;
                    hs.DiaChi = txtDiaChi.Text;
                    db.SubmitChanges();

                    HienHS();
                    MessageBox.Show("Sửa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CoThayDoi = true;
                    LamMoi();
                }
                
            }
        }
    }
}