using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TaskManager.Models;
using Telegram.Bot.Types.ReplyMarkups;

namespace TaskManager.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MainController : ControllerBase
    {

        private static TelegramBotClient client;

        public MainController(IOptions<Models.BotConfig> config)
        {
            string token = config.Value.TelegramBotTocken;
            client = new TelegramBotClient(token);
        }

        /// <summary>
        /// test
        /// </summary>
        /// <returns></returns>
        [HttpGet("test")]
        public List<Models.User> testc()
        {
            List<Models.User> m = new List<Models.User>();
            return m;           
        }

        [HttpPost("webhook")]
        public void WebHook()
        {
            using (var reader = new System.IO.StreamReader(ControllerContext.HttpContext.Request.Body, System.Text.Encoding.UTF8))
            {
                string value = reader.ReadToEndAsync().Result;
                Telegram.Bot.Types.Update update = JsonConvert.DeserializeObject<Telegram.Bot.Types.Update>(value);

                var x = update.Type;
                switch (update.Type) {
                    case Telegram.Bot.Types.Enums.UpdateType.Message:
                        Logic.Router.RunCommand(update.Message, client);
                        break;
                    case Telegram.Bot.Types.Enums.UpdateType.CallbackQuery:
                        Logic.Router.RunInlineCommand(update.CallbackQuery,client);
                        break;
                }
                                
            }
        }

    }

}