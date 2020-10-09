using Project.OnlineQA.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.Entities.Concrete
{
    public class UserSelection :ITable
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int SelectionId { get; set; }
        public Selection Selection { get; set; }
    }
}
