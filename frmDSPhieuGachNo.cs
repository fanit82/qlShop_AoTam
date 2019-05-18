using qlShop.models;
using System;
using System.Data;
using System.Windows.Forms;
namespace qlShop
{
    public partial class frmDSPhieuGachNo : Form
    {
        public frmDSPhieuGachNo()
        {
            InitializeComponent();
        }


        private void KhoiTaoLuoi()
        {
            int i = 0;
            gridView1.Columns[i].Caption = "Ngày gạch";
            gridView1.Columns[i].FieldName = "NgayGachNo";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns[i].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Số chứng từ";
            gridView1.Columns[i].FieldName = "PhieuGachNoID";


            i++;
            gridView1.Columns[i].Caption = "Khách hàng";
            gridView1.Columns[i].FieldName = "TenKhachHang";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Điện thoại";
            gridView1.Columns[i].FieldName = "SoDienThoai";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Số tiền";
            gridView1.Columns[i].FieldName = "TienThu";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "# ##0";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Công nợ sau thu";
            gridView1.Columns[i].UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            gridView1.Columns[i].UnboundExpression="[TienNoHienTai] - [TienThu]";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "# ##0";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;


            i++;
            gridView1.Columns[i].Caption = "Nhân viên thu";
            gridView1.Columns[i].FieldName = "NguoiDungID";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            //for (int j = 0; j < gridView1.RowCount; j++)
            //{
            //    gridView1.Columns[j].OptionsColumn.AllowEdit = false;
            //}

            // luoi con thể hiện chứng từ chi tiết
            i = 0;
            gridView2.Columns[i].Caption = "Đơn hàng";
            gridView2.Columns[i].FieldName = "DonHangID";
            gridView2.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView2.Columns[i].Caption = "Tiền nợ";
            gridView2.Columns[i].FieldName = "TienNo";
            gridView2.Columns[i].OptionsColumn.AllowEdit = false;
        }

        private void frmDSPhieuGachNo_Load(object sender, EventArgs e)
        {
            KhoiTaoLuoi();
            dateEditStart.DateTime = DateTime.Now;
            dateEditEnd.DateTime = DateTime.Now;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataSet ds =PhieuGachNoController.TimPhieuTheoNgay(dateEditStart.DateTime, dateEditEnd.DateTime);
            gridControl1.DataSource = ds.Tables[0];
            //gridControl1.ForceInitialize();
            // luoi con thể hiện chứng từ chi tiết
            gridView2.ViewCaption = "Danh sách đơn hàng";
            int i = 0;
            gridView2.Columns[i].Caption = "Đơn hàng";
            gridView2.Columns[i].FieldName = "DonHangID";
            gridView2.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView2.Columns[i].Caption = "Tiền nợ";
            gridView2.Columns[i].FieldName = "TienNo";
            gridView2.Columns[i].OptionsColumn.AllowEdit = false;
        }


    }
}
