using System;
using System.Transactions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using qlShop.models;
using qlShop.reports;
using qlShop.qlshop_model;

namespace qlShop
{
    public partial class frmAddDonHang : Form
    {
        //CurrencyManager cm = BindingContext[gridControl1.DataSource,gridControl1.DataMember] as CurrencyManager;
        public DonHang ViewItem { get; set; }
        public string forMode { set; get; }
        public DataTable tblDonHangChiTiet = null;
        public frmAddDonHang()
        {
            InitializeComponent();
            forMode = "NEW";
            //ViewItem = new DonHang();
        }

        private void frmAddDonHang_Load(object sender, EventArgs e)
        {
            //KhoiTaoDuLieuSearch();
            //txtSearch.Properties.DataSource = SanPhamController.GetActiveList();
            //txtSearch.Properties.DisplayMember = "SanPhamID";
            //txtSearch.Properties.ValueMember = "SanPhamID";
            txtSanPham.Properties.NullValuePrompt = "Scan mã sản phẩm vào đây";

            KhoiTaoLuoi();
            KhoiTaoDSKhachHang();
            //------------------------------------------
            dateEditNgayBan.DateTime = DateTime.Now;
            txtNhanVien.Text = Utility.NguoiSuDung.NguoiDungID;
            txtNhanVien.Properties.ReadOnly = true;
            txtMaPhieu.Properties.ReadOnly = true;
            

            txtTienHang.Properties.ReadOnly = true;
            txtTienHang.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtTienHang.Properties.DisplayFormat.FormatString = "### ### ##0";
            txtTienHang.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtTong.Properties.ReadOnly = true;
            txtTong.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtTong.Properties.DisplayFormat.FormatString = "### ### ##0";
            txtTong.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtConNo.Properties.ReadOnly = true;
            txtConNo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtConNo.Properties.DisplayFormat.FormatString = "### ### ##0";
            txtConNo.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtGiamGia.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtGiamGia.Properties.DisplayFormat.FormatString = "### ### ##0";
            txtGiamGia.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtThanhToan.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtThanhToan.Properties.DisplayFormat.FormatString = "### ### ##0";
            txtThanhToan.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtKhachDua.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtKhachDua.Properties.DisplayFormat.FormatString = "### ### ##0";
            txtKhachDua.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtTienThua.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtTienThua.Properties.DisplayFormat.FormatString = "### ### ##0";
            txtTienThua.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtTienThua.Properties.ReadOnly = true;
            



            //Chế độ view đơn hang
            if ((forMode.ToUpper().Equals("VIEW"))&& (ViewItem!=null)) 
            {
                txtMaPhieu.Text = ViewItem.DonHangID;
                dateEditNgayBan.DateTime = ViewItem.NgayBan;
                if (ViewItem.KhachHangID!=null)
                {
                    lookUpEditKhachHang.EditValue = ViewItem.KhachHangID;
                }
                txtNhanVien.Text = ViewItem.NhanVienID;
                txtGhiChu.Text = ViewItem.GhiChu;
                txtTienHang.Value = ViewItem.TienHang;
                txtGiamGia.Value = ViewItem.GiamGia;
                txtTong.Value = ViewItem.TongCong;
                txtThanhToan.Value = ViewItem.ThanhToan;
                txtConNo.Value = ViewItem.ConNo;
                txtKhachDua.Value = ViewItem.KhachDua == null ? 0 :(decimal) ViewItem.KhachDua;
                txtTienThua.Value = ViewItem.TienThua == null ? 0 : (decimal)ViewItem.TienThua;

                //lay danh sach san pham
                DataTable tblTemp = DonHangController.GetSanPham(ViewItem.DonHangID);
                KhoiTaoTableDonHangChiTiet();
                foreach (DataRow item in tblTemp.Rows)
                {
                    tblDonHangChiTiet.Rows.Add(item["SanPhamID"].ToString(),
                        item["TenSanPham"].ToString(),Convert.ToInt32(item["SoLuong"].ToString()),
                        Convert.ToInt32(item["DonGia"].ToString()));
                }
                gridControl1.DataSource = tblDonHangChiTiet;// DonHangController.GetSanPham(ViewItem.DonHangID);
                btnSave.Enabled = false;
            }
            CapNhatTrangThai();


            btnEdit.Enabled = false; //18/12/2015 ; khóa lại ko cho sauwr sau khi đã lưu đơn hàng.
        }
        private void KhoiTaoTableDonHangChiTiet()
        {
            if (tblDonHangChiTiet==null)
            {
                tblDonHangChiTiet = new DataTable();
            }
            tblDonHangChiTiet.Columns.Add(new DataColumn("SanPhamID", typeof(string)));
            tblDonHangChiTiet.Columns.Add(new DataColumn("TenSanPham", typeof(string)));
            tblDonHangChiTiet.Columns.Add(new DataColumn("SoLuong", typeof(int)));
            tblDonHangChiTiet.Columns.Add(new DataColumn("DonGia", typeof(int)));
            tblDonHangChiTiet.Columns.Add(new DataColumn("ThanhTien",typeof(decimal),"[SoLuong]*[DonGia]"));
            tblDonHangChiTiet.Columns.Add(new DataColumn("TonKho", typeof(int)));
            gridControl1.DataSource = tblDonHangChiTiet;
            CurrencyManager cm = BindingContext[gridControl1.DataSource, gridControl1.DataMember] as CurrencyManager;
            cm.ListChanged += new ListChangedEventHandler(cm_ListChanged);
        }

