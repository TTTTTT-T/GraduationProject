using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    class DBHelper
    {
        //数据库连接字符串
        private static string sqlcon = "server=.;database=UserMessageSystem;uid=sa;pwd=sa";
       
        //定义数据库连接对象
        private static SqlConnection con = new SqlConnection(sqlcon);
        /// <summary>
        /// 初始化数据库连接
        /// </summary>
        private static  void Init() {
            if(con.State == ConnectionState.Closed){
                con.Open();
            }
            else if (con.State == ConnectionState.Broken) {
                con.Close();
                con.Open();
            }
        }
        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql) {
            Init();
            SqlDataAdapter sda = new SqlDataAdapter(sql,con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            return dt;
        }

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool Edit(string sql) {
            Init();
            SqlCommand com = new SqlCommand(sql, con);
            int number = com.ExecuteNonQuery();
            con.Close();
            return number > 0;
        }
    }
}
