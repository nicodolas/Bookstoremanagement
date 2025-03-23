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
using System.Data;
namespace QuanLyBanSach.UserControls
{
    public partial class UCKhachHang : UserControl
    {
        QuanHuyenBLL qhbll = new QuanHuyenBLL();
        KhachHangBLL khbll = new KhachHangBLL();
        public UCKhachHang()
        {
            InitializeComponent();
            loadData();
            cangDeu();
            loadkh();
        }
        private void cangDeu()
        {
            int avg = lstV_dsKH.ClientSize.Width / lstV_dsKH.Columns.Count;
            foreach (ColumnHeader item in lstV_dsKH.Columns)
            {
                item.Width = avg;

            }
        }
        public void loadData()
        {
            cbo_Quan.DataSource = qhbll.getAllQuanHuyen();
            cbo_Quan.DisplayMember = "TENQUANHUYEN";
            cbo_Quan.ValueMember = "TENQUANHUYEN";

           
        }
        public void loadkh()
        {
            List<KhachHangDTO> lst = khbll.GetAllKH();
            foreach (var item in lst)
            {
                lstV_dsKH.Items.Add(item.MAKH).SubItems.Add(item.TENKH);
            }
        }

        private void lstV_dsKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstV_dsKH.SelectedItems.Count > 0)
            {
                string makh = lstV_dsKH.SelectedItems[0].Text.ToString().Trim();
                KhachHangDTO kh = khbll.getKHByID(makh);
                txtHoTen.Text = kh.TENKH;
                txtSDT.Text = kh.SDT;
                dtp_NgaySinh.Value = kh.NGAYSINH;
                cbo_Quan.Text = kh.DCHIKH;
                txtDiemTichLuy.Text = kh.DIEMTICHLUY.ToString();
                txtMaKh.Text = kh.MAKH;
                if (kh.GTINHKH.Equals("Nam"))
                {
                    rdo_Nam.Checked = true;
                }
                else
                {
                    rdo_Nu.Checked = true;
                }
             
            }
        }
        private bool TinhTuoi(DateTime ngaySinh)
        {
            DateTime ngayHienTai = DateTime.Now;
            int tuoi = ngayHienTai.Year - ngaySinh.Year;

            // Kiểm tra xem đã qua ngày sinh trong năm nay chưa, nếu chưa thì trừ đi 1 tuổi
            if (ngayHienTai.Month < ngaySinh.Month ||
                (ngayHienTai.Month == ngaySinh.Month && ngayHienTai.Day < ngaySinh.Day))
            {
                tuoi--;
            }

            return tuoi>18;
        }
        public bool ktInput()
        {
            return txtHoTen.Text.Length > 0 && (rdo_Nam.Checked || rdo_Nu.Checked) && TinhTuoi(dtp_NgaySinh.Value.Date);
        }
        private void btnThemKH_Click(object sender, EventArgs e)
        {
            
            txtMaKh.Text = khbll.taoMaKh();
            txtHoTen.Focus();
            btnLuuKH.Visible = true;
        }

        private void btnLuuKH_Click(object sender, EventArgs e)
        {
            string makh = khbll.taoMaKh();
            if (ktInput())
            {
                string hoten = txtHoTen.Text.Trim();
                string sdt = txtSDT.Text.Trim();
                DateTime ngaysinh = dtp_NgaySinh.Value;
                string dc = cbo_Quan.SelectedValue.ToString() + " ,TP.HCM";
                string gt = rdo_Nam.Checked ? "Nam" : "Nữ";
                int diemtl = 0;
                float giamgia = 0.0f;
                KhachHangDTO kh = new KhachHangDTO(makh, hoten, sdt, dc, gt, ngaysinh, diemtl, giamgia);
                if (khbll.insertKH(kh))
                {
                    MessageBox.Show("Thêm khách hàng thành công !");
                    lstV_dsKH.Items.Clear();
                    loadkh();
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại ");
                }
            }
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            if (lstV_dsKH.SelectedItems.Count > 0)
            {
                string makh = txtMaKh.Text.Trim();
                string hoten = txtHoTen.Text.Trim();
                string sdt = txtSDT.Text.Trim();
                DateTime ngaysinh = dtp_NgaySinh.Value;
                string dc = cbo_Quan.SelectedValue.ToString() + " ,TP.HCM";
                string gt = rdo_Nam.Checked ? "Nam" : "Nữ";
                KhachHangDTO kh = new KhachHangDTO(makh, hoten, sdt, dc, gt, ngaysinh );
                if (khbll.updateKH(kh))
                {
                    MessageBox.Show("Sửa khách hàng thành công !");
                    lstV_dsKH.Items.Clear();
                    loadkh();
                }
                else
                {
                    MessageBox.Show("Sửa khách hàng thất bại ");
                }
            }
        }
    }
}
