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
            dictionary.Add(new KeyValuePair<string, string>("SubordinateTasks","Назначенные задачи"));
            dictionary.Add(new KeyValuePair<string, string>("StartCreateTask", "Начать формулировку задачи"));
            dictionary.Add(new KeyValuePair<string, string>("EndCreateTask", "Закончить формулировку задачи"));
        }

        public string GetCommand(string text)
        {
            return dictionary.FirstOrDefault(x => x.Value == text).Key;
        }

        public string GetText(string command)
        {
            return dictionary.FirstOrDefault(x => x.Key == command).Value;
        }
    }
}
