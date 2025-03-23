using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace QuanLyBanSach.UserControls
{
    public partial class UCThongKe : UserControl
    {
        public UCThongKe()
        {
            InitializeComponent();
        }

        private void ReportThongke_Load(object sender, EventArgs e)
        {
            rptThongKe tk = new rptThongKe();
            tk.SetDatabaseLogon("sa", "123");
            tk.SetParameterValue("@ngayBD", dtpNgayBD.Value.ToString("yyyy-MM-dd"));
            tk.SetParameterValue("@ngayKT", dtpNgayKT.Value.ToString("yyyy-MM-dd"));
            ReportThongke.ReportSource = tk;
        }

        private void btnTKSanPham_Click(object sender, EventArgs e)
        {
            rptThongKe tk = new rptThongKe();
            tk.SetDatabaseLogon("sa", "123");
            tk.SetParameterValue("@ngayBD", dtpNgayBD.Value.ToString("yyyy-MM-dd"));
            tk.SetParameterValue("@ngayKT", dtpNgayKT.Value.ToString("yyyy-MM-dd"));
            ReportThongke.ReportSource = tk;
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            rptDoanhThu dt = new rptDoanhThu();
            dt.SetDatabaseLogon("sa", "123");
            dt.SetParameterValue("ngayBDMua", dtpNgayBD.Value.ToString("yyyy-MM-dd"));
            dt.SetParameterValue("ngayKTMua", dtpNgayKT.Value.ToString("yyyy-MM-dd"));
            ReportThongke.ReportSource = dt;
        }


        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            rptChiPhi cp = new rptChiPhi();
            cp.SetDatabaseLogon("sa", "123");
            cp.SetParameterValue("ngayDatBD", dtpNgayBD.Value.ToString("yyyy-MM-dd"));
            cp.SetParameterValue("ngayDatKT", dtpNgayKT.Value.ToString("yyyy-MM-dd"));
            ReportThongke.ReportSource = cp;
        }
    }
}
