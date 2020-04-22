using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Helpers.Commands
{
    public class WriteMessageToOpenedTaskCommand : BaseCommand
    {
        static CommandEnum _code = CommandEnum.WriteMessageToOpenedTask;
        static string _RU = $@"";
        static string _EN = $@"";

        public WriteMessageToOpenedTaskCommand(Telegram.Bot.Types.Update update):base(update, _RU, _EN, _code)
        {
            if(update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                if (Logic.TaskManager.GetOpenedEditTaskId(update.Message.From.Id) >= 0)
                {
                    base.IsCommandCatched = true;
                }
            }
        }

        public WriteMessageToOpenedTaskCommand(List<KeyValuePair<string,string>> p):base(p)
        {
            base.Code = _code;
            base.RU = _RU;
            base.EN = _EN;
        }
    }
}
