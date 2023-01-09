using System.Data.Entity;
using WebAppMVC.Helpers;

namespace WebAppMVC.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(): base("KondiDB") //Connection string in web.config
        {
            //Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseAlways<ApplicationDbContext>());
            Database.SetInitializer<ApplicationDbContext>(new AppDBInitializer());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<WebAppMVC.DTO.AuthenticateResponse> AuthenticateResponses { get; set; }
    }
}