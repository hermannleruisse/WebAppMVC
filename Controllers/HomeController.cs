﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMVC.DTO;
using WebAppMVC.Helpers;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CustomViewModel cVM = new CustomViewModel();
            cVM.Adresse = LoadData.LoadAdress();
            cVM.Departements = LoadData.LoadDepartement();
            cVM.Docteurs = LoadData.LoadDocteur();
            cVM.Temoignages = LoadData.LoadTemoignage();
            cVM.Services = LoadData.LoadService();
            cVM.WhyUss = LoadData.LoadWhyUs();
            cVM.Abouts = LoadData.LoadAbout();
            //cVM.Contact = new Contact();

            return View(cVM);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult IndexFront()
        {
            return View("index_front");
        }
    }
}