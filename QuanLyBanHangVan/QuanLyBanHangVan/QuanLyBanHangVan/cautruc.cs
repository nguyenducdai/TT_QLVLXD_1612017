using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace QuanLyBanHangVan
{
    class cautruc
    {
        private static string strcn = @"Data Source=G8276IJGE6YVPL9;Initial Catalog=VanCui;Integrated Security=True";
        public static string sophieu = "";
        public static void ExecuteNonQuery(string str)
        {
            SqlConnection cn = new SqlConnection(strcn);
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(str, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Có lỗi xảy ra");
            }
            finally
            {
                cn.Close();
            }
        }

        public static DataSet DoDuLieu(string select)
        {
            SqlConnection cn = new SqlConnection(strcn);
            SqlDataAdapter da = new SqlDataAdapter(select, cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public static DataTable GetTable(string select)
        {
            SqlConnection cn = new SqlConnection(strcn);
            SqlDataAdapter da = new SqlDataAdapter(select, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return (dt);
        }
        public static bool Kiemtra(string tendangnhap, string matkhau)
        {
            SqlConnection cn = new SqlConnection(strcn);
            SqlCommand cm = new SqlCommand("select * from TaiKhoan where MANV='" + tendangnhap + "' and MatKhau='" + matkhau + "'", cn);
            cn.Open();
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read())
            {
                cn.Close();
                return true;
            }
            else
            {
                cn.Close();
                return false;
            }
        }

        public void LoadComboBox(ComboBox cb, string query, string cotGiatri, string cotHienthi)//cot gia tri la ma,cot hien thi la ten
        {
            SqlConnection con = new SqlConnection(cautruc.strcn);
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "Bang");
                DataTable dt = ds.Tables["Bang"];
                cb.DataSource = dt;
                cb.SelectedIndex = 0;
                cb.DisplayMember = cotHienthi.Trim();
                cb.ValueMember = cotGiatri.Trim();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Có lỗi xảy ra");
            }
            finally
            {
                con.Close();
            }


        }

        public static void LoadDataGridView(DataGridView DGV, string query)
        {
            SqlConnection cn = new SqlConnection(cautruc.strcn);
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataSet ds = new DataSet();
                da.Fill(ds, "BANG");
                DGV.DataSource = ds.Tables["BANG"];
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Có lỗi xảy ra");
            }
            finally
            {
                cn.Close();
            }
        }

        public static void timkiem(DataGridView dtg, string sql)
        {
            SqlConnection cn = new SqlConnection(cautruc.strcn);
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                dtg.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Có lỗi xảy ra");
            }
            finally
            {
                cn.Close();
            }
        }

        public static void LayDuLieuCombox(ComboBox cmb, string sql, string TruongHienThi, string GiaTriAN)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cautruc.strcn);
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = TruongHienThi;
                cmb.ValueMember = GiaTriAN;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Có lỗi xảy ra");
            }

        }

        public static void LayDuLieu2Combox(ComboBox cmb1, ComboBox cmb2, string sql, string TruongHienThi1, string TruongHienThi2, string GiaTriAN)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cautruc.strcn);
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmb1.DataSource = ds.Tables[0];
                cmb2.DataSource = ds.Tables[0];
                cmb1.DisplayMember = TruongHienThi1;
                cmb2.DisplayMember = TruongHienThi2;
                cmb1.ValueMember = GiaTriAN;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Có lỗi xảy ra");
            }

        }
        public static string GetString(string select)
        {
            string _temp = "";
            try
            {
                SqlConnection cn = new SqlConnection(strcn);
                SqlCommand cmd = new SqlCommand(select, cn);
                cn.Open();
                _temp = Convert.ToString(cmd.ExecuteScalar());
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Có lỗi xảy ra");
            }
            return (_temp);
        }
    }
}
