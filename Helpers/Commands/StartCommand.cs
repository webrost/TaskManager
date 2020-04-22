using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Helpers.Commands
{
    public class StartCommand : BaseCommand
    {
        static CommandEnum _code = CommandEnum.Start;
        static string _RU = $@"Создать компанию";
        static string _EN = $@"Create company";

        public StartCommand(Telegram.Bot.Types.Update update):base(update, _RU, _EN, _code)
        {
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                if (update.Message.Text.ToLower() == "/start")
                {
                    base.IsCommandCatched = true;
                }
            }
        }

        public StartCommand(List<KeyValuePair<string,string>> p):base(p)
        {
            base.Code = _code;
            base.RU = _RU;
            base.EN = _EN;
        }
    }
}
