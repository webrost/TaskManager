using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Helpers.Commands
{
    public class CreateNewCompanyCommand : BaseCommand
    {
        static CommandEnum _code = CommandEnum.CreateNewCompany;

        public CreateNewCompanyCommand(Telegram.Bot.Types.Update update):base(update, _code)
        {
            if(update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                Models.Company company = Logic.UserManager.GetCompany(update.Message.Text);
                if (Logic.UserManager.GetUserId(update.Message.Chat.Id) < 0 && company == null)
                {
                    base.IsCommandCatched = true;                    
                }
            }
        }

        public CreateNewCompanyCommand(Telegram.Bot.Types.Update update, List<KeyValuePair<string,string>> p):base(update, _code, p)
        {
        }
    }
}
