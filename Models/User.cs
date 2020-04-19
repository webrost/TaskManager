﻿using System;
using System.Collections.Generic;

namespace TaskManager.Models
{
    public partial class User
    {
        public User()
        {
            Message = new HashSet<Message>();
            TaskCreatedByNavigation = new HashSet<Task>();
            TaskUser = new HashSet<Task>();
        }

        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int? RoleId { get; set; }
        public int? TelegramId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Message> Message { get; set; }
        public virtual ICollection<Task> TaskCreatedByNavigation { get; set; }
        public virtual ICollection<Task> TaskUser { get; set; }
    }
}