using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Helpers.Commands
{
    public class OpenNewTaskCommand : BaseCommand
    {
        static CommandEnum _code = CommandEnum.OpenNewTask;
        static string _RU = $@"Создать новую задачу";
        static string _EN = $@"Create new task";

        public OpenNewTaskCommand(Telegram.Bot.Types.Update update):base(update, _RU, _EN, _code)
        {

        }

        public OpenNewTaskCommand(List<KeyValuePair<string,string>> p):base(p)
        {
            base.Code = _code;
            base.RU = _RU;
            base.EN = _EN;
        }
    }
}
