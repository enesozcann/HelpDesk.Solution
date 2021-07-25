using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Entities.HDObjects
{
    public class TicketCreateViewModel
    {
        [DisplayName("Destek Bildirimi Başlığı"), Required(ErrorMessage = "Sorun başlığı boş geçilemez")]
        public string Title { get; set; }

        //[DisplayName("Parola"), Required(ErrorMessage = "Parola alanı boş geçilemez"), DataType(DataType.Password)]
        [DisplayName("Sorun İçeriği"), Required(ErrorMessage = "Sorun içeriği boş geçilemez")]
        public string Content { get; set; }
    }

    public class TicketUpdateViewModel
    {
        [DisplayName("Destek Bildirimi Id"), Required(ErrorMessage = "Sorun Id boş geçilemez")]
        public int Id { get; set; }

        [DisplayName("Destek Bildirimi Durumu"), Required(ErrorMessage = "Sorun başlığı boş geçilemez")]
        public int Status { get; set; }

        [DisplayName("Destek Bildirimi Cevap"), Required(ErrorMessage = "Cevap alanı boş geçilemez")]
        public string Content { get; set; }
    }
}