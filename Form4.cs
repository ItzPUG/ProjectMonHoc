using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

//using System.Text.RegularExpressions;
namespace ProjectQLHS
{
    public partial class frmDangNhap : Form
    {
        public bool checkacc(string ac)
        {
            return Regex.IsMatch(ac, "[a-zA-z0-9]$");
        }
        public frmDangNhap()
        {
            InitializeComponent();
        }
        public static string id;
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            using (QLHocSinhDataContext db = new QLHocSinhDataContext())
            {
                if (txtUsername.Text == "") { MessageBox.Show("Bạn chưa nhập tài khoản", "Message", MessageBoxButtons.OK); txtUsername.Focus(); return; }

                if (txtPass.Text == "") { MessageBox.Show("Bạn chưa nhập mật khẩu", "Message", MessageBoxButtons.OK); txtPass.Focus(); return; }
                if (checkacc(txtUsername.Text) == true && checkacc(txtPass.Text) == true)
                {
                    if (txtUsername.Text == "admin" && txtPass.Text == "admin")
                    {
                        this.Hide();
                        frmHeThong d = new frmHeThong();
                        d.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        if ((from x in db.TaiKhoans where x.Username == txtUsername.Text select x.Username).FirstOrDefault() != null && (from x in db.TaiKhoans where x.Password == txtPass.Text select x.Password).FirstOrDefault() != null)
                        {
                            id = txtUsername.Text;
                            frmThongTin t = new frmThongTin();
                            t.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Ten Tai Khoan Va Mat Khau Khong Dung Hoac Khong Ton Tai", "Message", MessageBoxButtons.OK); return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ten Tai Khoan Va Mat Khau Co Chua Ky Tu Dac Biet", "Message", MessageBoxButtons.OK); return;
                }
            }
        }


    }
}
