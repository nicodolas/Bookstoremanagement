namespace QuanLyBanSach.UserControls
{
    partial class UCThongKe
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpNgayKT = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpNgayBD = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnNhapHang = new FontAwesome.Sharp.IconButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnTKSanPham = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDoanhThu = new FontAwesome.Sharp.IconButton();
            this.ReportThongke = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1636, 79);
            this.panel1.TabIndex = 0;
            // 
            // dtpNgayKT
            // 
            this.dtpNgayKT.Checked = true;
            this.dtpNgayKT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayKT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKT.Location = new System.Drawing.Point(182, 22);
            this.dtpNgayKT.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayKT.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayKT.Name = "dtpNgayKT";
            this.dtpNgayKT.Size = new System.Drawing.Size(157, 36);
            this.dtpNgayKT.TabIndex = 10;
            this.dtpNgayKT.Value = new System.DateTime(2024, 12, 3, 21, 3, 45, 250);
            // 
            // dtpNgayBD
            // 
            this.dtpNgayBD.Checked = true;
            this.dtpNgayBD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBD.Location = new System.Drawing.Point(19, 22);
            this.dtpNgayBD.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayBD.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayBD.Name = "dtpNgayBD";
            this.dtpNgayBD.Size = new System.Drawing.Size(157, 36);
            this.dtpNgayBD.TabIndex = 10;
            this.dtpNgayBD.Value = new System.DateTime(2024, 12, 3, 21, 4, 34, 43);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dtpNgayKT);
            this.panel6.Controls.Add(this.dtpNgayBD);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(1291, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(345, 79);
            this.panel6.TabIndex = 9;
            this.panel6.Tag = "";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnNhapHang);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(490, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(245, 79);
            this.panel4.TabIndex = 7;
            // 
            // btnNhapHang
            // 
            this.btnNhapHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNhapHang.FlatAppearance.BorderSize = 0;
            this.btnNhapHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhapHang.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.btnNhapHang.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.btnNhapHang.IconChar = FontAwesome.Sharp.IconChar.LevelDown;
            this.btnNhapHang.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.btnNhapHang.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNhapHang.IconSize = 45;
            this.btnNhapHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhapHang.Location = new System.Drawing.Point(0, 0);
            this.btnNhapHang.Name = "btnNhapHang";
            this.btnNhapHang.Size = new System.Drawing.Size(245, 79);
            this.btnNhapHang.TabIndex = 4;
            this.btnNhapHang.Text = "     Nhập hàng";
            this.btnNhapHang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNhapHang.UseVisualStyleBackColor = true;
            this.btnNhapHang.Click += new System.EventHandler(this.btnNhapHang_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnTKSanPham);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(245, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(245, 79);
            this.panel3.TabIndex = 6;
            // 
            // btnTKSanPham
            // 
            this.btnTKSanPham.BackColor = System.Drawing.Color.White;
            this.btnTKSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTKSanPham.FlatAppearance.BorderSize = 0;
            this.btnTKSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTKSanPham.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.btnTKSanPham.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTKSanPham.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.btnTKSanPham.IconChar = FontAwesome.Sharp.IconChar.BarsProgress;
            this.btnTKSanPham.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.btnTKSanPham.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTKSanPham.IconSize = 45;
            this.btnTKSanPham.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTKSanPham.Location = new System.Drawing.Point(0, 0);
            this.btnTKSanPham.Name = "btnTKSanPham";
            this.btnTKSanPham.Size = new System.Drawing.Size(245, 79);
            this.btnTKSanPham.TabIndex = 4;
            this.btnTKSanPham.Text = "     Sản phẩm";
            this.btnTKSanPham.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTKSanPham.UseVisualStyleBackColor = false;
            this.btnTKSanPham.Click += new System.EventHandler(this.btnTKSanPham_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDoanhThu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(245, 79);
            this.panel2.TabIndex = 5;
            // 
            // btnDoanhThu
            // 
            this.btnDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDoanhThu.FlatAppearance.BorderSize = 0;
            this.btnDoanhThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoanhThu.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.btnDoanhThu.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.btnDoanhThu.IconChar = FontAwesome.Sharp.IconChar.MoneyBill;
            this.btnDoanhThu.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.btnDoanhThu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDoanhThu.IconSize = 45;
            this.btnDoanhThu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.btnDoanhThu.Name = "btnDoanhThu";
            this.btnDoanhThu.Size = new System.Drawing.Size(245, 79);
            this.btnDoanhThu.TabIndex = 6;
            this.btnDoanhThu.Text = "     Doanh thu";
            this.btnDoanhThu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDoanhThu.UseVisualStyleBackColor = true;
            this.btnDoanhThu.Click += new System.EventHandler(this.btnDoanhThu_Click);
            // 
            // ReportThongke
            // 
            this.ReportThongke.ActiveViewIndex = -1;
            this.ReportThongke.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportThongke.Cursor = System.Windows.Forms.Cursors.Default;
            this.ReportThongke.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportThongke.Location = new System.Drawing.Point(0, 79);
            this.ReportThongke.Name = "ReportThongke";
            this.ReportThongke.Size = new System.Drawing.Size(1636, 663);
            this.ReportThongke.TabIndex = 1;
            // 
            // UCThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ReportThongke);
            this.Controls.Add(this.panel1);
            this.Name = "UCThongKe";
            this.Size = new System.Drawing.Size(1636, 742);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer ReportThongke;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btnNhapHang;
        private FontAwesome.Sharp.IconButton btnTKSanPham;
        private FontAwesome.Sharp.IconButton btnDoanhThu;
        private System.Windows.Forms.Panel panel6;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayKT;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayBD;
    }
}
