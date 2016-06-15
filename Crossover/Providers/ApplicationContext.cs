using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crossover.API.Providers
{
    public class ApplicationContext: BaseValidatingTicketContext<OAuthAuthorizationServerOptions>
    {
        public ApplicationContext(IOwinContext context, OAuthAuthorizationServerOptions options, string clientId, string userName, string password, IList<string> scope)
        {

        }

        public string ClientId { get; }
        public IList<string> Scope { get; }
        public string UserName { get; }
    }
}