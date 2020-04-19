using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
namespace TaskManager.Logic
{
    public class Screen
    {
        public static Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup GetUsers(Message message) {
            ReplyKeyboardMarkup ret = new ReplyKeyboardMarkup();
            ret.Keyboard = new List<List<KeyboardButton>>();
            ret.ResizeKeyboard = true;
            foreach (var user in UserManager.getMyUsers(message))
            {
                var row = new List<KeyboardButton>();
                row.Add(new KeyboardButton() { 
                    Text = user.Name
                });
                ret.Keyboard.Append(row);
            }
            return ret;
        }
    }
}
