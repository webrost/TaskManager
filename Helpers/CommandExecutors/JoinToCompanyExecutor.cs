﻿using System;
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
    public class JoinToCompanyExecutor : ICommandExecutor
    {
        public bool TerminateFlow { get; set; }
        public Commands.BaseCommand OnCommand { get; set; }

        string secretCode = "";

        public void Run(Update update)
        {
            OnCommand = new Commands.JoinToCompanyCommand(update);
            TerminateFlow = OnCommand.IsCommandCatched;
            if (!OnCommand.IsCommandCatched) return;
            Action();
            Display();
        }

        void Action()
        {
            secretCode = Logic.UserManager.JoinToCompany(OnCommand.Message.Text, OnCommand.Message.From, OnCommand.Message.Chat);
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
                Text = Logic.Translator.GetText("JoinToCompanyMessage", OnCommand.Message.From.LanguageCode)
            }) ;

            screen.Show();
        }
    }
}
