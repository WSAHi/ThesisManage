using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace ThesisManage.DAL
{
    public static class DBHelper
    {
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
        /// �����ݿ�ִ�е�һ��TSQL����洢����
        /// </summary>
        /// <param name="sql">Ҫִ�е�SQL�����ߴ洢����</param>
        /// <returns>����ִ�н��</returns>
        public static int ExecuteCommand(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            int result = cmd.ExecuteNonQuery();
            return result;
        }
        /// <summary>
        /// �����ݿ�ִ�е�һ��TSQL����洢����
        /// </summary>
        /// <param name="sql">Ҫִ�е�SQL�����ߴ洢����</param>
        /// <returns>����һ��SqlDataReader</returns>
        public static SqlDataReader GetReader(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        /// <summary>
        /// �����ݿ�ִ�е�һ��TSQL����洢����
        /// </summary>
        /// <param name="sql">Ҫִ�е�SQL�����ߴ洢����</param>
        /// <returns>����һ��DataSet</returns>
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
