using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlertMan
{
    public class MysqlConn
    {
        static string strconn = ConfigurationManager.ConnectionStrings["strconn"].ToString().Trim();
        public static string TestConnect()
        {

            try
            {
                using (MySqlConnection conn = new MySqlConnection(strconn))
                {
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand();
                    comm.Connection = conn;
                    conn.Close();
                    conn.Dispose();
                }
                return "Connect Succesfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static DataTable Query_TBL(string sql)
        {
            DataTable dt = new DataTable("tmp");
            using (MySqlConnection conn = new MySqlConnection(strconn))
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand();
                comm.Connection = conn;
                comm.CommandText = sql;
                MySqlDataReader dr = comm.ExecuteReader();
                dt.Load(dr);
                conn.Close();
                conn.Dispose();
            }

            return dt;
        }
        public static object ExecuteScalar(string sql)
        {
            object obj;
            using (MySqlConnection conn = new MySqlConnection(strconn))
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand();
                comm.Connection = conn;
                comm.CommandText = sql;
                obj = comm.ExecuteScalar();
                conn.Close();
                conn.Dispose();
            }

            return obj;
        }
    }
}
