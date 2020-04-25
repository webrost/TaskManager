using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Helpers.Commands
{
    public class ListUsersWithTasksCommand : BaseCommand
    {
        static CommandEnum _code = CommandEnum.ListUsersWithTasks;

        public ListUsersWithTasksCommand(Telegram.Bot.Types.Update update):base(update, _code)
        {
        }

        public ListUsersWithTasksCommand(Telegram.Bot.Types.Update update, List<KeyValuePair<string, string>> p) : base(update, _code, p)
        {

        }
    }
}
