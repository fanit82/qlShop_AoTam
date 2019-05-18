using System;
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
    public partial class frmQuyTienMat : Form
    {
        public frmQuyTienMat()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmNhapXuatQuyTienMat f = new frmNhapXuatQuyTienMat();
            f.ShowDialog(this);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DateTime dtBegin = txtBegin.DateTime.Date;
            DateTime dtEnd = txtEnd.DateTime.Date.AddSeconds(86399);
            DataTable tblLichSu = QuyTienMatController.LichSuGiaoDich(dtBegin, dtEnd);
            gridControl1.DataSource = tblLichSu;
            gridView1.BestFitColumns();
            //if (tblLichSu.Rows.Count>0)
            //{
            //    txtDauNgay.EditValue = Convert.ToDecimal(tblLichSu.Rows[tblLichSu.Rows.Count - 1]["TienDauKy"].ToString());
            //    txtHienTai.EditValue = Convert.ToDecimal(tblLichSu.Rows[0]["TienCuoiKy"].ToString());                
            //}

        }

        private void frmQuyTienMat_Load(object sender, EventArgs e)
        {
            InitGrid();
            txtBegin.DateTime = DateTime.Today;
            txtEnd.DateTime = DateTime.Today;
            //txtDauNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //txtDauNgay.Properties.DisplayFormat.FormatString = "### ### ### ##0";
            //txtDauNgay.Properties.Mask.UseMaskAsDisplayFormat = true;

            //txtHienTai.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //txtHienTai.Properties.DisplayFormat.FormatString = "### ### ### ##0";
            //txtHienTai.Properties.Mask.UseMaskAsDisplayFormat = true;

            //txtNhap.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //txtNhap.Properties.DisplayFormat.FormatString = "### ### ### ##0";
            //txtNhap.Properties.Mask.UseMaskAsDisplayFormat = true;

            //txtXuat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //txtXuat.Properties.DisplayFormat.FormatString = "### ### ### ##0";
            //txtXuat.Properties.Mask.UseMaskAsDisplayFormat = true;

        }

        private void InitGrid()
        {
            int i = 0;
            gridView1.Columns[i].Caption = "Ngày";
            gridView1.Columns[i].FieldName = "Ngay_ThaoTac";

            i++;
            gridView1.Columns[i].Caption = "Chứng từ";
            gridView1.Columns[i].FieldName = "ChungTu_ID";

            i++;
            gridView1.Columns[i].Caption = "Nhập vào";
            gridView1.Columns[i].FieldName = "TienNhap";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ##0";

            i++;
            gridView1.Columns[i].Caption = "Lấy ra";
            gridView1.Columns[i].FieldName = "TienXuat";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ##0";

            i++;
            gridView1.Columns[i].Caption = "Số dư";
            gridView1.Columns[i].FieldName = "TienCuoiKy";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ##0";

            i++;
            gridView1.Columns[i].Caption = "Ghi chú";
            gridView1.Columns[i].FieldName = "GhiChu";

            for ( i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            }
            gridView1.OptionsView.ColumnAutoWidth = false;
        }
    }
}
