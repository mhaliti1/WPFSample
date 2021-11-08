using PersonalPro.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPro.ViewModel
{
    public static class Constants
    {

        public const string Connect = "Data Source=;Initial Catalog=;Integrated Security=True;";
    }
    public class dbConnect
    {

        private SqlConnection connect()
        {
            SqlConnection cnn = new SqlConnection(Constants.Connect);
            return cnn;
        }

        private DataTable execDT(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            SqlDataReader rd = cmd.ExecuteReader();
            dt.Load(rd);

            return dt;

        }


        public DataTable GetData(string query, int Value = 0)
        {

            using (SqlConnection cnn = connect())
            {
                using (SqlCommand cmd = new SqlCommand(@"[LoanAdminWrite].[SRI].[spGetData]", cnn))
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add("@query", SqlDbType.VarChar).Value = query;
                    cmd.Parameters.Add("@Value", SqlDbType.Int).Value = Value;



                    DataTable dt = execDT(cmd);

                    cnn.Close();
                    return dt;


                }
            }


        }


    }


    public class DataFactory
    {
        dbConnect db = new dbConnect();
        public List<Project> GetProjects()
        {
            

            List<Project> _list = new List<Project>();

            for (int i = 0; i < 10; i++)
            {
                _list.Add(new Project
                {
                    Id = i,
                    Name = "Project " + i,
                    Desc="Solution until you have a clear idea of what the problem is collect information. Collect sketchess...",
                    Status = "Open",
                    Owner = "Muhamet Haliti",
                    Department = 58000,
                    DueDate = DateTime.Now.AddMonths(1),
                
                });
            }
           
           

            return new List<Project>(_list);
        }


        public List<ToDo> GetTasks(int PID)
        {


            List<ToDo> _list = new List<ToDo>();

            for (int i = 0; i < 10; i++)
            {
                _list.Add(new ToDo
                {
                    Id = i,
                    ProID =PID,
                    TaskName = "Task " + i,
                    Status = "Open",
                    Assignee = "Muhamet Halit",
                    Category = "Planning",
                    DueDate = DateTime.Now.AddDays(1),

                });
            }



            return new List<ToDo>(_list);
        }

        public List<Comment> GetComments(int PID)
        {


            List<Comment> _list = new List<Comment>();

            for (int i = 0; i < 10; i++)
            {
                _list.Add(new Comment
                {
                    Id = i,
                    Text ="This is an example text",
                    CommentBy ="Muhamet Halit",
                    CommentDate =DateTime.Now, 
                    Source ="Project",
                    SourceId =PID

                   

                });
            }



            return new List<Comment>(_list);
        }
    }

}
