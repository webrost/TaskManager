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
        public static void SendKeyboard(string text, List<Models.KeyboardCommandEnum> commands, Telegram.Bot.TelegramBotClient client, Telegram.Bot.Types.Chat chat)
        {
            if (text == "") text = "*";
            client.SendTextMessageAsync(chat.Id, text, Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: BuildKeyboard(commands));
        }

        public static void SendInlineKeys(string text, List<InlineKeyboardButton> buttons, Telegram.Bot.TelegramBotClient client, Telegram.Bot.Types.Chat chat )
        {
            if (text == "") text = "*";
            client.SendTextMessageAsync(chat.Id, text, replyMarkup: BuildInlineKey(buttons));

        }
        public static void SendInlineKeysHorizontaly(string text, List<InlineKeyboardButton> buttons, Telegram.Bot.TelegramBotClient client, Telegram.Bot.Types.Chat chat)
        {
            if (text == "") text = "*";
            client.SendTextMessageAsync(chat.Id, text, Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: BuildInlineKeyHorizontaly(buttons));

        }
        public static void SendText(string text, Telegram.Bot.TelegramBotClient client, Telegram.Bot.Types.Chat chat)
        {
            client.SendTextMessageAsync(chat.Id, text, Telegram.Bot.Types.Enums.ParseMode.Html).Wait();
        }

        static Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup BuildKeyboard(List<Models.KeyboardCommandEnum> commands)
        {
            ReplyKeyboardMarkup ret = new ReplyKeyboardMarkup();
            CommandManager cm = new CommandManager();
            List<List<KeyboardButton>> keyboard = new List<List<KeyboardButton>>();
            ret.ResizeKeyboard = true;
            foreach (var command in commands)
            {
                var row = new List<KeyboardButton>();
                row.Add(new KeyboardButton()
                {
                    Text = cm.GetText(command.ToString())
                });
                keyboard.Add(row);
            }
            ret.Keyboard = keyboard;
            return ret;
        }
        
        static Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup BuildInlineKey(List<InlineKeyboardButton> buttons)
        {
            List<List<InlineKeyboardButton>> keyboard = new List<List<InlineKeyboardButton>>();
            foreach (var button in buttons)
            {
                var row = new List<InlineKeyboardButton>();
                row.Add(button);
                keyboard.Add(row);
            }
            InlineKeyboardMarkup ret = new InlineKeyboardMarkup(keyboard);
            return ret;
        }
        static Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup BuildInlineKeyHorizontaly(List<InlineKeyboardButton> buttons)
        {
            List<List<InlineKeyboardButton>> keyboard = new List<List<InlineKeyboardButton>>();
            var row = new List<InlineKeyboardButton>();
            foreach (var button in buttons)
            {
                row.Add(button);
            }
            keyboard.Add(row);
            InlineKeyboardMarkup ret = new InlineKeyboardMarkup(keyboard);
            return ret;
        }

    }
}
