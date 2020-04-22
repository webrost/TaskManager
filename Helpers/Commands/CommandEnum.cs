using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Helpers.Commands
{
    public enum CommandEnum
    {
        Start,
        SelectUserForTask,
        ListUsersWithTasks,
        ListUserTasks,
        OpenNewTask,
        CloseTask,
        WriteMessageToOpenedTask,
        DefaultCommand,
        CreateNewCompany,
        JoinToCompany        
    }
}
