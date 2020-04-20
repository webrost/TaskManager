using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Buffers;
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
                        CreatedTime = DateTime.Now,
                        TelegramId = from.Id                        
                    });
                    model.SaveChanges();
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
            using (Models.TContext model = new Models.TContext())
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

        public static List<Models.Task> getUserTask(string userid)
        {
            List<Models.Task> ret = new List<Models.Task>();
            int userId = int.Parse(userid);
            using (Models.TContext model = new Models.TContext())
            {
                ret = model.Task.Where(x => x.UserId == userId).ToList();
            }
            return ret;
        }

        public static int GetUserId(long telegramId)
        {
            int ret = -1;
            using (Models.TContext model = new Models.TContext())
            {
                if (model.User.Count(x => x.TelegramId == telegramId) > 0)
                {
                    ret = model.User.First(x => x.TelegramId == telegramId).Id;
                }
            }
            return ret;
        }

        public static string CreateNewCompany(string name)
        {
            Random rnd = new Random();
            string secretCode = "#"+rnd.Next(10000000, 99999999).ToString();
            using (Models.TContext model = new Models.TContext ()) {
                if (model.Company.Count(x=>x.Name == name) == 0)
                {
                    Models.Company c = new Models.Company();
                    c.Name = name;
                    c.SecretCode = secretCode;
                    model.Add(c);
                    model.SaveChanges();
                }
                else {
                    secretCode = model.Company.First(x => x.Name == name).SecretCode;
                }
            }
            return secretCode;
        }

        public static string JoinToCompany(string secretCode, int telegramUserId)
        {
            using (Models.TContext model = new Models.TContext())
            {
                if (model.User.Count(x => x.TelegramId == telegramUserId) > 0)
                {
                    if (model.Company.Count(x=>x.SecretCode == secretCode) > 0) {
                        Models.Company c = model.Company.First(x => x.SecretCode == secretCode);

                        Models.User u = model.User.First(x => x.TelegramId == telegramUserId);
                        u.CompanyId = c.Id;
                        model.SaveChanges();
                    }
                }
            }
            return "";
        }
    }
}
