using HelpDesk.Entities;
using System.Data.Entity;
using System.Reflection.Emit;

namespace HelpDesk.DataAccesLayer
{
    public class HDDatabaseContext : DbContext
    {
        public DbSet<HDUser> HDUsers { get; set; }
        public DbSet<HDTicket> HDTickets { get; set; }
        public DbSet<HDReply> HDReplys { get; set; }
        public DbSet<HDDepartmentCategory> HDDepartmentCategorys { get; set; }
        public HDDatabaseContext()
        {
            Database.SetInitializer(new HDInitializer());
        }
    }
}