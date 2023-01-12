using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppMVC.Models;

namespace WebAppMVC.Areas.ADMIN.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext context;

        public ContactController()
        {
            context = new ApplicationDbContext();
        }

        // GET: ADMIN/Contact
        public ActionResult Index()
        {
            IList<Contact> contacts = context.Contacts.OrderByDescending(x => x.Date).ToList();
            
            return View(contacts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                using(var ctx = new ApplicationDbContext())
                {
                    ctx.Contacts.Add(contact);
                    ctx.SaveChanges();
                }
                ViewBag.Message = "Message envoyer avec succès !";
                return View("Index");
            }
            
            ViewBag.Message = "Echec d'envoie de message ";
            return View("Index");
        }

        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = context.Contacts.Find(id);
            if(contact == null)
            {
                return HttpNotFound();
            }
            
            return View("detail", contact);
        }

        public ActionResult QuestionDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = context.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }

            return View("delete", contact);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            context.Contacts.Remove(context.Contacts.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}