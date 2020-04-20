using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class TasksInfo
    {
        public int CountAllTask { get; set; }
        public int CompletedTask { get; set; }
        public int OpenedTask { get; set; }
    }
}
