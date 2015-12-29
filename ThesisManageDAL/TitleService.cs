using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ThesisManage.Model;

namespace ThesisManage.DAL
{
    public class TitleService
    {
       
        //学生上传题目
        public int StuAddTitle(string titleName, int studentId, string Description)
        {
            string sql = string.Format("insert into Title(TitleName,Counts,State,Description,StudentId) values('{0}',1,0,'{1}',{2})", titleName, Description, studentId);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        //老师上传题目
        public int TeacherAddTitle(string titleName, int TEID, string Description, int chooseNum)
        {
            string sql = string.Format("insert into Title(TitleName,Counts,State,Description,TeacherId) values('{0}',{1},0,'{2}',{3})", titleName, chooseNum, Description, TEID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        //根据TitleId获取题目
        public Title GetTilteByTitleId(int titleId)
        {
            StudentService studentService = new StudentService();
            TeacherService teacherService=new TeacherService();
            string sql = string.Format("select * from Title where TID={0}",titleId);
            Title title = new Title();
            int teacherId = 0;
            int studentId = 0;
            SqlDataReader reader = DBHelper.GetReader(sql);
            if (reader.Read())
            {
                title.TID =Convert.ToInt32( reader["TID"]);
                title.TitleName = reader["TitleName"].ToString();
                title.Counts =Convert.ToInt32( reader["Counts"]);
                title.State =Convert.ToInt32( reader["State"]);
                title.HasChooseNum = Convert.ToInt32(reader["HasChooseNum"]);
                try
                {
                    teacherId = Convert.ToInt32(reader["TeacherId"]);
                }
                catch (Exception)
                { }
                try
                {
                    studentId = Convert.ToInt32(reader["StudentId"]);
                }
                catch (Exception)
                {
                }
                title.Description = reader["Description"].ToString();
                reader.Close();
                title.Teacher = teacherService.GetTeacherById(teacherId);
                title.Student = studentService.GetStudentBySID(studentId);
            }
            reader.Close();
            return title;
        }
        public Title GetTiByTitleId(int titleId)
        {
            StudentService studentService = new StudentService();
            TeacherService teacherService = new TeacherService();
            string sql = string.Format("select * from Title where TID={0}", titleId);
            Title title = new Title();
            int teacherId = 0;
            title.Student = null;
            SqlDataReader reader = DBHelper.GetReader(sql);
            if (reader.Read())
            {
                title.TID = Convert.ToInt32(reader["TID"]);
                title.TitleName = reader["TitleName"].ToString();
                title.Counts = Convert.ToInt32(reader["Counts"]);
                title.State = Convert.ToInt32(reader["State"]);
                title.HasChooseNum = Convert.ToInt32(reader["HasChooseNum"]);
                try
                {
                    teacherId = Convert.ToInt32(reader["TeacherId"]);
                }
                catch (Exception)
                { }
                title.Description = reader["Description"].ToString();
                reader.Close();
                title.Teacher = teacherService.GetTeacherById(teacherId);
            }
            reader.Close();
            return title;
        }
        //修改老师自己上报并未被审核的Title信息
        public int ModifiyTitle(string titleName,string description, int counts, int tID)
        {
            string sql = string.Format("update Title set TitleName ='{0}',Description='{1}',Counts={2} where TID={3}", titleName,description, counts, tID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        //修改审核通过题目的状态
        public int ModifiyTitleState(int tID)
        {
            string sql = string.Format("update Title set State=1 where TID={0}", tID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        public int ModifiyTitleUnState(int tID)
        {
            string sql = string.Format("update Title set State=2 where TID={0}", tID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        public int ModifiyTitleState(int tID, int teacherId)
        {
            string sql = string.Format("update Title set State=1,TeacherId={0},HasChooseNum=1,StudentId=null where TID={1}", teacherId, tID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        //删除题目
        public int DeleteTitle(int tID)
        {
            string sql = string.Format("delete Title where TID={0}",tID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        //获取可选的题目列表
        public List<Title> GetTitleList()
        {
            StudentService studentService = new StudentService();
            string sql = string.Format("select * from Title where State=1");
            TeacherService teacherService=new TeacherService();
            List<Title> list=new List<Title>();
            int teacherId = 0;
            int studentId = 0;
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow rows in table.Rows)
            {
                Title title = new Title();
                title.TID =Convert.ToInt32( rows["TID"]);
                title.Counts = Convert.ToInt32(rows["Counts"]);
                title.TitleName = rows["TitleName"].ToString();
                title.State = Convert.ToInt32(rows["State"]);
                title.HasChooseNum = Convert.ToInt32(rows["HasChooseNum"]);
                try
                {
                    teacherId = Convert.ToInt32(rows["TeacherId"]);
                }
                catch (Exception)
                { }
                try
                {
                    studentId = Convert.ToInt32(rows["StudentId"]);
                }
                catch (Exception)
                {
                }
                title.Description = rows["Description"].ToString();
                title.Teacher = teacherService.GetTeacherById(teacherId);
                title.Student = studentService.GetStudentBySID(studentId);
                list.Add(title);
            }
            return list;
        }
        //获取未审核的题目列表
        public List<Title> GetUnTitleList()
        {
            StudentService studentService = new StudentService();
            string sql = string.Format("select * from Title where State=0");
            TeacherService teacherService = new TeacherService();
            List<Title> list = new List<Title>();
            int teacherId = 0;
            int studentId = 0;
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow rows in table.Rows)
            {
                Title title = new Title();
                title.TID = Convert.ToInt32(rows["TID"]);
                title.Counts = Convert.ToInt32(rows["Counts"]);
                title.TitleName = rows["TitleName"].ToString();
                title.State = Convert.ToInt32(rows["State"]);
                title.HasChooseNum = Convert.ToInt32(rows["HasChooseNum"]);
                title.Description = rows["Description"].ToString();
                try
                {
                    teacherId = Convert.ToInt32(rows["TeacherId"]);
                }
                catch (Exception)
                {}
                try
                {
                    studentId = Convert.ToInt32(rows["StudentId"]);
                }
                catch (Exception)
                {
                }
                title.Teacher = teacherService.GetTeacherById(teacherId);
                title.Student = studentService.GetStudentBySID(studentId);
                list.Add(title);
            }
            return list;
        }
        //获取老师上传的题目列表
        public List<Title> GetTitleListByTeacherId(int TeacherId)
        {
            StudentService studentService = new StudentService();
            string sql = string.Format("select * from Title where TeacherId={0}", TeacherId);
            TeacherService teacherService = new TeacherService();

            List<Title> list = new List<Title>();
            int teacherId = 0;
            int studentId = 0;
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow rows in table.Rows)
            {
                Title title = new Title();
                title.TID = Convert.ToInt32(rows["TID"]);
                title.Counts = Convert.ToInt32(rows["Counts"]);
                title.TitleName = rows["TitleName"].ToString();
                title.State = Convert.ToInt32(rows["State"]);
                title.HasChooseNum = Convert.ToInt32(rows["HasChooseNum"]);
                title.Description = rows["Description"].ToString();
                try
                {
                    teacherId = Convert.ToInt32(rows["TeacherId"]);
                }
                catch (Exception)
                { }
                try
                {
                    studentId = Convert.ToInt32(rows["StudentId"]);
                }
                catch (Exception)
                {
                }
                title.Teacher = teacherService.GetTeacherById(teacherId);
                title.Student = studentService.GetStudentBySID(studentId);
                list.Add(title);
            }
            return list;
        }
        public int ModifiyTitleHasChooseNum(int tID)
        {
            string sql = string.Format("update Title set HasChooseNum=HasChooseNum+1 where TID={0}", tID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        public int ModifiyTitleChooseNum(int tID)
        {
            string sql = string.Format("update Title set HasChooseNum=HasChooseNum-1 where TID={0}", tID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        public DataSet GetTitle(string sql)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DBHelper.Connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "title");
            return dataset;
        }
        public int GetTitleCount()
        {
            string sql = string.Format("select num=count(*) from Title");
            SqlDataReader reader = DBHelper.GetReader(sql);
            int num = 0;
            if (reader.Read())
            {
                num = Convert.ToInt32(reader["num"]);
            }
            reader.Close();
            return num;
        }
        public int GetTitleCountsSum()
        {
            string sql = string.Format("select num=sum(Counts)  from title");
            SqlDataReader reader = DBHelper.GetReader(sql);
            int num = 0;
            if (reader.Read())
            {
                num = Convert.ToInt32(reader["num"]);
            }
            reader.Close();
            return num;
        }
    }
}
