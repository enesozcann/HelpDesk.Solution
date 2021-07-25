using HelpDesk.DataAccesLayer;
using HelpDesk.Entities;
using System;

namespace HelpDesk.BusinessLayer
{
    public class Test
    {
        private HDRepository<HDUser> r_user = new HDRepository<HDUser>();
        
        public Test()
        {
            // List<HDUser> HDUser = repo.List(x => x.Id > 1);
            HDDatabaseContext context = new HDDatabaseContext();
            context.Database.CreateIfNotExists();
        }

        public void Insert()
        {
            int result = r_user.Insert(new HDUser()
            {
                Name = "Mehhmet",
                Surname = "Laygısız",
                Ip = "192.168.1.2",
                IsModerator = true,
                IsAdmin = false,
                UserName = "ahmdlkygsz",
                Password = "dwqdqwd",
                CreatedOn = DateTime.Now,
                IsModified = true,
                ModifiedOn = DateTime.Now.AddHours(1),
                Department = 4
            });
        }
    }
}