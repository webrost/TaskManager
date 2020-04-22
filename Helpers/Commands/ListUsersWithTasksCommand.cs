using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Helpers.Commands
{
    public class ListUsersWithTasksCommand : BaseCommand
    {
        static CommandEnum _code = CommandEnum.ListUsersWithTasks;
        static string _RU = $@"Показать задачи сотрудников";
        static string _EN = $@"Show subbordinator tasks";

        public ListUsersWithTasksCommand(Telegram.Bot.Types.Update update):base(update, _RU, _EN, _code)
        {
        }

        public ListUsersWithTasksCommand(List<KeyValuePair<string,string>> p):base(p)
        {
            base.Code = _code;
            base.RU = _RU;
            base.EN = _EN;
        }
    }
}
