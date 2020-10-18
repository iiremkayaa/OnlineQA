using Project.OnlineQA.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.Entities.Concrete
{
    public class User : ITable
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        virtual public List<Question> Questions { get; set; }
        virtual public List<Comment> Comments { get; set; }
        virtual public List<UserSelection> UserSelections { get; set; }
    }
}
