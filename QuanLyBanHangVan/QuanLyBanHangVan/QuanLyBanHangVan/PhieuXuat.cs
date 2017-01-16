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
    public partial class PhieuXuat : Form
    {
        public PhieuXuat()
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
                string sqlquery = @"INSERT INTO PhieuXuat VALUES(N'" + txtmancc.Text.Trim() + "',N'" + dateTimePicker1.Text + "',N'" + cbmancc.SelectedValue + "','" + cbmanv.SelectedValue + "',N'" + txtdiengia.Text + "')";
                SqlCommand cmd = new SqlCommand(sqlquery, ketnoi.conn);
                cmd.ExecuteNonQuery();
                dataGridViewX1.DataSource = ketnoi.hienthi(@"Select*from PhieuXuat");
                ketnoi.dataClose();
                {


                    txtmancc.Clear();
                    cbmanv.ResetText();
                    cbmancc.ResetText();


                    txtdiengia.Clear();
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
            dateTimePicker1.Text = dataGridViewX1.Rows[t].Cells[1].Value.ToString().Trim();
            cbmancc.Text = dataGridViewX1.Rows[t].Cells[2].Value.ToString().Trim();
            cbmanv.Text = dataGridViewX1.Rows[t].Cells[3].Value.ToString().Trim();
            txtdiengia.Text = dataGridViewX1.Rows[t].Cells[4].Value.ToString().Trim();
        }
        ketnoi kn = new ketnoi();
        private void PhieuXuat_Load(object sender, EventArgs e)
        {
            ketnoi.dataOpen();
            dataGridViewX1.DataSource = ketnoi.hienthi(@" select *from Phieuxuat");
            string s = " select * from KhachHang";
            cbmancc.DataSource = kn.hienthicb(s);
            cbmancc.DisplayMember = "TenK";
            cbmancc.ValueMember = "MaK";


            string c = " select * from nhanvien";
            cbmanv.DataSource = kn.hienthicb(c);
            cbmanv.DisplayMember = "TenNV";
            cbmanv.ValueMember = "MaNV";
            ketnoi.dataClose();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi.dataOpen();
                string sqlquery = @"UPDATE PhieuXuat SET NgayXuat=N'" + dateTimePicker1.Text + "',MaKH=N'" + cbmancc.SelectedValue + "',MaNV='" + cbmanv.SelectedValue + "',DienGiai=N'" + txtdiengia.Text + "'where SoPX='" + txtmancc.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sqlquery, ketnoi.conn);
                cmd.ExecuteNonQuery();
                dataGridViewX1.DataSource = ketnoi.hienthi("select * from PhieuXuat");
                ketnoi.dataClose();
                {

                    txtmancc.Clear();
                    cbmanv.ResetText();
                    cbmancc.ResetText();


                    txtdiengia.Clear();
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
                    string sqlquery = @"DELETE from PhieuXuat where SoPX ='" + txtmancc.Text.Trim() + "'";
                    SqlCommand cmd = new SqlCommand(sqlquery, ketnoi.conn);
                    cmd.ExecuteNonQuery();
                    dataGridViewX1.DataSource = ketnoi.hienthi(@"Select * from PhieuXuat");
                    ketnoi.dataClose();

                    {

                        txtmancc.Clear();
                        cbmanv.ResetText();
                        cbmancc.ResetText();


                        txtdiengia.Clear();
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
