using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebAppMVC.Helpers;
using WebAppMVC.Models;

namespace WebAppMVC.Areas.ADMIN.Controllers
{
    public class DocteurController : Controller
    {
        // GET: ADMIN/Docteur
        private readonly ApplicationDbContext context;
        public readonly string dir;

        public DocteurController()
        {
            context = new ApplicationDbContext();
            dir = Folder.DirDoc;
        }

        public ActionResult Index()
        {
            IList<Docteur> docteurs = context.Docteurs.ToList();
            return View(docteurs);
        }

        public ActionResult Create()
        {
            return View("create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Docteur docteur)
        {
            if (!ModelState.IsValid)
            {
                return View("create");
            }
            if (!docteur.Photo.IsValid())
            {
                ModelState.AddModelError("Photo", "Veuillez charger un fichier .png, .jpg, .jpeg, .gif <= 5 MB");
                return View("create", docteur);
            }

            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    docteur.Url = FileManager.CustomUploadFile(docteur.Photo, dir);
                    ctx.Docteurs.Add(docteur);

                    ctx.SaveChanges();
                    TempData["Message"] = "Nouvel enrégistrement réussie avec succès !";
                }
            }
            catch (Exception exc)
            {
                ViewBag.Message = exc.Message;
                throw exc;
            }
            return RedirectToAction("Index");
        }



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docteur docteur = context.Docteurs.Find(id);
            if (docteur == null)
            {
                return HttpNotFound();
            }

            return View("edit", docteur);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Docteur docteur)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var doc = ctx.Docteurs.Find(id);
                    if (docteur.Photo != null)
                    {
                        if (!docteur.Photo.IsValid())
                        {
                            ModelState.AddModelError("Photo", "Veuillez charger un fichier .png, .jpg, .jpeg, .gif <= 5 MB");
                            return View("edit", docteur);
                        }

                        string oldImage = doc.Url;
                        string oldPath = Server.MapPath($"~/UploadedFiles/{dir}/{oldImage}");
                        FileInfo file = new FileInfo(oldPath);
                        if (file.Exists)//check file exsit or not  
                        {
                            file.Delete();
                        }
                        doc.Url = FileManager.CustomUploadFile(docteur.Photo, dir);
                    }

                    ctx.Entry(doc).State = EntityState.Modified;
                    if (TryUpdateModel(doc))
                        ctx.SaveChanges();

                    TempData["Message"] = "Mise à jour réussie avec succès !";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception exc)
            {
                ViewBag.Message = exc.Message;
                throw exc;
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docteur docteur = context.Docteurs.Find(id);
            if (docteur == null)
            {
                return HttpNotFound();
            }

            return View("detail", docteur);
        }

        public ActionResult QuestionDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docteur docteur = context.Docteurs.Find(id);
            if (docteur == null)
            {
                return HttpNotFound();
            }

            return View("delete", docteur);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            context.Docteurs.Remove(context.Docteurs.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}