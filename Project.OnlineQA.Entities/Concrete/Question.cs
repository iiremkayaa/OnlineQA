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
        virtual public List<Selection> Selections { get; set; }
        virtual public List<Comment> Comments { get; set; }
        public DateTime PostedTime { get; set; }
        public int UserId { get; set; }
        virtual public User User { get; set; }
    }
}
