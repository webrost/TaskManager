using System;
using System.Collections.Generic;

namespace TaskManager.Models
{
    public partial class Files
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int? FileSize { get; set; }
        public string FileUniqueId { get; set; }
        public string MimeType { get; set; }
        public int? Duration { get; set; }
        public string FileId { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public string Type { get; set; }
        public int? MessageId { get; set; }

        public virtual Message Message { get; set; }
    }
}
