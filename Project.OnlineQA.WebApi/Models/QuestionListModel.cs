using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.OnlineQA.WebApi.Models
{
    public class QuestionListModel 
    {
        public int Id { get; set; }
        public string Description { get; set; }
       
        public DateTime PostedTime { get; set; }
        virtual public User user { get; set; }
        public int UserId { get; set; }
    }
}
