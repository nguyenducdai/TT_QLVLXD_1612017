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
    public partial class BC : Form
    {
        public BC()
        {
            InitializeComponent();
        }

        private void BC_Load(object sender, EventArgs e)
        {
            string sql = "select HoaDonBH.SoHD as [Số hóa đơn], HoaDonBH.NgayBan as [Ngày bán],HoaDonBH.MaK as [Mã khách hàng], KhachHang.TenK as [Tên khách hàng],HoaDonBH.MaNV as [Mã nhân viên], NhanVien.TenNV as [Tên nhân viên], HoaDonBH.DienGiai as [Diễn giải] from NhanVien, KhachHang, HoaDonBH  where HoaDonBH.MaK=KhachHang.MaK and NhanVien.MaNV=HoaDonBH.MaNV ";
            CrystalReport1 bc = new CrystalReport1();
            bc.SetDataSource(Program.ExecSqlQuery(sql));
            crystalReportViewer1.ReportSource = bc;
        }
    }
}
