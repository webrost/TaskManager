using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Requests;

namespace TaskManager.Logic
{
    public class CommandManager
    {
        List<KeyValuePair<string, string>> dictionary = new List<KeyValuePair<string, string>>();

        public CommandManager() {
            dictionary.Add(new KeyValuePair<string, string>(Models.KeyboardCommandEnum.GetSubordinateTasks.ToString(), @"Назначенные задачи  📋"));
            dictionary.Add(new KeyValuePair<string, string>(Models.KeyboardCommandEnum.SelectUserForTask.ToString(), "Назначить задачу   ✒"));
            dictionary.Add(new KeyValuePair<string, string>(Models.KeyboardCommandEnum.EndCreateTask.ToString(), "Готово"));
            //dictionary.Add(new KeyValuePair<string, string>("ShowArchive", "Архив   📁"));
        }

        public string GetCommand(string text)
        {
            return dictionary.FirstOrDefault(x => x.Value == text).Key;
        }

        public string GetText(string command)
        {
            return dictionary.FirstOrDefault(x => x.Key == command).Value;
        }

        public string GetInlineCommand(string data)
        {
            return data.Split('?').Length == 1 ? data : data.Split('?')[0];
        }

        public List<KeyValuePair<string,string>> GetInlineParameters(string data)
        {
            List<KeyValuePair<string, string>> ret = new List<KeyValuePair<string, string>>();
            if (data.Split('?').Length > 1) {
                ret = data.Split('?')[1].Split('&').Select(x => new KeyValuePair<string, string>(x.Split('=')[0], x.Split('=')[1])).ToList();
            } 
            return ret;
        }
    }
}
