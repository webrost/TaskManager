﻿using System;
using System.Collections.Generic;

namespace TaskManager.Models
{
    public partial class Message
    {
        public Message()
        {
            Files = new HashSet<Files>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public int? TaskId { get; set; }
        public long? TelegramChatId { get; set; }
        public long? TelegramMessageId { get; set; }
        public int? CreatedId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? DeletedTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public string Type { get; set; }

        public virtual User Created { get; set; }
        public virtual Task Task { get; set; }
        public virtual ICollection<Files> Files { get; set; }
    }
}
