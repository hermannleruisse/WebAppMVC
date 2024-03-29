﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppMVC.Models;

namespace WebAppMVC.Helpers
{
    public static class LoadData
    {
        private static readonly ApplicationDbContext context = ApplicationDbContext.getInstance();

        public static Adresse LoadAdress()
        {
            return context.Adresses.First();
        }

        public static IEnumerable<Departement> LoadDepartement()
        {
            return context.Departements.ToList();
        }

        public static IEnumerable<Docteur> LoadDocteur()
        {
            return context.Docteurs.ToList();
        }
        
        public static IEnumerable<Temoignage> LoadTemoignage()
        {
            return context.Temoignages.ToList();
        }

        public static IEnumerable<Service> LoadService()
        {
            return context.Services.ToList();
        }

        public static IEnumerable<WhyUs> LoadWhyUs()
        {
            return context.WhyUs.ToList();
        }

        public static IEnumerable<About> LoadAbout()
        {
            return context.Abouts.ToList();
        }
    }
}