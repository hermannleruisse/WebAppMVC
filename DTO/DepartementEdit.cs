﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppMVC.DTO
{
    public class DepartementEdit
    {
        public int Id { get; set; }
        [Required]
        public string Libelle { get; set; }
        [Required]
        public string Description { get; set; }
        //public string Url { get; set; }

        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }
    }
}