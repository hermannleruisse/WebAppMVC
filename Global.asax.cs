using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebAppMVC.Helpers;
using WebAppMVC.Models;

namespace WebAppMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer(new AppDBInitializer());
            using (var ctx = ApplicationDbContext.getInstance())
            {
                ctx.Database.Initialize(true);
            }
        }
    }
}
