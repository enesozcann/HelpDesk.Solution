using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk.Entities
{
    public class HDEntityBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //not null

        [Required]
        public DateTime CreatedOn { get; set; } //not null - autofill

        public bool IsModified { get; set; } //default 0 - not null

        [Required]
        public DateTime ModifiedOn { get; set; } //if IsModified is 0 => nullable

        //public virtual HDUser CreatorUser { get; set; } //not null
        //public virtual HDUser ModifierUser { get; set; } //if IsModified is 0 => nullable
    }
}