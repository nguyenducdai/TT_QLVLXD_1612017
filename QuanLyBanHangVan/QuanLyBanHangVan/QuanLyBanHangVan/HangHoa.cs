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
    public partial class HangHoa : Form
    {
        public HangHoa()
        {
            InitializeComponent();
        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             int t = dataGridViewX1.CurrentCell.RowIndex;

            txtmancc.Text = dataGridViewX1.Rows[t].Cells[0].Value.ToString().Trim();
            txttenncc.Text = dataGridViewX1.Rows[t].Cells[1].Value.ToString().Trim();
            txtdiachi.Text = dataGridViewX1.Rows[t].Cells[2].Value.ToString().Trim();
           dateTimePicker1.Text = dataGridViewX1.Rows[t].Cells[3].Value.ToString().Trim();
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
                    string sqlquery = @"DELETE from HangHoa where maH ='" + txtmancc.Text.Trim() + "'";
                    SqlCommand cmd = new SqlCommand(sqlquery, ketnoi.conn);
                    cmd.ExecuteNonQuery();
                    dataGridViewX1.DataSource = ketnoi.hienthi(@"Select * from HangHoa");
                    ketnoi.dataClose();

                    {

                        txtdiachi.Clear();

                        txtmancc.Clear();
                        


                        txttenncc.Clear();
                        MessageBox.Show("Xóa thành công");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("loi:\r\n" + ex.Message.ToString());
                }
        }

        private void HangHoa_Load(object sender, EventArgs e)
        {
            ketnoi.dataOpen();
            dataGridViewX1.DataSource = ketnoi.hienthi(@" select *from HangHoa");
            ketnoi.dataClose();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show(" Bạn có muốn thoát không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Close();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
               try
            {
                ketnoi.dataOpen();
                string sqlquery = @"UPDATE HangHoa SET TenH=N'" + txttenncc.Text.Trim() + "',DVT=N'" + txtdiachi.Text.Trim() + "',Ngaysx='" +dateTimePicker1.Text.Trim() + "'where MaH='" + txtmancc.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sqlquery, ketnoi.conn);
                cmd.ExecuteNonQuery();
                dataGridViewX1.DataSource = ketnoi.hienthi("select * from HangHoa");
                ketnoi.dataClose();
                {

                    txtdiachi.Clear();

                    txtmancc.Clear();



                    txttenncc.Clear();
                }
                MessageBox.Show("Sửa thành công!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("loi:\r\n" + ex.Message.ToString());
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
             try
            {
                ketnoi.dataOpen();
                string sqlquery = @"INSERT INTO HangHoa VALUES(N'" + txtmancc.Text.Trim() + "',N'" + txttenncc.Text.Trim() + "',N'" + txtdiachi.Text.Trim() + "','" +dateTimePicker1.Text.Trim() + "')";
                SqlCommand cmd = new SqlCommand(sqlquery, ketnoi.conn);
                cmd.ExecuteNonQuery();
                dataGridViewX1.DataSource = ketnoi.hienthi(@"Select*from HangHoa");
                ketnoi.dataClose();
                {

                    txtdiachi.Clear();

                    txtmancc.Clear();



                    txttenncc.Clear();
                }
                MessageBox.Show("Thêm thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi:\r\n" + ex.Message.ToString());
            }
        }
        }
    }

