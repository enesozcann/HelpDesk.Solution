using HelpDesk.BusinessLayer;
using HelpDesk.Entities;
using HelpDesk.Entities.HDObjects;
using System.Diagnostics;
using System.Web.Mvc;

namespace HelpDesk.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Test test = new Test();
            
            return View();
        }

        public ActionResult TicketList()
        {
            return View();
        }

        public ActionResult Login()
        {
            Test test = new Test();
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                HDUserManager um = new HDUserManager();
                HDBusinnesLResults<HDUser> result = um.AuthUser(model);
                if (result.Errors.Count > 0)
                {
                    result.Errors.ForEach(x => ModelState.AddModelError("", x));
                    return View(model);
                }
                Session["auth-user"] = result.Result;
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult LoginWithIp()
        {
            string ip = Request.UserHostAddress;
            Debug.WriteLine(ip);
            HDUserManager um = new HDUserManager();
            HDBusinnesLResults<HDUser> result = um.AuthUserWithIp(ip);
            if (result.Errors.Count == 0)
            {
                Session["auth-user"] = result.Result;
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}