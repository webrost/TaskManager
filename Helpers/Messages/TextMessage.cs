using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace TaskManager.Helpers.Messages
{
    public class TextMessage:BaseMessage
    {
        public string TextRU { get; set; }
        public string TextEN { get; set; }

        public TextMessage(Commands.BaseCommand command):base(command)
        {

        }

        public void Show(ButtonsOrientationEnum orientation)
        {            
            if(orientation == ButtonsOrientationEnum.Horizontal)
            {
                Client.SendTextMessageAsync(Command.ChatId, TextRU, replyMarkup: GetHorizontalInlineKeyboard()).Wait();
            }
            else
            {
                Client.SendTextMessageAsync(Command.ChatId, TextRU, replyMarkup: GetVerticlalInlineKeyboard()).Wait();
            }
            
        }
    }
}
