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

        /// <summary>
        /// 学生上传自定义题目
        /// </summary>
        /// <param name="titleName">题目名称</param>
        /// <param name="studentID">学生登录（学号）ID</param>
        /// <param name="Description">题目描述</param>
        /// <param name="tEID">选择的指导老师的ID</param>
        /// <returns></returns>
        public int StuAddTitle(string titleName, int studentID, string Description, int tEID)
        {
            string sql = string.Format("INSERT INTO Title(TitleName,Counts,State,Description,StudentID,HasChooseNum,TeacherID) VALUES ('{0}',1,0,'{1}','{2}',0,'{3}')", titleName, Description, studentID, tEID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 教师上传自定义题目
        /// </summary>
        /// <param name="titleName">题目名称</param>
        /// <param name="TEID">教师内码</param>
        /// <param name="Description">题目描述</param>
        /// <param name="counts">题目可选择的总数</param>
        /// <returns></returns>
        public int TeacherAddTitle(string titleName, int TEID, string Description, int counts)
        {
            string sql = string.Format("INSERT INTO Title(TitleName,Counts,State,Description,TeacherID,HasChooseNum) VALUES ('{0}','{1}',0,'{2}','{3}',0)", titleName, counts, Description, TEID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 根据题目ID获取题目信息
        /// </summary>
        /// <param name="titleID">题目ID</param>
        /// <returns></returns>
        public Title GetTilteByTitleID(int titleID)
        {
            StudentService studentService = new StudentService();
            TeacherService teacherService = new TeacherService();
            string sql = string.Format("SELECT * FROM Title WHERE TitleID={0}", titleID);
            Title title = new Title();
            int teacherID = 0;
            int studentID = 0;
            SqlDataReader reader = DBHelper.GetReader(sql);
            if (reader.Read())
            {
                title.TitleID = Convert.ToInt32(reader["TitleID"]);
                title.TitleName = reader["TitleName"].ToString();
                title.Counts = Convert.ToInt32(reader["Counts"]);
                title.State = Convert.ToInt32(reader["State"]);
                title.HasChooseNum = Convert.ToInt32(reader["HasChooseNum"]);
                try
                {
                    teacherID = Convert.ToInt32(reader["TeacherID"]);
                }
                catch (Exception)
                {
                }
                try
                {
                    studentID = Convert.ToInt32(reader["StudentID"]);
                }
                catch (Exception)
                {
                }
                title.Description = reader["Description"].ToString();
                reader.Close();
                title.Teacher = teacherService.GetTeacherByID(teacherID);
                title.Student = studentService.GetStudentBySID(studentID);
            }
            reader.Close();
            return title;
        }
        /// <summary>
        /// 根据题目ID获取题目信息
        /// </summary>
        /// <param name="titleID">题目ID</param>
        /// <returns></returns>
        public Title GetTiByTitleID(int titleID)
        {
            TeacherService teacherService = new TeacherService();
            string sql = string.Format("SELECT * FROM Title WHERE TitleID={0}", titleID);
            Title title = new Title();
            int teacherID = 0;
            title.Student = null;
            SqlDataReader reader = DBHelper.GetReader(sql);
            if (reader.Read())
            {
                title.TitleID = Convert.ToInt32(reader["TitleID"]);
                title.TitleName = reader["TitleName"].ToString();
                title.Counts = Convert.ToInt32(reader["Counts"]);
                title.State = Convert.ToInt32(reader["State"]);
                title.HasChooseNum = Convert.ToInt32(reader["HasChooseNum"]);
                try
                {
                    teacherID = Convert.ToInt32(reader["TeacherID"]);
                }
                catch (Exception)
                {
                }
                title.Description = reader["Description"].ToString();
                reader.Close();
                title.Teacher = teacherService.GetTeacherByID(teacherID);
            }
            reader.Close();
            return title;
        }
        /// <summary>
        /// 教师修改上报的题目
        /// </summary>
        /// <param name="titleName">题目名称</param>
        /// <param name="Description">题目描述</param>
        /// <param name="counts">题目可选数量</param>
        /// <param name="titleID">题目ID</param>
        /// <returns></returns>
        public int ModifiyTitle(string titleName, string Description, int counts, int titleID)
        {
            string sql = string.Format("UPDATE Title SET TitleName ='{0}',Description='{1}',Counts={2} WHERE TitleID={3}", titleName, Description, counts, titleID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 修改审核通过题目的状态（教师上传的题目）
        /// </summary>
        /// <param name="titleID">题目ID</param>
        /// <returns></returns>
        public int ModifiyTitleState(int titleID)
        {
            string sql = string.Format("UPDATE Title SET State=1 WHERE TitleID={0}", titleID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 修改审核通过题目的状态（学生上传的自定义题目）
        /// </summary>
        /// <param name="teacherID">教师登录（工号）ID</param>
        /// <param name="titleID"></param>
        /// <returns></returns>
        public int ModifiyStudentTitleState(int titleID)
        {
            string sql = string.Format("UPDATE Title SET State=1,HasChooseNum=1 where TitleID={0}", titleID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 修改未审核通过的题目状态
        /// </summary>
        /// <param name="titleID">题目ID</param>
        /// <returns></returns>
        public int ModifiyTitleUnState(int titleID)
        {
            string sql = string.Format("UPDATE Title SET State=2 WHERE TitleID={0}", titleID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 删除题目
        /// </summary>
        /// <param name="titleID">题目ID</param>
        /// <returns></returns>
        public int DeleteTitle(int titleID)
        {
            string sql = string.Format("DELETE Title WHERE TitleID={0}", titleID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 获取可选的题目列表
        /// </summary>
        /// <returns></returns>
        public List<Title> GetTitleList()
        {
            StudentService studentService = new StudentService();
            string sql = string.Format("SELECT * FROM Title WHERE State=1");
            TeacherService teacherService = new TeacherService();
            List<Title> list = new List<Title>();
            int teacherID = 0;
            int studentID = 0;
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow rows in table.Rows)
            {
                Title title = new Title();
                title.TitleID = Convert.ToInt32(rows["TitleID"]);
                title.Counts = Convert.ToInt32(rows["Counts"]);
                title.TitleName = rows["TitleName"].ToString();
                title.State = Convert.ToInt32(rows["State"]);
                title.HasChooseNum = Convert.ToInt32(rows["HasChooseNum"]);
                try
                {
                    teacherID = Convert.ToInt32(rows["TeacherID"]);
                }
                catch (Exception)
                {
                }
                try
                {
                    studentID = Convert.ToInt32(rows["StudentID"]);
                }
                catch (Exception)
                {
                }
                title.Description = rows["Description"].ToString();
                title.Teacher = teacherService.GetTeacherByID(teacherID);
                title.Student = studentService.GetStudentBySID(studentID);
                list.Add(title);
            }
            return list;
        }
        /// <summary>
        /// 获取未审核的题目列表
        /// </summary>
        /// <returns></returns>
        public List<Title> GetUnTitleList()
        {
            StudentService studentService = new StudentService();
            string sql = string.Format("SELECT * FROM Title WHERE State=0");
            TeacherService teacherService = new TeacherService();
            List<Title> list = new List<Title>();
            int teacherID = 0;
            int studentID = 0;
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow rows in table.Rows)
            {
                Title title = new Title();
                title.TitleID = Convert.ToInt32(rows["TitleID"]);
                title.Counts = Convert.ToInt32(rows["Counts"]);
                title.TitleName = rows["TitleName"].ToString();
                title.State = Convert.ToInt32(rows["State"]);
                title.HasChooseNum = Convert.ToInt32(rows["HasChooseNum"]);
                title.Description = rows["Description"].ToString();
                try
                {
                    teacherID = Convert.ToInt32(rows["TeacherID"]);
                }
                catch (Exception)
                { }
                try
                {
                    studentID = Convert.ToInt32(rows["StudentID"]);
                }
                catch (Exception)
                {
                }
                title.Teacher = teacherService.GetTeacherByID(teacherID);
                title.Student = studentService.GetStudentBySID(studentID);
                list.Add(title);
            }
            return list;
        }
        /// <summary>
        /// 获取题目列表
        /// </summary>
        /// <param name="teacherID">教师登录（工号）ID</param>
        /// <returns></returns>
        public List<Title> GetTitleListByTeacherId(int teacherID)
        {
            StudentService studentService = new StudentService();
            string sql = string.Format("SELECT * FROM Title WHERE TeacherID={0}", teacherID);
            TeacherService teacherService = new TeacherService();

            List<Title> list = new List<Title>();
            int teacherId = 0;
            int studentId = 0;
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow rows in table.Rows)
            {
                Title title = new Title();
                title.TitleID = Convert.ToInt32(rows["TitleID"]);
                title.Counts = Convert.ToInt32(rows["Counts"]);
                title.TitleName = rows["TitleName"].ToString();
                title.State = Convert.ToInt32(rows["State"]);
                title.HasChooseNum = Convert.ToInt32(rows["HasChooseNum"]);
                title.Description = rows["Description"].ToString();
                try
                {
                    teacherId = Convert.ToInt32(rows["TeacherID"]);
                }
                catch (Exception)
                {
                }
                try
                {
                    studentId = Convert.ToInt32(rows["StudentID"]);
                }
                catch (Exception)
                {
                }
                title.Teacher = teacherService.GetTeacherByID(teacherId);
                title.Student = studentService.GetStudentBySID(studentId);
                list.Add(title);
            }
            return list;
        }
        /// <summary>
        /// 更新题目被选择数量（+）
        /// </summary>
        /// <param name="titleID">题目ID</param>
        /// <returns></returns>
        public int ModifiyTitleHasChooseNum(int titleID)
        {
            string sql = string.Format("UPDATE Title SET HasChooseNum=HasChooseNum+1 WHERE TitleID={0}", titleID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 更新题目被选择数量（-）
        /// </summary>
        /// <param name="titleID">题目ID</param>
        /// <returns></returns>
        public int ModifiyTitleChooseNum(int titleID)
        {
            string sql = string.Format("UPDATE Title SET HasChooseNum=HasChooseNum-1 WHERE TitleID={0}", titleID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 根据条件获取课题信息列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet GetTitle(string sql)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DBHelper.Connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "title");
            return dataset;
        }
        /// <summary>
        /// 题目数量
        /// </summary>
        /// <returns></returns>
        public int GetTitleCount()
        {
            string sql = string.Format("SELECT num=COUNT(*) FROM Title");
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
        /// 题目默认可选的总人数
        /// </summary>
        /// <returns></returns>
        public int GetTitleCountsSum()
        {
            string sql = string.Format("SELECT num=SUM(Counts) FROM title");
            SqlDataReader reader = DBHelper.GetReader(sql);
            int num = 0;
            if (reader.Read())
            {
                if (!Convert.IsDBNull(reader["num"]))
                {
                    num = Convert.ToInt32(reader["num"]);
                }
                else
                {
                    num = 0;
                }
            }
            reader.Close();
            return num;
        }
    }
}
