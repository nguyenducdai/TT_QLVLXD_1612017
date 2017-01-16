using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QuanLyBanHangVan
{
    public partial class NhaCungCap : Form
    {
        public NhaCungCap()
        {
            InitializeComponent();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {

            DialogResult traloi;
            traloi = MessageBox.Show(" Bạn có muốn thoát không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi.dataOpen();
                string sqlquery = @"INSERT INTO NhaCungCap VALUES(N'" + txtmancc.Text.Trim() + "',N'" + txttenncc.Text.Trim() + "',N'" + txtdiachi.Text.Trim() + "','" + txtsdt.Text.Trim() + "')";
                SqlCommand cmd = new SqlCommand(sqlquery, ketnoi.conn);
                cmd.ExecuteNonQuery();
                dataGridViewX1.DataSource = ketnoi.hienthi(@"Select*from NhaCungCap");
                ketnoi.dataClose();
                {

                    txtdiachi.Clear();

                    txtmancc.Clear();
                    txtsdt.Clear();


                    txttenncc.Clear();
                }
                MessageBox.Show("Thêm thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi:\r\n" + ex.Message.ToString());
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi.dataOpen();
                string sqlquery = @"UPDATE NhaCungCap SET tenncc=N'" + txttenncc.Text.Trim() + "',diachi=N'" + txtdiachi.Text.Trim() + "',SDT='" + txtsdt.Text.Trim() + "'where Mancc='" + txtmancc.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sqlquery, ketnoi.conn);
                cmd.ExecuteNonQuery();
                dataGridViewX1.DataSource = ketnoi.hienthi("select * from NhaCungCap");
                ketnoi.dataClose();
                {

                    txtdiachi.Clear();

                    txtmancc.Clear();
                    txtsdt.Clear();


                    txttenncc.Clear();
                }
                MessageBox.Show("Sửa thành công!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("loi:\r\n" + ex.Message.ToString());
            }
        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = dataGridViewX1.CurrentCell.RowIndex;

            txtmancc.Text = dataGridViewX1.Rows[t].Cells[0].Value.ToString().Trim();
            txttenncc.Text = dataGridViewX1.Rows[t].Cells[1].Value.ToString().Trim();
            txtdiachi.Text = dataGridViewX1.Rows[t].Cells[2].Value.ToString().Trim();
            txtsdt.Text = dataGridViewX1.Rows[t].Cells[3].Value.ToString().Trim();
        }

        private void NhaCungCap_Load(object sender, EventArgs e)
        {

            ketnoi.dataOpen();
            dataGridViewX1.DataSource = ketnoi.hienthi(@" select *from NhaCungCap");
            ketnoi.dataClose();
      
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {

            DialogResult traloi;
            traloi = MessageBox.Show(" Bạn có muốn xóa không ?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                try
                {
                    ketnoi.dataOpen();
                    string sqlquery = @"DELETE from NhaCungCap where mancc ='" + txtmancc.Text.Trim() + "'";
                    SqlCommand cmd = new SqlCommand(sqlquery, ketnoi.conn);
                    cmd.ExecuteNonQuery();
                    dataGridViewX1.DataSource = ketnoi.hienthi(@"Select * from NhaCungCap");
                    ketnoi.dataClose();

                    {

                        txtdiachi.Clear();

                        txtmancc.Clear();
                        txtsdt.Clear();


                        txttenncc.Clear();
                        MessageBox.Show("Xóa thành công");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("loi:\r\n" + ex.Message.ToString());
                }
        }
    }
}
