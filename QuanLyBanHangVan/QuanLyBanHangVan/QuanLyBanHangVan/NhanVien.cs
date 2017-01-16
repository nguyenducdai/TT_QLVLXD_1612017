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
    public partial class NhanVien : Form
    {
        public NhanVien()
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
                string sqlquery = @"INSERT INTO NhanVien VALUES(N'" + txtmancc.Text.Trim() + "',N'" + txttenncc.Text.Trim() + "',N'" + txtdiachi.Text.Trim() + "','" + dateTimePicker1.Text + "',N'" + txtchucvu.Text + "',N'" +comboBox1.Text + "')";
                SqlCommand cmd = new SqlCommand(sqlquery, ketnoi.conn);
                cmd.ExecuteNonQuery();
                dataGridViewX1.DataSource = ketnoi.hienthi(@"Select*from NhanVien");
                ketnoi.dataClose();
                {
                    txtdiachi.Clear();

                    txtmancc.Clear();
                    txtchucvu.Clear();
                    comboBox1.ResetText();

                    txttenncc.Clear();
                }
                MessageBox.Show("Thêm thành công!");
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
            dateTimePicker1.Text = dataGridViewX1.Rows[t].Cells[3].Value.ToString().Trim();
            txtchucvu.Text = dataGridViewX1.Rows[t].Cells[4].Value.ToString().Trim();
           comboBox1.Text = dataGridViewX1.Rows[t].Cells[5].Value.ToString().Trim();

        }

        private void NhanVien_Load(object sender, EventArgs e)
        {

            ketnoi.dataOpen();
            dataGridViewX1.DataSource = ketnoi.hienthi(@" select *from NhanVien");
            ketnoi.dataClose();
    
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi.dataOpen();
                string sqlquery = @"UPDATE NhanVien SET tenNV=N'" + txttenncc.Text.Trim() + "',diachi=N'" + txtdiachi.Text.Trim() + "',NgaySinh='" + dateTimePicker1.Text + "',ChucVu=N'" + txtchucvu.Text + "',GioiTinh=N'" + comboBox1.Text + "'where MaNV='" + txtmancc.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sqlquery, ketnoi.conn);
                cmd.ExecuteNonQuery();
                dataGridViewX1.DataSource = ketnoi.hienthi("select * from NhanVien");
                ketnoi.dataClose();
                {

                    txtdiachi.Clear();

                    txtmancc.Clear();
                    txtchucvu.Clear();
                    comboBox1.ResetText();

                    txttenncc.Clear();
                }
                MessageBox.Show("Sửa thành công!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("loi:\r\n" + ex.Message.ToString());
            }
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
                    string sqlquery = @"DELETE from NhanVien where maNV ='" + txtmancc.Text.Trim() + "'";
                    SqlCommand cmd = new SqlCommand(sqlquery, ketnoi.conn);
                    cmd.ExecuteNonQuery();
                    dataGridViewX1.DataSource = ketnoi.hienthi(@"Select * from NhanVien");
                    ketnoi.dataClose();

                    {

                        txtdiachi.Clear();

                        txtmancc.Clear();
                        txtchucvu.Clear();
                        comboBox1.ResetText();

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
