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
    public class DepartementController : Controller
    {
        // GET: ADMIN/Departement
        private readonly ApplicationDbContext context = ApplicationDbContext.getInstance();
        public readonly string dir = Folder.DirDep;

        public ActionResult Index()
        {
            IList<Departement> departements = context.Departements.ToList();
            return View(departements);
        }

        public ActionResult Create()
        {
            return View("create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Departement departement)
        {
            if (!ModelState.IsValid)
            {
                return View("create");
            }
            if (!departement.Photo.IsValid())
            {
                ModelState.AddModelError("Photo", "Veuillez charger un fichier .png, .jpg, .jpeg, .gif <= 5 MB");
                return View("create", departement);
            }

            try
            {
                using (var ctx = context)
                {
                    //string oldName = Path.GetFileName(departement.Photo.FileName);
                    //string newName = Guid.NewGuid().ToString()+Path.GetExtension(departement.Photo.FileName);
                    //string path = Path.Combine(Server.MapPath($"~/UploadedFiles/{dir}"), newName);
                    //departement.Photo.SaveAs(path);
                    
                    departement.Url = FileManager.CustomUploadFile(departement.Photo, dir);
                    ctx.Departements.Add(departement);

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
            Departement departement = context.Departements.Find(id);
            if (departement == null)
            {
                return HttpNotFound();
            }


            return View("edit", departement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Departement departement)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            try
            {
                using (var ctx = context)
                {
                    var dep = ctx.Departements.Find(id);
                    if (departement.Photo != null){
                        if (!departement.Photo.IsValid())
                        {
                            ModelState.AddModelError("Photo", "Veuillez charger un fichier .png, .jpg, .jpeg, .gif <= 5 MB");
                            return View("edit", departement);
                        }

                        string oldImage = dep.Url;
                        string oldPath = Server.MapPath($"~/UploadedFiles/{dir}/{oldImage}");
                        FileInfo file = new FileInfo(oldPath);
                        if (file.Exists)//check file exsit or not  
                        {
                            file.Delete();
                        }
                        dep.Url = FileManager.CustomUploadFile(departement.Photo, dir);
                    }

                    //dep.Libelle = departement.Libelle;
                    //dep.Description = departement.Description;

                    ctx.Entry(dep).State = EntityState.Modified;
                    if(TryUpdateModel(dep))
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
            Departement departement = context.Departements.Find(id);
            if (departement == null)
            {
                return HttpNotFound();
            }

            return View("detail", departement);
        }

        public ActionResult QuestionDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departement departement = context.Departements.Find(id);
            if (departement == null)
            {
                return HttpNotFound();
            }

            return View("delete", departement);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            context.Departements.Remove(context.Departements.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}