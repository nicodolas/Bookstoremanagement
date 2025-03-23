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
    public partial class frmPN : Form
    {
        public string MaPN { get; set; }
        public frmPN()
        {
            InitializeComponent();
        }
        public frmPN(string mapn)
        {
            InitializeComponent();
            MaPN = mapn;
        }

        private void frmPN_Load(object sender, EventArgs e)
        {
            InPN pn = new InPN();
            pn.SetDatabaseLogon("sa", "123");
            pn.SetParameterValue("MaPN", MaPN);
            Report_PN.ReportSource = pn;
        }
    }
}
