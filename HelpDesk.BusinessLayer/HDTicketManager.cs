using HelpDesk.DataAccesLayer;
using HelpDesk.Entities;
using HelpDesk.Entities.HDObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelpDesk.BusinessLayer
{
    public class HDTicketManager
    {
        private HDRepository<HDTicket> repo_ticket = new HDRepository<HDTicket>();

        public List<HDTicket> GetTicketList()
        {
            return repo_ticket.List();
        }

        public IQueryable<HDTicket> GetTicketMyList(HDUser user)
        {
            return repo_ticket.ListQ(x => x.Creator.Id == user.Id);
            //return repo_ticket.ListQ(x => x.Creator.Id == user.Id);

        }

        public HDDepartmentManager GetDepartment()
        {
            HDDepartmentManager hdm = new HDDepartmentManager();
            return hdm;
        }

        public HDTicket GetTicketDetail(int? id)
        {
            return repo_ticket.Find(x => x.Id == id);
        }

        public int InsertTicket(TicketCreateViewModel data, HDUser user)
        {
            int dbResult = repo_ticket.Insert(new HDTicket()
            {
                Title = data.Title,
                Content = data.Content,
                Status = 1,
                SolvedOn = DateTime.Now,
                CreatedOn = DateTime.Now,
                IsModified = false,
                ModifiedOn = DateTime.Now,
                Creator = user,
            });
            return dbResult;
        }

        public int UpdateTicket(HDTicket ticket)
        {
            return repo_ticket.Update(ticket);
        }

        //public HDBusinnesLResults<HDTicket> AuthUser(TicketCreateViewModel data)
        //{
        //    ////HDUser user = repo_ticket.Find(x => x.UserName == data.Username && x.Password == data.Password && x.IsModerator == true);
        //    //HDBusinnesLResults<HDUser> result = new HDBusinnesLResults<HDUser>();
        //    //if (user != null)
        //    //{
        //    //    result.Result = user;
        //    //    //w
        //    //}
        //    //else
        //    //{
        //    //    result.Errors.Add("Kullanıcı adı veya Parola yanlış.");
        //    //}
        //    //return result;
        //}
    }
}