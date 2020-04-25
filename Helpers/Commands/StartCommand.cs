using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Helpers.Commands
{
    public class StartCommand : BaseCommand
    {
        static CommandEnum _code = CommandEnum.Start;

        public StartCommand(Telegram.Bot.Types.Update update):base(update, _code)
        {            
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                if (update.Message.Text.ToLower() == "/start")
                {
                    base.IsCommandCatched = true;
                }
            }
        }

        public StartCommand(Telegram.Bot.Types.Update update, List<KeyValuePair<string, string>> p) : base(update, _code, p)
        {

        }
    }
}
