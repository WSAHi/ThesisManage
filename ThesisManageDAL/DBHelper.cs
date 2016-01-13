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
        /// �������
        /// </summary>
        private static SqlConnection connection;
        /// <summary>
        /// �������ݿ�
        /// </summary>
        public static SqlConnection Connection
        {
            get
            {
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
        /// ִ��SQL���
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <returns>��Ӱ�������</returns>
        public static int ExecuteCommand(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            int result = cmd.ExecuteNonQuery();
            return result;
        }
        /// <summary>
        /// ִ��SQL����һ��SqlDataReader
        /// </summary>
        /// <param name="safeSql">SQL���</param>
        /// <returns>����һ��SqlDataReader</returns>
        public static SqlDataReader GetReader(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        /// <summary>
        /// ִ��SQL����һ��DataSet
        /// </summary>
        /// <param name="safeSql">SQL���</param>
        /// <returns>����һ��DataSet</returns>
        public static DataTable GetDataSet(string safeSql)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }
    }
}
