using Generalate.Helpers;
using Generalate.Models;
using Serilog;
using System;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;

namespace Generalate
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            var path = AppContext.BaseDirectory;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
            .WriteTo.File(path + "\\Logs\\LogInfo_.log",
       rollingInterval: RollingInterval.Day,
       fileSizeLimitBytes: 10 * 1024 * 1024,
       retainedFileCountLimit: 2,
       rollOnFileSizeLimit: true,
       shared: true,
       flushToDiskInterval: TimeSpan.FromSeconds(1))
                    .CreateLogger();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //Database.SetInitializer<GeneralDBContext>(new DropCreateDatabaseIfModelChanges<GeneralDBContext>());
            Database.SetInitializer<GeneralDBContext>(null);

            Log.Information("App Stared");

            GlobalFilters.Filters.Add(new ExceptionFilter(), 0);

        }

    }
}
