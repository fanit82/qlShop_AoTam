namespace qlShop
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem11 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem10 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem13 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem4 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem5 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem12 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem7 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem6 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem8 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup3 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem14 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup4 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem9 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem17 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem15 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem16 = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2,
            this.navBarGroup3,
            this.navBarGroup4});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem1,
            this.navBarItem2,
            this.navBarItem3,
            this.navBarItem4,
            this.navBarItem5,
            this.navBarItem6,
            this.navBarItem7,
            this.navBarItem8,
            this.navBarItem9,
            this.navBarItem10,
            this.navBarItem11,
            this.navBarItem12,
            this.navBarItem13,
            this.navBarItem14,
            this.navBarItem15,
            this.navBarItem16,
            this.navBarItem17});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 140;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.ExplorerBar;
            this.navBarControl1.Size = new System.Drawing.Size(140, 620);
            this.navBarControl1.TabIndex = 9;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarGroup1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.navBarGroup1.Appearance.Options.UseFont = true;
            this.navBarGroup1.Appearance.Options.UseForeColor = true;
            this.navBarGroup1.Caption = "Bán Hàng";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Small;
            this.navBarGroup1.ImageOptions.SmallImage = global::qlShop.Properties.Resources.kpi_32x32;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem1),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem3),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem11),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem10),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem13)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "Đơn hàng";
            this.navBarItem1.ImageOptions.SmallImage = global::qlShop.Properties.Resources.task_32x32;
            this.navBarItem1.Name = "navBarItem1";
            this.navBarItem1.Tag = "frmDonHang";
            // 
            // navBarItem3
            // 
            this.navBarItem3.Caption = "Khách hàng";
            this.navBarItem3.ImageOptions.SmallImage = global::qlShop.Properties.Resources.contact_32x32;
            this.navBarItem3.Name = "navBarItem3";
            this.navBarItem3.Tag = "frmKhachHang";
            // 
            // navBarItem11
            // 
            this.navBarItem11.Caption = "Gạch nợ";
            this.navBarItem11.ImageOptions.LargeImage = global::qlShop.Properties.Resources.clearformatting_32x32;
            this.navBarItem11.ImageOptions.SmallImage = global::qlShop.Properties.Resources.clearformatting_32x32;
            this.navBarItem11.Name = "navBarItem11";
            this.navBarItem11.Tag = "frmGachNo";
            // 
            // navBarItem10
            // 
            this.navBarItem10.Caption = "Nhà cung cấp";
            this.navBarItem10.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem10.ImageOptions.SmallImage")));
            this.navBarItem10.Name = "navBarItem10";
            this.navBarItem10.Tag = "frmNhaCungCap";
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "Sản phẩm";
            this.navBarItem2.ImageOptions.SmallImage = global::qlShop.Properties.Resources.barcode_32x32;
            this.navBarItem2.Name = "navBarItem2";
            this.navBarItem2.Tag = "frmSanPham";
            // 
            // navBarItem13
            // 
            this.navBarItem13.Caption = "Trả hàng";
            this.navBarItem13.ImageOptions.SmallImage = global::qlShop.Properties.Resources.historyitem_32x32;
            this.navBarItem13.Name = "navBarItem13";
            this.navBarItem13.Tag = "frmDSTraHang";
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarGroup2.Appearance.Options.UseFont = true;
            this.navBarGroup2.Caption = "Quản lý";
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.ImageOptions.SmallImage = global::qlShop.Properties.Resources.pie_32x32;
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem4),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem5),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem12),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem7),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem6),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem8)});
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // navBarItem4
            // 
            this.navBarItem4.Caption = "Nhập kho";
            this.navBarItem4.ImageOptions.SmallImage = global::qlShop.Properties.Resources.addnewdatasource_32x32;
            this.navBarItem4.Name = "navBarItem4";
            this.navBarItem4.Tag = "frmNhapKho";
            // 
            // navBarItem5
            // 
            this.navBarItem5.Caption = "Tồn kho";
            this.navBarItem5.ImageOptions.SmallImage = global::qlShop.Properties.Resources.database_32x32;
            this.navBarItem5.Name = "navBarItem5";
            this.navBarItem5.Tag = "frmTonKho";
            // 
            // navBarItem12
            // 
            this.navBarItem12.Caption = "Quỹ Tiền Mặt";
            this.navBarItem12.ImageOptions.SmallImage = global::qlShop.Properties.Resources.currency_32x32;
            this.navBarItem12.Name = "navBarItem12";
            this.navBarItem12.Tag = "frmQuyTienMat";
            // 
            // navBarItem7
            // 
            this.navBarItem7.Caption = "Chi phí";
            this.navBarItem7.ImageOptions.SmallImage = global::qlShop.Properties.Resources.build_32x32;
            this.navBarItem7.Name = "navBarItem7";
            this.navBarItem7.Tag = "frmQLChiPhi";
            // 
            // navBarItem6
            // 
            this.navBarItem6.Caption = "Doanh số";
            this.navBarItem6.ImageOptions.SmallImage = global::qlShop.Properties.Resources.stackedbar_32x32;
            this.navBarItem6.Name = "navBarItem6";
            this.navBarItem6.Tag = "frmDoanhSo";
            // 
            // navBarItem8
            // 
            this.navBarItem8.Caption = "Tổng hợp";
            this.navBarItem8.ImageOptions.SmallImage = global::qlShop.Properties.Resources.kpi_32x32;
            this.navBarItem8.Name = "navBarItem8";
            this.navBarItem8.Tag = "frmTongHop";
            // 
            // navBarGroup3
            // 
            this.navBarGroup3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarGroup3.Appearance.Options.UseFont = true;
            this.navBarGroup3.Caption = "Tra cứu";
            this.navBarGroup3.Expanded = true;
            this.navBarGroup3.ImageOptions.SmallImage = global::qlShop.Properties.Resources.previewchart_32x32;
            this.navBarGroup3.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem14)});
            this.navBarGroup3.Name = "navBarGroup3";
            // 
            // navBarItem14
            // 
            this.navBarItem14.Caption = "Tra đơn hàng";
            this.navBarItem14.ImageOptions.SmallImage = global::qlShop.Properties.Resources.zoom100_32x32;
            this.navBarItem14.Name = "navBarItem14";
            this.navBarItem14.Tag = "frmTraCuuThongTin";
            // 
            // navBarGroup4
            // 
            this.navBarGroup4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarGroup4.Appearance.Options.UseFont = true;
            this.navBarGroup4.Caption = "Hệ thống";
            this.navBarGroup4.Expanded = true;
            this.navBarGroup4.ImageOptions.SmallImage = global::qlShop.Properties.Resources.technology_32x32;
            this.navBarGroup4.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem9),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem17),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem15),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem16)});
            this.navBarGroup4.Name = "navBarGroup4";
            // 
            // navBarItem9
            // 
            this.navBarItem9.Caption = "Cấu hình";
            this.navBarItem9.ImageOptions.SmallImage = global::qlShop.Properties.Resources.chartyaxissettings_32x32;
            this.navBarItem9.Name = "navBarItem9";
            this.navBarItem9.Tag = "frmCauHinh";
            // 
            // navBarItem17
            // 
            this.navBarItem17.Caption = "Đổi mật khẩu";
            this.navBarItem17.ImageOptions.SmallImage = global::qlShop.Properties.Resources.assigntome_32x32;
            this.navBarItem17.Name = "navBarItem17";
            // 
            // navBarItem15
            // 
            this.navBarItem15.Caption = "Đăng nhập lại";
            this.navBarItem15.ImageOptions.SmallImage = global::qlShop.Properties.Resources.refresh_32x32;
            this.navBarItem15.Name = "navBarItem15";
            // 
            // navBarItem16
            // 
            this.navBarItem16.Caption = "Thoát";
            this.navBarItem16.ImageOptions.SmallImage = global::qlShop.Properties.Resources.cancel_32x32;
            this.navBarItem16.Name = "navBarItem16";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 620);
            this.Controls.Add(this.navBarControl1);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem3;
        private DevExpress.XtraNavBar.NavBarItem navBarItem11;
        private DevExpress.XtraNavBar.NavBarItem navBarItem10;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem13;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem4;
        private DevExpress.XtraNavBar.NavBarItem navBarItem5;
        private DevExpress.XtraNavBar.NavBarItem navBarItem12;
        private DevExpress.XtraNavBar.NavBarItem navBarItem7;
        private DevExpress.XtraNavBar.NavBarItem navBarItem6;
        private DevExpress.XtraNavBar.NavBarItem navBarItem8;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup3;
        private DevExpress.XtraNavBar.NavBarItem navBarItem14;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup4;
        private DevExpress.XtraNavBar.NavBarItem navBarItem9;
        private DevExpress.XtraNavBar.NavBarItem navBarItem17;
        private DevExpress.XtraNavBar.NavBarItem navBarItem15;
        private DevExpress.XtraNavBar.NavBarItem navBarItem16;
    }
}

