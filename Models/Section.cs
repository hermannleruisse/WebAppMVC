using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMVC.Models
{
    public class Section
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public Menu Menu { get; set; }
        [Display(Name = "Titre de la section")]
        public string TitreSection { get; set; }
        [AllowHtml]
        [Display(Name = "Description de la section")]
        public string DescriptionSection { get; set; }

    }
}