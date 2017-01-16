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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btdangnhap_Click(object sender, EventArgs e)
        {

            if (txtTendangnhap.Text.Trim() == "")
            {
                if (txtMatkhau.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn Chưa Nhập Tên Đăng Nhập Và Mật Khẩu", "Thông Báo");
                    txtTendangnhap.Focus();
                    return;
                }
                else
                {
                    MessageBox.Show("Bạn Chưa Nhập Tên Đăng Nhập", "Thông Báo");
                    txtTendangnhap.Focus();

                    return;
                }
            }
            else
            {
                if (txtMatkhau.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn Chưa Nhập Mật Khẩu", "Thông Báo");
                    txtMatkhau.Focus();
                    return;
                }
                else
                {
                    if (cautruc.Kiemtra(txtTendangnhap.Text.Trim(), txtMatkhau.Text.Trim()))
                    {
                        // Mainfrm.EnableMenu();
                        MessageBox.Show("Đăng Nhập Thành Công", "Thông Báo");
                        Hide();
                        GiaoDienChinh a = new GiaoDienChinh();

                        a.ShowDialog();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {

            DialogResult traloi;
            traloi = MessageBox.Show(" Bạn có muốn thoát không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Close();
        }
    }
}
