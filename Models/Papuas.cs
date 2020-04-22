using System;
using System.Collections.Generic;

namespace TaskManager.Models
{
    public partial class Papuas
    {
        public Papuas()
        {
            Claim = new HashSet<Claim>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public string RoomCount { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public int? TelegramId { get; set; }
        public int FlatId { get; set; }

        public virtual Flat Flat { get; set; }
        public virtual ICollection<Claim> Claim { get; set; }
    }
}
