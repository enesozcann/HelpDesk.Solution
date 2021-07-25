using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk.Entities
{
    [Table("HDTickets", Schema = "dbo")]
    public class HDTicket : HDEntityBase
    {
        [Required]
        public string Title { get; set; } //not null

        [Required]
        public string Content { get; set; } //not null

        [Required]
        public int Status { get; set; } //default 0 - new / 1 - processing / 2 - cannot be solved / 3 - solved

        public DateTime SolvedOn { get; set; } //if Status is 2 or 3 => not null

        //public string SolverUser { get; set; }
        public virtual HDUser Creator { get; set; } //not null

        public virtual HDUser SolverUser { get; set; } //only status is 2 or 3
        public virtual List<HDReply> Replys { get; set; } //nullable
    }
}