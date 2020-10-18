using Project.OnlineQA.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.Entities.Concrete
{
    public class UserSelection :ITable
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        virtual public User User { get; set; }

        public int? SelectionId { get; set; }
        virtual public Selection Selection { get; set; }
    }
}
