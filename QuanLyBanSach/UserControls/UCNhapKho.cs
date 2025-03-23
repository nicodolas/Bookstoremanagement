using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using QLBS_BLL;
using QLBS_DTO;

namespace QuanLyBanSach.UserControls
{
    public partial class UCNhapKho : UserControl
    {
        private PhieuNhapBLL phieuNhapBLL = new PhieuNhapBLL();
        private SanPhamBLL sanPhamBLL = new SanPhamBLL();

        public UCNhapKho()
        {
            InitializeComponent();
            btnXoaCTPN.Enabled = false;
            btnXacNhanPN.Enabled = false;
            btnHuyXacNhanPN.Enabled=false;
        }

        private void UCNhapKho_Load(object sender, EventArgs e)
        {
            ToggleIconButtons(false);
            LoadData();
            AdjustColumnWidths();
            groupBox1.Visible = false;
            groupBox2.Visible = false;
        }

        private void ToggleIconButtons(bool visible)
        {
            btnInPN.Visible = visible;
            iconButton3.Visible = visible;
            iconButton4.Visible = visible;
            iconButton5.Visible = visible;
        }

        private void LoadData()
        {
            loadPN();
            loadNCC();
            LoadPNChoXacNhan();
        }

        public void loadNCC()
        {
            var nccList = phieuNhapBLL.getAllNCC();
            txtNCC.DataSource = nccList;
            txtNCC.DisplayMember = "TENNCC";
            txtNCC.ValueMember = "MANCC";
        }

        public void loadPN()
        {
            var pnList = phieuNhapBLL.getAllPN();
            lstV_DSPN.Items.Clear();  // Clear before adding
            foreach (var pn in pnList)
            {
                lstV_DSPN.Items.Add(pn.MAPN).SubItems.AddRange(new[]
                {
                    pn.NGAYDAT.ToString("dd/MM/yyyy"),
                    pn.TONGDAT.ToString("N0", new CultureInfo("vi-VN")) + " VND"
                });
            }
        }

        private void AdjustColumnWidths()
        {
            AdjustListViewColumns(lstV_DSPN);
            AdjustListViewColumns(lstV_DSCTPN);
            AdjustListViewColumns(lstV_PNChoXacNhan);
        }

        private void AdjustListViewColumns(ListView listView)
        {
            int avgWidth = listView.ClientSize.Width / listView.Columns.Count;
            foreach (ColumnHeader column in listView.Columns)
            {
                column.Width = avgWidth;
            }
        }

        private void lstV_DSPN_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstV_DSCTPN.Items.Clear();
            ChangeViewMode(false);
            ToggleCTHDInput(false);
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            btnInPN.Visible = lstV_DSPN.SelectedItems.Count > 0;
            if (lstV_DSPN.SelectedItems.Count > 0)
            {
                string mapn = lstV_DSPN.SelectedItems[0].Text.Trim();
                var dt = phieuNhapBLL.getPNByID(mapn);
                var cthds = phieuNhapBLL.getCTHDByID(mapn);
                UpdatePNDetails(dt);
                UpdateCTPNDetails(cthds);
            }
        }

        private void UpdatePNDetails(DataTable dt)
        {
            txtMaPN1.Text = txtMaPN2.Text = dt.Rows[0][0].ToString();
            dtp_NgayDat.Value = DateTime.Parse(dt.Rows[0][1].ToString());
            txtTongDat.Text = Convert.ToDecimal(dt.Rows[0][2]).ToString("N0") + " VND";
            txtNCC.Text = dt.Rows[0][3].ToString();
        }

        private void UpdateCTPNDetails(DataTable cthds)
        {
            foreach (DataRow row in cthds.Rows)
            {
                lstV_DSCTPN.Items.Add(row[0].ToString()).SubItems.AddRange(new[]
                {
                    row[1].ToString(),
                    String.Format(new CultureInfo("vi-VN"), "{0:N0} VND", row[2])
                });
            }
        }
        public void CapNhatSauKhiXoa(string mapn)
        {
            lstV_DSCTPN.Items.Clear(); // Xóa toàn bộ danh sách chi tiết phiếu nhập hiện tại

            if (!string.IsNullOrEmpty(mapn))
            {
                // Lấy lại danh sách chi tiết phiếu nhập từ cơ sở dữ liệu dựa trên mã phiếu nhập
                DataTable cthds = phieuNhapBLL.getCTHDByID(mapn);

                // Duyệt qua từng dòng dữ liệu và thêm vào ListView
                foreach (DataRow row in cthds.Rows)
                {
                    string tensp = row[0].ToString();
                    string sldat = row[1].ToString();
                    string giadat = String.Format(new CultureInfo("vi-VN"), "{0:N0} VND", row[2]);

                    // Thêm các chi tiết vào lstV_DSCTPN
                    lstV_DSCTPN.Items.Add(tensp).SubItems.AddRange(new[] { sldat, giadat });
                }
            }
        }


