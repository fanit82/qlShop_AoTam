using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using qlShop.models;
using qlShop.qlshop_model;

namespace qlShop
{
    public partial class frmImportSanPham : Form
    {

        DataTable tblNhomHang = null;



        public frmImportSanPham()
        {
            InitializeComponent();
            txtFileName.ReadOnly = true;
            gridView1.IndicatorWidth = 40;
            KhoiTaoTableDM_NhomHang();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "Excel file (*.xls)|*.xls|(*.xlsx)|*.xlsx"
            };                               
            if (fileDialog.ShowDialog()== DialogResult.OK)
            {
                txtFileName.Text = fileDialog.FileName;
                var DS = Utility.ImportExcelXLS(txtFileName.Text, true);
                DS.Tables[0].Columns.Add(new DataColumn("ERROR", typeof(String)));//add thêm cột này để xem lỗi;
                gridControl1.DataSource = DS.Tables[0];
                gridView1.OptionsView.ColumnAutoWidth = false;
                gridView1.BestFitColumns();
                //gridView1.DataSource = DS;                
            }
        }

        private void KhoiTaoTableDM_NhomHang()
        {
            tblNhomHang = new DataTable();
            tblNhomHang.Columns.Add(new DataColumn("NhomHangID", typeof(string)));
            tblNhomHang.Columns.Add(new DataColumn("TenNhomHang", typeof(string)));
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn cập nhật danh mục sản phẩm vào hệ thống?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int intTotalRow = gridView1.RowCount;
                int i = 1;
                int intDongXL = 0;
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption("Đợi xíu...");
                while (gridView1.RowCount> intDongXL) //xử lý từng dòng, từ dòng đầu tiên
                {
                    splashScreenManager1.SetWaitFormDescription(string.Format("Đang xử lý dòng {0}/{1}", i, intTotalRow));               
                    i++;
                    try
                    {
                        //nếu dòng đó có mã và tên sản phẩm thì xử lý
                        string strID = gridView1.GetRowCellValue(intDongXL, gridView1.Columns["SanPhamID"]).ToString();                        
                        string strTen = gridView1.GetRowCellValue(intDongXL, gridView1.Columns["TenSanPham"]).ToString();                        
                        if (strID != string.Empty)
                        {

                            //0:Ma SP
                            //1:TenSP
                            //2:GioTinh
                            //3:Nhom Size
                            //4:Gia ban le
                            //5:NhomSP
                            //6:DVT

                            SanPham objSanPham = new SanPham();
                            objSanPham.SanPhamID = strID;
                            string strNhomSize = gridView1.GetRowCellValue(intDongXL, gridView1.Columns["NhomSize"]).ToString();
                            if (strNhomSize != string.Empty)
                            {
                                objSanPham.NhomSize = strNhomSize;
                            }

                            string strNhomHang = gridView1.GetRowCellValue(intDongXL, gridView1.Columns["NhomSanPham"]).ToString();
                            if (strTen!=string.Empty)
                            {
                                objSanPham.TenSanPham = strTen;
                            }
                            else
                            {
                                objSanPham.TenSanPham = strNhomHang;
                            }                            
                            if (gridView1.GetRowCellValue(intDongXL, gridView1.Columns[2])!=null)
                            {
                                objSanPham.GioTinh = gridView1.GetRowCellValue(intDongXL, gridView1.Columns["GioTinh"]).ToString();
                            }
                            NhomHang objNhomHang = NhomHangController.GetByName(strNhomHang);
                            if (objNhomHang != null)
                            {
                                objSanPham.NhomHangID = objNhomHang.NhomHangID;
                            }
                            else
                            {
                                objNhomHang = new NhomHang();
                                objNhomHang.TenNhomHang = strNhomHang;
                                objNhomHang.NguoiDungID = Utility.NguoiSuDung.NguoiDungID;
                                objNhomHang.TenNguoiDung = Utility.NguoiSuDung.TenNguoiDung;
                                objSanPham.NhomHangID = NhomHangController.Add(objNhomHang);
                            }
                            //string strMaNhomHang = Utility.TenVietTat(strNhomHang);
                            //objSanPham.NhomHangID = strMaNhomHang;
                            if ((gridView1.GetRowCellValue(intDongXL, gridView1.Columns["GiaBanLe"]) != null))
                            {
                                int intGiaBan = 0;
                                if (Int32.TryParse(gridView1.GetRowCellValue(intDongXL, gridView1.Columns["GiaBanLe"]).ToString(),out intGiaBan))
                                {
                                    objSanPham.GiaBan = intGiaBan;
                                }
                                else
                                {
                                    objSanPham.GiaBan = 0;
                                }                                
                            }

                            //objSanPham.NgayKhoiTao = DateTime.Now;
                            if (gridView1.GetRowCellValue(intDongXL, gridView1.Columns["DVT"])!=null)
                            {
                                objSanPham.DVT = gridView1.GetRowCellValue(intDongXL, gridView1.Columns["DVT"]).ToString();
                            }

                            if (gridView1.GetRowCellValue(intDongXL, gridView1.Columns["EXT_ID"]) != null)
                            {
                                objSanPham.EXT_ID = gridView1.GetRowCellValue(intDongXL, gridView1.Columns["EXT_ID"]).ToString();
                            }

                            objSanPham.NguoiDungID = Utility.NguoiSuDung.NguoiDungID;
                            objSanPham.NgungKinhDoanh = false;
                            SanPhamController.Add(objSanPham);
                            gridView1.DeleteRow(intDongXL);//remove dong dang xly
                            //gridControl1.Invalidate();
                            //gridControl1.Update();                   

                        }
                        else
                        {
                            gridView1.SetRowCellValue(intDongXL, "ERROR", "Không có mã hoặc tên sản phẩm!");
                            intDongXL++; //bỏ qua dòng này không xly.
                        }
                    }
                    catch (Exception ex)
                    {
                        gridView1.SetRowCellValue(intDongXL, "ERROR", ex.Message);
                        //gridControl1.Invalidate();
                        //gridControl1.Update();
                        intDongXL++; //bỏ qua dòng lỗi; xly dòng tiep theo.
                        //throw;
                    }
                    //làm mới lại lưới
                    gridControl1.Invalidate();
                    gridControl1.Update();
                }

                //Them Danh Muc Nhom Hang vao he thong.

                splashScreenManager1.CloseWaitForm();
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(0);
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.Kind == DevExpress.Utils.Drawing.IndicatorKind.Header)
            {
                e.Info.DisplayText = "STT";
            }
            else
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString("00");
            }
        }
    }
}