        /*
        private void KhoiTaoDuLieuSearch()
        {
            int i = 0;            
            txtSearch.Properties.Columns[i].Caption = "Mã sản phẩm";
            txtSearch.Properties.Columns[i].FieldName = "SanPhamID";

            i++;
            txtSearch.Properties.Columns[i].Caption = "Tên sản phẩm";
            txtSearch.Properties.Columns[i].FieldName = "TenSanPham";

            i++;
            txtSearch.Properties.Columns[i].Caption = "Giá bán";
            txtSearch.Properties.Columns[i].FieldName = "GiaBan";
            txtSearch.Properties.Columns[i].FormatType = DevExpress.Utils.FormatType.Numeric;
            txtSearch.Properties.Columns[i].FormatString = "# ##0";

            i++;
            txtSearch.Properties.Columns[i].Caption = "Tồn kho";
            txtSearch.Properties.Columns[i].FieldName = "SLTonKho";
            //txtSearch.Properties.
            txtSearch.Properties.AutoSearchColumnIndex = 1;
            txtSearch.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            txtSearch.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            txtSearch.Properties.NullValuePrompt = "Nhập mã sản phẩm hoặc tên";
        }
        */
        private void KhoiTaoLuoi()
        {
            int i = 0;
            gridView1.Columns[i].Caption = "Mã sản phẩm";
            gridView1.Columns[i].FieldName = "SanPhamID";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Tên sản phẩm";
            gridView1.Columns[i].FieldName = "TenSanPham";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Số lượng";
            gridView1.Columns[i].FieldName = "SoLuong";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ##0";


            i++;
            gridView1.Columns[i].Caption = "Đơn giá";
            gridView1.Columns[i].FieldName = "DonGia";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ##0";

            i++;
            gridView1.Columns[i].Caption = "Thành Tiền";
            gridView1.Columns[i].FieldName = "ThanhTien";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            //gridView1.Columns[i].UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            //gridView1.Columns[i].UnboundExpression = "[SoLuong]*[DonGia]";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ##0";
            gridView1.Columns[i].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

            i++;
            gridView1.Columns[i].Caption = "#";
            gridView1.Columns[i].OptionsColumn.FixedWidth = true;
            gridView1.Columns[i].Width = 50;
            gridView1.OptionsView.ShowFooter = true;
        }

        private void KhoiTaoDSKhachHang()
        {
            lookUpEditKhachHang.Properties.DataSource = KhachHangController.GetList();
            lookUpEditKhachHang.Properties.DisplayMember="TenKhachHang";
            lookUpEditKhachHang.Properties.ValueMember="KhachHangID";
            lookUpEditKhachHang.Properties.NullText="Chưa chọn khách hàng";
            lookUpEditKhachHang.Text = string.Empty;
            lookUpEditKhachHang.Properties.Columns[0].Caption = "Mã khách hàng";
            lookUpEditKhachHang.Properties.Columns[0].FieldName = "KhachHangID";

            lookUpEditKhachHang.Properties.Columns[1].Caption = "Tên Khách Hàng";
            lookUpEditKhachHang.Properties.Columns[1].FieldName = "TenKhachHang";
            lookUpEditKhachHang.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            lookUpEditKhachHang.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
        }
        

