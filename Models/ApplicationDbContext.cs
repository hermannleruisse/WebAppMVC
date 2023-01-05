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
    }
}