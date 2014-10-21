using System.Collections.Generic;
using System.Web.Http;
using Core.Messaging;

namespace web.Controllers
{
    [RoutePrefix("api/Values")]
    public class ValuesController : ApiController
    {
        private readonly IServiceBus _bus;

        public ValuesController(IServiceBus bus)
        {
            _bus = bus;
        }

        // GET api/values
        [Route("")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [Route("{id:int}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [Route("{id:int}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [Route("{id:int}")]
        public void Delete(int id)
        {
        }
    }
}
