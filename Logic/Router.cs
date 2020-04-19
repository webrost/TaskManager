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

            ///---Keyboard Commands
            if(message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                switch (cm.GetCommand(message.Text))
                {
                    case "SubordinateTasks":
                        client.SendTextMessageAsync(message.Chat.Id, $"SubordinateTasks", replyMarkup: Screen.GetUsersInline(message));
                        break;
                    case "StartCreateTask":

                        break;
                    case "EndCreateTask":

                        break;
                    default:
                        UserManager.CreateNewUser(message.From);
                        client.SendTextMessageAsync(message.Chat.Id, $"****", replyMarkup: Screen.GetInitial(message));
                        break;
                }
            }            
        }

        public static void RunInlineCommand(Telegram.Bot.Types.CallbackQuery inline, Telegram.Bot.TelegramBotClient client)
        {
            Logic.CommandManager cm = new CommandManager();

            var p = cm.GetInlineParameters(inline.Data);

            ///--Inline command
            switch(cm.GetInlineCommand(inline.Data))
            {
                case "GetUserTask":
                    client.SendTextMessageAsync(inline.Message.Chat.Id, $"****", replyMarkup: Screen.GetUserTask(p.First(x=>x.Key == "userid").Value));
                    break;
            }
        }
    }
}
