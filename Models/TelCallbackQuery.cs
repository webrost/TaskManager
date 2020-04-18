using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class TelCallbackQuery
    {
        public string id { get; set; }

        public TelFrom from { get; set; }

        public TelMessage message { get; set; }

        public string chat_instance { get; set; }

        public string data { get; set; }
    }
}
