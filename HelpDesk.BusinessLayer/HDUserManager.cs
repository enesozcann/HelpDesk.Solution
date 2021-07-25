using HelpDesk.DataAccesLayer;
using HelpDesk.Entities;
using HelpDesk.Entities.HDObjects;

namespace HelpDesk.BusinessLayer
{
    public class HDUserManager
    {
        private HDRepository<HDUser> repo_user = new HDRepository<HDUser>();

        public HDBusinnesLResults<HDUser> AuthUser(LoginViewModel data)
        {
            HDUser user = repo_user.Find(x => x.UserName == data.Username && x.Password == data.Password && x.IsModerator == true);
            HDBusinnesLResults<HDUser> result = new HDBusinnesLResults<HDUser>();
            if (user != null)
            {
                result.Result = user;
                //w
            }
            else
            {
                result.Errors.Add("Kullanıcı adı veya Parola yanlış.");
            }
            return result;
        }

        public HDBusinnesLResults<HDUser> AuthUserWithIp(string ip)
        {
            HDUser user = repo_user.Find(x => x.Ip == ip);
            HDBusinnesLResults<HDUser> result = new HDBusinnesLResults<HDUser>();
            if (user != null)
            {
                result.Result = user;
                //w
            }
            else
            {
                result.Errors.Add("Eşleşen ip bulunamadı.");
            }
            return result;
        }
    }
}