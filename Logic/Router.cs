using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Logic
{
    public class Router
    {
        //public static void RunCommand(Telegram.Bot.Types.Message message, Telegram.Bot.TelegramBotClient client)
        //{
        //    Logic.CommandManager cm = new CommandManager();
        //    List<Models.KeyboardCommandEnum> commands = new List<Models.KeyboardCommandEnum>();
        //    List<Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton> buttons = new List<Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton>();

        //    ///---Keyboard Commands
        //        string command = cm.GetCommand(message.Text);
        //        Models.KeyboardCommandEnum cmd = KeyboardCommandEnum.UnknownCommand;
        //        if (command != null)
        //        {
        //            cmd = (Models.KeyboardCommandEnum)Enum.Parse(typeof(Models.KeyboardCommandEnum), command);
        //        }
                
        //        switch (cmd)
        //        {
        //            ///------------------------------------------------------------------
        //            case Models.KeyboardCommandEnum.GetSubordinateTasks:
        //                buttons.Clear();
        //                Models.TasksInfo userTaskInfo = new TasksInfo();
        //            foreach (var user in UserManager.getMyUsers(message))
        //                {
        //                userTaskInfo = TaskManager.GetTaskCount(user.Id);
        //                buttons.Add(new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton()
        //                    {                            
        //                        Text = $"{user.Name} ({userTaskInfo.CompletedTask}/{userTaskInfo.CountAllTask})",
        //                        CallbackData = InlineCommandEnum.ShowUserTasks.ToString()
        //                        + $"?userid={user.Id}"
        //                    }); ;
        //                }

        //                Screen.SendInlineKeys($"Выберите, человека, задачи которого Вы хотите просмотреть",
        //                    buttons, client, message.Chat);
        //            break;

        //            ///------------------------------------------------------------------
        //            case Models.KeyboardCommandEnum.SelectUserForTask:
        //                buttons.Clear();
        //                foreach(var user in UserManager.getMyUsers(message))
        //                {
        //                    buttons.Add(new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton()
        //                    {
        //                        Text = $"{user.Name} (0)",
        //                        CallbackData = InlineCommandEnum.CreateTask.ToString()
        //                        + $"?userid={user.Id}"
        //                    }) ;
        //                }

        //                Screen.SendInlineKeys($"Выберите, кому хотите назначить задачу",
        //                    buttons, client, message.Chat);
        //                break;

        //            ///------------------------------------------------------------------
        //            case Models.KeyboardCommandEnum.EndCreateTask:
        //                TaskManager.CloseOpenedEditTasks(message);
        //                commands.Clear();
        //                commands.Add(Models.KeyboardCommandEnum.GetSubordinateTasks);
        //                commands.Add(Models.KeyboardCommandEnum.SelectUserForTask);
        //                Screen.SendKeyboard($"Чтобы добавить или просмотреть задачи, нажмите на соответствующие кнопки ниже",
        //                    commands, client, message.Chat);
        //            break;

        //            ///------------------------------------------------------------------
        //            case KeyboardCommandEnum.UnknownCommand:
        //            if (UserManager.GetUserId(message.From.Id) >= 0) {
        //                if (TaskManager.GetOpenedEditTaskId(message) > 0)
        //                {
        //                    TaskManager.AddMessage(message, client);

        //                    commands.Clear();
        //                    commands.Add(Models.KeyboardCommandEnum.EndCreateTask);
        //                    Screen.SendKeyboard($"Добавьте еще описания или нажмите кнопку <i>Готово</i>",
        //                        commands, client, message.Chat);
        //                }
        //                else {
        //                    commands.Clear();
        //                    commands.Add(Models.KeyboardCommandEnum.GetSubordinateTasks);
        //                    commands.Add(Models.KeyboardCommandEnum.SelectUserForTask);
        //                    Screen.SendKeyboard($"Чтобы добавить или просмотреть задачи, нажмите на соответствующие кнопки ниже",
        //                        commands, client, message.Chat);
        //                }
        //            }
        //            else
        //            {
        //                if (message.Text.ToLower() == @"/start")
        //                {
        //                    Screen.SendText($@"Введите название Своей Компании для регистрации или введите код приглашения.", client, message.Chat);
        //                }
        //                else { 
        //                    Models.Company company = UserManager.GetCompany(message.Text);
        //                    if (company != null)
        //                    {
        //                        UserManager.JoinToCompany(message.Text, message.From, message.Chat);
        //                        Screen.SendText($@"Вы добавлены как сотрудник компании <i>{company.Name}</i>",client, message.Chat);
        //                    }
        //                    else
        //                    {
        //                        string secretCode = UserManager.CreateNewCompany(message.Text, message.From, message.Chat);
        //                        Screen.SendText($@"Вы успешно зарегистрировали компанию с именем <i>{message.Text}</i>.", client, message.Chat);
        //                        Screen.SendText($@"Добавьте сотрудников , переслав следующие 2 сообщения:", client, message.Chat);
        //                        Screen.SendText($@"Приглашаю тебя в Telegram бот для лёгкого коммуницирования и управления задачами. Перейди по ссылке @taskmanagerv1bot, нажми кнопу кнопу <i>/start</i> и введи следующий код:", client, message.Chat);
        //                        Screen.SendText($@"{secretCode}", client, message.Chat);
        //                        commands.Clear();
        //                        commands.Add(Models.KeyboardCommandEnum.GetSubordinateTasks);
        //                        commands.Add(Models.KeyboardCommandEnum.SelectUserForTask);
        //                        Screen.SendKeyboard($"Чтобы добавить или просмотреть задачи, нажмите на соответствующие кнопки ниже",
        //                            commands, client, message.Chat);
        //                    }                           
        //                }
                     
        //            }
        //                break;
        //        }
                        
        //}

        //public static void RunInlineCommand(Telegram.Bot.Types.CallbackQuery inline, Telegram.Bot.TelegramBotClient client, Telegram.Bot.Types.CallbackQuery message)
        //{
        //    Logic.CommandManager cm = new CommandManager();

        //    List<Models.KeyboardCommandEnum> commands = new List<Models.KeyboardCommandEnum>();
        //    List<KeyValuePair<string,string>> p = cm.GetInlineParameters(inline.Data);
        //    string command = cm.GetInlineCommand(inline.Data);
        //    InlineCommandEnum cmd = (InlineCommandEnum)Enum.Parse(typeof(InlineCommandEnum),command);

        //    ///--Inline command
        //    switch(cmd)
        //    {
        //        ///------------------------------------------------------------------
        //        case InlineCommandEnum.ShowUserTasks:
        //            List<Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton> buttons = new List<Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton>();

        //            User a = UserManager.GetUser(int.Parse(p.First(x => x.Key == "userid").Value));
        //            Logic.Screen.SendText($"<b>Задачи у <i>{a.Name}</i></b>:", client, message.Message.Chat);
        //            foreach (var task in UserManager.GetUserTasks(int.Parse(p.First(x=>x.Key=="userid").Value)))
        //            {
        //                buttons.Clear();
        //                buttons.Add(new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton()
        //                {
        //                    Text = "Редактировавть",
        //                    CallbackData = Models.InlineCommandEnum.EditTask.ToString() + "?taskid=" + task.Id
        //                });
        //                buttons.Add(new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton()
        //                {
        //                    Text = "Удалить",
        //                    CallbackData = Models.InlineCommandEnum.DeleteTask.ToString() + "?taskid=" + task.Id
        //                });
        //                int i = 0;
        //                string outData = "";
        //                foreach (var mess in TaskManager.GetMessages(task.Id).Where(x=>x.Type == "Text"))
        //                {
        //                    if(i==0)
        //                    {
        //                        outData += $"<b>{mess.Text}</b>";
        //                    }
        //                    else
        //                    {
        //                        outData += $"\n<i>· {mess.Text}</i>";
        //                    }
        //                    i++;
        //                }
        //                Logic.Screen.SendInlineKeysHorizontaly(outData, buttons, client, message.Message.Chat);
        //            }

        //            break;
        //        ///------------------------------------------------------------------
        //        case InlineCommandEnum.CreateTask:

        //            TaskManager.OpenNewTaskForEdit(message.Message, int.Parse(p.First(x => x.Key == "userid").Value));

        //            commands.Clear();
        //            commands.Add(Models.KeyboardCommandEnum.EndCreateTask);                    

        //            Screen.SendKeyboard($"Опишите задачу и добавьте вложения (фото, видео, голосовые сообщения, геолокации и т.д.), если нужно. После завершения нажмите кнопку <i>Готово</i>. Первое текстовое сообщение будет заглавным.",
        //                commands, client, message.Message.Chat);
        //            break;
        //    }
        //}
    }
}
