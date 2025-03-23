using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBS_BLL;
using QLBS_DTO;
namespace QuanLyBanSach.UserControls
{
    public partial class UCCaNhan : UserControl
    {
        NhanVienBLL nhanVienBLL = new NhanVienBLL();
        QuanHuyenBLL quanHuyenBLL = new QuanHuyenBLL();
        public string MANV { get; set; }
        public UCCaNhan()
        {
            InitializeComponent();
        }
        public UCCaNhan(string manv)
        {
            InitializeComponent();
            MANV = manv;
            txtHoTen.Enabled = false;
            txtSDT.Enabled = false;
            cbo_Quan.Enabled = false;
            grb_DoiMatKhau.Visible = false;
        }

        private void UCCaNhan_Load(object sender, EventArgs e)
        {
            NhanVienDTO nv = nhanVienBLL.getNhanVienById(MANV);
            txtHoTen.Text = nv.HOTENNV;
            txtMaNv.Text = nv.MANV;
            if (nv.GTINHNV.Equals("Nam"))
            {
                rdo_Nam.Checked = true;
            }
            else rdo_Nu.Checked = true;
            dtp_NgaySinh.Value = nv.NGAYSINHNV;
            cbo_Quan.Text = catDiaChi(nv.DCHINV);
            txtSDT.Text = nv.SDTNV;
            txtTenDN.Text = nv.TENDN;
        }
        private string catDiaChi(string diachi)
        {
            string[] emp = diachi.Split(',');
            return emp[0];
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            txtHoTen.Enabled = true;
            txtSDT.Enabled = true;
            cbo_Quan.Enabled = true;

            btnLuuThayDoi.Visible = true;
            //btnResetNV_Click(sender, e);
            txtHoTen.Focus();
            cbo_Quan.Enabled = true;
            cbo_Quan.DataSource = quanHuyenBLL.getAllQuanHuyen();
            cbo_Quan.DisplayMember = "TENQUANHUYEN";
            cbo_Quan.ValueMember = "TENQUANHUYEN";
            
            
        }
        private bool ktInputSua()
        {
            if (txtHoTen.Text.Length == 0 || txtSDT.Text.Length == 0 || (rdo_Nam.Checked == false && rdo_Nu.Checked == false))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private int TinhTuoi(DateTime ngaySinh)
        {
            DateTime ngayHienTai = DateTime.Now;
            int tuoi = ngayHienTai.Year - ngaySinh.Year;

            // Kiểm tra xem đã qua ngày sinh trong năm nay chưa, nếu chưa thì trừ đi 1 tuổi
            if (ngayHienTai.Month < ngaySinh.Month ||
                (ngayHienTai.Month == ngaySinh.Month && ngayHienTai.Day < ngaySinh.Day))
            {
                tuoi--;
            }

            return tuoi;
        }
        private void btnLuuThayDoi_Click(object sender, EventArgs e)
        {
            if (ktInputSua())
            {
                string manv = txtMaNv.Text.Trim();
                string tennv = txtHoTen.Text.Trim();
                string sdt = txtSDT.Text.Trim();
                string dc = cbo_Quan.SelectedValue.ToString() + ", " + txtHCM.Text;
                string gt = rdo_Nam.Checked ? "Nam" : "Nữ";
                DateTime ngaysinh = dtp_NgaySinh.Value.Date;

                if (nhanVienBLL.updateNhanVien(manv, tennv, sdt, dc, gt, ngaysinh))
                {
                   
                    MessageBox.Show("Sửa thông tin cá nhân thành công",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLuuThayDoi.Visible = false;
                    txtHoTen.Enabled = false;
                    txtSDT.Enabled = false;
                    cbo_Quan.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Sửa thông tin cá nhân thất bại",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            grb_DoiMatKhau.Visible = !grb_DoiMatKhau.Visible;
        }

        private void btnHienMK_Click(object sender, EventArgs e)
        {
            
            if (btnHienMK.IconChar == FontAwesome.Sharp.IconChar.EyeSlash)
            {
                btnHienMK.IconChar = FontAwesome.Sharp.IconChar.Eye;
                txtMK.PasswordChar = txtMKmoi.PasswordChar = txtXacNhanMK.PasswordChar = '*';
                     
            }
            else
            {
                btnHienMK.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                txtMK.PasswordChar = txtMKmoi.PasswordChar = txtXacNhanMK.PasswordChar = '\0';

            }
        }
        public bool ktInputMK()
        {
            if (txtMK.Text.Length == 0)
            {
                MessageBox.Show("Hãy nhập mật khẩu");
                txtMK.Focus();
                return false;
            }
            if (txtMKmoi.Text.Length == 0)
            {
                MessageBox.Show("Hãy nhập mật khẩu mới");
                txtMKmoi.Focus();
                return false;
            }
            if (txtXacNhanMK.Text.Length == 0)
            {
                MessageBox.Show("Hãy nhập xác nhận mật khẩu");
                txtXacNhanMK.Focus();
                return false;
            }
            return true;
        }
        private void btnXacNhanThayDoiMatKhau_Click(object sender, EventArgs e)
        {

            if (!ktInputMK())
            {
                return;
            }
            string mkcu = txtMK.Text.Trim();
            string mkmoi = txtMKmoi.Text.Trim();
            string xnmk = txtXacNhanMK.Text.Trim();
            if (!nhanVienBLL.kiemTraMKTrungNhau(MANV,mkcu))
            {
                MessageBox.Show("Sai mật khẩu cũ");
                txtMK.Focus();
            }
            else
            {
                if (!mkmoi.Equals(xnmk))
                {
                    MessageBox.Show("Hai mật khẩu không trùng khớp");
                    txtXacNhanMK.Focus();
                }else
                {
                    if (nhanVienBLL.doiMatKhau(MANV, mkmoi))
                    {
                        MessageBox.Show("Đổi mật khẩu thành công");

                    }
                    else
                    {
                        MessageBox.Show("Đổi mật khẩu thất bại");

                    }
                }
               
                

            }
        }
    }
}
