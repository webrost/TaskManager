using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TaskManager.Logic;
using TaskManager.Helpers.Commands;
using Microsoft.Extensions.Configuration;

namespace TaskManager.Helpers.CommandExecutors
{
    public class WriteMessageToOpenedTaskExecutor : ICommandExecutor
    {
        public bool TerminateFlow { get; set; }
        public Commands.BaseCommand OnCommand { get; set; }

        Telegram.Bot.TelegramBotClient Client;

        public void Run(Update update)
        {
            OnCommand = new Commands.WriteMessageToOpenedTaskCommand(update);
            TerminateFlow = OnCommand.IsCommandCatched;
            if (!OnCommand.IsCommandCatched) return;
            Action();
            Display();
        }

        void Action()
        {
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            string token = config.GetSection("BotConfig").GetValue<string>("TelegramBotTocken");
            Client = new Telegram.Bot.TelegramBotClient(token);
            Logic.TaskManager.AddMessage(OnCommand.Message, Client);
        }

        void Display()
        {
            Screens.BaseScreen screen = new Screens.BaseScreen(OnCommand);

            ///--define keydoard
            List<Commands.BaseCommand> keyboardCommands = new List<Commands.BaseCommand>();
            keyboardCommands.Add(new CloseTaskCommand(OnCommand.Update, new List<KeyValuePair<string, string>>()));            
            screen.Keyboard = keyboardCommands;


            ///--define display message 
            screen.Messages.Add(new Messages.TextMessage(OnCommand)
            {
                Text = Logic.Translator.GetText("WriteMessageToOpenedTaskMessage", OnCommand.Message.From.LanguageCode)
            }) ;

            screen.Show();
        }
    }
}
