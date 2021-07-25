using HelpDesk.DataAccesLayer;
using HelpDesk.Entities;
using HelpDesk.Entities.HDObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.BusinessLayer
{
    public class HDReplyManager
    {
        private HDRepository<HDReply> repo_reply = new HDRepository<HDReply>();

        public IQueryable<HDReply> GetReply(int? id)
        {
            return repo_reply.ListQ(x => x.OwnTicket == id);

            //return repo_reply.ListQ(x => x.OwnTicket.Id == id);
            
        }

        public int InsertReply(int id, string data, HDUser user)
        {
            int dbResult = repo_reply.Insert(new HDReply()
            {
                Content = data,
                CreatedOn = DateTime.Now,
                IsModified = false,
                ModifiedOn = DateTime.Now,
                Creator = user,
                OwnTicket = id
            });
            return dbResult;
        }
    }
}
