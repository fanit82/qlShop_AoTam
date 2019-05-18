using qlShop.reports;
using System;
using System.Windows.Forms;
namespace qlShop
{
    public partial class frmTongHop : Form
    {
        public frmTongHop()
        {
            InitializeComponent();
        }
        private void KhoiTaoThangNam()
        {
            //khởi tạo tháng
            for (int i = 1; i <= 12; i++)
            {
                cbbThang.Properties.Items.Add(i.ToString());
            }            
            //khởi tạo năm
            int NamHienTai = DateTime.Now.Year;
            //int j = NamHienTai - 2;
            for (int j = NamHienTai - 2; j <= NamHienTai; j++)
            {
                cbbNam.Properties.Items.Add(j.ToString());
            }
            cbbThang.Text = DateTime.Now.Month.ToString();
            cbbNam.Text = DateTime.Now.Year.ToString();
            cbbNam.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cbbThang.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        }

        private void frmTongHop_Load(object sender, EventArgs e)
        {
            KhoiTaoThangNam();
        }
        private void LayBaoCao()
        {
            int intThang = Convert.ToInt32(cbbThang.Text);
            int intNam = Convert.ToInt32(cbbNam.Text);
            BaoCaoTongHop rpt = new BaoCaoTongHop();
            rpt.SetDataSource(reportsController.prtBaoCaoTongHop(intThang, intNam));
            DateTime dtThangTruoc = new DateTime(intNam, intThang, 1).AddMonths(-1);
            rpt.SetParameterValue("TieuDe1", string.Format("THÁNG TRƯỚC \r\n({0}/{1})", dtThangTruoc.Month, dtThangTruoc.Year));
            rpt.SetParameterValue("TieuDe2", string.Format("THÁNG NÀY\r\n({0}/{1})", intThang, intNam));
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            LayBaoCao();
        }
    }
}
