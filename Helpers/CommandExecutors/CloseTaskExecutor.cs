using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TaskManager.Logic;
using TaskManager.Helpers.Commands;

namespace TaskManager.Helpers.CommandExecutors
{
    public class CloseTaskExecutor : ICommandExecutor
    {
        public bool TerminateFlow { get; set; }
        public Commands.BaseCommand OnCommand { get; set; }

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
            Logic.TaskManager.CloseOpenedEditTasks(OnCommand);
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
                TextRU = $@"Выберите действие",
                TextEN = $@"Choose action"
            }) ;

            screen.Show();
        }
    }
}
