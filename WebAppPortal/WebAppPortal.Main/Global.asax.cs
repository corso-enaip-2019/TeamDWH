using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebAppPortal.Contracts;
using WebAppPortal.Main.Infrastructure;
using WebAppPortal.Main.Models;

namespace WebAppPortal.Main
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //prende il file web config della cartella radice (~)
            Configuration configuration = WebConfigurationManager.OpenWebConfiguration("~");
            //prende la sezione appSetting dal file gestito
            AppSettingsSection appSettings = (AppSettingsSection)configuration.GetSection("appSettings");

            if (appSettings != null)
            {
                foreach (string key in appSettings.Settings.AllKeys.Where(s => s.Contains("Module")))
                {
                    var module = new ModuleStatusModel(key, appSettings.Settings[key].Value);
                    ModuleManager.Instance.Modules.Add(module);
                }
                ModuleManager.Instance.UpdateStatuses();
            }
        }
    }
}
