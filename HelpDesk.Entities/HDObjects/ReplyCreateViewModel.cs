using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Entities.HDObjects
{
    public class ReplyCreateViewModel
    {
        [DisplayName("Ticket Id"), Required(ErrorMessage ="Ticket id alınamadı.")]
        public int Id { get; set; }

        [DisplayName("Sorun İçeriği"), Required(ErrorMessage = "Sorun içeriği boş geçilemez")]
        public string Content { get; set; }
    }
}
