﻿using System;
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
        /// 添加论文
        /// </summary>
        /// <param name="thesis"></param>
        /// <returns></returns>
        public int InsertThesis(Thesis thesis)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = DBHelper.Connection;
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO Thesis(StudentID,TitleID,PublishDate,Contents) VALUES (@StudentID,@TitleID,@PublishDate,@Contents)";
            SqlParameter StudentId = new SqlParameter("@StudentId", SqlDbType.Int);
            StudentId.Value = thesis.Student.SID;
            cmd.Parameters.Add(StudentId);
            SqlParameter TitleId = new SqlParameter("@TitleID", SqlDbType.Int);
            TitleId.Value = thesis.Title.TID;
            cmd.Parameters.Add(TitleId);
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
        public int GetCountsByStuId(int studentID)
        {
            Thesis thsis = new Thesis();
            string sql = string.Format("SELECT Contents FROM Thesis WHERE StudentID={0}", studentID);
            SqlDataReader reader = DBHelper.GetReader(sql);
            FileStream fs;
            BinaryWriter bw;
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
                fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
                bw = new BinaryWriter(fs);
                startIndex = 0;
                //将字节流读入outbyte缓冲区中并返回读取的字节数
                reval = reader.GetBytes(0, startIndex, outbyte, 0, buffersize);
                //当读取的字节流达到缓冲区允许的最大长度时要卸载缓冲区内的数据并将数据写入文件
                while (reval == buffersize)
                {
                    bw.Write(outbyte);
                    bw.Flush();
                    //重新设定开始读取的位置，并继续读取和写数据
                    startIndex += buffersize;
                    reval = reader.GetBytes(0, startIndex, outbyte, 0, buffersize);
                }
                //将缓冲区内最后剩余的数据写入文件
                bw.Write(outbyte, 0, (int)reval - 1);
                bw.Flush();
                bw.Close();
                fs.Close();

            }
            reader.Close();
            return num;
        }
        /// <summary>
        /// 记录论文相关信息
        /// </summary>
        /// <param name="thesis"></param>
        /// <returns></returns>
        public int UpdateThesisByStuId(Thesis thesis)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = DBHelper.Connection;
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE Thesis SET PublishDate=@PublishDate,Contents=@Contents where StudentID=@StudentID";
            SqlParameter StudentId = new SqlParameter("@StudentID", SqlDbType.Int);
            StudentId.Value = thesis.Student.SID;
            cmd.Parameters.Add(StudentId);
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
        /// 获取论文信息
        /// </summary>
        /// <param name="studentID">学生编号</param>
        /// <returns></returns>
        public Thesis GetThesisByStuId(int studentID)
        {
            int studentId = 0;
            int titleId = 0;
            Thesis thsis = new Thesis();
            StudentService studentService = new StudentService();

            string sql = string.Format("SELECT * FROM Thesis WHERE StudentID={0}", studentID);
            SqlDataReader reader = DBHelper.GetReader(sql);
            if (reader.Read())
            {
                thsis.ThesisID = Convert.ToInt32(reader["ThesisID"]);
                thsis.PublishDate = reader["PublishDate"].ToString();
                studentId = Convert.ToInt32(reader["StudentID"]);
                titleId = Convert.ToInt32(reader["TitleID"]);
                reader.Close();
                thsis.Student = studentService.GetStudentBySID(studentId);
                thsis.Title = titleService.GetTilteByTitleId(titleId);
            }
            reader.Close();
            return thsis;
        }
        /// <summary>
        /// 获取论文
        /// 标题是统一老师上传的
        /// </summary>
        /// <param name="teacherID">教师编号</param>
        /// <returns></returns>
        public List<Thesis> GetThesisWithOenTeacher(int teacherID)
        {
            int studentId = 0;
            int titleId = 0;

            string sql = string.Format("SELECT * FROM Thesis WHERE TitleID IN (SELECT TID FROM Title WHERE TeacherID={0})", teacherID);
            List<Thesis> list = new List<Thesis>();
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow rows in table.Rows)
            {
                Thesis thsis = new Thesis();
                thsis.ThesisID = Convert.ToInt32(rows["ThesisID"]);
                thsis.PublishDate = rows["PublishDate"].ToString();
                studentId = Convert.ToInt32(rows["StudentID"]);
                titleId = Convert.ToInt32(rows["TitleID"]);
                thsis.Student = studentService.GetStudentBySID(studentId);
                thsis.Title = titleService.GetTilteByTitleId(titleId);
                list.Add(thsis);
            }
            return list;
        }
        /// <summary>
        /// 获取论文相关信息
        /// </summary>
        /// <param name="thesisID">论文编号</param>
        /// <returns></returns>
        public Thesis GetThesisById(int thesisID)
        {
            int studentId = 0;
            int titleId = 0;
            Thesis thsis = new Thesis();
            StudentService studentService = new StudentService();

            string sql = string.Format("SELECT * FROM Thesis WHERE ThesisID={0}", thesisID);
            SqlDataReader reader = DBHelper.GetReader(sql);
            if (reader.Read())
            {
                thsis.ThesisID = Convert.ToInt32(reader["ThesisID"]);
                thsis.PublishDate = reader["PublishDate"].ToString();
                studentId = Convert.ToInt32(reader["StudentID"]);
                titleId = Convert.ToInt32(reader["TitleID"]);
                reader.Close();
                thsis.Student = studentService.GetStudentBySID(studentId);
                thsis.Title = titleService.GetTilteByTitleId(titleId);
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
        /// 删除论文
        /// </summary>
        /// <param name="studentID">学生编号</param>
        /// <returns></returns>
        public int DeleteThesisByStudentId(int studentID)
        {
            string sql = string.Format("DELETE Thesis WHERE StudentID={0}", studentID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
    }
}
