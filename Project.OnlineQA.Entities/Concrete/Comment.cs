using Project.OnlineQA.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.Entities.Concrete
{
    public class Comment :ITable
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Description { get; set; }
        public DateTime commentDate { get; set; }

    }
}
