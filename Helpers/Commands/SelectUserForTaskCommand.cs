using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Helpers.Commands
{
    public class SelectUserForTaskCommand : BaseCommand
    {
        static CommandEnum _code = CommandEnum.SelectUserForTask;

        public SelectUserForTaskCommand(Telegram.Bot.Types.Update update):base(update,_code)
        {
        }

        public SelectUserForTaskCommand(Telegram.Bot.Types.Update update, List<KeyValuePair<string, string>> p) : base(update, _code, p)
        {


        }
    }
}
