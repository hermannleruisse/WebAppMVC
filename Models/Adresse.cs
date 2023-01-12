using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppMVC.Models
{
    public class Adresse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        [Display(Name = "Lien twitter")]
        public string UrlTwitter { get; set; }

        [Display(Name = "Lien facebook")]
        public string UrlFacebook { get; set; }

        [Display(Name = "Lien instagram")]
        public string UrlInstagram { get; set; }
        
        [Display(Name = "Lien google map")]
        public string UrlMap { get; set; }
    }
}