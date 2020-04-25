using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Helpers.Commands
{
    public class WriteMessageToOpenedTaskCommand : BaseCommand
    {
        static CommandEnum _code = CommandEnum.WriteMessageToOpenedTask;

        public WriteMessageToOpenedTaskCommand(Telegram.Bot.Types.Update update):base(update, _code)
        {
            if(update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                if (Logic.TaskManager.GetOpenedEditTaskId(update.Message.From.Id) >= 0)
                {
                    base.IsCommandCatched = true;
                }
            }
        }

        public WriteMessageToOpenedTaskCommand(Telegram.Bot.Types.Update update, List<KeyValuePair<string, string>> p) : base(update, _code, p)
        {

        }
    }
}
