using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TaskManager.Logic;
using TaskManager.Helpers.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;

namespace TaskManager.Helpers.CommandExecutors
{
    public class CloseTaskExecutor : ICommandExecutor
    {
        public bool TerminateFlow { get; set; }
        public Commands.BaseCommand OnCommand { get; set; }

        public Telegram.Bot.TelegramBotClient Client;

        public void Run(Update update)
        {
            OnCommand = new Commands.CloseTaskCommand(update);
            TerminateFlow = OnCommand.IsCommandCatched;
            if (!OnCommand.IsCommandCatched) return;
            Action();
            Display();
        }

        void Action()
        {

            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
            string botToken = config.GetSection("BotConfig").GetValue<string>("TelegramBotTocken");
            Client = new Telegram.Bot.TelegramBotClient(botToken);

            var taskId = Logic.TaskManager.GetOpenedEditTaskId(OnCommand.Message.Chat.Id);
            using (Models.TContext model = new Models.TContext()) {
                var task = model.Task.First(x => x.Id == taskId);
                var telegramUserId = model.User.First(x => x.Id == task.UserId).TelegramId;
                Client.SendTextMessageAsync(telegramUserId, $@"Вам назначена новая задача #{task.Id}");
            }
            Logic.TaskManager.CloseOpenedEditTasks(OnCommand);
        }

        void Display()
        {
            Screens.BaseScreen screen = new Screens.BaseScreen(OnCommand);

            ///--define keydoard
            List<Commands.BaseCommand> keyboardCommands = new List<Commands.BaseCommand>();
            keyboardCommands.Add(new SelectUserForTaskCommand(OnCommand.Update, new List<KeyValuePair<string, string>>()));
            keyboardCommands.Add(new ListUsersWithTasksCommand(OnCommand.Update, new List<KeyValuePair<string, string>>()));
            screen.Keyboard = keyboardCommands;


            ///--define display message 
            screen.Messages.Add(new Messages.TextMessage(OnCommand)
            {
                Text = Logic.Translator.GetText("CloseTaskMessage1", OnCommand.Message.From.LanguageCode)
            }) ;

            screen.Show();
        }
    }
}
