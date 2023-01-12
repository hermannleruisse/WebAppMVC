using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppMVC.Models;

namespace WebAppMVC.Helpers
{
    public static class LoadData
    {
        private static readonly ApplicationDbContext context;

        static LoadData()
        {
            context = new ApplicationDbContext();
        }

        public static Adresse LoadAdress()
        {
            return context.Adresses.First();
        }

        public static IEnumerable<Departement> LoadDepartement()
        {
            return context.Departements.ToList();
        }
    }
}