using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebAppMVC.Helpers;

namespace WebAppMVC.Models
{
    public class Temoignage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nom complet")]
        public string NomComplet { get; set; }
        [Required]
        public string Titre { get; set; }
        [Required]
        public string Description { get; set; }

        public string Url { get; set; }

        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }

        public string getPhotoUrl() => $"~/UploadedFiles/{Folder.DirDoc}/" + Url;
    }
}