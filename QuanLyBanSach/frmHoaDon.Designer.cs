
namespace QuanLyBanSach
{
    partial class frmHoaDon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Report_HoaDon = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // Report_HoaDon
            // 
            this.Report_HoaDon.ActiveViewIndex = -1;
            this.Report_HoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Report_HoaDon.Cursor = System.Windows.Forms.Cursors.Default;
            this.Report_HoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Report_HoaDon.Location = new System.Drawing.Point(0, 0);
            this.Report_HoaDon.Name = "Report_HoaDon";
            this.Report_HoaDon.Size = new System.Drawing.Size(729, 342);
            this.Report_HoaDon.TabIndex = 0;
            // 
            // frmHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 342);
            this.Controls.Add(this.Report_HoaDon);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmHoaDon";
            this.Text = "frmHoaDon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHoaDon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer Report_HoaDon;
    }
}