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
    public class ListUsersWithTasksExecutor : ICommandExecutor
    {
        public bool TerminateFlow { get; set; }
        public Commands.BaseCommand OnCommand { get; set; }

        public void Run(Update update)
        {
            OnCommand = new Commands.ListUsersWithTasksCommand(update);
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
                Helpers.Commands.ListUserTasksCommand inilneCommand = new Helpers.Commands.ListUserTasksCommand(OnCommand.Update, parameters);
                Models.TasksInfo taskInfo = Logic.TaskManager.GetTaskCount(user.Id);
                inilneCommand.Text = $@"{user.Name} ({taskInfo.CompletedTask}/{taskInfo.CountAllTask})";
                usersCommands.Add(inilneCommand);
            }

            ///--define display message with inline keys
            screen.Messages.Add(new Messages.TextMessage(OnCommand)
            {
                Text = Logic.Translator.GetText("ListUsersWithTaskMessage", OnCommand.Message.From.LanguageCode),
                InlineCommands = usersCommands
            }) ;

            screen.Show();
        }
    }
}
