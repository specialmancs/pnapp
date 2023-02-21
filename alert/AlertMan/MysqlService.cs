using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlertMan
{
    public class MysqlService
    {
        public static DataTable read_alert()
        {
            string sql = "SELECT id, icd, users, read_status, create_date FROM tb_alert WHERE  read_status=0";
            DataTable dt =MysqlConn.Query_TBL(sql);
            return dt;
        }
        public static void update_status(string id)
        {
            string sql = "UPDATE tb_alert SET  read_status=1 WHERE id= "+id;
            MysqlConn.ExecuteScalar(sql);
        }
    }
}
