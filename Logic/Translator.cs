using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TaskManager.Helpers;

namespace TaskManager.Logic
{
    public class Translator
    {
        public static string GetText(string textid
            , Telegram.Bot.Types.Update update
            , List<KeyValuePair<string,string>> parameters = null
            ) {

            string ret = "";
            string rootPath = FlowRunner.hostingEnvironment.ContentRootPath;
            string fileContent = File.ReadAllText(Path.Combine(rootPath, "text.json"));

            List<Models.localizedMessage> messages = 
            Newtonsoft.Json.JsonConvert.DeserializeObject<List<Models.localizedMessage>>(fileContent);

            string currLang = "en";
            switch(update.Type)
            {
                case Telegram.Bot.Types.Enums.UpdateType.Message:
                    currLang = update.Message.From.LanguageCode;
                    break;
                case Telegram.Bot.Types.Enums.UpdateType.CallbackQuery:
                    currLang = update.CallbackQuery.Message.From.LanguageCode;
                    break;
                default:break;
            }

            if (messages.Count(x => x.id == textid) > 0)
            { 
                switch(currLang)
                {
                    case "ru":
                        ret = messages.First(x => x.id == textid).ru;
                        break;
                    default:
                        ret = messages.First(x => x.id == textid).en;
                        break;
                }                
            }
            else {
                ret = "Translation not found";
            }

            if (parameters != null) {
                parameters.ForEach(p =>
                    ret = ret.Replace(@"{{"+p.Key+"}}",p.Value)
                ) ;
            }

            return ret;
        }

        public static string GetText(string textid, string currLang, List<KeyValuePair<string, string>> parameters = null)
        {

            string ret = "";
            string rootPath = FlowRunner.hostingEnvironment.ContentRootPath;
            string fileContent = File.ReadAllText(Path.Combine(rootPath, "text.json"));

            List<Models.localizedMessage> messages =
            Newtonsoft.Json.JsonConvert.DeserializeObject<List<Models.localizedMessage>>(fileContent);

            if (messages.Count(x => x.id == textid) > 0)
            {
                switch (currLang)
                {
                    case "ru":
                        ret = messages.First(x => x.id == textid).ru;
                        break;
                    default:
                        ret = messages.First(x => x.id == textid).en;
                        break;
                }
            }
            else
            {
                ret = "Translation not found";
            }

            if (parameters != null)
            {
                parameters.ForEach(p =>
                    ret = ret.Replace(@"{{" + p.Key + "}}", p.Value)
                );
            }

            return ret;
        }
    }
}
