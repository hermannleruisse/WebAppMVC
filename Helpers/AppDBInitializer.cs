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
            context.SaveChanges();
        }
    }
}