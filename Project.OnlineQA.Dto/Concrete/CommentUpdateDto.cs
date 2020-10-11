using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.Dto.Concrete
{
    public class CommentUpdateDto
    {
        public int Id { get; set; }
        public int? QuestionId { get; set; }
        public int? UserId { get; set; }
        public string Description { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
