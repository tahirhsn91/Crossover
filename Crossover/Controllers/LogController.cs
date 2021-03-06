﻿using Crossover.API.Attribute;
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
    public class LogController : ApiController
    {
        private ILogService logService;
        public LogController()
        {
            this.logService = IoC.Resolve<ILogService>("LogService");
        }

        [Authorize]
        [Throttle]
        public object Post(Log entity)
        {
            if (entity == null)
            {
                string message = "invalid JSON";
                ExceptionHelper.ThrowAPIException(HttpStatusCode.BadRequest, message, message);
            }

            bool result = this.logService.SaveLog(entity);

            return new
            {
                success = result
            };
        }
    }
}
