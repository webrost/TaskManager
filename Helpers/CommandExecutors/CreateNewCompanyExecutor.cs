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
    public class CreateNewCompanyExecutor : ICommandExecutor
    {
        public bool TerminateFlow { get; set; }
        public Commands.BaseCommand OnCommand { get; set; }

        string secretCode = "";

        public void Run(Update update)
        {
            OnCommand = new Commands.CreateNewCompanyCommand(update);
            TerminateFlow = OnCommand.IsCommandCatched;
            if (!OnCommand.IsCommandCatched) return;
            Action();
            Display();
        }

        void Action()
        {
            secretCode = Logic.UserManager.CreateNewCompany(OnCommand.Message.Text, OnCommand.Message.From, OnCommand.Message.Chat);
        }

        void Display()
        {
            Screens.BaseScreen screen = new Screens.BaseScreen(OnCommand);

            ///--define keydoard
            List<Commands.BaseCommand> keyboardCommands = new List<Commands.BaseCommand>();
            keyboardCommands.Add(new SelectUserForTaskCommand(new List<KeyValuePair<string, string>>()));
            keyboardCommands.Add(new ListUsersWithTasksCommand(new List<KeyValuePair<string, string>>()));
            screen.Keyboard = keyboardCommands;


            ///--define display message 
            screen.Messages.Add(new Messages.TextMessage(OnCommand)
            {
                TextRU = $@"Вы создали компанию {OnCommand.Message.Text}. Отошлите код приглашения.",
                TextEN = $@"Enter task"
            }) ;
            screen.Messages.Add(new Messages.TextMessage(OnCommand)
            {
                TextRU = $@"{secretCode}",
                TextEN = $@"{secretCode}"
            });

            screen.Show();
        }
    }
}
