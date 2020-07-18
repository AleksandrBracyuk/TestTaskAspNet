using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TestTaskServer.Data;
using TestTaskServer.Models;

namespace TestTaskServer.Controllers
{
    public class RegistrationInfoController : ApiController
    {
        RegistrationInfoService _service = new RegistrationInfoService();

        // GET: api/RegistrationInfo
        public IEnumerable<Info> Get()
        {
            return _service.GetAllInfoes();
        }


        // POST: api/RegistrationInfo
        public IHttpActionResult Post([FromBody]InfoRequest value)
        {
            var ret = _service.PushInfo(value);
            return Ok(ret);
        }
    }
}
