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
        public int? UserId { get; set; }
        public string Description { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
