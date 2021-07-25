using HelpDesk.DataAccesLayer;
using HelpDesk.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.DataAccesLayer
{
    public class HDInitializer : CreateDatabaseIfNotExists<HDDatabaseContext>
    {
        protected override void Seed(HDDatabaseContext context)
        {
            HDDepartmentCategory bilgi = new HDDepartmentCategory()
            {
                Title = "Bilgi İşlem",
                Description = "Bilgi İşlem",
                CreatedOn = DateTime.Now,
                IsModified = false,
                ModifiedOn = DateTime.Now
            };
           
            HDUser admin = new HDUser()
            {
                Name = "Enes",
                Surname = "Özcan",
                Ip = "::1",
                IsModerator = true,
                IsAdmin = true,
                UserName = "admin",
                Password = "123",
                Department = 1,
                CreatedOn = DateTime.Now,
                IsModified = false,
                ModifiedOn = DateTime.Now
            };
            context.HDUsers.Add(admin);
            HDTicket tickets = new HDTicket()
            {
                Title = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(10, 25)),
                Content = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                Status = 1,
                SolvedOn = DateTime.Now,
                CreatedOn = DateTime.Now,
                IsModified = false,
                ModifiedOn = DateTime.Now,
                Creator = admin
            };
            context.HDDepartmentCategorys.Add(bilgi);
            context.SaveChanges();
            //fake department
            for (int i = 0; i < 5; i++)
            {
                HDDepartmentCategory ornek = new HDDepartmentCategory()
                {
                    Title = FakeData.NameData.GetCompanyName(),
                    Description = FakeData.TextData.GetAlphabetical(15),
                    CreatedOn = FakeData.DateTimeData.GetDatetime(),
                    IsModified = false,
                    ModifiedOn = DateTime.Now
                };
                context.HDDepartmentCategorys.Add(ornek);
            }
            context.SaveChanges();

            //fake user
            for (int k = 0; k < 10; k++)
            {
                HDUser user = new HDUser()
                {
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Ip = FakeData.NetworkData.GetIpAddress(),
                    IsModerator = false,
                    IsAdmin = false,
                    Department = FakeData.NumberData.GetNumber(2, 6),
                    CreatedOn = DateTime.Now,
                    IsModified = false,
                    ModifiedOn = DateTime.Now
                };
                context.HDUsers.Add(user);
            }
            context.SaveChanges();

            //fake ticket
            for (int j = 0; j < 20; j++)
            {
                HDTicket ticket = new HDTicket()
                {
                    Title = FakeData.TextData.GetSentences(1),
                    Content = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                    Status = FakeData.NumberData.GetNumber(1,4),
                    SolvedOn = DateTime.Now,
                    CreatedOn = DateTime.Now,
                    IsModified = false,
                    ModifiedOn = DateTime.Now,
                    Creator = admin
                };
                context.HDTickets.Add(ticket);
            }
            context.SaveChanges();
            //fake reply
            for (int t = 0; t < 20; t++)
            {
                HDReply reply = new HDReply()
                {
                    Content = FakeData.TextData.GetSentences(1),
                    IsModified = false,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    OwnTicket = FakeData.NumberData.GetNumber(1, 20),
                    Creator = admin
                };
                context.HDReplys.Add(reply);
            }
            context.SaveChanges();
        }
    }
}

