using System;
using System.Windows.Forms;
using qlShop.models;
using qlShop.qlshop_model;

namespace qlShop
{
    public partial class frmAddKhachHang : Form
    {
        public KhachHang EditItem { set; get; }
        public string strNewKhachHangID = string.Empty;
        public string frmMode { set; get; }
        public frmAddKhachHang()
        {
            this.frmMode = string.Empty;
            InitializeComponent();
        }

        private void frmAddKhachHang_Load(object sender, EventArgs e)
        {
            KhoiTaoLuoi();
            gridControl1.DataSource = KhachHangController.GetList();
            txtSearch.Properties.NullValuePrompt = "Nhập mã/tên/số điện thoại để tìm khách hàng";
            if ((this.EditItem!=null)&& this.frmMode.ToUpper().Equals("EDIT")) //user edit or copy
            {
                txtTenKhachhang.Text = EditItem.TenKhachHang;
                txtSoDienThoai.Text = EditItem.SoDienThoai;
                dtSinhNhat.EditValue = EditItem.SinhNhat == null ? null : EditItem.SinhNhat;
                radioGroupGioiTinh.EditValue = EditItem.GioiTinh;
                txtEmail.Text = EditItem.Email;
                txtGhiChu.Text = EditItem.GhiChu;
                txtKhachHangID.Text = EditItem.KhachHangID;
                txtDiaChi.Text = EditItem.DiaChi;
                //không cho chỉnh sửa các thoogn tin khi edit
                txtKhachHangID.Properties.ReadOnly = true;
            }
        }
        private void Save()
        {
            KhachHang item = new KhachHang();
            item.TenKhachHang = txtTenKhachhang.Text.Trim();
            item.SoDienThoai = txtSoDienThoai.Text.Trim();
            item.Email = txtEmail.Text.Trim();
            item.GioiTinh = Convert.ToBoolean(radioGroupGioiTinh.EditValue);
            item.GhiChu = txtGhiChu.Text;
            item.DiaChi = txtDiaChi.Text.Trim();
            if (dtSinhNhat.EditValue!= null)
            {
                item.SinhNhat = dtSinhNhat.DateTime;                 
            }
            else
            {
                //DateTime? nulldate = null;
                item.SinhNhat = null;
            }
            
            //-thong tin bao mat
            item.NguoiDungID = Utility.NguoiSuDung.NguoiDungID;
            item.TenNguoiDung = Utility.NguoiSuDung.TenNguoiDung;
            item.LastUpdate = DateTime.Now;

            //--sử lý phần mã khách hang tu dong hoặc nguoi dung tu nhap vao
            if (txtKhachHangID.Text.Trim().Equals(string.Empty)) //nguoi dung ko nhap, he thong tu tao ma
            {
                item.KhachHangID = KhachHangController.TaoMaKhachHang("KH", 8);
            }
            else
            {
                item.KhachHangID = txtKhachHangID.Text.Trim();
            }
            if (this.frmMode.ToUpper().Equals("EDIT"))
            {
                KhachHangController.Edit(item);
                EditItem = null;
            }
            else
            {
                KhachHangController.Add(item);
                strNewKhachHangID = item.KhachHangID; //lấy mã khách hàng mới vừa được tạo để đưa về form gọi
            }
            item = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }
        ///-----------------------------------------------------
        ///
        private void KhoiTaoLuoi()
        {
            int i = 0;
            gridView1.Columns[i].Caption = "Khách hàng";
            gridView1.Columns[i].FieldName = "KhachHangID";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            i++;
            gridView1.Columns[i].Caption = "Tên khách hàng";
            gridView1.Columns[i].FieldName = "TenKhachHang";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Số đt";
            gridView1.Columns[i].FieldName = "SoDienThoai";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Sinh nhật";
            gridView1.Columns[i].FieldName = "SinhNhat";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;


            i++;
            gridView1.Columns[i].Caption = "#";
            gridView1.Columns[i].OptionsColumn.FixedWidth = true;
            gridView1.Columns[i].Width = 50;
            //gridView1.ActiveFilterString = "[NgungKinhDoanh]=false";
            gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;

            //gr_btn_del.Buttons[1].Visible = false;//Ẩn nút kinh doanh lại - vì mặc định đang hiển thị các sp kinh doanh
        }
        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.ActiveFilterString = string.Format("[KhachHangID] like '%{0}%' or [TenKhachHang] like '%{0}%' or [SoDienThoai] like '%{0}%'", txtSearch.Text);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Save();
            gridControl1.DataSource = KhachHangController.GetList();
        }

        private void gr_btn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string strKhachHangID = string.Empty;
            int introw = gridView1.FocusedRowHandle;
            if (introw>=0)
	        {
		         strKhachHangID = gridView1.GetRowCellValue(introw,"KhachHangID").ToString();
	        }            
            if ((e.Button.Caption.ToUpper().Equals("SELECT")) &&(strKhachHangID!=string.Empty))
            {
                strNewKhachHangID = strKhachHangID;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }


    }
}
