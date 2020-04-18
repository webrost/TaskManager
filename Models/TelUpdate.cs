using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class TelUpdate
    {
        public int update_id { get; set; }
        public TelMessage message { get; set; }

        public TelCallbackQuery callback_query { get; set; }
    }
}
