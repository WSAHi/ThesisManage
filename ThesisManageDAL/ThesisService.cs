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
        public int InsertThesis(Thesis thesis)
        {
            SqlCommand cmd=new SqlCommand();
            SqlConnection conn = DBHelper.Connection;
            cmd.Connection = conn;
              cmd.CommandText="insert into Thesis(StudentId,TitleId,PublishDate,Contents) values(@StudentId,@TitleId,@PublishDate,@Contents)";
              SqlParameter StudentId=new SqlParameter("@StudentId",System.Data.SqlDbType.Int);
              StudentId.Value=thesis.Student.SID;
              cmd.Parameters.Add(StudentId);
              SqlParameter TitleId=new SqlParameter("@TitleId",System.Data.SqlDbType.Int);
              TitleId.Value=thesis.Title.TID;
              cmd.Parameters.Add(TitleId);
             SqlParameter PublishDate=new SqlParameter("@PublishDate",System.Data.SqlDbType.VarChar,50);
              PublishDate.Value=thesis.PublishDate;
              cmd.Parameters.Add(PublishDate);
               //添加word文件
              SqlParameter Contents=new SqlParameter("@Contents",System.Data.SqlDbType.Image);//见本段最后注解
              Contents.Value=thesis.Content;
              cmd.Parameters.Add(Contents);
              int num=cmd.ExecuteNonQuery();
              conn.Close();
            return num;
        }
        public int GetCountsByStuId(int stuId)
        {
            Thesis thsis = new Thesis();
            string sql = string.Format("select Contents from Thesis where StudentId={0}", stuId);
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
        public int UpdateThesisByStuId(Thesis thesis)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = DBHelper.Connection;
            cmd.Connection = conn;
            cmd.CommandText = "update Thesis set PublishDate=@PublishDate,Contents=@Contents where StudentId=@StudentId";
            SqlParameter StudentId = new SqlParameter("@StudentId", System.Data.SqlDbType.Int);
            StudentId.Value = thesis.Student.SID;
            cmd.Parameters.Add(StudentId);
            SqlParameter PublishDate = new SqlParameter("@PublishDate", System.Data.SqlDbType.VarChar, 50);
            PublishDate.Value = thesis.PublishDate;
            cmd.Parameters.Add(PublishDate);
            //添加word文件
            SqlParameter Contents = new SqlParameter("@Contents", System.Data.SqlDbType.Image);//见本段最后注解
            Contents.Value = thesis.Content;
            cmd.Parameters.Add(Contents);
            int num = cmd.ExecuteNonQuery();
            conn.Close();
            return num;
        }
        public Thesis GetThesisByStuId(int stuId)
        {
            int studentId = 0;
            int titleId = 0;
            Thesis thsis = new Thesis();
            StudentService studentService = new StudentService();
           
            string sql = string.Format("select * from Thesis where StudentId={0}", stuId);
            SqlDataReader reader = DBHelper.GetReader(sql);
            if (reader.Read())
            {
                thsis.ThesisID =Convert.ToInt32(reader["ThesisID"]);
                thsis.PublishDate = reader["PublishDate"].ToString();
                studentId =Convert.ToInt32(reader["StudentId"]);
                titleId = Convert.ToInt32(reader["TitleId"]);
                reader.Close();
               thsis.Student=studentService.GetStudentBySID(studentId);
               thsis.Title = titleService.GetTilteByTitleId(titleId);
            }
            reader.Close();
            return thsis;
        }
        //获取论文，标题是统一老师上传的
        public List<Thesis> GetThesisWithOenTeacher(int TEID)
        {
            int studentId = 0;
            int titleId = 0;

            string sql = string.Format("select * from thesis where titleid in (select tid from title where teacherid={0})", TEID);
            List<Thesis> list = new List<Thesis>();
             DataTable table = DBHelper.GetDataSet(sql);
             foreach (DataRow rows in table.Rows)
             {
                 Thesis thsis = new Thesis();
                 thsis.ThesisID = Convert.ToInt32(rows["ThesisID"]);
                 thsis.PublishDate = rows["PublishDate"].ToString();
                 studentId = Convert.ToInt32(rows["StudentId"]);
                 titleId = Convert.ToInt32(rows["TitleId"]);
                 thsis.Student = studentService.GetStudentBySID(studentId);
                 thsis.Title = titleService.GetTilteByTitleId(titleId);
                 list.Add(thsis);
             }
             return list;
        }
        public Thesis GetThesisById(int id)
        {
            int studentId = 0;
            int titleId = 0;
            Thesis thsis = new Thesis();
            StudentService studentService = new StudentService();

            string sql = string.Format("select * from Thesis where ThesisID={0}", id);
            SqlDataReader reader = DBHelper.GetReader(sql);
            if (reader.Read())
            {
                thsis.ThesisID = Convert.ToInt32(reader["ThesisID"]);
                thsis.PublishDate = reader["PublishDate"].ToString();
                studentId = Convert.ToInt32(reader["StudentId"]);
                titleId = Convert.ToInt32(reader["TitleId"]);
                reader.Close();
                thsis.Student = studentService.GetStudentBySID(studentId);
                thsis.Title = titleService.GetTilteByTitleId(titleId);
            }
            reader.Close();
            return thsis;
        }
        public int GetThesisCount()
        {
            string sql = string.Format("select num=count(*) from Thesis");
            SqlDataReader reader = DBHelper.GetReader(sql);
            int num = 0;
            if (reader.Read())
            {
                num = Convert.ToInt32(reader["num"]);
            }
            reader.Close();
            return num;
        }
        public int DeleteThesisByStudentId(int studentId)
        {
            string sql = string.Format("delete Thesis where StudentId={0}", studentId);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
    }
}
