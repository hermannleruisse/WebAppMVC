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
                "quos qui similique accusamus nostrum rem vero", Url = "departments-1.jpg" },

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
                    UrlFacebook = "", UrlInstagram = "", UrlTwitter = ""
                },
                new Docteur
                {
                    NomComplet = "Sarah Jhonson", Titre = "Anesthesiologist",
                    Description = "Aut maiores voluptates amet et quis praesentium qui senda para", Url = "doctors-2.jpg",
                    UrlFacebook = "", UrlInstagram = "", UrlTwitter = ""
                },
                new Docteur
                {
                    NomComplet = "William Anderson", Titre = "Cardiology",
                    Description = "Quisquam facilis cum velit laborum corrupti fuga rerum quia", Url = "doctors-3.jpg",
                    UrlFacebook = "", UrlInstagram = "", UrlTwitter = ""
                },
                new Docteur
                {
                    NomComplet = "Amanda Jepson", Titre = "Neurosurgeon",
                    Description = "Dolorum tempora officiis odit laborum officiis et et accusamus", Url = "doctors-4.jpg",
                    UrlFacebook = "", UrlInstagram = "", UrlTwitter = ""
                }
            };
            context.Docteurs.AddRange(docteurs);

            context.SaveChanges();
        }
    }
}