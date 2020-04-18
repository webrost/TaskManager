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
        public string testc()
        {
            return "Hello world";
        }

        [HttpPost("webhook")]
        public void WebHook()
        {
            using (var reader = new System.IO.StreamReader(ControllerContext.HttpContext.Request.Body, System.Text.Encoding.UTF8))
            {
                string value = reader.ReadToEndAsync().Result;
                TelUpdate update = JsonConvert.DeserializeObject<TelUpdate>(value);

                var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                {
                    Keyboard = new[] {
                        new[] // row 1
                        {
                            new KeyboardButton("Первая кнопко"),
                            new KeyboardButton("Вторая кнопко"),
                        },
                    },
                    ResizeKeyboard = true
                };

                client.SendTextMessageAsync(update.message.chat.id, $"xxxxxxxxxxxxx", replyMarkup: keyboard);

            }

            //if (update == null) return;
            //var message = update.Message;


            //if (message?.Type == MessageType.ContactMessage)
            //{

            //}
        }

    }

}