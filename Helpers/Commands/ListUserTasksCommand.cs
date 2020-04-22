using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Helpers.Commands
{
    public class ListUserTasksCommand : BaseCommand
    {
        static CommandEnum _code = CommandEnum.ListUserTasks;
        static string _RU = $@"Задачи по сотруднику";
        static string _EN = $@"User tasks";

        public ListUserTasksCommand(Telegram.Bot.Types.Update update):base(update, _RU, _EN, _code)
        {
        }

        public ListUserTasksCommand(List<KeyValuePair<string,string>> p):base(p)
        {
            base.Code = _code;
            base.RU = _RU;
            base.EN = _EN;
        }
    }
}
