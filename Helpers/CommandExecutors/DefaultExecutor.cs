using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TaskManager.Logic;
using TaskManager.Helpers.Commands;
using Telegram.Bot.Requests;

namespace TaskManager.Helpers.CommandExecutors
{
    public class DefaultExecutor : ICommandExecutor
    {
        public bool TerminateFlow { get; set; }
        public Commands.BaseCommand OnCommand { get; set; }

        public void Run(Update update)
        {
            OnCommand = new Commands.DefaultCommand(update);
            Action();
            Display();
        }

        void Action()
        {

        }

        void Display()
        {
            Screens.BaseScreen screen = new Screens.BaseScreen(OnCommand);

            ///--define keydoard
            List<Commands.BaseCommand> keyboardCommands = new List<Commands.BaseCommand>();
            keyboardCommands.Add(new SelectUserForTaskCommand(OnCommand.Update, new List<KeyValuePair<string,string>>()));
            keyboardCommands.Add(new ListUsersWithTasksCommand(OnCommand.Update, new List<KeyValuePair<string, string>>()));
            screen.Keyboard = keyboardCommands;



            ///--define display message with inline keys
            screen.Messages.Add(new Messages.TextMessage(OnCommand)
            {
                Text = Translator.GetText("DefaultMessage", OnCommand.Message.From.LanguageCode)
            }) ;

            screen.Show();
        }
    }
}
