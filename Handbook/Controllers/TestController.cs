using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Handbook.Code;
using System.Web.Http.Cors;

namespace Handbook.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TestController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        public string Something()
        {
            var test = User.Identity.Name;
            return "Hello";
        }

        [HttpGet]
        [AllowAnonymous]
        public List<AllMenu> TestMenu()
        {
            MenuHelper helper = new MenuHelper();
            return helper.GetMenus();
        }

        [AllowAnonymous]
        [HttpPost]
        public HttpResponseMessage GetLinks([FromBody] int menuId)
        {
            MenuHelper helper = new MenuHelper();
            return Request.CreateResponse(HttpStatusCode.OK, new { links = helper.GetMenuDetails(menuId)});
            //return new HttpRequestMessage(HttpStatusCode.OK, helper.GetMenuDetails(menuId));
            //return helper.GetMenuDetails(menuId);
        }
    }
}
