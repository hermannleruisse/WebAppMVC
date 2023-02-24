using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAppMVC.Models;
using BCryptNet = BCrypt.Net.BCrypt;

namespace WebAppMVC.Helpers
{
    public class AppDBInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            createTestUsers(context);
            base.Seed(context);
        }

        private void createTestUsers(ApplicationDbContext context)
        {
            // add hardcoded test users to db on startup
            var testUsers = new List<User>
            {
                new User { Id = 1, FirstName = "Admin", LastName = "User", Username = "admin", Password = BCryptNet.HashPassword("admin"), Role = Role.Admin },
                new User { Id = 2, FirstName = "Normal", LastName = "User", Username = "user", Password = BCryptNet.HashPassword("user"), Role = Role.User }
            };
            context.Users.AddRange(testUsers);

            var contact = new List<Contact>
            {
                new Contact { Nom = "admin", Objet = "Renseignement", Email = "admin@gmail.com", Message = "bla bla" }
            };
            context.Contacts.AddRange(contact);

            var addresse = new List<Adresse>
            {
                new Adresse { Location = "A108 Adam Street, New York, NY 535022", Phone = "+1 5589 55488 55", Email = "info@example.com" }
            };
            context.Adresses.AddRange(addresse);

            var departements = new List<Departement>
            {
                new Departement { Libelle = "Cardiology", Description = "Qui laudantium consequatur laborum sit qui ad sapiente " +
                "dila parde sonata raqer a videna mareta paulona marka"+ " Et nobis maiores eius. " +
                "Voluptatibus ut enim blanditiis atque harum sint. Laborum eos " +
                "ipsum ipsa odit magni. Incidunt hic ut molestiae aut qui. Est repellat " +
                "minima eveniet eius et quis magni nihil. Consequatur dolorem quaerat " +
                "quos qui similique accusamus nostrum rem vero", Url = "departments-1.jpg"},

                new Departement { Libelle = "Neurology", Description = "Qui laudantium consequatur laborum sit qui ad sapiente " +
                "dila parde sonata raqer a videna mareta paulona marka"+ " Et nobis maiores eius. " +
                "Voluptatibus ut enim blanditiis atque harum sint. Laborum eos " +
                "ipsum ipsa odit magni. Incidunt hic ut molestiae aut qui. Est repellat " +
                "minima eveniet eius et quis magni nihil. Consequatur dolorem quaerat " +
                "quos qui similique accusamus nostrum rem vero", Url = "departments-2.jpg" },

                new Departement { Libelle = "Hepatology", Description = "Qui laudantium consequatur laborum sit qui ad sapiente " +
                "dila parde sonata raqer a videna mareta paulona marka"+ " Et nobis maiores eius. " +
                "Voluptatibus ut enim blanditiis atque harum sint. Laborum eos " +
                "ipsum ipsa odit magni. Incidunt hic ut molestiae aut qui. Est repellat " +
                "minima eveniet eius et quis magni nihil. Consequatur dolorem quaerat " +
                "quos qui similique accusamus nostrum rem vero", Url = "departments-3.jpg" },

                new Departement { Libelle = "Pediatrics", Description = "Qui laudantium consequatur laborum sit qui ad sapiente " +
                "dila parde sonata raqer a videna mareta paulona marka"+ " Et nobis maiores eius. " +
                "Voluptatibus ut enim blanditiis atque harum sint. Laborum eos " +
                "ipsum ipsa odit magni. Incidunt hic ut molestiae aut qui. Est repellat " +
                "minima eveniet eius et quis magni nihil. Consequatur dolorem quaerat " +
                "quos qui similique accusamus nostrum rem vero", Url = "departments-4.jpg" },

                new Departement { Libelle = "Eye Care", Description = "Qui laudantium consequatur laborum sit qui ad sapiente " +
                "dila parde sonata raqer a videna mareta paulona marka"+ " Et nobis maiores eius. " +
                "Voluptatibus ut enim blanditiis atque harum sint. Laborum eos " +
                "ipsum ipsa odit magni. Incidunt hic ut molestiae aut qui. Est repellat " +
                "minima eveniet eius et quis magni nihil. Consequatur dolorem quaerat " +
                "quos qui similique accusamus nostrum rem vero", Url = "departments-5.jpg" }
            };
            context.Departements.AddRange(departements);

            var docteurs = new List<Docteur>
            {
                new Docteur
                {
                    NomComplet = "Walter White", Titre = "Chief Medical Officer",
                    Description = "Explicabo voluptatem mollitia et repellat qui dolorum quasi", Url = "doctors-1.jpg",
                    UrlFacebook = "https://www.google.com/", UrlInstagram = "https://www.google.com/",
                    UrlTwitter = "https://www.google.com/", UrlLinkedin = ""
                },
                new Docteur
                {
                    NomComplet = "Sarah Jhonson", Titre = "Anesthesiologist",
                    Description = "Aut maiores voluptates amet et quis praesentium qui senda para", Url = "doctors-2.jpg",
                    UrlFacebook = "", UrlInstagram = "", UrlTwitter = "", UrlLinkedin = ""
                },
                new Docteur
                {
                    NomComplet = "William Anderson", Titre = "Cardiology",
                    Description = "Quisquam facilis cum velit laborum corrupti fuga rerum quia", Url = "doctors-3.jpg",
                    UrlFacebook = "", UrlInstagram = "", UrlTwitter = "", UrlLinkedin = ""
                },
                new Docteur
                {
                    NomComplet = "Amanda Jepson", Titre = "Neurosurgeon",
                    Description = "Dolorum tempora officiis odit laborum officiis et et accusamus", Url = "doctors-4.jpg",
                    UrlFacebook = "", UrlInstagram = "", UrlTwitter = "", UrlLinkedin = ""
                }
            };
            context.Docteurs.AddRange(docteurs);

            var temoignages = new List<Temoignage>
            {
                new Temoignage{ 
                    Titre = "Ceo &amp; Founder", NomComplet = "Saul Goodman", 
                    Description="Proin iaculis purus consequat sem cure digni ssim donec porttitora entum suscipit rhoncus. " +
                    "Accusantium quam, ultricies eget id, aliquam eget nibh et. Maecen aliquam, risus at semper.",
                    Url="testimonials-1.jpg"
                },
                new Temoignage{
                    Titre = "Designer", NomComplet = "Sara Wilsson",
                    Description="Export tempor illum tamen malis malis eram quae irure esse labore quem cillum quid cillum eram malis quorum velit fore eram velit sunt aliqua noster fugiat irure amet legam anim culpa.",
                    Url="testimonials-2.jpg"
                },
                new Temoignage{
                    Titre = "Store Owner", NomComplet = "Jena Karlis",
                    Description="Enim nisi quem export duis labore cillum quae magna enim sint quorum nulla quem veniam duis minim tempor labore quem eram duis noster aute amet eram fore quis sint minim.",
                    Url="testimonials-3.jpg"
                },
                new Temoignage{
                    Titre = "Freelancer", NomComplet = "Matt Brandon",
                    Description="Fugiat enim eram quae cillum dolore dolor amet nulla culpa multos export minim fugiat minim velit minim dolor enim duis veniam ipsum anim magna sunt elit fore quem dolore labore illum veniam.",
                    Url="testimonials-4.jpg"
                },
                new Temoignage{
                    Titre = "Entrepreneur", NomComplet = "John Larson",
                    Description="Quis quorum aliqua sint quem legam fore sunt eram irure aliqua veniam tempor noster veniam enim culpa labore duis sunt culpa nulla illum cillum fugiat legam esse veniam culpa fore nisi cillum quid.",
                    Url="testimonials-5.jpg"
                }
            };
            context.Temoignages.AddRange(temoignages);

            var services = new List<Service>
            {
                new Service{ Libelle = "Lorem Ipsum", Description = "Voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi", Icone = "heartbeat"},
                new Service{ Libelle = "Sed ut perspiciatis", Description = "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore", Icone = "pills"},
                new Service{ Libelle = "Magni Dolores", Description = "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia", Icone = "hospital-user"},
                new Service{ Libelle = "Nemo Enim", Description = "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis", Icone = "dna"},
                new Service{ Libelle = "Dele cardo", Description = "Quis consequatur saepe eligendi voluptatem consequatur dolor consequuntur", Icone = "wheelchair"},
                new Service{ Libelle = "Divera don", Description = "Modi nostrum vel laborum. Porro fugit error sit minus sapiente sit aspernatur", Icone = "notes-medical"}
            };
            context.Services.AddRange(services);

            var menus = new List<Menu>
            {
                new Menu { Code = "001", Libelle = "Accueil", Position = 1, Visible = true},
                new Menu { Code = "002", Libelle = "A propos", Position = 2, Visible = true},
                new Menu { Code = "003", Libelle = "Services", Position = 3, Visible = true},
                new Menu { Code = "004", Libelle = "Départements", Position = 4, Visible = true},
                new Menu { Code = "005", Libelle = "Docteurs", Position = 5, Visible = true},
                new Menu { Code = "006", Libelle = "Contact", Position = 6, Visible = true},
                new Menu { Code = "007", Libelle = "Prendre un rendez-vous", Position = 7, Visible = true}
            };
            context.Menus.AddRange(menus);

            context.SaveChanges();
        }
    }
}