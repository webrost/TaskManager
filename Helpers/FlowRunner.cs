using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Helpers.CommandExecutors;
using Microsoft.AspNetCore.Hosting;

namespace TaskManager.Helpers
{
    public class FlowRunner
    {
        List<ICommandExecutor> Executors { get; set; }

        public static IHostingEnvironment hostingEnvironment { get; set; }

        public FlowRunner()
        {
            Executors = new List<ICommandExecutor>();

            ///---- Create company executors
            Executors.Add(new StartExecutor());
            Executors.Add(new CreateNewCompanyExecutor());
            Executors.Add(new JoinToCompanyExecutor());


            Executors.Add(new SelectUserForTaskExecutor());
            Executors.Add(new ListUsersWithTasksExecutor());
            Executors.Add(new ListUserTasksExecutor());
            Executors.Add(new OpenNewTaskExecutor());
            Executors.Add(new CloseTaskExecutor());

            ///-----Last executors-----
            Executors.Add(new WriteMessageToOpenedTaskExecutor());
            Executors.Add(new DefaultExecutor());
        }

        public void Execute(Telegram.Bot.Types.Update update)
        {
            foreach(var executor in Executors)
            {
                executor.Run(update);
                if (executor.TerminateFlow) break;
            }
        }
    }
}
