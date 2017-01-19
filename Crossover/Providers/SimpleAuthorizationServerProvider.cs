using Crossover.Core.Entity;
using Crossover.Core.Helpers;
using Crossover.Core.IService;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Crossover.API.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            string applicationId = string.Empty;
            string applicationSecret = string.Empty;

            if (context.Request.Headers.Keys.Contains("applicationId"))
            {
                applicationId = context.Request.Headers["applicationId"];
            }
            else if (context.Request.Headers.Keys.Contains("applicationId"))
            {
                applicationId = context.Request.Headers["applicationId"];
            }

            if (context.Request.Headers.Keys.Contains("applicationSecret"))
            {
                applicationSecret = context.Request.Headers["applicationSecret"];
            }

            IAuthService authService = IoC.Resolve<IAuthService>("AuthService");
            Application application = authService.GetApplication(applicationId);
            if (application == null)
            {
                string message = "invalid credentials";

                ExceptionHelper.ThrowAPIException(System.Net.HttpStatusCode.Unauthorized, message, message);
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("applicationId", application.ApplicationId));
            identity.AddClaim(new Claim("displayName", application.DisplayName));

            context.Validated(identity);

        }
    }
}