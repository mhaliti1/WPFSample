using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPro.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Status { get; set; }
        public DateTime? DueDate { get; set; }
        public string Owner { get; set; }
        public long Department { get; set; }
      


    }

    public class ToDo
    {
        public int Id { get; set; }
        public int? ProID { get; set; }
        public string TaskName { get; set; }
        public string Assignee { get; set; }
        public DateTime? DueDate { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }

    }

    public class Comment
    {

        public int Id { get; set; }
        public int SourceId { get; set; }
        public string Source { get; set; }
        public string Text { get; set; }
        public string CommentBy { get; set; }
        public DateTime CommentDate { get; set; }
       

    }
}
