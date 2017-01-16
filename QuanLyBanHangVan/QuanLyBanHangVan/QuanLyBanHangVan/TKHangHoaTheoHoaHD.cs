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
    public partial class TKHangHoaTheoHoaHD : Form
    {
        public TKHangHoaTheoHoaHD()
        {
            InitializeComponent();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
             if (txtMaTD.Text != "")
            {
                cautruc.LoadDataGridView(dataGridViewX1, "select * from ChiTietHoaDon where SoHD like N'%" + txtMaTD.Text + "%'");
            }
           
                
                else
                {
                    MessageBox.Show("Không tìm thấy bản ghi nào");
                    return;
                }
        }
    }
}
