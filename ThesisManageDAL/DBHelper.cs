using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace ThesisManage.DAL
{
    public static class DBHelper
    {
        private static SqlConnection connection;
        /// <summary>
        /// 连接数据库
        /// </summary>
        public static SqlConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OpenConter"].ToString());
                    connection.Open();
                }
                else if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                else if (connection.State == ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
        }
        /// <summary>
        /// 对数据库执行的一个TSQL语句或存储过程
        /// </summary>
        /// <param name="sql">要执行的SQL语句或者存储过程</param>
        /// <returns>返回执行结果</returns>
        public static int ExecuteCommand(string sql)
        {
            return new SqlCommand(sql, Connection).ExecuteNonQuery();
        }
        /// <summary>
        /// 对数据库执行的一个TSQL语句或存储过程
        /// </summary>
        /// <param name="sql">要执行的SQL语句或者存储过程</param>
        /// <returns>返回一个SqlDataReader</returns>
        public static SqlDataReader GetReader(string sql)
        {
            return new SqlCommand(sql, Connection).ExecuteReader();
        }
        /// <summary>
        /// 对数据库执行的一个TSQL语句或存储过程
        /// </summary>
        /// <param name="sql">要执行的SQL语句或者存储过程</param>
        /// <returns>返回一个DataSet</returns>
        public static DataTable GetDataSet(string sql)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, Connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }
    }
}
