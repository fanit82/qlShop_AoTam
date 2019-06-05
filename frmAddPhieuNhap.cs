using qlShop.models;
using qlShop.qlshop_model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace qlShop
{
    public partial class frmAddPhieuNhap : Form
    {
        public PhieuNhap ViewItem { get; set; }
        public string forMode { set; get; }
        public DataTable tblDonHangChiTiet = null;

        public frmAddPhieuNhap()
        {
            forMode = string.Empty;
            InitializeComponent();
        }

        private void lookUpEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void KhoiTaoTableDonHangChiTiet()
        {
            if (tblDonHangChiTiet == null)
            {
                tblDonHangChiTiet = new DataTable();
            }
            tblDonHangChiTiet.Columns.Add(new DataColumn("SanPhamID", typeof(string)));
            tblDonHangChiTiet.Columns.Add(new DataColumn("TenSanPham", typeof(string)));
            tblDonHangChiTiet.Columns.Add(new DataColumn("SoLuong", typeof(int)));
            tblDonHangChiTiet.Columns.Add(new DataColumn("DonGia", typeof(int)));
            tblDonHangChiTiet.Columns.Add(new DataColumn("ThanhTien", typeof(decimal), "[SoLuong]*[DonGia]"));
            tblDonHangChiTiet.Columns.Add(new DataColumn("TonKho", typeof(int)));
            gridControl1.DataSource = tblDonHangChiTiet;
            CurrencyManager cm = BindingContext[gridControl1.DataSource, gridControl1.DataMember] as CurrencyManager;
            cm.ListChanged += new ListChangedEventHandler(cm_ListChanged);
        }

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
            gridView1.Columns[i].DisplayFormat.FormatString = "# ##0";


            i++;
            gridView1.Columns[i].Caption = "Đơn giá";
            gridView1.Columns[i].FieldName = "DonGia";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "# ##0";

            i++;
            gridView1.Columns[i].Caption = "Thành Tiền";
            gridView1.Columns[i].FieldName = "ThanhTien";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            //gridView1.Columns[i].UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            //gridView1.Columns[i].UnboundExpression = "[SoLuong]*[DonGia]";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "# ##0";
            gridView1.Columns[i].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

            i++;
            gridView1.Columns[i].Caption = "#";
            gridView1.Columns[i].OptionsColumn.FixedWidth = true;
            gridView1.Columns[i].Width = 50;
            gridView1.OptionsView.ShowFooter = true;
        }

        //private void KhoiTaoDuLieuSearch()
        //{
        //    int i = 0;
        //    txtSanPham.Properties.Columns[i].Caption = "Mã sản phẩm";
        //    txtSanPham.Properties.Columns[i].FieldName = "SanPhamID";

        //    i++;
        //    txtSanPham.Properties.Columns[i].Caption = "Tên sản phẩm";
        //    txtSanPham.Properties.Columns[i].FieldName = "TenSanPham";

        //    i++;
        //    txtSanPham.Properties.Columns[i].Caption = "Giá bán";
        //    txtSanPham.Properties.Columns[i].FieldName = "GiaBan";
        //    txtSanPham.Properties.Columns[i].FormatType = DevExpress.Utils.FormatType.Numeric;
        //    txtSanPham.Properties.Columns[i].FormatString = "# ##0";

        //    i++;
        //    txtSanPham.Properties.Columns[i].Caption = "Tồn kho";
        //    txtSanPham.Properties.Columns[i].FieldName = "SLTonKho";
        //    //txtSearch.Properties.
        //    txtSanPham.Properties.AutoSearchColumnIndex = 1;
        //    txtSanPham.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
        //    txtSanPham.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;

        //    txtSanPham.Properties.DisplayMember = "SanPhamID";
        //    txtSanPham.Properties.ValueMember = "SanPhamID";
        //    txtSanPham.Properties.NullValuePrompt = "Nhập mã sản phẩm hoặc tên";
        //}

        private void KhoiTaoDSNhaCungCap()
        {
            lookUpEditNhaCungCap.Properties.DataSource = NhaCungCapControlller.GetList();
            lookUpEditNhaCungCap.Properties.DisplayMember = "TenNhaCungCap";
            lookUpEditNhaCungCap.Properties.ValueMember = "NhaCungCapID";
            lookUpEditNhaCungCap.Properties.NullText = "Chưa chọn nhà cung cấp";
            lookUpEditNhaCungCap.Text = string.Empty;
            lookUpEditNhaCungCap.Properties.Columns[0].Caption = "Mã nhà cung cấp";
            lookUpEditNhaCungCap.Properties.Columns[0].FieldName = "NhaCungCapID";

            lookUpEditNhaCungCap.Properties.Columns[1].Caption = "Tên nhà cung cấp";
            lookUpEditNhaCungCap.Properties.Columns[1].FieldName = "TenNhaCungCap";
            lookUpEditNhaCungCap.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            lookUpEditNhaCungCap.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
        }

        private void frmAddPhieuNhap_Load(object sender, EventArgs e)
        {
            //KhoiTaoDuLieuSearch();
            //txtSanPham.Properties.DataSource = SanPhamController.GetActiveList();
            KhoiTaoLuoi();
            KhoiTaoDSNhaCungCap();
            //------------------------------------------
            dateEditNgayBan.DateTime = DateTime.Now;
            txtNhanVien.Text = Utility.NguoiSuDung.NguoiDungID;
            txtNhanVien.Properties.ReadOnly = true;
            txtMaPhieu.Properties.ReadOnly = true;


            txtTienHang.Properties.ReadOnly = true;
            txtTienHang.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtTienHang.Properties.DisplayFormat.FormatString = "# ##0";
            txtTienHang.Properties.Mask.UseMaskAsDisplayFormat = true;



            txtConNo.Properties.ReadOnly = true;
            txtConNo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtConNo.Properties.DisplayFormat.FormatString = "# ##0";

            txtThanhToan.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtThanhToan.Properties.DisplayFormat.FormatString = "# ##0";

            //Chế độ view đơn hang
            if ((forMode.ToUpper().Equals("VIEW")) && (ViewItem != null))
            {
                txtMaPhieu.Text = ViewItem.PhieuNhapID;
                dateEditNgayBan.DateTime = ViewItem.NgayNhap;
                if (ViewItem.NhaCungCapID != null)
                {
                    lookUpEditNhaCungCap.EditValue = ViewItem.NhaCungCapID;
                }
                txtNhanVien.Text = ViewItem.NhanVienID;
                txtGhiChu.Text = ViewItem.GhiChu;
                txtTienHang.Value = ViewItem.TienHang;
                txtThanhToan.Value = ViewItem.ThanhToan;
                txtConNo.Value = ViewItem.ConNo;

                //lay danh sach san pham
                gridControl1.DataSource = PhieuNhapController.GetSanPham(ViewItem.PhieuNhapID);

                btnSave.Enabled = false;
            }


        }

        private void Save()
        {
            PhieuNhap itemSave = new PhieuNhap();
            //thong tin ban hang
            itemSave.PhieuNhapID = PhieuNhapController.TaoMaPhieuNhap("PN", 10);
            itemSave.NgayNhap = dateEditNgayBan.DateTime;
            if (lookUpEditNhaCungCap.EditValue != null)
            {
                itemSave.NhaCungCapID = lookUpEditNhaCungCap.EditValue.ToString();
                itemSave.TenNhaCungCap = lookUpEditNhaCungCap.Text;
            }
            itemSave.GhiChu = txtGhiChu.Text;
            itemSave.NhanVienID = txtNhanVien.Text;
            itemSave.TenNhanVien = Utility.NguoiSuDung.TenNguoiDung;
            itemSave.LastUpdate = DateTime.Now;
            //thong tin thanh toan
            itemSave.TienHang = txtTienHang.Value;
            itemSave.ThanhToan = txtThanhToan.Value;
            itemSave.ConNo = txtConNo.Value;
            //lay thong tin chi tiet don hang
            List<PhieuNhapChiTiet> PhieuNhapItems = new List<PhieuNhapChiTiet>();
            if (tblDonHangChiTiet != null)
            {
                foreach (DataRow item in tblDonHangChiTiet.Rows)
                {
                    PhieuNhapChiTiet newitem = new PhieuNhapChiTiet();
                    newitem.PhieuNhapID = itemSave.PhieuNhapID;
                    newitem.SanPhamID = item["SanPhamID"].ToString();
                    newitem.TenSanPham = item["TenSanPham"].ToString();
                    newitem.SoLuong = Convert.ToInt32(item["SoLuong"].ToString());
                    newitem.DonGia = Convert.ToDecimal(item["DonGia"].ToString());
                    newitem.TonKho = SanPhamController.GetTonKho(newitem.SanPhamID);
                    PhieuNhapItems.Add(newitem);
                }
            }
            PhieuNhapController.Add(itemSave, PhieuNhapItems);

        }
        void cm_ListChanged(object sender, ListChangedEventArgs e)
        {
            //gridView1.PostEditor();
            //txtTienHang.Text = gridView1.Columns[4].SummaryItem.SummaryValue.ToString();
            //MessageBox.Show("Test");
            //foreach (var item in tblDonHangChiTiet.Rows)
            //{

            //}
            txtTienHang.Text = tblDonHangChiTiet.Compute("sum(ThanhTien)", null).ToString();
            txtThanhToan.Value = txtTienHang.Value;
            txtConNo.Value = txtTienHang.Value - txtThanhToan.Value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            frmNhapKho f = new frmNhapKho();
            f.MdiParent = this.MdiParent;
            f.Show();
            this.Dispose();
        }

        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            frmNhapKho f = new frmNhapKho();
            f.MdiParent = this.MdiParent;
            f.Show();
            this.Dispose();
        }

        private void lookUpEditNhaCungCap_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption.ToUpper().Equals("ADD"))
            {
                frmAddNhaCungCap f = new frmAddNhaCungCap();
                f.ShowDialog(this);
                lookUpEditNhaCungCap.Properties.DataSource = NhaCungCapControlller.GetList();
                if (f.strNewNhaCungCapID != string.Empty)
                {
                    lookUpEditNhaCungCap.EditValue = f.strNewNhaCungCapID;
                }
                f.Dispose();
            }
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
            {
                string strSanPhamID = string.Empty;
            if (txtSanPham.EditValue != null)
            {
                strSanPhamID = txtSanPham.EditValue.ToString();
            }
            else
            {
                return;
            }

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
                        //gridView1.RefreshData();
                    }
                    else
                    {
                        DataRow findRow = tblDonHangChiTiet.Select(string.Format("[SanPhamID]='{0}'", strSanPhamID))[0];
                        findRow["SoLuong"] = Convert.ToInt32(findRow["SoLuong"]) + 1;
                    }
                    gridView1.RefreshData();
                    txtSanPham.Focus();
                    txtSanPham.SelectAll();
                }
            }
        }

        private void gr_btn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption.ToUpper().Equals("DEL"))
            {
                int intRow = gridView1.FocusedRowHandle;
                if (intRow >= 0)
                {
                    string strSanPhamID = gridView1.GetRowCellValue(intRow, "SanPhamID").ToString();
                    DataRow[] Rows = tblDonHangChiTiet.Select(string.Format("[SanPhamID]='{0}'", strSanPhamID));
                    if (Rows.Count() == 1)
                    {
                        tblDonHangChiTiet.Rows.Remove(Rows[0]);
                        gridView1.RefreshData();
                    }
                }
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
                    //gridView1.RefreshData();
                }
                else
                {
                    DataRow findRow = tblDonHangChiTiet.Select(string.Format("[SanPhamID]='{0}'", strSanPhamID))[0];
                    findRow["SoLuong"] = Convert.ToInt32(findRow["SoLuong"]) + 1;
                }
                gridView1.RefreshData();
            }
        }

        private void txtSanPham_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption.ToUpper().Equals("FIND"))
            {
                frmTimSanPham f = new frmTimSanPham();
                f.SendSanPhamID = new frmTimSanPham.SendData(SellNewITem);
                f.ShowDialog(this);
            }
        }
    }
}
