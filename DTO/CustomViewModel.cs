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
    }
}