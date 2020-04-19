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
        public static Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup GetUsers(Message message)
        {
            ReplyKeyboardMarkup ret = new ReplyKeyboardMarkup();
            List<List<KeyboardButton>> keyboard = new List<List<KeyboardButton>>();
            ret.ResizeKeyboard = true;
            foreach (var user in UserManager.getMyUsers(message))
            {
                var row = new List<KeyboardButton>();
                row.Add(new KeyboardButton()
                {
                    Text = user.Name
                });
                keyboard.Add(row);
            }
            ret.Keyboard = keyboard;
            return ret;
        }

        /// <summary>
        /// Return user list with tasks
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup GetUsersInline(Message message)
        {
            List<List<InlineKeyboardButton>> keyboard = new List<List<InlineKeyboardButton>>();


            foreach (var user in UserManager.getMyUsers(message))
            {
                var row = new List<InlineKeyboardButton>();
                row.Add(new InlineKeyboardButton()
                {
                    Text = user.Name,
                    CallbackData = "GetUserTask?userid=" + user.Id
                });
                keyboard.Add(row);
            }
            InlineKeyboardMarkup ret = new InlineKeyboardMarkup(keyboard);
            return ret;
        }

        /// <summary>
        /// Prepare keyboard for initial screen
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup GetInitial(Message message)
        {
            ReplyKeyboardMarkup ret = new ReplyKeyboardMarkup();
            List<List<KeyboardButton>> keyboard = new List<List<KeyboardButton>>();
            ret.ResizeKeyboard = true;

            var row1 = new List<KeyboardButton>();
            var row2 = new List<KeyboardButton>();
            var row3 = new List<KeyboardButton>();
            row1.Add(new KeyboardButton()
            {
                Text = @"Назначить задачу" + ('\uF589').ToString()
            }) ;
            row2.Add(new KeyboardButton()
            {
                Text = "Назначиные задачи"
            }); ;
            row3.Add(new KeyboardButton()
            {
                Text = "Архив"
            }); ;
            keyboard.Add(row1);
            keyboard.Add(row2);
            keyboard.Add(row3);
            ret.Keyboard = keyboard;
            return ret;
        }

        /// <summary>
        /// Return user tasks
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup GetUserTask(string userid)
        {
            List<List<InlineKeyboardButton>> keyboard = new List<List<InlineKeyboardButton>>();


            foreach (var task in UserManager.getUserTask(userid))
            {
                var row = new List<InlineKeyboardButton>();
                row.Add(new InlineKeyboardButton()
                {
                    Text = task.Name,
                    CallbackData = "xxxx?userid="
                });
                keyboard.Add(row);
            }
            InlineKeyboardMarkup ret = new InlineKeyboardMarkup(keyboard);
            return ret;
        }
    }
}
