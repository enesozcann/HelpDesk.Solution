using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk.Entities
{
    [Table("HDReplys", Schema = "dbo")]
    public class HDReply : HDEntityBase
    {
        [Required]
        public string Content { get; set; } //not null

        public int OwnTicket { get; set; } //not null
 
        [Required, ForeignKey("OwnTicket")]
        public virtual HDTicket HDTicket { get; set; } //not null

        public virtual HDUser Creator { get; set; }
    }
}