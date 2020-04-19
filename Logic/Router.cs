using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Logic
{
    public class Router
    {
        public static void RunCommand(Telegram.Bot.Types.Message message)
        {
            Logic.CommandManager cm = new CommandManager();
            switch(cm.GetCommand(message.Text))
            {
                case "SubordinateTasks":
                    break;
                case "StartCreateTask":
                    break;
                case "EndCreateTask":
                    break;
                default:
                    Console.Write("Default action");
                    break;
            }
        }
    }
}
