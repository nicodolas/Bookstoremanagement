using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanSach
{
    public partial class frmHoaDon : Form
    {
        string MaHD { get; set; }
        public frmHoaDon()
        {
            InitializeComponent();
        }
        public frmHoaDon(string mahd)
        {
            InitializeComponent();
            MaHD = mahd;
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                InHD hd = new InHD();
                hd.SetDatabaseLogon("sa", "123");
                hd.SetParameterValue("MAHD", MaHD);

                if (Report_HoaDon != null)
                {
                    Report_HoaDon.ReportSource = hd;
                }
            }
            catch (AccessViolationException ex)
            {
                MessageBox.Show("Access Violation Exception occurred: " + ex.Message);
                // Log thêm thông tin chi tiết vào file hoặc console
            }


        }

        private void Report_HoaDon_Load(object sender, EventArgs e)
        {
            //Report_HoaDon.AutoSizeMode = AutoSizeMode.GrowOnly;
            //Report_HoaDon.Zoom(75); // Hoặc chọn giá trị zoom khác nếu cần

        }
    }
}
