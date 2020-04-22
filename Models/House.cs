using System;
using System.Collections.Generic;

namespace TaskManager.Models
{
    public partial class House
    {
        public House()
        {
            FrontDoor = new HashSet<FrontDoor>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public int? ResidentialId { get; set; }

        public virtual Residential Residential { get; set; }
        public virtual ICollection<FrontDoor> FrontDoor { get; set; }
    }
}
