using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Helpers.CommandExecutors
{
    public interface ICommandExecutor
    {
        void Run(Telegram.Bot.Types.Update update);
        bool TerminateFlow { get; set; }
        Commands.BaseCommand OnCommand { get; set; }
    }
}
