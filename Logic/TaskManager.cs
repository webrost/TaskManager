using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Logic
{
    public class TaskManager
    {
        public static int OpenNewTaskForEdit(Telegram.Bot.Types.Message message, int telegramUserId)
        {
            using (Models.TContext model = new Models.TContext())
            {
                var task = new Models.Task()
                {
                    Name = "",
                    CreatedTime = DateTime.Now,
                    CreatedBy = UserManager.GetUserId(message.From.Id),
                    UserId = UserManager.GetUserId(telegramUserId),
                    TechStatus = TechStatusEnum.InEdit.ToString()
                };
                model.Task.Add(task);
                model.SaveChanges();
                return task.Id;
            }
        }

        public static int GetOpenedEditTaskId(Telegram.Bot.Types.Message message)
        {
            int ret = -1;
            using (Models.TContext model = new Models.TContext())
            {
                var me = model.User.First(x => x.TelegramId == message.From.Id);
                if(model.Task.Count(x=>x.CreatedBy == me.Id && x.TechStatus == Models.TechStatusEnum.InEdit.ToString()) > 0)
                {
                    ret = model.Task.First(x => x.CreatedBy == me.Id && x.TechStatus == Models.TechStatusEnum.InEdit.ToString()).Id;
                }
                model.SaveChanges();
            }
            return ret;
        }

        public static void CloseOpenedEditTasks(Telegram.Bot.Types.Message message)
        {
            using (Models.TContext model = new Models.TContext())
            {
                foreach(var task in model.Task.Where(x=>x.CreatedBy == message.From.Id
                && x.TechStatus == Models.TechStatusEnum.InEdit.ToString()))
                {
                    task.TechStatus = Models.TechStatusEnum.CompleteEdit.ToString();
                }
                model.SaveChanges();
            }
        }

        public static int AddMessage(Telegram.Bot.Types.Message message)
        {
            int ret = 1;
            int taskId = GetOpenedEditTaskId(message);
            using (Models.TContext model = new Models.TContext())
            {
                var m = new Models.Message();
                m.TelegramChatId = message.Chat.Id;
                m.TelegramMessageId = message.MessageId;
                m.TaskId = taskId;
                m.CreatedId = message.From.Id;
                m.CreatedTime = DateTime.Now;
                model.Message.Add(m);
                model.SaveChanges();

                switch (message.Type)
                {
                    case Telegram.Bot.Types.Enums.MessageType.Text:
                        m.Text = message.Text;
                        m.Type = message.Type.ToString();
                        model.SaveChanges();
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Document:
                        Models.Files file = new Files();
                        file.MessageId = m.Id;
                        file.FileName = message.Document.FileName;
                        file.FileId = message.Document.FileId;
                        file.FileSize = message.Document.FileSize;
                        file.FileUniqueId = message.Document.FileUniqueId;
                        file.MimeType = message.Document.MimeType;
                        file.Type = Telegram.Bot.Types.Enums.MessageType.Document.ToString();
                        model.Files.Add(file);
                        model.SaveChanges();
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Video:
                        Models.Files video = new Files();
                        video.MessageId = m.Id;
                        video.FileId = message.Video.FileId;
                        video.FileSize = message.Video.FileSize;
                        video.FileUniqueId = message.Video.FileUniqueId;
                        video.MimeType = message.Video.MimeType;
                        video.Duration = message.Video.Duration;
                        video.Width = message.Video.Width;
                        video.Height = message.Video.Height;
                        video.Type = Telegram.Bot.Types.Enums.MessageType.Video.ToString();
                        model.Files.Add(video);
                        model.SaveChanges();
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.VideoNote:
                        Models.Files videoNote = new Files();
                        videoNote.MessageId = m.Id;
                        videoNote.FileId = message.VideoNote.FileId;
                        videoNote.FileSize = message.VideoNote.FileSize;
                        videoNote.FileUniqueId = message.VideoNote.FileUniqueId;
                        videoNote.Duration = message.VideoNote.Duration;
                        videoNote.Type = Telegram.Bot.Types.Enums.MessageType.VideoNote.ToString();
                        model.Files.Add(videoNote);
                        model.SaveChanges();
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Voice:
                        Models.Files voice = new Files();
                        voice.MessageId = m.Id;
                        voice.FileId = message.Voice.FileId;
                        voice.FileSize = message.Voice.FileSize;
                        voice.FileUniqueId = message.Voice.FileUniqueId;
                        voice.Duration = message.Voice.Duration;
                        voice.MimeType = message.Voice.MimeType;
                        voice.Type = Telegram.Bot.Types.Enums.MessageType.Voice.ToString();
                        model.Files.Add(voice);
                        model.SaveChanges();
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Photo:
                        foreach(var photo in message.Photo)
                        {
                            Models.Files p = new Files();
                            p.MessageId = m.Id;
                            p.FileId = photo.FileId;
                            p.FileSize = photo.FileSize;
                            p.FileUniqueId = photo.FileUniqueId;
                            p.Width = photo.Width;
                            p.Height = photo.Height;
                            p.Type = Telegram.Bot.Types.Enums.MessageType.Photo.ToString();
                            model.Files.Add(p);
                            model.SaveChanges();
                        }
                        break;
                    default:
                        break;
                }                
                model.SaveChanges();
                ret = m.Id;
            }
            return ret;
        }
}
}
