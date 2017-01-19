using Crossover.Core.Entity;
using Crossover.Core.Helpers;
using Crossover.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Crossover.API.Controllers
{
    public class RegisterController : ApiController
    {
        private IRegisterService registerService;

        public RegisterController()
        {
            this.registerService = IoC.Resolve<IRegisterService>("RegisterService");
        }

        [AllowAnonymous]
        public Application Post(Application value)
        {
            if (value == null)
            {
                string message = "invalid JSON";
                ExceptionHelper.ThrowAPIException(HttpStatusCode.BadRequest, message, message);
            }

            return this.registerService.Register(value);
        }
    }
}
