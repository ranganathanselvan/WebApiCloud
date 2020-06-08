using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApiCloud.App_Start;

namespace WebApiCloud
{
    public partial class Startup
    {
        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = GlobalConfiguration.Configuration;
            var registry = new DefaultRegistry();
            config.DependencyResolver = new DependencyResolver(registry.Container);
            ConfigureAuth(app);
        }
    }
}