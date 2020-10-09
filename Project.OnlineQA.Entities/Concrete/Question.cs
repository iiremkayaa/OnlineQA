using Project.OnlineQA.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.Entities.Concrete
{
    public class Question : ITable
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<Selection> Selections { get; set; }
        public List<Comment> Comments { get; set; }
        public DateTime PostedTime { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
