using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Logic
{
    public class UserManager
    {
        public static void CreateNewUser(Telegram.Bot.Types.User from)
        {
            using (Models.TContext model = new Models.TContext()) { 
                if(model.User.Count(x=>x.TelegramId == from.Id) == 0)
                {
                    model.Add(new Models.User() {
                        Name = $"{from.FirstName} {from.LastName}",
                        TelegramId = from.Id                        
                    }); ;
                }
            }
        }

        public static bool IsUserExists(Telegram.Bot.Types.User from)
        {
            using (Models.TContext model = new Models.TContext())
            {
                return (model.User.Count(x => x.TelegramId == from.Id) > 0);
            }
        }

        public static List<Models.User> getMyUsers(Telegram.Bot.Types.Message message)
        {
            List<Models.User> ret = new List<Models.User>();
            using (TaskManager.Models.TContext model = new Models.TContext())
            {
                if(model.User.Count(x=>x.TelegramId == message.From.Id) > 0)
                {
                    var me = model.User.First(x => x.TelegramId == message.From.Id);
                    if(me.CompanyId != null)
                    {
                        ret = model.User.Where(x=>x.CompanyId == me.CompanyId).ToList();
                    }
                }                
            }
            return ret;
        }
    }
}
