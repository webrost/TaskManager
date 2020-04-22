using System;
using System.Collections.Generic;

namespace TaskManager.Models
{
    public partial class Claim
    {
        public int Id { get; set; }
        public DateTime? Created { get; set; }
        public string Text { get; set; }
        public DateTime? Date { get; set; }
        public string VisitorName { get; set; }
        public string CarInfo { get; set; }
        public int? PapuasId { get; set; }

        public virtual Papuas Papuas { get; set; }
    }
}
