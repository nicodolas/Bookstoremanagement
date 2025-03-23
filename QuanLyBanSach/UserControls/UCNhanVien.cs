using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBS_BLL;
using QLBS_DTO;

namespace QuanLyBanSach.UserControls
{
    public partial class UCNhanVien : UserControl
    {
        NhanVienBLL nhanVienBLL = new NhanVienBLL();
        TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();
        QuanHuyenBLL quanHuyenBLL = new QuanHuyenBLL();
        public UCNhanVien()
        {
            InitializeComponent();
            loadNhanVien();
            trangThaiXem();
            cangDeu();
            btnXoaNV.Enabled = false;
            btnSuaNV.Enabled = false;
        }
        public void trangThaiXem()
        {
            btnLuuThayDoi.Visible = false;
            txtMK.Visible = false;
            label8.Visible = false;
            btnLuuNV.Visible = false;
            cbo_Quan.Enabled = false;
            lblMaNV.Visible = false;
            txtMaNv.Visible = false;
            chk_MKMD.Visible = false;
            chk_KhoiPhucMatKhau.Visible = false;
        }
        private void cangDeu()
        {
            int avg = lstV_dsNV.ClientSize.Width / lstV_dsNV.Columns.Count;
            foreach (ColumnHeader item in lstV_dsNV.Columns)
            {
                item.Width = avg;

            }
        }
        public void loadNhanVien()
        {
            lstV_dsNV.Items.Clear();
            List<NhanVienDTO> danhSachNhanVien = nhanVienBLL.GetAllNhanVien();
            foreach (var item in danhSachNhanVien)
            {
                if(item.TINHTRANG.Equals("Đang làm"))
                    lstV_dsNV.Items.Add(item.MANV).SubItems.Add(item.HOTENNV);
            }
        }

        private void lstV_dsNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnXoaNV.Enabled = btnSuaNV.Enabled = lstV_dsNV.SelectedItems.Count > 0;
            if (lstV_dsNV.SelectedItems.Count > 0)
            {

                trangThaiXem();
                string manv = lstV_dsNV.SelectedItems[0].Text;
                NhanVienDTO nv = nhanVienBLL.getNhanVienById(manv);
                txtHoTen.Text = nv.HOTENNV;
                txtSDT.Text = nv.SDTNV;
                txtTenDN.Text = nv.TENDN;
                cbo_Quan.Text = catDiaChi(nv.DCHINV);
                dtp_NgaySinh.Value = nv.NGAYSINHNV;
                rdo_Nam.Checked = nv.GTINHNV.Equals("Nam");
                rdo_Nu.Checked = !rdo_Nam.Checked;
            }
        }
        private string catDiaChi(string diachi)
        {
            string[] emp = diachi.Split(',');
            return emp[0];
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            lstV_dsNV.Enabled = !lstV_dsNV.Enabled;
            chk_KhoiPhucMatKhau.Visible = false;
            btnLuuThayDoi.Visible = false;
            lblMaNV.Visible = true;
            txtMaNv.Visible = true ;
            txtMK.Visible = true;
            label8.Visible = true;
            btnLuuNV.Visible = true;
            btnResetNV_Click(sender, e);
            txtHoTen.Focus();
            cbo_Quan.Enabled = true;
            cbo_Quan.DataSource = quanHuyenBLL.getAllQuanHuyen();
            cbo_Quan.DisplayMember = "TENQUANHUYEN";
            cbo_Quan.ValueMember = "TENQUANHUYEN";
            //txtTenDN.Text = "nhanvien" + (taiKhoanBLL.getNumberAccMax() + 1).ToString();
            txtTenDN.Text = taiKhoanBLL.GenerateUsername();
            //MessageBox.Show(taiKhoanBLL.GenerateUsername());
            txtMaNv.Text = "NV" + (taiKhoanBLL.getNumberAccMax() + 1).ToString("D3");
            chk_MKMD.Visible = true;
        }

