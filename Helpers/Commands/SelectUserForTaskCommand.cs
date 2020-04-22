using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Helpers.Commands
{
    public class SelectUserForTaskCommand : BaseCommand
    {
        static CommandEnum _code = CommandEnum.SelectUserForTask;
        static string _RU = $@"Назначить задачу";
        static string _EN = $@"Assign task";

        public SelectUserForTaskCommand(Telegram.Bot.Types.Update update):base(update,_RU, _EN, _code)
        {
        }

        public SelectUserForTaskCommand(List<KeyValuePair<string,string>> p):base(p)
        {
            base.Code = _code;
            base.RU = _RU;
            base.EN = _EN;
        }
    }
}
