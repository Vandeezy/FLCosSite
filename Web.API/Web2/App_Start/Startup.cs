using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(Web2.App_Start.Startup))]
namespace Web2.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            //config IoC
            AutofacConfig.Initialize(config);
            // config Authorization
            ConfigureOAuth(app, config.DependencyResolver);
            // config webApi
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }

    }
}