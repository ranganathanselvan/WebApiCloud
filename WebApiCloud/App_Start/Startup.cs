﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using WebApiCloud.Providers;

namespace WebApiCloud
{
    public partial class Startup
    {
        /// <summary>
        /// OAuthOptions property
        /// </summary>
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        static Startup()
        {
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/api/token"),
                Provider = new OAuthProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                AllowInsecureHttp = true
            };
        }

        /// <summary>
        /// ConfigureAuth
        /// </summary>
        /// <param name="app"></param>
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}