        private void gr_btn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption.ToUpper().Equals("DEL"))
            {
                int intRow = gridView1.FocusedRowHandle;
                if (intRow>=0)
                {
                    string strSanPhamID = gridView1.GetRowCellValue(intRow, "SanPhamID").ToString();
                    DataRow[] Rows = tblDonHangChiTiet.Select(string.Format("[SanPhamID]='{0}'", strSanPhamID));
                    if (Rows.Count()==1)
                    {
                        tblDonHangChiTiet.Rows.Remove(Rows[0]);
                        gridView1.RefreshData();
                    }
                }
            }
        }

        private void lookUpEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption.ToUpper().Equals("ADD"))
            {
                frmAddKhachHang f = new frmAddKhachHang();
                f.ShowDialog(this);
                lookUpEditKhachHang.Properties.DataSource = KhachHangController.GetList();
                if (f.strNewKhachHangID != string.Empty)
                {
                    lookUpEditKhachHang.EditValue = f.strNewKhachHangID;
                }
                f.Dispose();
            }
        }

  
        //static CurrencyManager cm = BindingContext[gridControl1.DataSource,gridControl1.DataMember] as CurrencyManager;
        //CurrencyManager cm = BindingContext[gridControl1.DataSource, gridControl1.DataMember] as CurrencyManager;
        //cm.ListChanged += new ListChangedEventHandler(cm_ListChanged);


        void cm_ListChanged(object sender, ListChangedEventArgs e)
        {
            //gridView1.PostEditor();
            //txtTienHang.Text = gridView1.Columns[4].SummaryItem.SummaryValue.ToString();
            //MessageBox.Show("Test");
            //foreach (var item in tblDonHangChiTiet.Rows)
            //{
                
            //}
            if (!forMode.ToUpper().Equals("VIEW"))
            {
                txtTienHang.Text = tblDonHangChiTiet.Compute("sum(ThanhTien)", null).ToString();
                txtTong.Value = txtTienHang.Value - txtGiamGia.Value;
                txtThanhToan.Value = txtTong.Value;
                txtConNo.Value = txtTong.Value - txtThanhToan.Value;
            }
            
        }


        private void txtGiamGia_EditValueChanged(object sender, EventArgs e)
        {
            txtTong.Value = txtTienHang.Value - txtGiamGia.Value;
            txtThanhToan.Value = txtTong.Value;
            txtConNo.Value = txtTong.Value - txtThanhToan.Value;
        }

        private void txtThanhToan_EditValueChanged(object sender, EventArgs e)
        {
            txtConNo.Value = txtTong.Value - txtThanhToan.Value;
            if (txtKhachDua.Value >0)
            {
                txtTienThua.Value = txtKhachDua.Value - txtThanhToan.Value; 
            }
            
        }

        private void Save()
        {

            using (TransactionScope scope = new TransactionScope())
            {

                DonHang itemSave = new DonHang();
                //kiem tra xem co phai nguoi dung dang sua don hang hay khong
                if (forMode.ToUpper().Equals("EDIT"))//dang sua don hang, phai xu ly xoa don hang cu
                {
                    string strDonHangID = txtMaPhieu.Text;
                    DonHangController.Del(strDonHangID);
                    itemSave.DonHangID = strDonHangID;
                    itemSave.NgayBan = dateEditNgayBan.DateTime;
                    itemSave.LastUpdate = DateTime.Now;//ngay sua don hang
                }
                else
                {
                    itemSave.DonHangID = DonHangController.TaoMaDonHang("EX", 10);
                    itemSave.NgayBan = dateEditNgayBan.DateTime;
                }
                //thong tin ban hang                        
                if (lookUpEditKhachHang.EditValue != null)
                {
                    itemSave.KhachHangID = lookUpEditKhachHang.EditValue.ToString();
                    itemSave.TenKhachHang = lookUpEditKhachHang.Text;
                }
                itemSave.GhiChu = txtGhiChu.Text;
                itemSave.NhanVienID = txtNhanVien.Text;
                itemSave.TenNhanVien = Utility.NguoiSuDung.TenNguoiDung;
                itemSave.LastUpdate = DateTime.Now;
                //thong tin thanh toan
                itemSave.TienHang = txtTienHang.Value;
                itemSave.GiamGia = txtGiamGia.Value;
                itemSave.TongCong = txtTong.Value;
                itemSave.ThanhToan = txtThanhToan.Value;
                itemSave.ConNo = txtConNo.Value;

                itemSave.KhachDua = txtKhachDua.Value;
                itemSave.TienThua = txtTienThua.Value;
                //lay thong tin chi tiet don hang
                List<DonHangChiTiet> DonHangItems = new List<DonHangChiTiet>();
                if (tblDonHangChiTiet != null)
                {
                    foreach (DataRow item in tblDonHangChiTiet.Rows)
                    {
                        DonHangChiTiet newitem = new DonHangChiTiet();
                        newitem.DonHangID = itemSave.DonHangID;
                        newitem.SanPhamID = item["SanPhamID"].ToString();
                        newitem.TenSanPham = item["TenSanPham"].ToString();
                        newitem.SoLuong = Convert.ToInt32(item["SoLuong"].ToString());
                        newitem.DonGia = Convert.ToDecimal(item["DonGia"].ToString());
                        //newitem.TonKho = SanPhamController.GetTonKho(newitem.SanPhamID);
                        DonHangItems.Add(newitem);
                    }
                }
                DonHangController.Add(itemSave, DonHangItems);
                scope.Complete();
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //kiểm tra demo phần mềm-------------------------//
            //DateTime Ngayhethan = new DateTime(2015, 8 ,15);
            //if (DateTime.Now >Ngayhethan)
            //{
            //    MessageBox.Show("Phần mềm đã hết hạn sử dụng, vui lòng liên hệ tác giả.","Cảnh báo",MessageBoxButtons.OK);
            //    return;
            //}
            Save();
            frmDonHang f = new frmDonHang();
            f.MdiParent = this.MdiParent;
            f.Show();
            this.Dispose();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            frmDonHang f = new frmDonHang();
            f.MdiParent = this.MdiParent;
            f.Show();
            this.Dispose();
        }

        
        private void SellNewITem(string strSanPhamID)
        {
            if (SanPhamController.IsExitsItem(strSanPhamID))
            {
                SanPham itemSP = SanPhamController.GetItem(strSanPhamID);
                if (tblDonHangChiTiet == null)
                {
                    KhoiTaoTableDonHangChiTiet();
                }
                if (tblDonHangChiTiet.Select(string.Format("[SanPhamID]='{0}'", strSanPhamID)).Count() < 1)
                {
                    tblDonHangChiTiet.Rows.Add(itemSP.SanPhamID, itemSP.TenSanPham, 1, itemSP.GiaBan);
                }
                else
                {
                    DataRow findRow = tblDonHangChiTiet.Select(string.Format("[SanPhamID]='{0}'", strSanPhamID))[0];
                    findRow["SoLuong"] = Convert.ToInt32(findRow["SoLuong"]) + 1;
                }
                gridView1.RefreshData();
            }

        }

        private void CapNhatTrangThai()
        {
            switch (forMode.ToUpper())
            {
                case "VIEW":
                    btnCancel.Enabled = false;
                    btnSave.Enabled = false;
                    btnEdit.Enabled = true;
                    //
                    txtSanPham.Enabled = false;
                    gridView1.Columns["SoLuong"].OptionsColumn.AllowEdit = false;
                    gridView1.Columns["DonGia"].OptionsColumn.AllowEdit = false;
                    gridColumn6.OptionsColumn.AllowEdit = false;
                    lookUpEditKhachHang.Enabled = false;
                    dateEditNgayBan.Enabled = false;
                    txtGhiChu.Enabled = false;
                    txtGiamGia.Enabled = false;
                    txtThanhToan.Enabled = false;

                    break;
                case "EDIT": //dang edit du lieu
                    btnCancel.Enabled = true;
                    btnSave.Enabled = true;
                    btnEdit.Enabled = false;
                    //
                    txtSanPham.Enabled = true;
                    gridView1.Columns["SoLuong"].OptionsColumn.AllowEdit = true;
                    gridView1.Columns["DonGia"].OptionsColumn.AllowEdit = true;
                    gridColumn6.OptionsColumn.AllowEdit = true;
                    lookUpEditKhachHang.Enabled = true;
                    dateEditNgayBan.Enabled = true;
                    txtGhiChu.Enabled = true;
                    txtGiamGia.Enabled = true;
                    txtThanhToan.Enabled = true;

                    break;
                case "NEW": //Them don hang moi
                    btnCancel.Enabled = false;
                    btnSave.Enabled = true;
                    btnEdit.Enabled = false;
                    //
                    txtSanPham.Enabled = true;
                    gridView1.Columns["SoLuong"].OptionsColumn.AllowEdit = true;
                    gridView1.Columns["DonGia"].OptionsColumn.AllowEdit = true;
                    gridColumn6.OptionsColumn.AllowEdit = true;
                    lookUpEditKhachHang.Enabled = true;
                    dateEditNgayBan.Enabled = true;
                    txtGhiChu.Enabled = true;
                    txtGiamGia.Enabled = true;
                    txtThanhToan.Enabled = true;

                    break;
                default:
                    break;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            forMode = "EDIT";
            CapNhatTrangThai();
        }

        private void txtKhachDua_EditValueChanged(object sender, EventArgs e)
        {
            txtTienThua.Value = txtKhachDua.Value - txtThanhToan.Value;
            if (txtTienThua.Value<0)
            {
                txtTienThua.Value = 0;
            }
        }

        private void txtKhachDua_DoubleClick(object sender, EventArgs e)
        {
            if (txtKhachDua.Value==0)
            {
                txtKhachDua.Value = txtThanhToan.Value;
            }
        }


        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Caption.ToUpper().Equals("FIND"))
            {
                frmTimSanPham f = new frmTimSanPham();
                f.SendSanPhamID = new frmTimSanPham.SendData(SellNewITem);
                f.ShowDialog(this);
            }
        }

        private void txtSanPham_KeyDown(object sender, KeyEventArgs e)
        {
            string strSanPhamID = string.Empty;
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSanPham.EditValue != null)
                {
                    strSanPhamID = txtSanPham.EditValue.ToString();
                }
                else
                {
                    return;
                }
                SellNewITem(strSanPhamID);
                txtSanPham.Focus();
                txtSanPham.SelectAll();
            }
        }

        private void btnPrinterTest_Click(object sender, EventArgs e)
        {
            //tao source de in thu don hang

            DataTable TblPrinter = new DataTable();

            TblPrinter.Columns.Add(new DataColumn("DonHangID", typeof(string)));
            TblPrinter.Columns.Add(new DataColumn("TenKhachHang", typeof(string)));
            TblPrinter.Columns.Add(new DataColumn("NgayBan", typeof(DateTime)));
            TblPrinter.Columns.Add(new DataColumn("NhanVienID", typeof(string)));
            TblPrinter.Columns.Add(new DataColumn("GhiChu", typeof(string)));
            TblPrinter.Columns.Add(new DataColumn("TienHang", typeof(decimal)));
            TblPrinter.Columns.Add(new DataColumn("GiamGia", typeof(decimal)));
            TblPrinter.Columns.Add(new DataColumn("TongCong", typeof(decimal)));
            TblPrinter.Columns.Add(new DataColumn("ThanhToan", typeof(decimal)));
            TblPrinter.Columns.Add(new DataColumn("ConNo", typeof(decimal)));
            TblPrinter.Columns.Add(new DataColumn("KhachDua", typeof(decimal)));
            TblPrinter.Columns.Add(new DataColumn("TienThua", typeof(decimal)));
            TblPrinter.Columns.Add(new DataColumn("TenSanPham", typeof(string)));
            TblPrinter.Columns.Add(new DataColumn("SoLuong", typeof(int)));
            TblPrinter.Columns.Add(new DataColumn("DonGia", typeof(decimal)));

            foreach (DataRow item in tblDonHangChiTiet.Rows)
            {
                TblPrinter.Rows.Add(
                    "000",
                    lookUpEditKhachHang.Text,
                    dateEditNgayBan.DateTime,
                    txtNhanVien.EditValue,
                    txtGhiChu.Text,
                    txtTienHang.EditValue == null ? 0 : txtTienHang.EditValue,
                    txtGiamGia.EditValue == null ? 0 : txtGiamGia.EditValue,
                    txtTong.EditValue == null ? 0 : txtTong.EditValue,
                    txtThanhToan.EditValue == null ? 0 : txtThanhToan.EditValue,
                    txtConNo.EditValue == null ? 0 : txtConNo.EditValue,
                    txtKhachDua.EditValue == null ? 0 : txtKhachDua.EditValue,
                    txtTienThua.EditValue == null ? 0 : txtTienThua.EditValue,
                    item["TenSanPham"].ToString(),
                    Convert.ToDecimal( item["SoLuong"].ToString()),
                    Convert.ToDecimal( item["DonGia"].ToString())
                    );
            }
            ////-------------------------------------------------------
            PhieuTam rp = new PhieuTam();
            rp.SetDataSource(TblPrinter);
            rp.Refresh();
            ThongTinShop shop = ThongTinShopController.GetItem();
            rp.SetParameterValue("TenShop", shop.TenShop);
            rp.SetParameterValue("DiaChi", shop.DiaChi);
            rp.SetParameterValue("SoDienThoai", shop.SoDienThoai);
            rp.SetParameterValue("WebSite", shop.website);
            frmViewReports fReport = null;
            foreach (Form item in MdiChildren)
            {
                if (item.GetType() == typeof(frmViewReports))
                {
                    fReport = (item as frmViewReports);
                    fReport.crystalReportViewer1.ReportSource = rp;
                    fReport.Activate();
                    return;
                }
            }
            fReport = new frmViewReports();
            fReport.crystalReportViewer1.ReportSource = rp;
            fReport.MdiParent = this.MdiParent;
            fReport.Show();            
        }
    }
}

