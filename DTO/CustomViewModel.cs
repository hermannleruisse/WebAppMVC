using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppMVC.Models;

namespace WebAppMVC.DTO
{
    public class CustomViewModel
    {
        public Adresse Adresse { get; set; }
        public Contact Contact { get; set; }
        public IEnumerable<Departement> Departements { get; set; }
        public IEnumerable<Docteur> Docteurs { get; set; }
        public IEnumerable<Temoignage> Temoignages { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<WhyUs> WhyUss { get; set; }
        public IEnumerable<About> Abouts { get; set; }
    }
}