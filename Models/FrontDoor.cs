using System;
using System.Collections.Generic;

namespace TaskManager.Models
{
    public partial class FrontDoor
    {
        public FrontDoor()
        {
            Flat = new HashSet<Flat>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public int? HouseId { get; set; }

        public virtual House House { get; set; }
        public virtual ICollection<Flat> Flat { get; set; }
    }
}
