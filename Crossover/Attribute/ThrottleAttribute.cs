using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Caching;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Crossover.API.Attribute
{
    public class ThrottleAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            bool allowExecute = false;
            string specialWaitingKey = "SpecialWaiting";

            HttpRuntime.Cache.Add(Guid.NewGuid().ToString(),
                true,
                null,
                DateTime.Now.AddMinutes(Core.Helpers.ConfigurationHelper.RequestExpiry),
                Cache.NoSlidingExpiration,
                CacheItemPriority.Low,
                null);

            if (HttpRuntime.Cache.Count > Core.Helpers.ConfigurationHelper.RateLimit)
            {
                if (HttpRuntime.Cache[specialWaitingKey] == null)
                {
                    HttpRuntime.Cache.Add(specialWaitingKey,
                    true,
                    null,
                    DateTime.Now.AddMinutes(Core.Helpers.ConfigurationHelper.SpecialWaiting),
                    Cache.NoSlidingExpiration,
                    CacheItemPriority.Low,
                    null);
                }

                allowExecute = false;
            }
            else
            {
                if (HttpRuntime.Cache[specialWaitingKey] == null)
                {
                    allowExecute = true;
                }
                else
                {
                    allowExecute = false;
                }
            }

            if (!allowExecute)
            {
                string Message = string.Empty;
                Message = "Exceeding the rate limiting.";

                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden, Message);
            }
        }
    }
}