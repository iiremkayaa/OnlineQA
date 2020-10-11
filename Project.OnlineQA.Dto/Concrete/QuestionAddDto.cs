using Project.OnlineQA.Dto.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.Dto.Concrete
{
    public class QuestionAddDto :IDto
    {
        public string Description { get; set; }
        public DateTime PostedTime { get; set; }
        public int UserId { get; set; }
    }
}
