using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanHangVan
{
    public partial class BCHiTiet : Form
    {
        public BCHiTiet()
        {
            InitializeComponent();
        }

        private void BCHiTiet_Load(object sender, EventArgs e)
        {
            string sql = "select ChiTietHoaDon.SoHD as [Số hóa đơn], ChiTietHoaDon.MaH as [Mã hàng hóa], HangHoa.TenH as [Tên hàng hóa], ChiTietHoaDon.SL as [Số lượng], ChiTietHoaDon.DonGia as [Đơn giá], ChiTietHoaDon.ThanhTien as [Thành tiền] from HangHoa, ChiTietHoaDon where ChiTietHoaDon.MaH=HangHoa.MaH ";
            CrystalReport3 bc = new CrystalReport3();
            bc.SetDataSource(Program.ExecSqlQuery(sql));
            crystalReportViewer1.ReportSource = bc;
        }
    }
}
