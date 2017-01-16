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
    public partial class TKHangHoa : Form
    {
        public TKHangHoa()
        {
            InitializeComponent();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {

            if (txtMaTD.Text != "")
            {
                cautruc.LoadDataGridView(dataGridViewX1, "select * from HangHoa where MaH like N'%" + txtMaTD.Text + "%'");
            }
            else
            {
                if (textBox1.Text != "")
                {
                    cautruc.LoadDataGridView(dataGridViewX1, "select* from HangHoa where TenH like N'%" + textBox1.Text + "%'");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bản ghi nào");
                    return;
                }
            }
        }
    }
}
