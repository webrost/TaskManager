using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Helpers.Messages
{
    public class PhotoMessage:BaseMessage
    {
        public string Photo { get; set; }
        public PhotoMessage(Commands.BaseCommand command) : base(command) { }
    }
}
