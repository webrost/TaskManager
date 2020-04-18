using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class TelMessage
    {
        public int message_id { get; set; }
        public TelFrom from {get;set;}
        public TelChat chat { get; set; }
        public int date { get; set; }
        public string text { get; set; }
    }
}
