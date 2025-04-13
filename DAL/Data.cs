using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Data

    {
        // Kết nối CSDL
        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection("Server = 192.168.1.4, 1433; Database = QL_Nhac; User Id = sa; Password = YourStrongPassword123!; TrustServerCertificate = True;");
        }

        public DataTable GetTable(string sql)
        {
            SqlConnection conn = GetSqlConnection();
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql,conn);
            adapter.Fill(dt);
            conn.Dispose();
            return dt;
        }

        public void excuteNonquery(string sql)
        {
            SqlConnection conn = GetSqlConnection();
            conn.Open();
            SqlCommand cm = new SqlCommand(sql, conn);
            cm.ExecuteNonQuery();
            conn.Dispose();
            conn.Close();
        }
    }
}
