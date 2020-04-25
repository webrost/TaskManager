using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TaskManager.Helpers.Commands
{
    public class BaseCommand
    {
        public CommandEnum Code { get; set; }
        public string Text { get; set; }
        public string RawText { get; set; }
        public bool IsCommandCatched { get; set; }
        public CommandTypeEnum Type { get; set; }
        public long ChatId { get; set; }
        public long FromId { get; set; }
        public List<KeyValuePair<string,string>> Parameters {get; set; }
        public Telegram.Bot.Types.Message Message { get; set; }
        public Telegram.Bot.Types.Update Update { get; set; }
        public BaseCommand(Telegram.Bot.Types.Update update, CommandEnum code) {
            IsCommandCatched = false;
            Code = code;
            Text = Logic.Translator.GetText(code.ToString(), update);
            Update = update;
            switch (update.Type)
            {
                case Telegram.Bot.Types.Enums.UpdateType.Message:
                    Type = CommandTypeEnum.Keyboard;
                    RawText = update.Message.Text;
                    ChatId = update.Message.Chat.Id;
                    FromId = update.Message.From.Id;
                    Message = update.Message;
                    if (RawText == Text) {
                        IsCommandCatched = true;
                    }
                    break;
                case Telegram.Bot.Types.Enums.UpdateType.CallbackQuery:
                    RawText = update.CallbackQuery.Data;
                    Type = CommandTypeEnum.Inline;
                    ChatId = update.CallbackQuery.Message.Chat.Id;
                    FromId = update.CallbackQuery.Message.From.Id;
                    Message = update.CallbackQuery.Message;
                    if (RawText.Split('?').Length > 1)
                    {
                        Parameters = RawText.Split('?')[1].Split('&').Select(x => new KeyValuePair<string, string>(x.Split('=')[0], x.Split('=')[1])).ToList();
                    }
                    if (RawText.Split('?')[0] == Code.ToString())
                    {
                        IsCommandCatched = true;
                    }
                    break;
            }
        }
        public BaseCommand(Telegram.Bot.Types.Update update, CommandEnum code, List<KeyValuePair<string, string>> p)
        {
            Parameters = p;
            Update = update;
            Code = code;
            Text = Logic.Translator.GetText(code.ToString(), update);
            switch (update.Type)
            {
                case Telegram.Bot.Types.Enums.UpdateType.Message:
                    Type = CommandTypeEnum.Keyboard;
                    RawText = update.Message.Text;
                    ChatId = update.Message.Chat.Id;
                    FromId = update.Message.From.Id;
                    Message = update.Message;
                    if (RawText == Text)
                    {
                        IsCommandCatched = true;
                    }
                    break;
                case Telegram.Bot.Types.Enums.UpdateType.CallbackQuery:
                    RawText = update.CallbackQuery.Data;
                    Type = CommandTypeEnum.Inline;
                    ChatId = update.CallbackQuery.Message.Chat.Id;
                    FromId = update.CallbackQuery.Message.From.Id;
                    Message = update.CallbackQuery.Message;
                    if (RawText.Split('?').Length > 1)
                    {
                        Parameters = RawText.Split('?')[1].Split('&').Select(x => new KeyValuePair<string, string>(x.Split('=')[0], x.Split('=')[1])).ToList();
                    }
                    if (RawText.Split('?')[0] == Code.ToString())
                    {
                        IsCommandCatched = true;
                    }
                    break;
            }
        }
    }
}
