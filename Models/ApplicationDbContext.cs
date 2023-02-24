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

        public DbSet<DTO.AuthenticateResponse> AuthenticateResponses { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Docteur> Docteurs { get; set; }
        public DbSet<Temoignage> Temoignages { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Section> Sections { get; set; }
    }
}