        private void btnResetNV_Click(object sender, EventArgs e)
        {
            txtHoTen.Focus();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtMK.Clear();
            rdo_Nam.Checked = false;
            rdo_Nu.Checked = false;
            dtp_NgaySinh.Value = DateTime.Today;
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
        private bool ktInput()
        {
            if (txtHoTen.Text.Length == 0 || txtSDT.Text.Length == 0 ||txtMK.Text.Length==0||(rdo_Nam.Checked==false&&rdo_Nu.Checked==false))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnLuuNV_Click(object sender, EventArgs e)
        {
            if (TinhTuoi(dtp_NgaySinh.Value.Date) < 18) {
                MessageBox.Show("Nhân viên chưa đủ 18 tuổi"); return;
            }
            if (ktInput())
            {
                string manv = txtMaNv.Text.Trim();
                string tennv = txtHoTen.Text.Trim();
                string sdt = txtSDT.Text.Trim();
                string dc = cbo_Quan.SelectedValue.ToString() +", "+txtHCM.Text;
                string gt = rdo_Nam.Checked ? "Nam" : "Nữ";
                DateTime ngaysinh = dtp_NgaySinh.Value.Date;
                string tendn = txtTenDN.Text.Trim();
                string mk = txtMK.Text.Trim();
                NhanVienDTO nv = new NhanVienDTO(manv,tennv,sdt,dc,gt,ngaysinh,tendn);
                TaiKhoanDTO newtk = new TaiKhoanDTO()
                {
                    TenDN = tendn,
                    MatKhau = mk,
                    VaiTro = "NV"
                };
                try
                {
                    if (taiKhoanBLL.createAccount(newtk))
                    {
                        if (nhanVienBLL.insertNhanVien(nv))
                        MessageBox.Show("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadNhanVien();
                    }
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("Thêm nhân viên thất bại\n"+ ex.Message, "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này không ?\nNếu xóa thì tài khoản nhân viên cũng sẽ mất !!",
                                              "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (r == DialogResult.Yes)
            {
                try
                {
                    string manv = lstV_dsNV.SelectedItems[0].Text;
                    string tendn = txtTenDN.Text.Trim();

                    // Xóa nhân viên
                    bool isNhanVienDeleted = nhanVienBLL.DeleteNhanVien(manv);

                    if (isNhanVienDeleted)
                    {
                        // Nếu xóa nhân viên thành công, tiến hành xóa tài khoản
                        // bool isAccountDeleted = taiKhoanBLL.deleteAccount(tendn);

                        //if (isAccountDeleted)
                        //{
                        //    MessageBox.Show("Xóa nhân viên và tài khoản thành công !");
                        //    loadNhanVien();
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Xóa nhân viên thành công, nhưng không thể xóa tài khoản !");
                        //}
                        MessageBox.Show("Xóa nhân viên thành công");
                        loadNhanVien();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên để xóa !");
                    }
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi với thông tin chi tiết
                    MessageBox.Show("Xóa nhân viên thất bại: " + ex.Message);
                }
            }
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            lstV_dsNV.Enabled = !lstV_dsNV.Enabled;
            chk_MKMD.Visible = false;
            btnLuuNV.Visible = false;
            chk_KhoiPhucMatKhau.Visible = true;
            lblMaNV.Visible = true;
            txtMaNv.Visible = true;
            //txtMK.Visible = true;
            //label8.Visible = true;
            btnLuuThayDoi.Visible = true;
            //btnResetNV_Click(sender, e);
            txtHoTen.Focus();
            cbo_Quan.Enabled = true;
            cbo_Quan.DataSource = quanHuyenBLL.getAllQuanHuyen();
            cbo_Quan.DisplayMember = "TENQUANHUYEN";
            cbo_Quan.ValueMember = "TENQUANHUYEN";
            if (lstV_dsNV.SelectedItems.Count > 0)
            {
                string manv = lstV_dsNV.SelectedItems[0].Text;
                txtTenDN.Text = nhanVienBLL.getNhanVienById(manv).TENDN;
                txtMaNv.Text = manv;
            }
        }
        private bool ktInputSua()
        {
            if (txtHoTen.Text.Length == 0 || txtSDT.Text.Length == 0  || (rdo_Nam.Checked == false && rdo_Nu.Checked == false))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnLuuThayDoi_Click(object sender, EventArgs e)
        {
            if (TinhTuoi(dtp_NgaySinh.Value.Date) < 18)
            {
                MessageBox.Show("Nhân viên chưa đủ 18 tuổi"); return;
            }
            if (chk_KhoiPhucMatKhau.Checked)
            {
                if (ktInput())
                {
                    string manv = txtMaNv.Text.Trim();
                    string tennv = txtHoTen.Text.Trim();
                    string sdt = txtSDT.Text.Trim();
                    string dc = cbo_Quan.SelectedValue.ToString() + ", " + txtHCM.Text;
                    string gt = rdo_Nam.Checked ? "Nam" : "Nữ";
                    DateTime ngaysinh = dtp_NgaySinh.Value.Date;
                    string tendn = txtTenDN.Text.Trim();
                    string mk = txtMK.Text.Trim();

                    if (nhanVienBLL.updateNhanVien(manv, tennv, sdt, dc, gt, ngaysinh))
                    {
                        if (taiKhoanBLL.updateAccount(tendn, mk))
                        {
                            chk_KhoiPhucMatKhau.Checked = false;
                            lstV_dsNV.Enabled = true;
                            MessageBox.Show("Sửa thông tin nhân viên thành công",
                           "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadNhanVien();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sửa thông tin nhân viên thất bại",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
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
                        chk_KhoiPhucMatKhau.Checked = false;
                        lstV_dsNV.Enabled = true;
                        MessageBox.Show("Sửa thông tin nhân viên thành công",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        loadNhanVien();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thông tin nhân viên thất bại",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
        }

        private void chk_MKMD_CheckedChanged(object sender, EventArgs e)
        {
            txtMK.Text = chk_MKMD.Checked ? "123" : string.Empty;
        }

        private void chk_KhoiPhucMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMK.Text = chk_KhoiPhucMatKhau.Checked ? "123" : string.Empty;
        }
    }
}
