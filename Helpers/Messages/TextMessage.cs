using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace TaskManager.Helpers.Messages
{
    public class TextMessage:BaseMessage
    {
        public string Text { get; set; }

        public TextMessage(Commands.BaseCommand command):base(command)
        {

        }

        public void Show(ButtonsOrientationEnum orientation)
        {            
            if(orientation == ButtonsOrientationEnum.Horizontal)
            {
                Client.SendTextMessageAsync(Command.ChatId, Text, replyMarkup: GetHorizontalInlineKeyboard(), parseMode: Telegram.Bot.Types.Enums.ParseMode.Html).Wait();
            }
            else
            {
                Client.SendTextMessageAsync(Command.ChatId, Text, replyMarkup: GetVerticlalInlineKeyboard(), parseMode: Telegram.Bot.Types.Enums.ParseMode.Html).Wait();
            }
            
        }
    }
}
