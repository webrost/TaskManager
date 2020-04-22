using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Helpers.Commands
{
    public class JoinToCompanyCommand : BaseCommand
    {
        static CommandEnum _code = CommandEnum.JoinToCompany;
        static string _RU = $@"Создать новую компанию";
        static string _EN = $@"Create new company";

        public JoinToCompanyCommand(Telegram.Bot.Types.Update update):base(update, _RU, _EN, _code)
        {
            if(update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                Models.Company company = Logic.UserManager.GetCompany(update.Message.Text);
                if (Logic.UserManager.GetUserId(update.Message.Chat.Id) < 0 && company != null)
                {
                    base.IsCommandCatched = true;                    
                }
            }
        }

        public JoinToCompanyCommand(List<KeyValuePair<string,string>> p):base(p)
        {
            base.Code = _code;
            base.RU = _RU;
            base.EN = _EN;
        }
    }
}
