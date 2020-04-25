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
using TaskManager.Helpers;
using Microsoft.AspNetCore.Hosting;

namespace TaskManager.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MainController : ControllerBase
    {

        private static TelegramBotClient client;
        private IHostingEnvironment _hostingEnv;

        public MainController(IOptions<Models.BotConfig> config, IHostingEnvironment hostingEnv)
        {
            string token = config.Value.TelegramBotTocken;
            _hostingEnv = hostingEnv;
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
            Telegram.Bot.Types.ChatId chatId = new ChatId(303268292);            
            client.SendTextMessageAsync(chatId,"xxxxx");
            return m;           
        }

        [HttpPost("webhook")]
        public void WebHook()
        {
            using (var reader = new System.IO.StreamReader(ControllerContext.HttpContext.Request.Body, System.Text.Encoding.UTF8))
            {
                string value = reader.ReadToEndAsync().Result;
                Telegram.Bot.Types.Update update = JsonConvert.DeserializeObject<Telegram.Bot.Types.Update>(value);
                FlowRunner.hostingEnvironment = _hostingEnv;
                FlowRunner flowRunner = new FlowRunner();                
                flowRunner.Execute(update);
            }
        }

    }

}