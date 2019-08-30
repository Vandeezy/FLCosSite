using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web2.Controllers
{
    public class BaseController : ApiController
    {
        protected readonly JsonSerializerSettings _apiSerializerSettings;
    }
}
