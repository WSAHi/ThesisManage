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
        /// 学生上传题目
        /// </summary>
        /// <param name="titleName"></param>
        /// <param name="studentID"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        public int StuAddTitle(string titleName, int studentID, string Description)
        {
            string sql = string.Format("insert into Title(TitleName,Counts,State,Description,StudentId,HasChooseNum) values('{0}',1,0,'{1}','{2}',0)", titleName, Description, studentID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 教师上传题目
        /// </summary>
        /// <param name="titleName"></param>
        /// <param name="TEID"></param>
        /// <param name="Description"></param>
        /// <param name="chooseNum"></param>
        /// <returns></returns>
        public int TeacherAddTitle(string titleName, int TEID, string Description, int chooseNum)
        {
            string sql = string.Format("insert into Title(TitleName,Counts,State,Description,TeacherId,HasChooseNum) values('{0}','{1}',0,'{2}','{3}',0)", titleName, chooseNum, Description, TEID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 根据题目ID获取题目信息
        /// </summary>
        /// <param name="tID">题目ID</param>
        /// <returns></returns>
        public Title GetTilteByTitleId(int tID)
        {
            StudentService studentService = new StudentService();
            TeacherService teacherService = new TeacherService();
            string sql = string.Format("select * from Title where TID={0}", tID);
            Title title = new Title();
            int teacherId = 0;
            int studentId = 0;
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
        public Title GetTiByTitleId(int tID)
        {
            StudentService studentService = new StudentService();
            TeacherService teacherService = new TeacherService();
            string sql = string.Format("select * from Title where TID={0}", tID);
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
        /// <summary>
        /// 修改教师自己上报并未被审核的题目信息
        /// </summary>
        /// <param name="titleName">题目名称</param>
        /// <param name="Description">描述</param>
        /// <param name="counts">数量</param>
        /// <param name="tID">题目ID</param>
        /// <returns></returns>
        public int ModifiyTitle(string titleName, string Description, int counts, int tID)
        {
            string sql = string.Format("update Title set TitleName ='{0}',Description='{1}',Counts={2} where TID={3}", titleName, Description, counts, tID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 修改审核通过题目的状态
        /// </summary>
        /// <param name="tID">题目ID</param>
        /// <returns></returns>
        public int ModifiyTitleState(int tID)
        {
            string sql = string.Format("update Title set State=1 where TID={0}", tID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 修改未审核通过的题目状态
        /// </summary>
        /// <param name="tID">题目ID</param>
        /// <returns></returns>
        public int ModifiyTitleUnState(int tID)
        {
            string sql = string.Format("update Title set State=2 where TID={0}", tID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 修改题目的选择状态
        /// </summary>
        /// <param name="teacherID"></param>
        /// <param name="tID"></param>
        /// <returns></returns>
        public int ModifiyTitleState(int teacherID, int tID)
        {
            string sql = string.Format("update Title set State=1,TeacherId={0},HasChooseNum=1,StudentId=null where TID={1}", teacherID, tID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 删除题目
        /// </summary>
        /// <param name="tID">题目ID</param>
        /// <returns></returns>
        public int DeleteTitle(int tID)
        {
            string sql = string.Format("delete Title where TID={0}", tID);
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
            string sql = string.Format("select * from Title where State=1");
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
        /// <summary>
        /// 获取未审核的题目列表
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 获取教师上传的题目列表
        /// </summary>
        /// <param name="TeacherId">教师编号</param>
        /// <returns></returns>
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
        /// <summary>
        /// 更新题目被选择数量（+）
        /// </summary>
        /// <param name="tID">题目ID</param>
        /// <returns></returns>
        public int ModifiyTitleHasChooseNum(int tID)
        {
            string sql = string.Format("update Title set HasChooseNum=HasChooseNum+1 where TID={0}", tID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 更新题目被选择数量（-）
        /// </summary>
        /// <param name="tID">题目ID</param>
        /// <returns></returns>
        public int ModifiyTitleChooseNum(int tID)
        {
            string sql = string.Format("update Title set HasChooseNum=HasChooseNum-1 where TID={0}", tID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 获取题目表
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
        /// <summary>
        /// 题目默认可选的总人数
        /// </summary>
        /// <returns></returns>
        public int GetTitleCountsSum()
        {
            string sql = string.Format("select num=sum(Counts)  from title");
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
