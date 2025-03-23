using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBS_DTO;
using QLBS_BLL;

namespace QuanLyBanSach.UserControls
{
    public partial class UCDonHang : UserControl
    {
        HoaDonBLL hoaDonBLL = new HoaDonBLL();
        KhachHangBLL khachHangBLL = new KhachHangBLL();
        NhanVienBLL nhanVienBLL = new NhanVienBLL();
        SanPhamBLL sanPhamBLL = new SanPhamBLL();
        public UCDonHang()
        {
            InitializeComponent();
            btnXacNhanTT.Visible = btnInHD.Visible = iconButton5.Visible = btnSua.Visible = false;  
            loadHoaDon();

            loadata();
            cangDeu();
        }
        private void cangDeu()
        {
            int avg = LstV_dsHD.ClientSize.Width / LstV_dsHD.Columns.Count;
            foreach (ColumnHeader item in LstV_dsHD.Columns)
            {
                item.Width = avg;

            }
        }
        public void loadHoaDon()
        {
            LstV_dsHD.Items.Clear();
            List<HoaDonDTO> lstHoaDon = hoaDonBLL.GetAllHoaDon();
            foreach (var item in lstHoaDon)
            {
                ListViewItem listViewItem = new ListViewItem(item.MAHD);
                LstV_dsHD.Items.Add(listViewItem).SubItems.AddRange(new[] { item.NGAYLAPHD.ToShortDateString() });
            }
        }

        private void LstV_dsHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnXacNhanTT.Enabled = btnSua.Enabled = LstV_dsHD.SelectedItems.Count > 0;
            if (LstV_dsHD.SelectedItems.Count >0)
            {
                panel5.Visible = true;
                string mahd = LstV_dsHD.SelectedItems[0].Text;
                HoaDonDTO hd = hoaDonBLL.getHoaDonByMaHD(mahd);
                txtbMaHd.Text = mahd.ToString();
                cbbNhanVien.Text = hoaDonBLL.getNhanVienByMaNV(hd.MANV);
                cbbKhachHang.Text = hoaDonBLL.getKhachHangByMaKH(hd.MAKH);
                txtbTongTien.Text= hd.TONGTIEN.ToString();
                LstV_SP.Items.Clear();

                List<CTHDDTO> lstSanPham = hoaDonBLL.getSanPhamByMaHD(mahd);
                foreach (var item in lstSanPham)
                {
                    ListViewItem listViewItem = new ListViewItem(item.MASP);
                    listViewItem.SubItems.Add(item.SLMUA.ToString());
                    LstV_SP.Items.Add(listViewItem);
                }
                txtbMaHd.Enabled  = txtbTongTien.Enabled = false;
                btnInHD.Show();
            }
        }

      

