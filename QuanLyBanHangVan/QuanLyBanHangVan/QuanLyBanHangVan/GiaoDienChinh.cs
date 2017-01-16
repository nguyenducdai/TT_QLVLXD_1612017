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
    public partial class GiaoDienChinh : Form
    {
        public GiaoDienChinh()
        {
            InitializeComponent();
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HangHoa a = new HangHoa();
            a.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhachHang a = new KhachHang();
            a.Show();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhaCungCap a = new NhaCungCap();
            a.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVien a = new NhanVien();
            a.Show();

        }

        private void tìmKiếmHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TKHangHoa a = new TKHangHoa();
            a.Show();
        }

        private void tìmKiếmHàngHóaTheoHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TKHangHoaTheoHoaHD a = new TKHangHoaTheoHoaHD();
            a.Show();

        }

        private void phiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhieuNhap a = new PhieuNhap();
            a.Show();
        }

        private void chiTiếtPhiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chitietphieunhap a = new Chitietphieunhap();
            a.Show();
        }

        private void phiếuXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhieuXuat a = new PhieuXuat();
            a.Show();
        }

        private void chiTiếtPhiếuXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChitietPhieuXuat a = new ChitietPhieuXuat();
            a.Show();
        }

        private void hóaĐơnBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDonBH a = new HoaDonBH();
            a.Show();
        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChitietHoaDon a = new ChitietHoaDon();
            a.Show();
        }

        private void báoCáoChiTiếtBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BCHiTiet a = new BCHiTiet();
            a.Show();
        }

        private void báoCáoTổngHợpBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BC a = new BC();
            a.Show();
        }
    }
}
