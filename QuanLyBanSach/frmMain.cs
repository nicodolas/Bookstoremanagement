using QuanLyBanSach.UserControls;
using System;
using System.Drawing;
using System.Windows.Forms;
using CustomBox.RJControls;
using System.Data.SqlClient;
using QLBS_BLL;
using QLBS_DAL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyBanSach
{
    public partial class frmMain : Form
    {
        //private string _username;
        //string employeeName = "";
        //public string GetEmployeeName(string username)
        //{
        //    using (SqlConnection connection = new SqlConnection(DBConnect.connectionString))
        //    {
        //        string query = "SELECT HOTENNV FROM NHANVIEN WHERE TENDN = @Username";
        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("@Username", username);

        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            employeeName = reader["HOTENNV"].ToString();
        //        }
        //    }

        //    return employeeName;
        //}
        //public frmMain(string role)
        //{
        //    if (role.Equals("Admin"))
        //    {
        //        InitializeComponent();
        //        UCDonHang uc = new UCDonHang();
        //        addUserControl(uc);
        //        lblTitle.Text = " Đơn hàng ";
        //        lblTenND.Text = "Hi, " + "Admin";
        //    }
        //    else
        //    {
        //        InitializeComponent();
        //        UCDonHang uc = new UCDonHang();
        //        addUserControl(uc);
        //        lblTitle.Text = " Đơn hàng ";
        //        lblTenND.Text = "Hi, " + GetEmployeeName(employeeName);
        //        //===
        //        btnThongke.Visible = false;
        //        btnKho.Visible = false;
        //        btnNhanVien.Visible = false;
        //    }
        //}
        private string _username;

        public frmMain(string role, string username)
        {
            _username = username;
            InitializeComponent();

            if (role.Equals("Admin"))
            {
                UCTrangChu uc = new UCTrangChu();
                addUserControl(uc);
                lblTitle.Text = " Trang chủ ";
                lblTenND.Text = "Hi, Admin";
                btnInfoCaNhan.Visible = false;
            }
            else
            {
                UCTrangChu uc = new UCTrangChu();
                addUserControl(uc);
                lblTitle.Text = " Trang chủ ";
                lblTenND.Text = "Hi, " + GetEmployeeName(_username);
                btnThongke.Visible = false;
                btnKho.Visible = false;
                btnNhanVien.Visible = false;
            }
        }

        public string GetEmployeeName(string username)
        {
            string employeeName = "";

            using (SqlConnection connection = new SqlConnection(DBConnect.connectionString))
            {
                string query = "Select HOTENNV From NHANVIEN Where TENDN = @Username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    employeeName = reader["HOTENNV"].ToString();
                }
            }
            return employeeName;
        }

        private void btnmain_Click(object sender, EventArgs e)
        {
            Size formSize;
            formSize = this.ClientSize;
            this.WindowState = FormWindowState.Maximized;

        }
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            var result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                
                e.Cancel = true;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMinisize_Click(object sender, EventArgs e)
        {
            Size formSize;
            formSize = this.ClientSize;
            this.WindowState = FormWindowState.Minimized;

        }
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
            
        }
        private void addUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            pnlDesktopp.Controls.Clear();
            pnlDesktopp.Controls.Add(uc);
            uc.BringToFront();
        }
         
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            UCNhanVien uc = new UCNhanVien();
            addUserControl(uc);
            lblTitle.Text = " Nhân viên ";
        }
        
        private void btnSach_Click(object sender, EventArgs e)
        {
            UCSanPham uc = new UCSanPham();
            addUserControl(uc);
            lblTitle.Text = " Sản phẩm ";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
           frmDangnhap frm = new frmDangnhap();
            frm.ShowDialog();
            this.Close();
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            UCDonHang uc = new UCDonHang();
            addUserControl (uc);
            lblTitle.Text = " Đơn hàng ";
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            UCNhapKho uc = new UCNhapKho();
            addUserControl(uc);
            lblTitle.Text = " Nhập kho  ";
        }

        //private void Open_Dropdownmenu(RJDropdownMenu dropdownMenu , object sender)
        //{
        //    Control control = (Control)sender;
        //    dropdownMenu.VisibleChanged += new EventHandler((sender2, ev) => DropdowMenu_VisibleChanged(sender2, ev, control));
        //    dropdownMenu.Show(control, control.Width, 0);
        //}
        //private void DropdowMenu_VisibleChanged(object sender, EventArgs e, Control ctrl)
        //{

        //    RJDropdownMenu dropdownMenu = (RJDropdownMenu)sender;
        //    if (!DesignMode)
        //    {
        //        if (dropdownMenu.Visible)
        //            ctrl.BackColor = Color.FromArgb(250, 224, 199);
        //        else
        //            ctrl.BackColor = Color.FromArgb(250, 245, 224);
        //    }
        //}

        //private void xuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    UCXuatKho uc = new UCXuatKho();
        //    addUserControl(uc);
        //    lblTitle.Text = "  Xuất kho  ";
        //}

        //private void nhậpKhoToolStripMenuItem_Click_1(object sender, EventArgs e)
        //{
        //    UCNhapKho uc = new UCNhapKho();
        //    addUserControl(uc);
        //    lblTitle.Text = " Nhập kho  ";
        //}

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            UCKhachHang uc = new UCKhachHang();
            addUserControl(uc);
            lblTitle.Text = "  Khách hàng  ";
        }

        private void btnThongke_Click(object sender, EventArgs e)
        {
            UCThongKe uc = new UCThongKe();
            addUserControl(uc);
            lblTitle.Text = " Thống kê ";
        }

        NhanVienBLL nhanVienBLL = new NhanVienBLL();
        private void btnInfoCaNhan_Click(object sender, EventArgs e)
        {
            string manv = nhanVienBLL.getMaNVByUserName(_username.Trim());
            UCCaNhan uc = new UCCaNhan(manv);
            addUserControl(uc);
            lblTitle.Text = " Thông tin cá nhân ";
        }

        private void picAvt_Click(object sender, EventArgs e)
        {
            UCTrangChu uc = new UCTrangChu();
            addUserControl(uc);
            lblTitle.Text = " Trang chủ ";
        }
    }
}