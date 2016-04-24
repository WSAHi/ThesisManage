using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ThesisManage.Model;
using System.IO;

namespace ThesisManage.DAL
{
    public class ThesisService
    {
        StudentService studentService = new StudentService();
        TitleService titleService = new TitleService();
        /// <summary>
        /// 插入论文相关信息
        /// </summary>
        /// <param name="thesis">论文信息</param>
        /// <returns></returns>
        public int InsertThesis(Thesis thesis)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = DBHelper.Connection;
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO Thesis(StudentID,TitleID,PublishDate,Contents) VALUES (@StudentID,@TitleID,@PublishDate,@Contents)";
            SqlParameter SID = new SqlParameter("@StudentID", SqlDbType.Int);
            SID.Value = thesis.Student.SID;
            cmd.Parameters.Add(SID);
            SqlParameter TID = new SqlParameter("@TitleID", SqlDbType.Int);
            TID.Value = thesis.Title.TID;
            cmd.Parameters.Add(TID);
            SqlParameter PublishDate = new SqlParameter("@PublishDate", SqlDbType.VarChar, 50);
            PublishDate.Value = thesis.PublishDate;
            cmd.Parameters.Add(PublishDate);
            //添加word文件
            SqlParameter Contents = new SqlParameter("@Contents", SqlDbType.Image);
            Contents.Value = thesis.Content;
            cmd.Parameters.Add(Contents);
            int num = cmd.ExecuteNonQuery();
            conn.Close();
            return num;
        }
        /// <summary>
        /// 更新论文相关信息
        /// </summary>
        /// <param name="thesis">论文信息</param>
        /// <returns></returns>
        public int UpdateThesisByStuID(Thesis thesis)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = DBHelper.Connection;
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE Thesis SET PublishDate=@PublishDate,Contents=@Contents where StudentID=@StudentID";
            SqlParameter SID = new SqlParameter("@StudentID", SqlDbType.Int);
            SID.Value = thesis.Student.SID;
            cmd.Parameters.Add(SID);
            SqlParameter PublishDate = new SqlParameter("@PublishDate", SqlDbType.VarChar, 50);
            PublishDate.Value = thesis.PublishDate;
            cmd.Parameters.Add(PublishDate);
            //添加word文件
            SqlParameter Contents = new SqlParameter("@Contents", SqlDbType.Image);//见本段最后注解
            Contents.Value = thesis.Content;
            cmd.Parameters.Add(Contents);
            int num = cmd.ExecuteNonQuery();
            conn.Close();
            return num;
        }
        /// <summary>
        /// 根据学生登录（学号）ID获取论文内容
        /// </summary>
        /// <param name="studentID">学生登录（学号）ID</param>
        /// <returns></returns>
        public int GetCountsByStuID(int studentID)
        {
            Thesis thsis = new Thesis();
            string sql = string.Format("SELECT Contents FROM Thesis WHERE StudentID={0}", studentID);
            SqlDataReader reader = DBHelper.GetReader(sql);
            FileStream fileStream;
            BinaryWriter binaryWriter;
            int num = 0;
            //设定允许读取到缓冲区的最大长度
            int buffersize = 1000;
            //要将字节流读入的缓冲区
            byte[] outbyte = new byte[buffersize];
            //用于记录已经读取的字节数
            long reval;
            //字段中的索引，从这里开始读取操作
            long startIndex;
            //FileStream对象将封装的文件的相对路径或绝对路径
            string filePath = @"ThesisManage\毕业论文.doc";
            while (reader.Read())
            {
                //outbyte = (byte[])reader["Contents"];
                num = 1;
                fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
                binaryWriter = new BinaryWriter(fileStream);
                startIndex = 0;
                //将字节流读入outbyte缓冲区中并返回读取的字节数
                reval = reader.GetBytes(0, startIndex, outbyte, 0, buffersize);
                //当读取的字节流达到缓冲区允许的最大长度时要卸载缓冲区内的数据并将数据写入文件
                while (reval == buffersize)
                {
                    binaryWriter.Write(outbyte);
                    binaryWriter.Flush();
                    //重新设定开始读取的位置，并继续读取和写数据
                    startIndex += buffersize;
                    reval = reader.GetBytes(0, startIndex, outbyte, 0, buffersize);
                }
                //将缓冲区内最后剩余的数据写入文件
                binaryWriter.Write(outbyte, 0, (int)reval - 1);
                binaryWriter.Flush();
                binaryWriter.Close();
                fileStream.Close();

            }
            reader.Close();
            return num;
        }
        /// <summary>
        /// 根据学生登录（学号）ID获取论文信息
        /// </summary>
        /// <param name="studentID">学生登录（学号）ID</param>
        /// <returns></returns>
        public Thesis GetThesisByStuID(int studentID)
        {
            int titleID = 0;
            Thesis thsis = new Thesis();
            StudentService studentService = new StudentService();

            string sql = string.Format("SELECT * FROM Thesis WHERE StudentID={0}", studentID);
            SqlDataReader reader = DBHelper.GetReader(sql);
            if (reader.Read())
            {
                thsis.ThesisID = Convert.ToInt32(reader["ThesisID"]);
                thsis.PublishDate = reader["PublishDate"].ToString();
                studentID = Convert.ToInt32(reader["StudentID"]);
                titleID = Convert.ToInt32(reader["TitleID"]);
                reader.Close();
                thsis.Student = studentService.GetStudentBySID(studentID);
                thsis.Title = titleService.GetTilteByTitleID(titleID);
            }
            reader.Close();
            return thsis;
        }
        /// <summary>
        /// 根据某教师上传的题目ID获取与该题目有关的论文信息
        /// </summary>
        /// <param name="teacherID">教师登录（工号）ID</param>
        /// <returns></returns>
        public List<Thesis> GetThesisWithTeacher(int teacherID)
        {
            int studentID = 0;
            int titleID = 0;
            string sql = string.Format("SELECT * FROM Thesis WHERE TitleID IN (SELECT TID FROM Title WHERE TeacherID={0})", teacherID);
            List<Thesis> list = new List<Thesis>();
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow rows in table.Rows)
            {
                Thesis thsis = new Thesis();
                thsis.ThesisID = Convert.ToInt32(rows["ThesisID"]);
                thsis.PublishDate = rows["PublishDate"].ToString();
                studentID = Convert.ToInt32(rows["StudentID"]);
                titleID = Convert.ToInt32(rows["TitleID"]);
                thsis.Student = studentService.GetStudentBySID(studentID);
                thsis.Title = titleService.GetTilteByTitleID(titleID);
                list.Add(thsis);
            }
            return list;
        }
        /// <summary>
        /// 根据论文ID获取论文的相关信息
        /// </summary>
        /// <param name="thesisID">论文ID</param>
        /// <returns></returns>
        public Thesis GetThesisById(int thesisID)
        {
            int studentID = 0;
            int titleID = 0;
            Thesis thsis = new Thesis();
            StudentService studentService = new StudentService();

            string sql = string.Format("SELECT * FROM Thesis WHERE ThesisID={0}", thesisID);
            SqlDataReader reader = DBHelper.GetReader(sql);
            if (reader.Read())
            {
                thsis.ThesisID = Convert.ToInt32(reader["ThesisID"]);
                thsis.PublishDate = reader["PublishDate"].ToString();
                studentID = Convert.ToInt32(reader["StudentID"]);
                titleID = Convert.ToInt32(reader["TitleID"]);
                reader.Close();
                thsis.Student = studentService.GetStudentBySID(studentID);
                thsis.Title = titleService.GetTilteByTitleID(titleID);
            }
            reader.Close();
            return thsis;
        }
        /// <summary>
        /// 获取论文数量
        /// </summary>
        /// <returns></returns>
        public int GetThesisCount()
        {
            string sql = string.Format("SELECT num=COUNT(*) FROM Thesis");
            SqlDataReader reader = DBHelper.GetReader(sql);
            int num = 0;
            if (reader.Read())
            {
                num = Convert.ToInt32(reader["num"]);
            }
            reader.Close();
            return num;
        }
        /// <summary>
        /// 根据学生登录（学号）ID删除论文信息
        /// </summary>
        /// <param name="studentID">学生登录（学号）ID</param>
        /// <returns></returns>
        public int DeleteThesisByStudentID(int studentID)
        {
            string sql = string.Format("DELETE Thesis WHERE StudentID={0}", studentID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
    }
}
