using System.Data.Entity;

namespace WebAppMVC.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(): base("KondiDB") //Connection string in web.config
        {
            Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseAlways<ApplicationDbContext>());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<WebAppMVC.DTO.AuthenticateResponse> AuthenticateResponses { get; set; }
    }
}