using System;
using System.Collections.Generic;

namespace TaskManager.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int? RoleId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Role Role { get; set; }
    }
}
