using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using QLBS_DTO;
using QLBS_BLL;

namespace QuanLyBanSach.UserControls
{
    public partial class UCSanPham : UserControl
    {
        SanPhamBLL sanPhamBLL = new SanPhamBLL();
        public UCSanPham()
        {
            InitializeComponent();
            cangDeu();
            loadSP();
            trangThaiXem(false);
            btnXoaSP.Enabled = false;
            btnSuaSP.Enabled = false;
           
            //====
            btnLuuSP.Visible = false;
            btnThemSP.Visible = false;
            btnSuaSP.Visible = false;
            btnResetSP.Visible = false;
            iconButton3.Visible = false;
            btnXoaSP.Visible = false;
        }
        private void cangDeu()
        {
            int totalWidth = lstV_DSSP.ClientSize.Width; // Tổng chiều rộng của ListView
            int numColumns = lstV_DSSP.Columns.Count; // Số lượng cột

            if (numColumns == 0) return; // Tránh lỗi nếu không có cột

            // Tỉ lệ phần của mỗi cột
            int[] columnRatios = { 1, 2, 4 }; // Tỉ lệ cho từng cột

            // Tính tổng tỉ lệ
            int totalRatio = columnRatios.Sum(); // Tổng tỉ lệ (7 phần)

            // Gán chiều rộng cho các cột dựa trên tỉ lệ
            for (int i = 0; i < numColumns; i++)
            {
                // Tính chiều rộng cho cột
                int columnWidth = totalWidth * columnRatios[i] / totalRatio;
                lstV_DSSP.Columns[i].Width = columnWidth;
            }
        }

      
        public void loadSP()
        {
            List<SanPhamDTO> lst = sanPhamBLL.getAllSP();
          
            foreach (var item in lst)
            {
                string ma = item.MASP.ToString();
                string ten = item.TENSP.ToString();
                lstV_DSSP.Items.Add((lstV_DSSP.Items.Count + 1).ToString()).SubItems.AddRange(new[] { ma, ten });
            }
        }

