using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace QuanLyBanHangVan
{
    class ketnoi
    {
        public static string strcn = @"Data Source=G8276IJGE6YVPL9;Initial Catalog=VanCui;Integrated Security=True";
        SqlCommand sqlcom;
        SqlDataReader sqldr;
        SqlConnection con;
        public static SqlConnection conn = null;

        public SqlConnection taoketnoi()
        {
            con = new SqlConnection(@" Data Source=G8276IJGE6YVPL9;Initial Catalog=VanCui;Integrated Security=True  ");
            return con;
        }

        public static void dataOpen()
        {
            try
            {
                string sqlquery = @" Data Source=G8276IJGE6YVPL9;Initial Catalog=VanCui;Integrated Security=True ";
                conn = new SqlConnection(sqlquery);
                conn.Open();
            }
            catch
            {
                MessageBox.Show("Ket noi that bai");
            }
        }
        public static SqlConnection cnn = new SqlConnection(@" Data Source=G8276IJGE6YVPL9;Initial Catalog=VanCui;Integrated Security=True   ");
        public static DataTable hienthi(string sqlquery)
        {
            SqlCommand cmd = new SqlCommand(sqlquery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public static void LoadDataGridView(DataGridView DGV, string query)
        {
            SqlConnection cn = new SqlConnection(ketnoi.strcn);
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
            SqlConnection cn = new SqlConnection(ketnoi.strcn);
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

        public DataTable taobang(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter(sql, cnn);
            ds.Fill(dt);
            return (dt);
        }
        public static void dataClose()
        {
            try
            {
                string sqlquery = @" Data Source=G8276IJGE6YVPL9;Initial Catalog=VanCui;Integrated Security=True";
                conn = new SqlConnection(sqlquery);
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Khong the ket noi");
            }
        }

        public DataTable hienthicb(string sqlquery)
        {
            SqlCommand cmd = new SqlCommand(sqlquery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public static void Combobox1(ComboBox Combobox, string tenhienthi, string MaTrinhDo, string table)
        {
            string sqlquery = "select " + MaTrinhDo + "," + tenhienthi + " from " + table; SqlCommand cmd = new SqlCommand(sqlquery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd); DataTable dt = new DataTable(); Combobox.DataSource = dt;
            Combobox.DisplayMember = MaTrinhDo; Combobox.ValueMember = tenhienthi;
        }
        public static void ComboBox2(ComboBox combobox, string tenhienthi, string table)
        {
            string sqlquery = "select" + tenhienthi + " from " + table; SqlCommand cmd = new SqlCommand(sqlquery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            combobox.DataSource = dt;
            combobox.DisplayMember = tenhienthi;
            combobox.ValueMember = tenhienthi;
        }
        public string LoadLable(string sql)
        {
            string ketqua = "";
            con = taoketnoi();
            con.Open();
            sqlcom = new SqlCommand(sql, con);
            sqldr = sqlcom.ExecuteReader();
            while (sqldr.Read())
            {
                ketqua = sqldr[0].ToString();
            }
            con.Close();
            return ketqua;
        }
        private SqlDataAdapter dataAp;
        private DataTable dataTable;
        public DataTable GetDataTable(string sql)
        {
            // Tạo dataApdapter, thực hiện câu lệnh query
            dataAp = new SqlDataAdapter(sql, conn);
            // Đổ dữ liệu vào DataTable
            dataTable = new DataTable();
            dataAp.Fill(dataTable);
            return dataTable;
        }

        public static string NextID(string lastID, string prefixID)
        {
            int nextID = int.Parse(lastID.Remove(0, prefixID.Length)) + 1;
            int lengthNumerID = lastID.Length - prefixID.Length;
            string zeroNumber = "";
            for (int i = 1; i <= lengthNumerID; i++)
            {
                if (nextID < Math.Pow(10, i))
                {
                    for (int j = 1; j <= lengthNumerID - i; i++)
                    {
                        zeroNumber += "0";
                    }
                    return prefixID + zeroNumber + nextID.ToString();
                }
            }
            return prefixID + nextID;

        }
        public string GetLastID(string nameTable, string nameFiled)
        {
            string sql = "SELECT TOP 1 " + nameFiled + " FROM " + nameTable + " ORDER BY " + nameFiled + " DESC";
            // thực hiện câu truy vấn trên
            GetDataTable(sql);
            return dataTable.Rows[0][nameFiled].ToString();
        }
    }
}
