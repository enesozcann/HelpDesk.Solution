using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk.Entities
{
    [Table("HDUsers", Schema = "dbo")]
    public class HDUser : HDEntityBase
    {
        [Required, StringLength(25)]
        public string Name { get; set; } //not null

        [Required, StringLength(25)]
        public string Surname { get; set; } //not null

        //[StringLength(35)]
        //public string ProfileImage { get; set; }

        [StringLength(15)]
        public string Ip { get; set; } //nullable

        public bool IsModerator { get; set; } //default 0 not null
        public bool IsAdmin { get; set; } //default 0 not null

        //is admin or moderator start
        [StringLength(16)]
        public string UserName { get; set; } //if IsModerator or IsAdmin 0 => nullable

        [StringLength(32)]
        public string Password { get; set; } //if IsModerator or IsAdmin 0 => nullable

        public int Department { get; set; } //not null

        [ForeignKey("Department")]
        public virtual HDDepartmentCategory HDDepartmentCategory { get; set; } //not null

        //is admin or moderator finish.
        public virtual List<HDTicket> Tickets { get; set; }  //nullable

        public virtual List<HDReply> Replys { get; set; }
    }
}