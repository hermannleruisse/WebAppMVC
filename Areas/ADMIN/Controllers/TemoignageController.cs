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
    public class TemoignageController : Controller
    {
        private readonly ApplicationDbContext context;
        public readonly string dir;

        public TemoignageController()
        {
            context = new ApplicationDbContext();
            dir = Folder.DirTesti;
        }

        // GET: ADMIN/Temoignage
        public ActionResult Index()
        {
            IList<Temoignage> temoignages = context.Temoignages.ToList();
            return View(temoignages);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Temoignage temoignage)
        {
            if (!ModelState.IsValid)
            {
                return View("create");
            }
            if (!temoignage.Photo.IsValid())
            {
                ModelState.AddModelError("Photo", "Veuillez charger un fichier .png, .jpg, .jpeg, .gif <= 5 MB");
                return View("create", temoignage);
            }

            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    temoignage.Url = FileManager.CustomUploadFile(temoignage.Photo, dir);
                    ctx.Temoignages.Add(temoignage);

                    ctx.SaveChanges();
                    TempData["Message"] = "Nouvelle enrégistrement réussie avec succès !";
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
            Temoignage temoignage = context.Temoignages.Find(id);
            if (temoignage == null)
            {
                return HttpNotFound();
            }

            return View("edit", temoignage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Temoignage temoignage)
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
                    if (temoignage.Photo != null)
                    {
                        if (!temoignage.Photo.IsValid())
                        {
                            ModelState.AddModelError("Photo", "Veuillez charger un fichier .png, .jpg, .jpeg, .gif <= 5 MB");
                            return View("edit", temoignage);
                        }

                        string oldImage = doc.Url;
                        string oldPath = Server.MapPath($"~/UploadedFiles/{dir}/{oldImage}");
                        FileInfo file = new FileInfo(oldPath);
                        if (file.Exists)//check file exsit or not  
                        {
                            file.Delete();
                        }
                        doc.Url = FileManager.CustomUploadFile(temoignage.Photo, dir);
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
            Temoignage temoignage = context.Temoignages.Find(id);
            if (temoignage == null)
            {
                return HttpNotFound();
            }

            return View("detail", temoignage);
        }

        public ActionResult QuestionDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temoignage temoignage = context.Temoignages.Find(id);
            if (temoignage == null)
            {
                return HttpNotFound();
            }

            return View("delete", temoignage);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            context.Temoignages.Remove(context.Temoignages.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}