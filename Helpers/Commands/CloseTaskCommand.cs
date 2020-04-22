using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Helpers.Commands
{
    public class CloseTaskCommand : BaseCommand
    {
        static CommandEnum _code = CommandEnum.CloseTask;
        static string _RU = $@"Окончить формулирование задачи";
        static string _EN = $@"Finish task defining";

        public CloseTaskCommand(Telegram.Bot.Types.Update update):base(update, _RU, _EN, _code)
        {

        }

        public CloseTaskCommand(List<KeyValuePair<string,string>> p):base(p)
        {
            base.Code = _code;
            base.RU = _RU;
            base.EN = _EN;
        }
    }
}
