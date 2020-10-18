using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.OnlineQA.WebApi.Models
{
    public class SelectionListModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int NumberOfSelection { get; set; }
        virtual public Question Question { get; set; }
        public int? QuestionId { get; set; }
    }
}
