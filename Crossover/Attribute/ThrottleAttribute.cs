using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Crossover.API.Attribute
{
    public class ThrottleAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var key = 
            var allowExecute = false;

            if (HttpRuntime.Cache[key] == null)
            {
                HttpRuntime.Cache.Add(key,
                    1, // is this the smallest data we can have?
                    null, // no dependencies
                    DateTime.Now.AddMinutes(1), // absolute expiration
                    Cache.NoSlidingExpiration,
                    CacheItemPriority.Low,
                    null); // no callback

                allowExecute = true;
            }

            if (!allowExecute)
            {
                if (string.IsNullOrEmpty(Message))
                {
                    Message = "You may only perform this action every {n} seconds.";
                }

                actionContext.Response = actionContext.Request.CreateResponse(
                    HttpStatusCode.Conflict,
                    Message.Replace("{n}", Seconds.ToString())
                );
            }
        }
    }
}