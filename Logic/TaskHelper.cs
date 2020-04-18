using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Logic
{
    public class TaskHelper
    {
        public List<Models.Company> getCompanies()
        {
            List<Models.Company> ret = new List<Models.Company>();
            using (TaskManager.Models.TContext model = new Models.TContext())
            {
                ret = model.Company.ToList();
            }
            return ret;
        }

        public List<Models.User> getUsers()
        {
            List<Models.User> ret = new List<Models.User>();
            using (TaskManager.Models.TContext model = new Models.TContext())
            {
                ret = model.User.ToList();
            }
            return ret;
        }
    }
}
