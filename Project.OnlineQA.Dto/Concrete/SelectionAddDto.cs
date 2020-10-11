using Project.OnlineQA.Dto.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.Dto.Concrete
{
    public class SelectionAddDto :IDto
    {
        public string Description { get; set; }
        public int NumberOfSelection { get; set; }
        public int? QuestionId { get; set; }
    }
}
