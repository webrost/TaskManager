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
        public static bool IsUserExists(Telegram.Bot.Types.User from)
        {
            using (Models.TContext model = new Models.TContext())
            {
                return (model.User.Count(x => x.TelegramId == from.Id) > 0);
            }
        }

        public static List<Models.User> getMyUsers(Helpers.Commands.BaseCommand command)
        {
            List<Models.User> ret = new List<Models.User>();
            using (Models.TContext model = new Models.TContext())
            {
                if(model.User.Count(x=>x.TelegramId == command.FromId) > 0)
                {
                    var me = model.User.First(x => x.TelegramId == command.FromId);
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

        public static List<Models.Task> GetUserTasks(int userId)
        {
            List<Models.Task> ret = new List<Models.Task>();
            using (Models.TContext model = new Models.TContext())
            {
                ret = model.Task.Where(x => x.UserId == userId).ToList();
            }
            return ret;
        }

        public static Models.User GetUser(int userId)
        {
            Models.User ret = new Models.User();
            using (Models.TContext model = new Models.TContext())
            {
                ret = model.User.First(x => x.Id == userId);
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

        public static Models.Company GetCompany(string secretCode)
        {
            Models.Company ret = null;
            using (Models.TContext model = new Models.TContext())
            {
                if (model.Company.Count(x => x.SecretCode == secretCode) > 0)
                {
                    ret = model.Company.First(x => x.SecretCode == secretCode);
                }
            }
            return ret;
        }

        public static string CreateNewCompany(string name, Telegram.Bot.Types.User from, Telegram.Bot.Types.Chat chat)
        {
            Random rnd = new Random();
            Models.Company c = new Models.Company();
            string secretCode = "_"+rnd.Next(10000000, 99999999).ToString();
            using (Models.TContext model = new Models.TContext ()) {
                if (model.Company.Count(x=>x.Name == name) == 0)
                {                    
                    c.Name = name;
                    c.SecretCode = secretCode;
                    model.Add(c);
                    model.SaveChanges();

                    int roleId = model.Role.First(x => x.Name == "Boss").Id;
                    model.Add(new Models.User()
                    {
                        Name = $"{from.FirstName} {from.LastName}",
                        CreatedTime = DateTime.Now,
                        TelegramId = from.Id,
                        CompanyId = c.Id,
                        RoleId = roleId,
                        TelegramChatId = chat.Id.ToString()
                    });
                    model.SaveChanges();
                }


            }
            return secretCode;
        }

        public static string JoinToCompany(string secretCode, Telegram.Bot.Types.User from, Telegram.Bot.Types.Chat chat)
        {
            using (Models.TContext model = new Models.TContext())
            {
                if (model.User.Count(x => x.TelegramId == from.Id) == 0)
                {
                    if (model.Company.Count(x=>x.SecretCode == secretCode) > 0) {
                        Models.Company c = model.Company.First(x => x.SecretCode == secretCode);

                        int roleId = model.Role.First(x => x.Name == "Subordinator").Id;
                        model.Add(new Models.User()
                        {
                            Name = $"{from.FirstName} {from.LastName}",
                            CreatedTime = DateTime.Now,
                            TelegramId = from.Id,
                            CompanyId = c.Id,
                            RoleId = roleId,
                            TelegramChatId = chat.Id.ToString()
                        });
                        model.SaveChanges();
                    }
                }
            }
            return "";
        }
    }
}
