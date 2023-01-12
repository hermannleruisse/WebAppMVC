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

            context.SaveChanges();
        }
    }
}