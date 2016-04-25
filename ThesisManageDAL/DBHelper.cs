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
        /// �������ݿ�
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
        /// �����ݿ�ִ�е�һ��TSQL����洢����
        /// </summary>
        /// <param name="sql">Ҫִ�е�SQL�����ߴ洢����</param>
        /// <returns>����ִ�н��</returns>
        public static int ExecuteCommand(string sql)
        {
            return new SqlCommand(sql, Connection).ExecuteNonQuery();
        }
        /// <summary>
        /// �����ݿ�ִ�е�һ��TSQL����洢����
        /// </summary>
        /// <param name="sql">Ҫִ�е�SQL�����ߴ洢����</param>
        /// <returns>����һ��SqlDataReader</returns>
        public static SqlDataReader GetReader(string sql)
        {
            return new SqlCommand(sql, Connection).ExecuteReader();
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
