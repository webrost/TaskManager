using System;
using System.Collections.Generic;

namespace TaskManager.Models
{
    public partial class Task
    {
        public Task()
        {
            Message = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? CreatedBy { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int? EstimateInHours { get; set; }
        public DateTime? FinishTime { get; set; }
        public DateTime? StartTime { get; set; }
        public long? TelegramChatId { get; set; }
        public string TelegramFrom { get; set; }
        public DateTime? DeleteTime { get; set; }
        public string TechStatus { get; set; }
        public DateTime? TechStatusChanged { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Message> Message { get; set; }
    }
}
