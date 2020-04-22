using System;
using System.Collections.Generic;

namespace TaskManager.Models
{
    public partial class Residential
    {
        public Residential()
        {
            House = new HashSet<House>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string District { get; set; }

        public virtual ICollection<House> House { get; set; }
    }
}
