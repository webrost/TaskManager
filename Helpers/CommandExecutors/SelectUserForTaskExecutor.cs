using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TaskManager.Logic;
using TaskManager.Helpers.Commands;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TaskManager.Helpers.CommandExecutors
{
    public class SelectUserForTaskExecutor : ICommandExecutor
    {
        public bool TerminateFlow { get; set; }
        public Commands.BaseCommand OnCommand { get; set; }

        public void Run(Update update)
        {
            OnCommand = new Commands.SelectUserForTaskCommand(update);
            TerminateFlow = OnCommand.IsCommandCatched;
            if (!OnCommand.IsCommandCatched) return;
            Action();
            Display();
        }

        void Action()
        {

        }

        void Display()
        {
            Screens.BaseScreen screen = new Screens.BaseScreen(OnCommand);

            ///--define inline keys
            List<Commands.BaseCommand> usersCommands = new List<Commands.BaseCommand>();
            foreach (var user in UserManager.getMyUsers(OnCommand))
            {
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
                parameters.Add(new KeyValuePair<string, string>("userId", user.Id.ToString()));
                Commands.OpenNewTaskCommand inilneCommand = new Commands.OpenNewTaskCommand(parameters);
                Models.TasksInfo taskInfo = Logic.TaskManager.GetTaskCount(user.Id);
                inilneCommand.RU = $@"{user.Name} ({taskInfo.CompletedTask}/{taskInfo.CountAllTask})";
                inilneCommand.EN = $@"{user.Name} ({taskInfo.CompletedTask}/{taskInfo.CountAllTask})";
                usersCommands.Add(inilneCommand);
            }

            ///--define display message with inline keys
            screen.Messages.Add(new Messages.TextMessage(OnCommand)
            {
                TextRU = $@"Выберите исполнителя",
                TextEN = $@"Select executor",
                InlineCommands = usersCommands
            }) ;

            screen.Show();
        }
    }
}
