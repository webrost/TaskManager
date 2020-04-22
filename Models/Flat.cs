using System;
using System.Collections.Generic;

namespace TaskManager.Models
{
    public partial class Flat
    {
        public Flat()
        {
            Papuas = new HashSet<Papuas>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public string RoomCount { get; set; }
        public int? FrontDoorId { get; set; }

        public virtual FrontDoor FrontDoor { get; set; }
        public virtual ICollection<Papuas> Papuas { get; set; }
    }
}
