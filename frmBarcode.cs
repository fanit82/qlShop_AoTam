using qlShop.models;
using qlShop.qlshop_model;
using qlShop.reports;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace qlShop
{
    public partial class frmBarcode : Form
    {
        public DataTable tblDonHangChiTiet = null;
        public frmBarcode()
        {
            InitializeComponent();
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
            //CurrencyManager cm = BindingContext[gridControl1.DataSource, gridControl1.DataMember] as CurrencyManager;
            //cm.ListChanged += new ListChangedEventHandler(cm_ListChanged);
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
            gridView1.Columns[i].Caption = "Số lượng bản in";
            gridView1.Columns[i].FieldName = "SoLuong";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "# ##0";


            i++;
            gridView1.Columns[i].Caption = "#";
            gridView1.Columns[i].OptionsColumn.FixedWidth = true;
            gridView1.Columns[i].Width = 50;
            gridView1.OptionsView.ShowFooter = true;
        }

        private void frmBarcode_Load(object sender, EventArgs e)
        {
            KhoiTaoLuoi();
            KhoiTaoDuLieuSearch();
            txtSearch.Properties.DataSource = SanPhamController.GetAllList();
            //gridControl1.DataSource = SanPhamController.GetAllList();
        }
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

            txtSearch.Properties.DisplayMember = "SanPhamID";
            txtSearch.Properties.ValueMember = "SanPhamID";
        }

        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            string strSanPhamID = txtSearch.EditValue.ToString();
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
                    gridView1.RefreshData();
                }
            }
        }

        public void printBarcode()
        {
            DataTable tblInBarcode = new DataTable();
            tblInBarcode.TableName = "SanPham";
            tblInBarcode.Columns.Add(new DataColumn("SanPhamID",typeof(string)));
            tblInBarcode.Columns.Add(new DataColumn("TenSanPham", typeof(string)));
            tblInBarcode.Columns.Add(new DataColumn("GiaBan", typeof(string)));

            foreach (DataRow item in tblDonHangChiTiet.Rows)
            {
                int intSLin = Convert.ToInt32(item["SoLuong"]);
                for (int i = 0; i < intSLin; i++)
                {
                    tblInBarcode.Rows.Add(item["SanPhamID"], item["TenSanPham"], item["DonGia"]);
                }
            }
            BarCode rpt = new BarCode();
            rpt.SetDataSource(tblInBarcode);
            frmViewReports f = new frmViewReports();
            f.crystalReportViewer1.ReportSource = rpt;
            f.MdiParent = this.MdiParent;
            f.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printBarcode();
        }
    }
}

