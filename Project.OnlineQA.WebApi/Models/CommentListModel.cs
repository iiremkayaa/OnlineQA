using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.OnlineQA.WebApi.Models
{
    public class CommentListModel
    {
        public int Id { get; set; }
        public int? QuestionId { get; set; }
        virtual public Question Question { get; set; }
        public int? UserId { get; set; }
        virtual public User User { get; set; }
        public string Description { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
