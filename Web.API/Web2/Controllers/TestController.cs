using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web2.Controllers
{
    public class TestController : ApiController
    {
        public void Put(int id, [FromBody]string value)
        {
        }

        public void Get(int id)
        {
        }
    }
}
