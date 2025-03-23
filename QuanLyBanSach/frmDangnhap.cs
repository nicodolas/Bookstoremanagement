using QLBS_BLL;
using QLBS_DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyBanSach
{
    public partial class frmDangnhap : Form
    {
        TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();
        NhanVienBLL nhanVienBLL = new NhanVienBLL();
        public frmDangnhap()
        {
            InitializeComponent();
        }
        private void chkQuenMK_CheckedChanged(object sender, EventArgs e)
        {
            if (chkQuenMK.Checked)
            {
                txtmatkhau.PasswordChar = '\0';
            }
            else
            {
                txtmatkhau.PasswordChar = '●';
            }

        }

        private void btnminisize_Click_1(object sender, EventArgs e)
        {
            Size formSize;
            formSize = this.ClientSize;
            this.WindowState = FormWindowState.Minimized;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDN = txtTaikhoan.Text.Trim();
            string matKhau = txtmatkhau.Text.Trim();

            TaiKhoanDTO taiKhoan = taiKhoanBLL.DangNhap(tenDN, matKhau);

            if (taiKhoan != null)
            {
                NhanVienDTO nv = nhanVienBLL.getNhanVienByTenDN(tenDN);
                if (taiKhoan.VaiTro.Equals("Admin"))
                {
                    this.Hide();
                    frmMain frmMain = new frmMain(taiKhoan.VaiTro, tenDN);
                    frmMain.Show();
                }
               
              else if(nv.TINHTRANG.Equals("Đã nghỉ"))
                {
                    MessageBox.Show("Tài khoản bị vô hiệu hóa do nhân viên đã nghỉ");
                }
                else
                {
                    this.Hide();
                    frmMain frmMain = new frmMain(taiKhoan.VaiTro, tenDN);
                    frmMain.Show();
                }
             
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!");

            }
        }
        private void frmDangnhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}