        private void lstV_DSSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnXoaSP.Enabled = btnSuaSP.Enabled = lstV_DSSP.SelectedItems.Count > 0;
            if (lstV_DSSP.SelectedItems.Count > 0)
            {
                
                string masp = lstV_DSSP.SelectedItems[0].SubItems[1].Text;
                DataTable dt = sanPhamBLL.getSPByID(masp);
                try
                {
                    txtMaSP.Text = dt.Rows[0][0].ToString();
                    txtTenSp.Text = dt.Rows[0][1].ToString();
                    txtNamPH.Text = dt.Rows[0][2].ToString();
                    txtSL.Text = dt.Rows[0][3].ToString();
                    txtGiaBan.Text = dt.Rows[0][4].ToString();
                    txtTenTG.Text = dt.Rows[0][5].ToString();
                    cbo_tenNXB.Text = dt.Rows[0][6].ToString();
                    cbo_TenLoai.Text = dt.Rows[0][7].ToString();
                }
                catch (Exception ex)
                {

                     MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void trangThaiXem(bool value)
        {
            txtTenTG.Enabled = value;
            txtTenSp.Enabled = value;
            txtSL.Enabled = value;
            txtNamPH.Enabled = value;
            txtMaSP.Enabled = value;
            txtGiaBan.Enabled = value;
            cbo_TenLoai.Enabled = value;
            cbo_tenNXB.Enabled = value;
        }
        public void loadNXB()
        {
            cbo_tenNXB.DataSource = sanPhamBLL.getDSNXB();
            cbo_tenNXB.DisplayMember = "TENNXB";
            cbo_tenNXB.ValueMember = "MANXB";
        }
        public void loadLoai()
        {
            cbo_TenLoai.DataSource = sanPhamBLL.getDSLoai();
            cbo_TenLoai.DisplayMember = "TENLOAI";
            cbo_TenLoai.ValueMember = "MALOAI";
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            trangThaiXem(true);
            lstV_DSSP.Enabled = !lstV_DSSP.Enabled;
            if (lstV_DSSP.Enabled == true)
                trangThaiXem(false);
            loadNXB();
            loadLoai();
            btnResetSP_Click(sender, e);
            btnLuuSP.Visible = true;

        }

        private void btnResetSP_Click(object sender, EventArgs e)
        {
            txtGiaBan.Clear();
            txtMaSP.Clear();
            txtNamPH.Clear();
            txtSL.Clear();
            txtTenTG.Clear();
            cbo_TenLoai.SelectedIndex = 0;
            cbo_tenNXB.SelectedIndex = 0;
            txtTenSp.Clear();
            txtMaSP.Clear();
            txtMaSP.Focus();
        }

    

        private void btnLuuSP_Click(object sender, EventArgs e)
        {
            // Kiểm tra các đầu vào
            //if (!ValidateInputs())
            //{
            //    return; // Ngừng thực hiện nếu có đầu vào không hợp lệ
            //}

            string masp = txtMaSP.Text.Trim();
            string tensp = txtTenSp.Text.Trim();
            string tentg = txtTenTG.Text.Trim();
            int sl = int.Parse(txtSL.Text);
            int namph = int.Parse(txtNamPH.Text);
            decimal giaban = decimal.Parse(txtGiaBan.Text);
            string maloai = cbo_TenLoai.SelectedValue.ToString();
            string manxb = cbo_tenNXB.SelectedValue.ToString();
            SanPhamDTO sp = new SanPhamDTO(masp, tensp, tentg, namph, giaban, sl, maloai, manxb);

            if (sanPhamBLL.insertSP(sp))
            {
                MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void cboTimSPTheoLoai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UCSanPham_Load(object sender, EventArgs e)
        {
           
        }

      

        private void btnFind_Click(object sender, EventArgs e)
        {
            string tensp = txt_TimKiemTheoTen.Text.Trim();
            DataTable dt = sanPhamBLL.TimKiemSanPhamTheoTen(tensp);
            lstV_DSSP.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                lstV_DSSP.Items.Add((lstV_DSSP.Items.Count + 1).ToString()).SubItems.AddRange(new[] { row[0].ToString(), row[1].ToString() });

            }
        }

        



        // Hàm kiểm tra các đầu vào
        //private bool ValidateInputs()
        //{
        //    if (string.IsNullOrWhiteSpace(txtMaSP.Text))
        //    {
        //        MessageBox.Show("Mã sản phẩm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtMaSP.Focus();
        //        return false;
        //    }

        //    if (string.IsNullOrWhiteSpace(txtTenSp.Text))
        //    {
        //        MessageBox.Show("Tên sản phẩm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtTenSp.Focus();
        //        return false;
        //    }

        //    if (string.IsNullOrWhiteSpace(txtTenTG.Text))
        //    {
        //        MessageBox.Show("Tên tác giả không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtTenTG.Focus();
        //        return false;
        //    }

        //    if (string.IsNullOrWhiteSpace(txtSL.Text) || !int.TryParse(txtSL.Text, out _))
        //    {
        //        MessageBox.Show("Số lượng không được để trống và phải là số nguyên hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtSL.Focus();
        //        return false;
        //    }

        //    if (string.IsNullOrWhiteSpace(txtNamPH.Text) || !int.TryParse(txtNamPH.Text, out _))
        //    {
        //        MessageBox.Show("Năm phát hành không được để trống và phải là số nguyên hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtNamPH.Focus();
        //        return false;
        //    }

        //    if (string.IsNullOrWhiteSpace(txtGiaBan.Text) || !decimal.TryParse(txtGiaBan.Text, out _))
        //    {
        //        MessageBox.Show("Giá bán không được để trống và phải là số hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtGiaBan.Focus();
        //        return false;
        //    }

        //    if (cbo_TenLoai.SelectedValue == null)
        //    {
        //        MessageBox.Show("Bạn cần chọn loại sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        cbo_TenLoai.Focus();
        //        return false;
        //    }

        //    if (cbo_tenNXB.SelectedValue == null)
        //    {
        //        MessageBox.Show("Bạn cần chọn nhà xuất bản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        cbo_tenNXB.Focus();
        //        return false;
        //    }

        //    return true; // Tất cả các đầu vào đều hợp lệ
        //}




        //private void keypress_so(object sender, KeyPressEventArgs e)
        //{
        //    Control ctr = (Control)sender;
        //    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
        //        e.Handled = true;

        //}


    }
}
