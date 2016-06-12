using Crossover.Core.Entity;
using Crossover.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Crossover.Controllers
{
    public class ValuesController : ApiController
    {
        IRegisterService registerService;

        public ValuesController(IRegisterService registerService)
        {
            this.registerService = registerService;
        }

        // GET api/values
        public List<Application> Get()
        {
            return this.registerService.GetApplication();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
