using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace ThesisManage.DAL
{
    public static class DBHelper
    {
        /// <summary>
        /// 定义变量
        /// </summary>
        private static SqlConnection connection;
        /// <summary>
        /// 连接数据库
        /// </summary>
        public static SqlConnection Connection
        {
            get
            {
                //string connectionString = "Data Source=.\\Sqlexpress;Initial Catalog=ThesisManage; Integrated Security=True";//uid=sa;Password=sa";
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["OpenConter"].ToString();
                if (connection == null)
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
        }
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="safeSql">SQL语句</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteCommand(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            int result = cmd.ExecuteNonQuery();
            return result;
        }
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="values"></param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteCommand(string sql, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            return cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="safeSql">SQL语句</param>
        /// <returns>返回的结果集中的第一行的第一列。忽略其他行列</returns>
        public static int GetScalar(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }
        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="values"></param>
        /// <returns>返回的结果集中的第一行的第一列。忽略其他行列</returns>
        public static int GetScalar(params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection;
            cmd.CommandText = "Pro_InsertOrder";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(values);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }
        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="values"></param>
        /// <returns>返回的结果集中的第一行的第一列。忽略其他行列</returns>
        public static int GetScalar(string sql, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }
        /// <summary>
        /// 执行SQL返回一个SqlDataReader
        /// </summary>
        /// <param name="safeSql">SQL语句</param>
        /// <returns>返回一个SqlDataReader</returns>
        public static SqlDataReader GetReader(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        /// <summary>
        /// 执行SQL返回一个SqlDataReader
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="values"></param>
        /// <returns>返回一个SqlDataReader</returns>
        public static SqlDataReader GetReader(string sql, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        /// <summary>
        /// 执行SQL返回一个DataSet
        /// </summary>
        /// <param name="safeSql">SQL语句</param>
        /// <returns>返回一个DataSet</returns>
        public static DataTable GetDataSet(string safeSql)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }
        /// <summary>
        /// 执行SQL返回一个DataSet
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="values"></param>
        /// <returns>返回一个DataSet</returns>
        public static DataTable GetDataSet(string sql, params SqlParameter[] values)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }
    }
}