        public void ChangeViewMode(bool editMode)
        {
            txtMaPN1.Enabled = txtNCC.Enabled = txtTongDat.Enabled = dtp_NgayDat.Enabled = editMode;
        }

        public void ToggleCTHDInput(bool showInput)
        {
            // Hide/Show corresponding controls
            txtMaPN2.Visible = cbo_TenSP.Visible = num_SL.Visible = btnXoaCTPN.Visible = btnThemCTPN.Visible = label7.Visible = label9.Visible = label10.Visible =  showInput;
            txtMaPN1.Visible = txtTongDat.Visible = dtp_NgayDat.Visible = label2.Visible = label3.Visible = label4.Visible = !showInput;
            txtMaPN2.Enabled = false; // Always disable input
            txtGiaDat.Visible = showInput;
            label8.Visible = showInput;
            
        }

        public void ResetCTHDInput()
        {
            txtMaPN2.Clear();
            num_SL.Value = 1;
        }

        public void CheckCTPNListCount()
        {
            btnLuuPN.Visible = lstV_DSCTPN.Items.Count > 0;
        }

        //public void loadDSSP()
        //{
        //    cbo_TenSP.DataSource = sanPhamBLL.getAllSP();
        //    cbo_TenSP.DisplayMember = "TENSP";
        //    cbo_TenSP.ValueMember = "MASP";
        //}
        public void loadDSSP_DatHang()
        {
            cbo_TenSP.DataSource = sanPhamBLL.getAllSP_DatHang();
            cbo_TenSP.DisplayMember = "TENSP";
            cbo_TenSP.ValueMember = "MASP";
        }
        private void btnThemPN_Click(object sender, EventArgs e)
        {
            cbo_TenSP.Items.Clear();
            loadDSSP_DatHang();
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            lstV_DSPN.Enabled = false;
            iconButton5.Visible = true;
            ResetCTHDInput();
            ToggleCTHDInput(true);
            lstV_DSCTPN.Items.Clear();
            txtMaPN2.Focus();
            
            CheckCTPNListCount();
            string mapn = phieuNhapBLL.generateNewPN();
            txtMaPN2.Text = mapn;
            string mancc = txtNCC.SelectedValue.ToString();
            txtNCC.Enabled = true;

            PhieuNhapDTO newPN = new PhieuNhapDTO(mapn, DateTime.Now.Date, 0, mancc);
            ShowMessage(phieuNhapBLL.createPN(newPN), "Tạo phiếu nhập thành công", "Tạo phiếu nhập thất bại");
        }
        private bool KiemTraSLVaGiaDat()
        {
            int sldat = (int)num_SL.Value;
            decimal giadat;

            // Kiểm tra nếu giá trị num_SL âm
            if (sldat <= 0)
            {
                MessageBox.Show("Số lượng đặt phải lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra nếu giá trị txtGiaDat không phải là số hợp lệ hoặc giá trị bằng 0
            if (!decimal.TryParse(txtGiaDat.Text, out giadat) || giadat <= 0)
            {
                MessageBox.Show("Giá đặt phải là số dương và khác 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnThemCTPN_Click(object sender, EventArgs e)
        {
            if (!KiemTraSLVaGiaDat())
            {
                return; 
            }
            CheckCTPNListCount();
            txtNCC.Enabled = true;
            string mapn = txtMaPN2.Text;
            string masp = cbo_TenSP.SelectedValue.ToString();
            int sldat = (int)num_SL.Value;
            decimal giadat = decimal.Parse(txtGiaDat.Text);

            CTPNDTO newCTPN = new CTPNDTO(mapn, masp, sldat, giadat);
            if (phieuNhapBLL.createCTPN(newCTPN))
            {
                MessageBox.Show("Thêm chi tiết phiếu nhập thành công");
              
                lstV_DSCTPN.Items.Add(cbo_TenSP.Text).SubItems.AddRange(new[]
                {
                    sldat.ToString(),
                    giadat.ToString("N0", new CultureInfo("vi-VN")) + " VND"
                });
                CheckCTPNListCount();
            }
            else
            {
                MessageBox.Show("Thêm chi tiết phiếu nhập thất bại");
            }
        }

        private void btnXoaCTPN_Click(object sender, EventArgs e)
        {
            CheckCTPNListCount();

   
            string mapn = txtMaPN2.Text;
            string masp = cbo_TenSP.SelectedValue.ToString();

         
            bool result = phieuNhapBLL.deleteCTPN(mapn, masp);

          
            ShowMessage(result, "Xóa chi tiết phiếu nhập thành công", "Xóa chi tiết phiếu nhập thất bại");
            CapNhatSauKhiXoa(mapn);



        }


        private void ShowMessage(bool success, string successMsg, string failMsg)
        {
            MessageBox.Show(success ? successMsg : failMsg);
        }
        private void btnLuuPN_Click(object sender, EventArgs e)
        {
            UCNhapKho_Load(sender, e);
            btnLuuPN.Visible = false;
            lstV_DSPN.Enabled = true;

        }
        private void lstV_DSCTPN_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnXoaCTPN.Enabled = lstV_DSCTPN.SelectedItems.Count > 0;
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            lstV_DSPN.Enabled = true;
            iconButton5.Visible = false;
            loadPN();
        }

        private void LoadPNChoXacNhan()
        {
            var pnList = phieuNhapBLL.getAllPNChoXacNhan();
            lstV_PNChoXacNhan.Items.Clear();  // Clear before adding
            foreach (var pn in pnList)
            {
                lstV_PNChoXacNhan.Items.Add(pn.MAPN).SubItems.AddRange(new[]
                {
                    pn.NGAYDAT.ToString("dd/MM/yyyy"),
                    pn.TONGDAT.ToString("N0", new CultureInfo("vi-VN")) + " VND"
                });
            }
        }

        private void lstV_PNChoXacNhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstV_DSCTPN.Items.Clear();
            ChangeViewMode(false);
            ToggleCTHDInput(false);
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            btnInPN.Visible = lstV_PNChoXacNhan.SelectedItems.Count > 0;
          btnHuyXacNhanPN.Enabled = btnXacNhanPN.Enabled = lstV_PNChoXacNhan.SelectedItems.Count > 0;

            if (lstV_PNChoXacNhan.SelectedItems.Count > 0)
            {

                string mapn = lstV_PNChoXacNhan.SelectedItems[0].Text.Trim();
                var dt = phieuNhapBLL.getPNByID(mapn);
                var cthds = phieuNhapBLL.getCTHDByID(mapn);
                UpdatePNDetails(dt);
                UpdateCTPNDetails(cthds);
            }
           
        }

        private void btnXacNhanPN_Click(object sender, EventArgs e)
        {
            string mapn = txtMaPN2.Text.Trim();
            if (MessageBox.Show("Bạn có chắc sẽ xác nhận đơn hàng này:"+mapn,"Thông báo",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                bool xacnhan = phieuNhapBLL.xacNhanPN(mapn);

                ShowMessage(xacnhan, "Xác nhận phiếu nhập thành công", "Xác nhận phiếu nhập thất bại");
                if (xacnhan)
                {
                    phieuNhapBLL.CapNhatSoLuongTonKho_SauKhiDatHang(mapn);
                }
                LoadData();
            }

          
            
            
        }

        private void btnHuyXacNhanPN_Click(object sender, EventArgs e)
        {
            string mapn = txtMaPN2.Text.Trim();
            if (MessageBox.Show("Bạn có chắc sẽ hủy phiếu nhập này:" + mapn, "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool xacnhan = phieuNhapBLL.huyXacNhanPN(mapn);

                ShowMessage(xacnhan, "Hủy thành công", "Hủy phiếu nhập thất bại");
                LoadData();
            }
        }

        private void btnTimPNTheoNgay_Click(object sender, EventArgs e)
        {
            DateTime ngaybd = dtp_NgayBatDau.Value.Date;
            DateTime ngaykt = dtp_NgayKetThuc.Value.Date;
            if (ngaybd > ngaykt)
            {
                MessageBox.Show("Ngày cần tìm kiếm không hợp lệ!");
                return;
            }
            var pnList = phieuNhapBLL.TimKiemPhieuNhapTheoNgay(ngaybd,ngaykt);
            lstV_DSPN.Items.Clear();  // Clear before adding
            foreach (var pn in pnList)
            {
                lstV_DSPN.Items.Add(pn.MAPN).SubItems.AddRange(new[]
                {
                    pn.NGAYDAT.ToString("dd/MM/yyyy"),
                    pn.TONGDAT.ToString("N0", new CultureInfo("vi-VN")) + " VND"
                });
            }
        }

        private void btnInPN_Click(object sender, EventArgs e)
        {
            string mapn = txtMaPN1.Text.Trim();
            frmPN frm = new frmPN(mapn);
            frm.ShowDialog();
        }
    }
}
