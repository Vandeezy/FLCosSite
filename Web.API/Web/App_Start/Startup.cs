using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(Web.App_Start.Startup))]
namespace Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            // config IoC
            AutofacConfig.Initialize(config);

            // config Authorization
            //AuthConfig.ConfigureAuth(app, config.DependencyResolver);

            // config webApi
            WebApiConfig.Register(config);
            app.UseWebApi(config);

            // config language detection
            //app.Use();

            // Config Swagger
            //SwaggerConfig.Register(config);

            // Config default permission
            //PermissionConfig.ConfigDefaultPermissions(config.DependencyResolver);

            // Configure errors
            // TODO: Create custom errors 
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            // Init Logger
            //CspsLogger.InitLogger("CSPS2.WebApi");
            //CspsLogger.WriteToLogger(LogGravity.Info, "StartUp", "Server running");
        }
    }
}