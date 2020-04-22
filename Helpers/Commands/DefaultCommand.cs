using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Helpers.Commands
{
    public class DefaultCommand : BaseCommand
    {
        static CommandEnum _code = CommandEnum.DefaultCommand;
        static string _RU = $@"";
        static string _EN = $@"";

        public DefaultCommand(Telegram.Bot.Types.Update update):base(update,_RU,_EN,_code)
        {
        }

        public DefaultCommand(List<KeyValuePair<string,string>> p):base(p)
        {
            base.Code = _code;
            base.RU = _RU;
            base.EN = _EN;
        }
    }
}
