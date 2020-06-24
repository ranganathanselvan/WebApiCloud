using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace WebApiCloud
{
    /// <summary>
    /// WebApiApplication
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        /// <summary>
        /// Application_BeginRequest
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.Flush();
            }

            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            //if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            //{
            //    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
            //    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
            //    HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
            //    HttpContext.Current.Response.End();
            //}
        }

    }
}

