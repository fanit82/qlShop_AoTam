using qlShop.models;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace qlShop
{
    public partial class frmAddSanPham : Form
    {
        public SanPham itemCopy = null;
        public string formMode = string.Empty;
        public frmAddSanPham()
        {
            InitializeComponent();
        }

        private void frmAddSanPham_Load(object sender, EventArgs e)
        {
            // khởi tạo các định dạng----------------------
            //txtGiaBan.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //txtGiaBan.Properties.DisplayFormat.FormatString = "### ### ### ##0";
            txtGiaBan.Properties.Mask.UseMaskAsDisplayFormat = true;

            //txtGiaVon.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //txtGiaVon.Properties.DisplayFormat.FormatString = "### ### ### ##0";
            txtGiaVon.Properties.Mask.UseMaskAsDisplayFormat = true;

            KhoiTaoTreelistNhomHang();
            LayDanhSachNhomHang();
            LayDanhSachNSX();
            //
            if (itemCopy!=null) //truong hop copy hoạc edit san pham
            {                
                txtSoLuong.EditValue = itemCopy.SLTonKho;
                txtGiaVon.EditValue = itemCopy.GiaVon;
                txtGiaBan.EditValue = itemCopy.GiaBan;
                chkChoXuatAm.Checked = itemCopy.ChoXuatAm;
                chkNgungKinhDoanh.Checked = itemCopy.NgungKinhDoanh;
                if (itemCopy.NhaSanXuatID!=null)
                {
                    lookupNSX.EditValue = itemCopy.NhaSanXuatID;    
                }
                if (itemCopy.NhomHangID!=null)
                {
                    treelistNhomHang.EditValue = itemCopy.NhomHangID;    
                }
                
                cbbThueVAT.EditValue = itemCopy.ThuaVAT;

                if (itemCopy.HinhAnh!=null)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(itemCopy.HinhAnh.ToArray() as byte[]);
                    //MemoryStream ms = new MemoryStream(byteArrayIn);
                    //Image returnImage = Image.FromStream(ms);
                    //return returnImage;
                    imgHinhAnh.EditValue = Image.FromStream(ms);
                }

                if (formMode.ToUpper().Equals("COPY")) //copy san pham
                {
                    txtTenSanPham.Text = itemCopy.TenSanPham + "- Copy";
                }
                else
                {
                    if (formMode.ToUpper().Equals("EDIT"))//Edit san pham
                    {
                        txtTenSanPham.Text = itemCopy.TenSanPham;
                        txtMaSanPham.Text = itemCopy.SanPhamID;
                        txtMaSanPham.Properties.ReadOnly = true; // không cho sửa mã sản phẩm
                        txtSoLuong.Properties.ReadOnly = true;//khong cho sửa số lượng tồn
                    }
                }
            }

            //kiểm tra nếu là nhân viên thì không cho xem giá vốn va cac chuc nang cap nhat
            if (Utility.NguoiSuDung.Roles.ToUpper().Equals(Utility.NHANVIEN.ToUpper()))
            {
                txtGiaVon.Properties.PasswordChar = '*';
                btnAdd.Enabled = false;
                btnPrint.Enabled = false;
            }
            //else
            //{
            //    txtGiaVon.Properties.PasswordChar = null;                
            //}

        }
        private void KhoiTaoTreelistNhomHang()
        {
            treelistNhomHang.Properties.TreeList.Columns[0].Caption = "Nhóm hàng";
            treelistNhomHang.Properties.TreeList.Columns[0].FieldName = "TenNhomHang";
            //khong hien thi duong ke
            treelistNhomHang.Properties.TreeList.OptionsView.ShowHorzLines = false;
            treelistNhomHang.Properties.TreeList.OptionsView.ShowVertLines = false;
            treelistNhomHang.Properties.NullText = "chưa chọn nhóm hàng";
            treelistNhomHang.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
        }
        private void LayDanhSachNhomHang()
        {
            treelistNhomHang.Properties.DataSource= NhomHangController.Getlist();
            treelistNhomHang.Properties.DisplayMember = "TenNhomHang";
            treelistNhomHang.Properties.ValueMember = "NhomHangID";
            treelistNhomHang.Properties.TreeList.KeyFieldName = "NhomHangID";
            treelistNhomHang.Properties.TreeList.ParentFieldName = "NhomHangChaID";
        }
        private void LayDanhSachNSX()
        {
            lookupNSX.Properties.DataSource = NhaSanXuatController.GetList();
            lookupNSX.Properties.DisplayMember = "TenNhaSanXuat";
            lookupNSX.Properties.ValueMember = "NhaSanXuatID";
            lookupNSX.Properties.NullText = "chưa chọn nhà sản xuất";
            lookupNSX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
        }

        private void lookupNhomHang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if( e.Button.Index==1)
            {
                frmAddNhomHang f = new frmAddNhomHang();
                f.ShowDialog(this);
                //load lại danh sach nhom hang.
                treelistNhomHang.Properties.DataSource = NhomHangController.Getlist();
            }
        }
        
        private void treelistNhomHang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                frmAddNhomHang f = new frmAddNhomHang();
                f.ShowDialog(this);
            }
        }


        private bool KiemTraNhap()
        {
            bool isError = true;
            string strError = string.Empty;
            //kiểm tra các trường không được rỗng
            if (txtTenSanPham.Text.Trim().Length<1)
            {
                isError = false;
                strError += "Tên sản phẩm không được để trống";
            }
            
            //kiểm tra số lượng tồn kho
            if (txtSoLuong.EditValue == null)
            {
                txtSoLuong.EditValue = 0;
            }
            if (txtGiaVon.EditValue == null)
            {
                txtGiaVon.EditValue = 0;
            }
            if (txtGiaBan.EditValue == null)
            {
                txtGiaBan.EditValue = 0;
            }
            if (cbbThueVAT.EditValue==null)
            {
                cbbThueVAT.EditValue = 0;
            }
            if (strError!=string.Empty)
            {
                MessageBox.Show(strError,"Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            return isError;
        }
        private void Save()
        {
            if (!KiemTraNhap())
            {
                return;
            }
            SanPham item = new SanPham();
            //---------thông tin chung---------------------
            item.TenSanPham = txtTenSanPham.Text.Trim();
            item.SLTonKho =Int32.Parse(txtSoLuong.EditValue.ToString());
            item.GiaVon = Int32.Parse(txtGiaVon.EditValue.ToString());
            item.GiaBan = Int32.Parse(txtGiaBan.EditValue.ToString());
            item.ChoXuatAm = chkChoXuatAm.Checked;
            if (treelistNhomHang.EditValue!=null)
            {
                item.NhomHangID = Int32.Parse(treelistNhomHang.EditValue.ToString());
                item.TenNhomHang = treelistNhomHang.Text;
            }
            else
            {
                item.NhomHangID = null;
                item.TenNhomHang = "Chưa chọn nhóm hàng";
            }


            if (lookupNSX.EditValue!=null)
            {
                item.NhaSanXuatID = Int32.Parse(lookupNSX.EditValue.ToString());
                item.TenNhaSanXuat = lookupNSX.Text;
            }
            else
            {
                item.NhaSanXuatID = null;
                item.TenNhaSanXuat = "Chưa chọn nhà sản xuất";
            }
                        
            item.ThuaVAT = Int32.Parse(cbbThueVAT.EditValue.ToString());
            // xử lý hình ảnh sản phẩm--------------------------------------
            if (imgHinhAnh.EditValue!=null)
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    imgHinhAnh.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] bytes = ms.ToArray();
                    item.HinhAnh = bytes;
                }
                //Image pic = Image.FromFile(imgHinhAnh);
                //DevExpress.XtraEditors.Controls.ByteImageConverter.ToByteArray()
                //item.HinhAnh =  imgHinhAnh.EditValue as byte[];
            }
            else
            {
                item.HinhAnh = null;
            }
            //-----------------------------------------------------------------
            //---Xử lý mã sản phẩm - trường hợp user tự tạo hoặc máy tính tạo tự động--------------
            if (!txtMaSanPham.Text.Equals(string.Empty)) // người dùng tự nhập
            {
                item.SanPhamID = txtMaSanPham.Text.Trim();
            }
            else //máy tính phải tự tạo ra.....
            {
                item.SanPhamID = SanPhamController.TaoMaSanPham("SP", 8);
            }

            if ((!formMode.ToUpper().Equals("EDIT"))&&(SanPhamController.IsExitsItem(item.SanPhamID)))
            {
                MessageBox.Show("Mã sản phẩm này đã tồn tại, vui lòng nhập mã khác","Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }


            // thông tin bao mật
            item.NguoiDungID = Utility.NguoiSuDung.NguoiDungID;
            item.TenNguoiDung = Utility.NguoiSuDung.TenNguoiDung;
            item.LastUpdate = DateTime.Now;
            //------------------------------------------------
            if (formMode.ToUpper().Equals("EDIT"))
            {
                SanPhamController.Edit(item);
                formMode = string.Empty;
            }
            else //trường hợp copy hoặc add sản phẩm mới
            {
                SanPhamController.Add(item);
            }            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }

        private void lookupNSX_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption.ToUpper().Equals("ADD"))
            {
                frmAddNhaSanXuat f = new frmAddNhaSanXuat();
                f.ShowDialog(this);
                int intNhaSanXuatID = f.intNhaSanXuatID; //lay ma nha san xuat ma nguoi dung moi them vo
                f.Dispose();
                lookupNSX.Properties.DataSource = NhaSanXuatController.GetList();
                if (intNhaSanXuatID>-1)
                {
                    lookupNSX.EditValue = intNhaSanXuatID;
                }
            }
        }

        private void imgHinhAnh_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog opf = new OpenFileDialog())
            {
                imgHinhAnh.LoadImage();
                //opf.Filter="JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
                //if (opf.ShowDialog()== System.Windows.Forms.DialogResult.OK)
                //{
                //    imgHinhAnh.LoadImage();
                //}
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Save();
            if (checkEdit1.Checked==false)
            {
                txtTenSanPham.Text = string.Empty;
                txtGiaBan.EditValue = 0;
                txtGiaVon.EditValue = 0;
                txtSoLuong.EditValue = 0;
                chkChoXuatAm.Checked = true;
                chkNgungKinhDoanh.Checked = false;
                lookupNSX.EditValue = null;
                treelistNhomHang.EditValue = null;                
                cbbThueVAT.EditValue = 0;                
            }
            txtMaSanPham.Text = string.Empty;
            txtSoLuong.Properties.ReadOnly = false;
            txtMaSanPham.Properties.ReadOnly = false;
            formMode = string.Empty;
            itemCopy = null;
            txtTenSanPham.Focus();
            txtTenSanPham.SelectAll();
        }
    }
}
