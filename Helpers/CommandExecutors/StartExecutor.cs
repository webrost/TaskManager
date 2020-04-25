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
    public class StartExecutor : ICommandExecutor
    {
        public bool TerminateFlow { get; set; }
        public Commands.BaseCommand OnCommand { get; set; }

        public void Run(Update update)
        {
            OnCommand = new Commands.StartCommand(update);
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

            ///--define display message with inline keys
            screen.Messages.Add(new Messages.TextMessage(OnCommand)
            {
                Text = Logic.Translator.GetText("NotRegusteredMessage", OnCommand.Message.From.LanguageCode)            
            }) ;
            screen.Messages.Add(new Messages.TextMessage(OnCommand)
            {
                Text = Logic.Translator.GetText("EnterCompanyNameMessage", OnCommand.Message.From.LanguageCode)
            });

            screen.Show();
        }
    }
}
