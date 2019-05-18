using DevExpress.XtraTreeList.Nodes;
using qlShop.models;
using System;
using System.Windows.Forms;
namespace qlShop
{
    public partial class frmAddNhomHang : Form
    {
        public frmAddNhomHang()
        {
            InitializeComponent();
        }

        public void KhoiTaoCotTreelist()
        {
            int i = 0;
            treeList1.Columns[i].Caption = "Nhóm hàng";
            treeList1.Columns[i].FieldName = "TenNhomHang";
            i++;
            treeList1.Columns[i].Caption = "";
            treeList1.Columns[i].FieldName = "NhomHangID";
            treeList1.Columns[i].Visible = false;
            i++;
            treeList1.Columns[i].Caption = "Cập nhật";
            treeList1.Columns[i].FieldName = "LastUpdate";

        }
        public void LayDanhSachNhomHang()
        {
            treeList1.DataSource= NhomHangController.Getlist();
            treeList1.KeyFieldName = "NhomHangID";
            treeList1.ParentFieldName = "NhomHangChaID";

            trlNhomHangCha.Properties.DataSource = NhomHangController.Getlist();
            trlNhomHangCha.Properties.DisplayMember = "TenNhomHang";
            trlNhomHangCha.Properties.ValueMember = "NhomHangID";
            trlNhomHangCha.Properties.TreeList.KeyFieldName = "NhomHangID";
            trlNhomHangCha.Properties.TreeList.ParentFieldName = "NhomHangChaID";

            //khong hien thi duong ke
            trlNhomHangCha.Properties.TreeList.OptionsView.ShowHorzLines = false;
            trlNhomHangCha.Properties.TreeList.OptionsView.ShowVertLines  = false;
            trlNhomHangCha.Properties.NullText = "chưa chọn nhóm hàng cha";
            trlNhomHangCha.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            //trlNhomHangCha.Text = "chưa chọn nhóm hàng";
        }

        private void frmAddNhomHang_Load(object sender, EventArgs e)
        {
            KhoiTaoCotTreelist();
            LayDanhSachNhomHang();
        }
        private void Save()
        {
            NhomHang item = new NhomHang();
            item.TenNhomHang = txtTenNhomHang.Text.Trim();
            if (trlNhomHangCha.EditValue!=null)
            {
                item.NhomHangChaID = Int32.Parse(trlNhomHangCha.EditValue.ToString());    
            }
            else
            {
                item.NhomHangChaID = null;
            }            
            item.NguoiDungID = Utility.NguoiSuDung.NguoiDungID;
            item.TenNguoiDung = Utility.NguoiSuDung.TenNguoiDung;
            item.LastUpdate = DateTime.Now;
            NhomHangController.Add(item);
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Save();
            //load lai danh sach nhom hang
            trlNhomHangCha.Properties.DataSource = NhomHangController.Getlist();
            treeList1.DataSource = NhomHangController.Getlist();
            treeList1.ExpandAll();
        }

        private void Treelist_btnDel_Click(object sender, EventArgs e)
        {
            TreeListNode nodeSelect = null;
            nodeSelect = treeList1.FocusedNode;
            if (nodeSelect!=null)
            {
                if (nodeSelect.Nodes.Count > 0)
                {
                    MessageBox.Show("Không xóa được nhóm này <Chỉ được xóa nhóm không có nhóm con>");
                }
                else
                {
                    if (MessageBox.Show("Bạn có muốn xóa nhóm hàng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        int intNhomHangID = Int32.Parse(nodeSelect["NhomHangID"].ToString());
                        NhomHangController.Del(intNhomHangID);
                        //load lai danh sach nhom hang
                        trlNhomHangCha.Properties.DataSource = NhomHangController.Getlist();
                        treeList1.DataSource = NhomHangController.Getlist();
                        treeList1.ExpandAll();
                    }                    
                }                                               
            }            
        }
    }
}
