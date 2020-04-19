using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Logic
{
    public class Router
    {
        public static void RunCommand(Telegram.Bot.Types.Message message, Telegram.Bot.TelegramBotClient client)
        {
            Logic.CommandManager cm = new CommandManager();
            if(message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                switch (cm.GetCommand(message.Text))
                {
                    case "SubordinateTasks":

                        break;
                    case "StartCreateTask":

                        break;
                    case "EndCreateTask":

                        break;
                    default:
                        UserManager.CreateNewUser(message.From);
                        //client.SendTextMessageAsync(message.Chat.Id, $"xxxxxxxxxxxxx", replyMarkup: Screen.GetUsers(message));
                        client.SendTextMessageAsync(message.Chat.Id, $"xxxxxxxxxxxxx", replyMarkup: Screen.GetInitial(message));

                        Console.Write("Default action");
                        break;
                }
            }
            
        }
    }
}
