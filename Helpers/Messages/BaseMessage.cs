using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Helpers.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Telegram.Bot.Types.ReplyMarkups;


namespace TaskManager.Helpers.Messages
{
    public class BaseMessage
    {
        public BaseCommand Command { get; set; }
        public Telegram.Bot.TelegramBotClient Client { get; set; }
        public List<Commands.BaseCommand> InlineCommands { get; set; }

        public BaseMessage(BaseCommand command)
        {
            Command = command;
            InlineCommands = new List<BaseCommand>();
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            string token = config.GetSection("BotConfig").GetValue<string>("TelegramBotTocken");
            Client = new Telegram.Bot.TelegramBotClient(token);
        }

        public InlineKeyboardMarkup GetVerticlalInlineKeyboard()
        {
            List<List<InlineKeyboardButton>> keyboard = new List<List<InlineKeyboardButton>>();
            foreach (var button in InlineCommands)
            {
                var row = new List<InlineKeyboardButton>();
                row.Add(new InlineKeyboardButton() { 
                    Text = button.Text,
                    CallbackData = button.Code+"?"+String.Join('&',button.Parameters.Select(x=>x.Key+"="+x.Value))
                });
                keyboard.Add(row);
            }
            InlineKeyboardMarkup ret = new InlineKeyboardMarkup(keyboard);
            return ret;
        }
        public InlineKeyboardMarkup GetHorizontalInlineKeyboard()
        {
            List<List<InlineKeyboardButton>> keyboard = new List<List<InlineKeyboardButton>>();
            foreach (var button in InlineCommands)
            {
                var row = new List<InlineKeyboardButton>();
                row.Add(new InlineKeyboardButton()
                {
                    Text = button.Text,
                    CallbackData = button.Code + "?" + String.Join('&', button.Parameters.Select(x => x.Key + "=" + x.Value))
                });
                keyboard.Add(row);
            }
            InlineKeyboardMarkup ret = new InlineKeyboardMarkup(keyboard);
            return ret;
        }
    }
}
