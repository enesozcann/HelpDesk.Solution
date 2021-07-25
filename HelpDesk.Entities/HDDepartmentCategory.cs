using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk.Entities
{
    [Table("HDDepartmentCategories", Schema = "dbo")]
    public class HDDepartmentCategory : HDEntityBase
    {
        [Required]
        public string Title { get; set; } //not null

        [Required]
        public string Description { get; set; } //not null

        public virtual ICollection<HDUser> Users { get; set; } //nullable
    }
}