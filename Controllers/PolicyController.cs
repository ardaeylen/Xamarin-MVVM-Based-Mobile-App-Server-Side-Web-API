using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LastWebApi.Models;
using LastWebApi.Services;
using System.Web.Http.Description;

namespace LastWebApi.Controllers
{
    public class PolicyController : ApiController
    {
        public static XamarinService xamarinService;

        public PolicyController()
        {
            xamarinService = new XamarinService();
        }
        [HttpGet]
        public IHttpActionResult GetPolicies()
        {
            return Ok(xamarinService.GetPolicies());
        }

        [HttpGet]
        public IHttpActionResult Get(int userid)
        {
            return Ok(xamarinService.GetPoliciesByUserId(userid));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int policeno)
        {
            return Ok(xamarinService.DeletePolicy(policeno));
        }
        [HttpPost]
        public IHttpActionResult Post(Policy policy)
        {
            return Ok(xamarinService.AddPolicy(policy));
        }
    }
}
