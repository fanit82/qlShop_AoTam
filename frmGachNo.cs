using qlShop.models;
using qlShop.qlshop_model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace qlShop
{
    public partial class frmGachNo : Form
    {
        string strTrangThai = "view";
        public frmGachNo()
        {
            InitializeComponent();
        }

        private void KhoiTaoLuoi()
        {
            int i = 0;
            gridView1.Columns[i].Caption = "Chọn";
            gridView1.Columns[i].FieldName = "Chon";
            gridView1.Columns[i].OptionsColumn.FixedWidth = true;
            gridView1.Columns[i].Width = 50;
            //gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Ngày";
            gridView1.Columns[i].FieldName = "NgayBan";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns[i].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Đơn hàng";
            gridView1.Columns[i].FieldName = "DonHangID";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Khách hàng";
            gridView1.Columns[i].FieldName = "TenKhachHang";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Điện thoại";
            gridView1.Columns[i].FieldName = "SoDienThoai";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Tiền hàng";
            gridView1.Columns[i].FieldName = "TienHang";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "# ##0";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Giảm giá";
            gridView1.Columns[i].FieldName = "GiamGia";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "# ##0";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Tổng cộng";
            gridView1.Columns[i].FieldName = "TongCong";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ##0";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Thanh toán";
            gridView1.Columns[i].FieldName = "ThanhToan";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ##0";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Nợ";
            gridView1.Columns[i].FieldName = "ConNo";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ##0";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Nhân viên";
            gridView1.Columns[i].FieldName = "TenNhanVien";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            //for (int j = 0; j < gridView1.RowCount; j++)
            //{
            //    gridView1.Columns[j].OptionsColumn.AllowEdit = false;
            //}
        }

        private void frmGachNo_Load(object sender, EventArgs e)
        {
            KhoiTaoLuoi();
            KhoiTaoDSKhachHang();
            KhoiTaoTrangThaiTextbox();
        }

        private void KhoiTaoDSKhachHang()
        {
            lookUpEditKhachHang.Properties.DataSource = KhachHangController.GetList();
            lookUpEditKhachHang.Properties.DisplayMember = "TenKhachHang";
            lookUpEditKhachHang.Properties.ValueMember = "KhachHangID";
            lookUpEditKhachHang.Properties.NullText = "Chưa chọn khách hàng";
            lookUpEditKhachHang.Text = string.Empty;
            lookUpEditKhachHang.Properties.Columns[0].Caption = "Mã khách hàng";
            lookUpEditKhachHang.Properties.Columns[0].FieldName = "KhachHangID";

            lookUpEditKhachHang.Properties.Columns[1].Caption = "Tên Khách Hàng";
            lookUpEditKhachHang.Properties.Columns[1].FieldName = "TenKhachHang";
            lookUpEditKhachHang.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            lookUpEditKhachHang.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
        }

        private void repositoryItemCheckEditChon_CheckedChanged(object sender, EventArgs e)
        {
            gridView1.PostEditor();
            int introw = gridView1.FocusedRowHandle;
            bool isChon = false;
            if (introw>=0)
	        {
                isChon = Convert.ToBoolean(gridView1.GetRowCellValue(introw, "Chon"));
	        }
            if (isChon)
            {
                calcEditSoTienThu.Value += Convert.ToDecimal(gridView1.GetRowCellValue(introw, "ConNo"));
            }
            else
            {
                calcEditSoTienThu.Value -= Convert.ToDecimal(gridView1.GetRowCellValue(introw, "ConNo"));
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (lookUpEditKhachHang.EditValue != null)
            {
                DataTable tblKH = null;
                tblKH = DonHangController.LayDonHangConNo_KhachHang(lookUpEditKhachHang.EditValue.ToString());
                tblKH.Columns.Add(new DataColumn("Chon", typeof(bool)));
                foreach (DataRow item in tblKH.Rows)
                {
                    item["Chon"] = false;
                }
                gridControl1.DataSource = tblKH;

                //-----------------
                KhachHang iKhachHang = null;
                iKhachHang = KhachHangController.GetItem(lookUpEditKhachHang.EditValue.ToString());
                if (iKhachHang != null)
                {
                    txtKhachHangID.Text = iKhachHang.KhachHangID;
                    txtTenKhachHang.Text = iKhachHang.TenKhachHang;
                    calcEditTongTien.Value = iKhachHang.TongTienHang;
                    calcEditConNo.Value = iKhachHang.CongNo;
                    txtSoDienThoai.Text = iKhachHang.SoDienThoai;
                }

                strTrangThai = "add";
                DieuKhienTrangThai();
            }
        }

        private void DieuKhienTrangThai()
        {
            switch (strTrangThai.ToUpper())
            {
                case "VIEW":
                    btnChon.Enabled = true;
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                    break;
                case "ADD": //nguoi su dung dang nhap thong tin
                    btnChon.Enabled = false;
                    btnSave.Enabled = true;
                    btnCancel.Enabled = true;
                    break;
                default:
                    break;
            }
        }


        private void KhoiTaoTrangThaiTextbox()
        {
            txtKhachHangID.Properties.ReadOnly = true;
            txtTenKhachHang.Properties.ReadOnly = true;
            txtSoDienThoai.Properties.ReadOnly = true;
            calcEditTongTien.Properties.ReadOnly = true;
            calcEditConNo.Properties.ReadOnly = true;

            txtSoPhieu.Properties.ReadOnly = true;
            dateEditNgayThu.Properties.ReadOnly = true;
            calcEditSoTienThu.Properties.ReadOnly = true;
            calcEditTongTien.Properties.ReadOnly = true;
            txtNhanVien.Properties.ReadOnly = true;

            calcEditTongTien.Value = 0;
            calcEditSoTienThu.Value = 0;
            txtNhanVien.Text = Utility.NguoiSuDung.NguoiDungID;

            calcEditTongTien.Properties.Mask.UseMaskAsDisplayFormat = true;
            calcEditSoTienThu.Properties.Mask.UseMaskAsDisplayFormat = true;
            calcEditConNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            dateEditNgayThu.DateTime = DateTime.Now;

            lookUpEditKhachHang.Properties.NullValuePrompt = "Chưa chọn khách hàng";
        }
        private void Resetform()
        {
            gridControl1.DataSource = null;
            txtSoPhieu.Text = string.Empty;
            dateEditNgayThu.DateTime = DateTime.Now;
            calcEditSoTienThu.Value = 0;
            //
            txtKhachHangID.Text = string.Empty;
            txtTenKhachHang.Text = string.Empty;
            txtSoDienThoai.Text = string.Empty;
            calcEditConNo.Value = 0;
            calcEditTongTien.Value = 0;
            calcEditSoTienThu.Value = 0;            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            strTrangThai = "view";
            DieuKhienTrangThai();
            Resetform();
        }

        private void save()
        {
            PhieuGachNo iPhieuGachNo = new PhieuGachNo();
            iPhieuGachNo.PhieuGachNoID = PhieuGachNoController.TaoMaPhieuGachNo("GN", 8);
            iPhieuGachNo.KhachHangID = txtKhachHangID.Text;
            iPhieuGachNo.TenKhachHang = txtTenKhachHang.Text;
            iPhieuGachNo.TienNoHienTai = calcEditConNo.Value;
            iPhieuGachNo.TienThu = calcEditSoTienThu.Value;
            iPhieuGachNo.NguoiDungID = txtNhanVien.Text;
            iPhieuGachNo.NgayGachNo = dateEditNgayThu.DateTime;
            List<PhieuGachNoChiTiet> ListPhieu = new List<PhieuGachNoChiTiet>();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(gridView1.GetRowCellValue(i, "Chon")))
                {
                    PhieuGachNoChiTiet newitem = new PhieuGachNoChiTiet();
                    newitem.DonHangID = gridView1.GetRowCellValue(i, "DonHangID").ToString();
                    newitem.PhieuGachNoID = iPhieuGachNo.PhieuGachNoID;
                    newitem.TienNo = Convert.ToDecimal(gridView1.GetRowCellValue(i, "ConNo"));
                    ListPhieu.Add(newitem);
                }
            }
            PhieuGachNoController.Add(iPhieuGachNo, ListPhieu);
            //fanit82 modify for v3
            //đưa tiền gạch nợ vào quỹ tiền mặt
            QuyTienMatController.NhapQuyTienMat(iPhieuGachNo.PhieuGachNoID, iPhieuGachNo.NgayGachNo, iPhieuGachNo.TienThu, "GN", "Khách trả tiền nợ");
            txtSoPhieu.Text = iPhieuGachNo.PhieuGachNoID;
            strTrangThai = "view";
            DieuKhienTrangThai();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //kiểm tra xem có so tien gach no ko
            if (calcEditSoTienThu.Value <=0)
            {
                MessageBox.Show("Vui lòng chọn phiếu gạch nợ trước khi ghi","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            save();
            MessageBox.Show("Đã ghi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXemPhieu_Click(object sender, EventArgs e)
        {
            frmDSPhieuGachNo f = new frmDSPhieuGachNo();
            f.ShowDialog();
        }

        private void lookUpEditKhachHang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption.ToUpper().Equals("FIND"))
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
        
    }
}
