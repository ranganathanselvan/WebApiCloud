using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApiCloud.Models;
using WebApiCloud.Services;

namespace WebApiCloud.Providers
{
    /// <summary>
    /// OAuthProvider
    /// </summary>
    public class OAuthProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// GrantResourceOwnerCredentials to check Credentials
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        #region[GrantResourceOwnerCredentials]
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                var userName = context.UserName;
                var password = context.Password;
                var userService = new UserService(); // our created one
                var user = userService.ValidateUser(userName, password);
                if (user != null)
                {
                    var claims = getClaims(user);
                    ClaimsIdentity oAuthIdentity = new ClaimsIdentity(claims,
                                Startup.OAuthOptions.AuthenticationType);

                    var properties = CreateProperties(user.Email);
                    var ticket = new AuthenticationTicket(oAuthIdentity, properties);
                    context.Validated(ticket);
                }
                else
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect");
                }
            });
        }
        private List<Claim> getClaims(User user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Sid, Convert.ToString(user.Id)));
            claims.Add(new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            if (user.UserRoles != null)
            {
                foreach (var item in user.UserRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item.RoleName));
                }
            }
            return claims;
        }
        #endregion

        /// <summary>
        /// ValidateClientAuthentication
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        #region[ValidateClientAuthentication]
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
                context.Validated();

            return Task.FromResult<object>(null);
        }
        #endregion

        /// <summary>
        /// TokenEndpoint
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        #region[TokenEndpoint]
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
        #endregion

        /// <summary>
        /// CreateProperties
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        #region[CreateProperties]
        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
        #endregion
    }
}