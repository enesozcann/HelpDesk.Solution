using HelpDesk.BusinessLayer;
using HelpDesk.Entities;
using HelpDesk.Entities.HDObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HelpDesk.WebApp.Controllers
{
    public class TicketController : Controller
    {
        // GET: Ticket
        private HDTicketManager tm = new HDTicketManager();
        private HDReplyManager rm = new HDReplyManager();

        public ActionResult TicketsAll()
        {
            return View(tm.GetTicketList());
        }

        public ActionResult Index()
        {
            return View(tm.GetTicketList().OrderByDescending(x => x.ModifiedOn).ToList());
        }

        public ActionResult MyTicketList()
        {
            HDUser user = null;
            user = Session["auth-user"] as HDUser;
            return View(tm.GetTicketMyList(user).OrderByDescending(x => x.ModifiedOn).ToList());

            //return View(tm.GetTicketMyList(user).OrderByDescending(x => x.ModifiedOn));
        }

        public ActionResult TicketDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDTicket ticket = new HDTicket();
            ticket = tm.GetTicketDetail(id);
            //Reply getir
            //<List>HDReply reply = null;
            //reply = rm.GetReply(id).OrderByDescending(x => x.ModifiedOn).ToList();
            if (ticket == null)
            {
                return HttpNotFound();
            }
            GetReplys(id);
            return PartialView("_PartialTicketDetail", Tuple.Create<HDTicket, TicketUpdateViewModel>(ticket, new TicketUpdateViewModel()));
        }
        public ActionResult GetReplys(int? id)
        {
            List<HDReply> veri = rm.GetReply(id).OrderByDescending(x => x.ModifiedOn).ToList();
            if (veri != null){
                return PartialView("_PartialReply", veri);
            }
            return PartialView("_PartialReply", null);
        }
        public ActionResult CreateReply()
        {
            return PartialView("_PartialReplySave");
        }
        [HttpPost]
        public ActionResult CreateReply(int id,string content)
        {
            HDUser user = null;
            user = Session["auth-user"] as HDUser;
            HDReplyManager rm = new HDReplyManager();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            else
            {
                if (content == "")
                {
                    return HttpNotFound();
                }
                else
                {
                    rm.InsertReply(id, content, user);
                    return Json(new { result = true }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public ActionResult TicketCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TicketCreate(TicketCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                HDUser user = null;
                user = Session["auth-user"] as HDUser;
                HDTicketManager hdm = new HDTicketManager();
                try
                {
                    hdm.InsertTicket(model, user);
                    return RedirectToAction("MyTicketList");
                }
                catch (System.Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult TicketUpdate(int? id, int status)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDTicketManager tm = new HDTicketManager();
            HDTicket ticket = tm.GetTicketDetail(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ticket.Status = status;
            tm.UpdateTicket(ticket);
            return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            //return PartialView("_PartialTicketDetail", Tuple.Create<HDTicket, TicketUpdateViewModel>(ticket, new TicketUpdateViewModel()));
        }
    }
}