using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Entities.HDObjects
{
    public class LoginViewModel
    {
        [DisplayName("Kullanıcı Adı"), Required(ErrorMessage = "Kullanıcı adı alanı boş geçilemez")]
        public string Username { get; set; }

        [DisplayName("Parola"), Required(ErrorMessage = "Parola alanı boş geçilemez"), DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class LoginViewModelWithIp
    {
        [Required(ErrorMessage = "Eşleşen bir IP bulunamadı")]
        public string Ip { get; set; }
    }
}