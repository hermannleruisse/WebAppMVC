﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using WebAppMVC.Helpers;

namespace WebAppMVC.Models
{
    public class Departement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Libelle { get; set; }
        [Required]
        public string Description { get; set; }
        public string Url { get; set; }

        [NotMapped]
        //[Required(ErrorMessage = "Veuillez charger un fichier")]
        //[ValidateFile(ErrorMessage = "Veuillez charger un fichier .png, .jpg, .jpeg, .gif <= 5 MB")]
        public HttpPostedFileBase Photo { get; set; }

        public string getPhotoUrl() => $"~/UploadedFiles/{Folder.DirDep}/" + Url;
    }
}