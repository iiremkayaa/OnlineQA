﻿using Project.OnlineQA.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.Entities.Concrete
{
    public class Selection :ITable
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int NumberOfSelection { get; set; }
        public int? QuestionId { get; set; }
        virtual public Question Question { get; set; }
        virtual public List<UserSelection> UserSelections { get; set; }




    }
}
