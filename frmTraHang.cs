using System;
using System.Transactions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using qlShop.models;
namespace qlShop
{
    public partial class frmTraHang : Form
    {
        TraHang TraHangItem = null;
        DataTable tblDS = null;
        DonHang itemDonHang = null;
        public frmTraHang()
        {
            InitializeComponent();
        }


        private void InitGrid()
        {

            int i = 0;

            bandedGridView1.Columns[i].Caption = "Mã sản phẩm";
            bandedGridView1.Columns[i].FieldName = "SanPhamID";
            bandedGridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            bandedGridView1.Columns[i].Caption = "Tên sản phẩm";
            bandedGridView1.Columns[i].FieldName = "TenSanPham";
            bandedGridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            bandedGridView1.Columns[i].Caption = "Đã mua";
            bandedGridView1.Columns[i].FieldName = "SoLuong";
            bandedGridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            bandedGridView1.Columns[i].DisplayFormat.FormatString = "### ### ##0";
            bandedGridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            bandedGridView1.Columns[i].Caption = "Đ.Giá(mua)";
            bandedGridView1.Columns[i].FieldName = "DonGia";
            bandedGridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            bandedGridView1.Columns[i].DisplayFormat.FormatString = "### ### ##0";
            bandedGridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            bandedGridView1.Columns[i].Caption = "Thành Tiền";
            //gridView1.Columns[i].FieldName = "ThanhTien";
            bandedGridView1.Columns[i].OptionsColumn.AllowEdit = false;
            bandedGridView1.Columns[i].UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            bandedGridView1.Columns[i].UnboundExpression = "[SoLuong]*[DonGia]";
            bandedGridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            bandedGridView1.Columns[i].DisplayFormat.FormatString = "### ### ##0";
            bandedGridView1.Columns[i].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;



            i++;
            bandedGridView1.Columns[i].Caption = "SL Trả";
            bandedGridView1.Columns[i].FieldName = "SLTraLai";
            bandedGridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            bandedGridView1.Columns[i].DisplayFormat.FormatString = "### ### ##0";            

            i++;
            bandedGridView1.Columns[i].Caption = "Đ.Giá(Thu lại)";
            bandedGridView1.Columns[i].FieldName = "DonGiaTra";
            bandedGridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            bandedGridView1.Columns[i].DisplayFormat.FormatString = "### ### ##0";


            i++;
            bandedGridView1.Columns[i].Caption = "Thành Tiền";
            //gridView1.Columns[i].FieldName = "ThanhTien";
            bandedGridView1.Columns[i].OptionsColumn.AllowEdit = false;
            bandedGridView1.Columns[i].UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            bandedGridView1.Columns[i].UnboundExpression = "[SLTraLai]*[DonGiaTra]";
            bandedGridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            bandedGridView1.Columns[i].DisplayFormat.FormatString = "### ### ##0";
            bandedGridView1.Columns[i].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

            bandedGridView1.OptionsView.ColumnAutoWidth = false;
            //i++;
            //gridView1.Columns[i].Caption = "#";
            //gridView1.Columns[i].OptionsColumn.FixedWidth = true;
            //gridView1.Columns[i].Width = 50;
            bandedGridView1.OptionsView.ShowFooter = true;

            //gridView1.OptionsView.AllowCellMerge = true;
            //gridView1.Columns["SoLuong"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            //gridView1.Columns["DonGia"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
        }

        private void buttonEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)// user clcik enter
            {
                string strDonHangID = txtDonHangID.Text.Trim();
                itemDonHang = DonHangController.GetItem(strDonHangID);
                if (itemDonHang!=null)
                {
                    txtNgayBan.DateTime = itemDonHang.NgayBan;
                    txtNhanVien.Text = itemDonHang.TenNhanVien;
                    txtTongTien.EditValue = itemDonHang.TongCong;
                    txtGiamGia.EditValue = itemDonHang.GiamGia;
                    txtTienTT.EditValue = itemDonHang.ThanhToan;
                    txtTenKhachHang.Text = itemDonHang.TenKhachHang;
                    //txtDiaChi.Text = itemDonHang.di

                    tblDS = DonHangController.GetSanPham(strDonHangID);
                    tblDS.Columns.Add(new DataColumn("SLTraLai", typeof(int)));
                    tblDS.Columns.Add(new DataColumn("DonGiaTra", typeof(int)));
                    foreach (DataRow item in tblDS.Rows)
                    {
                        item["SLTraLai"] = 0;
                        item["DonGiaTra"] = Convert.ToDecimal(item["DonGia"].ToString());
                    }
                    gridControl1.DataSource = tblDS;
                    bandedGridView1.BestFitColumns();
                    txtDonHangID.Enabled = false;
                }
            }
        }

        private void frmTraHang_Load(object sender, EventArgs e)
        {
            InitGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal decTongTienTra = 0;
            if (itemDonHang == null)
	        {
		         MessageBox.Show("Chưa tìm thấy đơn hàng cần trả");
                 return;
	        }
            List<TraHangChiTiet> ListTraHang = new List<TraHangChiTiet>();
            if ((tblDS == null) || (tblDS.Rows.Count == 0))
            {
                MessageBox.Show("Chưa tìm thấy đơn hàng cần trả");
                return;
            }
            else
            {
                foreach (DataRow item in tblDS.Rows)
                {
                    TraHangChiTiet newitem = new TraHangChiTiet();
                    newitem.SanPhamID = item["SanPhamID"].ToString();
                    int intSoLuongBan = 0;
                    int.TryParse(item["SoLuong"].ToString(), out intSoLuongBan);
                    newitem.SoLuongBan = intSoLuongBan;

                    int intSoLuongTra = 0;
                    int.TryParse(item["SLTraLai"].ToString(), out intSoLuongTra);
                    newitem.SoLuongTra = intSoLuongTra;
                    newitem.TenSanPham = item["TenSanPham"].ToString();
                    decimal decDonGia = 0;
                    decimal.TryParse(item["DonGia"].ToString(), out decDonGia);
                    newitem.DonGia = decDonGia;

                    decimal decDonGiaTra = 0;
                    decimal.TryParse(item["DonGiaTra"].ToString(), out decDonGiaTra);
                    newitem.DonGiaTra = decDonGiaTra;
                    decTongTienTra += decDonGiaTra * intSoLuongTra;
                    ListTraHang.Add(newitem);
                }
            }
            TraHangItem = new TraHang();
            TraHangItem.DonHangID = txtDonHangID.Text;
            TraHangItem.NgayTra = DateTime.Now;
            TraHangItem.NgayBan = itemDonHang.NgayBan;
            TraHangItem.KhachHangID = itemDonHang.KhachHangID;
            TraHangItem.TenKhachHang = itemDonHang.TenKhachHang;
            TraHangItem.NhanVienID = Utility.NguoiSuDung.NguoiDungID;
            TraHangItem.TenNhanVien = Utility.NguoiSuDung.TenNguoiDung;
            TraHangItem.GhiChu = txtGhiChu.Text;
            TraHangItem.TongTienTra = decTongTienTra;
            using (TransactionScope TScope = new TransactionScope())
            {
                TraHangController.Add(TraHangItem, ListTraHang);
                QuyTienMatController.XuatQuyTienMat(TraHangItem.TraHangID, TraHangItem.NgayTra, decTongTienTra, "RT", "Khách trả lại hàng");
                btnSave.Enabled = false;
                MessageBox.Show("Đã ghi thành công");
                TScope.Complete();
            }           
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            txtDonHangID.Enabled = true;
            txtDonHangID.Focus();
            tblDS = null;
            gridControl1.DataSource = tblDS;
        }
    }
}
