using LastWebApi.Models;
using LastWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace LastWebApi.Controllers
{
    
    public class UserController : ApiController
    {
        public static XamarinService xamarinService;
        public UserController()
        {
            xamarinService = new XamarinService();
        }
        [HttpGet]
        public IHttpActionResult Get(string username,string password)
        {
            return Ok(xamarinService.LoginFunction(username, password));
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(xamarinService.GetUsers());
        }
        [HttpPost]
        public IHttpActionResult Post(User user)
        {
            return Ok(xamarinService.AddUser(user));
        }

    }
}
