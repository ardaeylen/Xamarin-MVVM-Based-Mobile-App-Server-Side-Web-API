using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LastWebApi.Models;
using LastWebApi.Services;
namespace LastWebApi.Controllers
{
    public class CarPolicyController : ApiController
    {
        public static XamarinService XamarinService { get; set; }
        public CarPolicyController()
        {
            XamarinService = new XamarinService();
        }
        [HttpGet]
        public IHttpActionResult GetCarPolicyByPoliceNo(int policeno)
        {
            return Ok(XamarinService.GetCarPolicy(policeno));
        }
        [HttpPost]
        public IHttpActionResult PostCarPolicy(CarPolicy carpolicy)
        {
            return Ok(XamarinService.AddCarPolicy(carpolicy));
        }
        [HttpDelete]
        public IHttpActionResult DeleteCarPolicy(int policeno)
        {
            return Ok(XamarinService.DeleteCarPolicy(policeno));
        }
    }
}
