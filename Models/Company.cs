using System;
using System.Collections.Generic;

namespace TaskManager.Models
{
    public partial class Company
    {
        public Company()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string SecretCode { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}