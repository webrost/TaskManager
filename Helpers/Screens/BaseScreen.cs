using Microsoft.AspNetCore.Server.HttpSys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace TaskManager.Helpers.Screens
{
    public class BaseScreen
    {
        public List<Commands.BaseCommand> Keyboard { get; set; }
        public List<Messages.TextMessage> Messages { get; set; }
        public List<Messages.PhotoMessage> Photos { get; set; }
        public Telegram.Bot.TelegramBotClient Client { get; set; }

        public Commands.BaseCommand Command;

        public BaseScreen(Commands.BaseCommand command)
        {
            Command = command;
            Keyboard = new List<Commands.BaseCommand>();
            Messages = new List<Messages.TextMessage>();
            Photos = new List<Messages.PhotoMessage>();

            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            string token = config.GetSection("BotConfig").GetValue<string>("TelegramBotTocken");
            Client = new Telegram.Bot.TelegramBotClient(token);
        }
        public void Show()
        {
            Messages.ForEach(mes => mes.Show(Helpers.Messages.ButtonsOrientationEnum.Vertical));
            if(Keyboard.Count() == 0)
            {
                Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardRemove remove = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardRemove();
                Client.SendTextMessageAsync(Command.ChatId, "--", replyMarkup: remove);
            }
            else
            {
                ShowKeyboard();
            }            
        }

        public void ShowKeyboard()
        {
            Client.SendTextMessageAsync(Command.ChatId, "--", replyMarkup: BuildKeyboard()).Wait();
        }

        Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup BuildKeyboard()
        {
            Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup ret = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup();

            List<List<Telegram.Bot.Types.ReplyMarkups.KeyboardButton>> keyboard = new List<List<Telegram.Bot.Types.ReplyMarkups.KeyboardButton>>();
            ret.ResizeKeyboard = true;
            foreach (var command in Keyboard)
            {
                var row = new List<Telegram.Bot.Types.ReplyMarkups.KeyboardButton>();
                row.Add(new Telegram.Bot.Types.ReplyMarkups.KeyboardButton()
                {
                    Text = command.RU
                });
                keyboard.Add(row);
            }
            ret.Keyboard = keyboard;
            return ret;
        }
    }
}