        private void btnThem_Click(object sender, EventArgs e)
        {
            cbbNhanVien.Visible = true;
            cbbKhachHang.Visible = true;
            panel5.Visible = true;
            LstV_SP.Items.Clear();
            txtbMaHd.Text = hoaDonBLL.taoMaHD();
            txtbTongTien.Clear();
           cbbKhachHang.Enabled = txtbTongTien.Enabled =  cbbNhanVien.Enabled = true;
          
      
            cbbKhachHang.DataSource = khachHangBLL.getAllKH_Include_VangLai();
            cbbKhachHang.ValueMember = "MAKH";
            cbbKhachHang.DisplayMember = "TENKH";
            cbbNhanVien.DataSource = nhanVienBLL.GetAllNhanVien();
            cbbNhanVien.ValueMember = "MANV";
            cbbNhanVien.DisplayMember = "HOTENNV";
            btnLuuHD.Show();
            btnLuuHD.Enabled = true;
        }

        
        private bool ktInput()
        {
            if (txtbMaHd.Text.Length == 0 || cbbKhachHang.SelectedItem == null || cbbNhanVien.SelectedItem == null )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnLuuHD_Click(object sender, EventArgs e)
        {
            if (ktInput())
            {
                string mahd = txtbMaHd.Text.Trim();
                string makh = cbbKhachHang.SelectedValue.ToString();
                string manv = cbbNhanVien.SelectedValue.ToString();
                DateTime ngaylap = DateTime.Now.Date;
                HoaDonDTO newhd = new HoaDonDTO()
                {
                    MAHD=mahd,
                    MAKH=makh,
                    MANV=manv,
                    TONGTIEN=0,
                    NGAYLAPHD=ngaylap
                };
                try
                {
                    if (hoaDonBLL.insertHoaDon(newhd))
                    {
                        MessageBox.Show("Thêm hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadHoaDon();
                        btnLuuHD.Visible = false;
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Thêm hóa đơn thất bại\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cbbSanPham.DataSource = sanPhamBLL.getAllSP();
            cbbSanPham.ValueMember = "MASP";
            cbbSanPham.DisplayMember = "TENSP";
        }
        public void loadata()
        {
            cbbNhanVien.DataSource = nhanVienBLL.GetAllNhanVien();
            cbbNhanVien.DisplayMember = "HOTENNV";
            cbbNhanVien.ValueMember = "MANV";

            cbbKhachHang.DataSource = khachHangBLL.getAllKH_Include_VangLai();
            cbbKhachHang.DisplayMember = "TENKH";
            cbbKhachHang.ValueMember = "MAKH";

            cbbSanPham.DataSource = sanPhamBLL.getAllSP();
            cbbSanPham.ValueMember = "MASP";
            cbbSanPham.DisplayMember = "TENSP";

            // Bật AutoCompleteMode cho ComboBox
            cbbNhanVien.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbNhanVien.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbbKhachHang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbKhachHang.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbbSanPham.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbSanPham.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void btnAddSP_Click(object sender, EventArgs e)
        {
            string mahd = txtbMaHd.Text.Trim();
            string masp = cbbSanPham.SelectedValue.ToString();
            int sl = int.Parse(NumbericSoLuong.Value.ToString());
            decimal gia = hoaDonBLL.getGiaByMaSP(masp);
            if (sl > sanPhamBLL.getSLTonKho_SanPham(masp))
            {
                MessageBox.Show("Số lượng trong kho không đủ");
                return;
            }
            // Tạo đối tượng chi tiết hóa đơn mới
            CTHDDTO newcthd = new CTHDDTO()
            {
                MAHD = mahd,
                MASP = masp,
                SLMUA = sl,
                GIABAN = gia
            };

            try
            {
                // Thêm chi tiết hóa đơn mới vào cơ sở dữ liệu
                if (hoaDonBLL.insertCTHD(newcthd))
                {
                    MessageBox.Show("Thêm chi tiết hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cập nhật lại tổng tiền hóa đơn
                    loadHoaDon();
                    txtbTongTien.Text = hoaDonBLL.getHoaDonByMaHD(mahd).TONGTIEN.ToString();
                    btnXacNhanTT.Visible = true;
                    //cập nhật số lượng tồn kho
                    hoaDonBLL.CapNhatSoLuongTonKho_SauKhiMua(masp, sl);

                    // Xóa các mục cũ khỏi ListView
                    LstV_SP.Items.Clear();

                    // Lấy danh sách sản phẩm và hiển thị trong ListView
                    List<CTHDDTO> lstSanPham = hoaDonBLL.getSanPhamByMaHD(mahd);
                    foreach (var item in lstSanPham)
                    {
                        ListViewItem listViewItem = new ListViewItem(item.MASP);
                        listViewItem.SubItems.Add(item.SLMUA.ToString());
                        listViewItem.SubItems.Add(item.GIABAN.ToString());
                        LstV_SP.Items.Add(listViewItem);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm chi tiết hóa đơn thất bại\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void Search(object sender, EventArgs e)
        {
           
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            string mahd = txtbMaHd.Text.Trim();
            frmHoaDon frm = new frmHoaDon(mahd);
            frm.ShowDialog();
        }

        private void btnXacNhanTT_Click(object sender, EventArgs e)
        {
            string mahd = txtbMaHd.Text.Trim();
            if (hoaDonBLL.XacNhanThanhToan(mahd))
            {
                MessageBox.Show("Xác nhận thanh toán thành công");
                btnXacNhanTT.Visible = false;
                btnInHD.Show();
                hoaDonBLL.TinhDiemTichLuy(mahd);
            }
            else
            {
                MessageBox.Show("Xác nhận thanh toán thất bại");

            }
        }

        private void btnTimHDTheoNgay_Click(object sender, EventArgs e)
        {
            DateTime ngaybd = dtp_NgayBatDau.Value.Date;
            DateTime ngaykt = dtp_NgayKetThuc.Value.Date;
            if (ngaybd > ngaykt)
            {
                MessageBox.Show("Ngày cần tìm kiếm không hợp lệ!");
                return;
            }
            LstV_dsHD.Items.Clear();
            List<HoaDonDTO> lstHoaDon = hoaDonBLL.TimKiemHDTheoNgay(ngaybd,ngaykt);
            foreach (var item in lstHoaDon)
            {
                ListViewItem listViewItem = new ListViewItem(item.MAHD);
                LstV_dsHD.Items.Add(listViewItem).SubItems.AddRange(new[] { item.NGAYLAPHD.ToShortDateString() });
            }
        }
    }
}
