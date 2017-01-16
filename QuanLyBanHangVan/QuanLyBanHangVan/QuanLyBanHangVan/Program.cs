using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace QuanLyBanHangVan
{
    static class Program
    {
        public static SqlConnection conn = new SqlConnection();
        public static SqlDataAdapter da;

        public static String connstr = @"Data Source=G8276IJGE6YVPL9;Initial Catalog=VanCui;Integrated Security=True";
     
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TKHangHoaTheoHoaHD());
        }
        
        public static DataTable ExecSqlQuery(String cmd)
        {
            DataTable dt1 = new DataTable();
            conn = new SqlConnection(connstr);
            da = new SqlDataAdapter(cmd, conn);
            da.Fill(dt1);
            return dt1;
        }
    }
}
    