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
    public partial class Chitietphieunhap : Form
    {
        public Chitietphieunhap()
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
                string sqlquery = @"INSERT INTO ChiTietPhieuNhap VALUES(N'" + cbsopn.Text + "',N'" + cbmah.SelectedValue + "',N'" + txtsoluong.Text + "','" + txtdongia.Text + "',N'" + txtthanhtien.Text + "')";
                SqlCommand cmd = new SqlCommand(sqlquery, ketnoi.conn);
                cmd.ExecuteNonQuery();
                dataGridViewX1.DataSource = ketnoi.hienthi(@"Select*from ChiTietPhieuNhap");
                ketnoi.dataClose();
                {


                    cbmah.ResetText();
                    cbsopn.ResetText();
                    txtsoluong.Clear();

                    txtdongia.Clear();
                    txtthanhtien.Clear();

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
                string sqlquery = @"UPDATE ChiTietPhieuNhap SET SL=N'" + txtsoluong.Text + "',DonGia='" + txtdongia.Text + "',ThanhTien=N'" + txtthanhtien.Text + "'where SoPN='" + cbsopn.Text + "' and MaH= '" + cbmah.SelectedValue + "'";
                SqlCommand cmd = new SqlCommand(sqlquery, ketnoi.conn);
                cmd.ExecuteNonQuery();
                dataGridViewX1.DataSource = ketnoi.hienthi("select * from ChiTietPhieuNhap");
                ketnoi.dataClose();
                {


                    cbmah.ResetText();
                    cbsopn.ResetText();
                    txtsoluong.Clear();

                    txtdongia.Clear();
                    txtthanhtien.Clear();
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
                    string sqlquery = @"DELETE from ChiTietPhieuNhap where SoPN='" + cbsopn.Text + "' and MaH= '" + cbmah.SelectedValue + "'";
                    SqlCommand cmd = new SqlCommand(sqlquery, ketnoi.conn);
                    cmd.ExecuteNonQuery();
                    dataGridViewX1.DataSource = ketnoi.hienthi(@"Select * from ChiTietPhieuNhap");
                    ketnoi.dataClose();

                    {

                        cbmah.ResetText();
                        cbsopn.ResetText();
                        txtsoluong.Clear();

                        txtdongia.Clear();
                        txtthanhtien.Clear();
                        MessageBox.Show("Xóa thành công");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("loi:\r\n" + ex.Message.ToString());
                }
        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = dataGridViewX1.CurrentCell.RowIndex;

            cbsopn.Text = dataGridViewX1.Rows[t].Cells[0].Value.ToString().Trim();
            cbmah.Text = dataGridViewX1.Rows[t].Cells[1].Value.ToString().Trim();
            txtsoluong.Text = dataGridViewX1.Rows[t].Cells[2].Value.ToString().Trim();
            txtdongia.Text = dataGridViewX1.Rows[t].Cells[3].Value.ToString().Trim();
            txtthanhtien.Text = dataGridViewX1.Rows[t].Cells[4].Value.ToString().Trim();
        }
        ketnoi kn = new ketnoi();

        private void Chitietphieunhap_Load(object sender, EventArgs e)
        {
            ketnoi.dataOpen();
            dataGridViewX1.DataSource = ketnoi.hienthi(@" select *from ChiTietPhieuNhap");
            string s = " select * from PhieuNhap";
            cbsopn.DataSource = kn.hienthicb(s);
            cbsopn.DisplayMember = "SoPN";
            cbsopn.ValueMember = "SoPN";


            string c = " select * from HangHoa";
            cbmah.DataSource = kn.hienthicb(c);
            cbmah.DisplayMember = "TenH";
            cbmah.ValueMember = "MaH";
            ketnoi.dataClose();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            Double sl, dongia, thahtien;
            sl = Double.Parse(txtsoluong.Text);
            dongia = Double.Parse(txtdongia.Text);
            thahtien = sl * dongia;
            txtthanhtien.Text = thahtien.ToString();
        }
    }
}
