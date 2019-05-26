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
    public partial class frmImportSanPham : Form
    {
        public frmImportSanPham()
        {
            InitializeComponent();
            txtFileName.ReadOnly = true;
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
            }
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text == string.Empty)
            {
                return;
            }
            string strFileOpen = string.Empty;
            strFileOpen = txtFileName.Text;
            var DS = Utility.ImportExcelXLS(strFileOpen, true);
            DS.Tables[0].Columns.Add(new DataColumn("ERROR", typeof(String)));//add thêm cột này để xem lỗi;
            gridControl1.DataSource = DS.Tables[0];
            gridView1.BestFitColumns();
            //gridView1.DataSource = DS;
            lblStatus.Text = string.Format("Tổng số dòng là: {0}", gridView1.RowCount);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn cập nhật danh mục sản phẩm vào hệ thống?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int intTotalRow = gridView1.RowCount;
                int i = 1;
                int intDongXL = 0;
                while (gridView1.RowCount> intDongXL) //xử lý từng dòng, từ dòng đầu tiên
                {
                    lblStatus.Text = string.Format("Đang xử lý dòng {0}/{1}",i,intTotalRow);
                    lblStatus.Invalidate();
                    lblStatus.Update();                    
                    i++;
                    try
                    {
                        //kiểm tra dong đó có dữ liệu thì XLy
                        if (gridView1.GetRowCellValue(0, gridView1.Columns[0]) != null)
                        {
                            SanPham objSanPham = new SanPham();
                            objSanPham.SanPhamID = gridView1.GetRowCellValue(intDongXL, gridView1.Columns[0]).ToString();

                                                        

                            string strNhomSize = gridView1.GetRowCellValue(intDongXL, gridView1.Columns[3]).ToString();
                            if (strNhomSize != string.Empty)
                            {
                                objSanPham.NhomSize = strNhomSize;
                            }                            
                            objSanPham.TenSanPham = gridView1.GetRowCellValue(intDongXL, gridView1.Columns[1]).ToString();
                            if (gridView1.GetRowCellValue(intDongXL, gridView1.Columns[2])!=null)
                            {
                                objSanPham.GioTinh = gridView1.GetRowCellValue(intDongXL, gridView1.Columns[2]).ToString();
                            }                            
                            objSanPham.NhomHangID = null;
                            objSanPham.GiaBan = Convert.ToInt32(gridView1.GetRowCellValue(intDongXL, gridView1.Columns[5]).ToString());
                            objSanPham.NgayKhoiTao = DateTime.Now;
                            objSanPham.DVT = gridView1.GetRowCellValue(intDongXL, gridView1.Columns[7]).ToString();
                            objSanPham.NguoiDungID = Utility.NguoiSuDung.NguoiDungID;
                            objSanPham.NgungKinhDoanh = false;

                            SanPhamController.Add(objSanPham);
                            gridView1.DeleteRow(intDongXL);//remove dong đầu tiên   
                            gridControl1.Invalidate();
                            gridControl1.Update();
                        }
                    }
                    catch (Exception ex)
                    {
                        gridView1.SetRowCellValue(intDongXL, "ERROR", ex.Message);
                        gridControl1.Invalidate();
                        gridControl1.Update();
                        intDongXL++; //bỏ qua dòng lỗi; xly dòng tiep theo.
                        //throw;
                    }
                }
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(0);
        }
    }
}
