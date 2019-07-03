using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAppPortal.Main.Infrastructure;
using WebAppPortal.Main.Models;

namespace WebAppPortal.Main.Controllers
{
    [Authorize]
    [RoutePrefix("api/main")]
    public class MainController : ApiController
    {
        [HttpGet]
        [Route("modules")]
        public List<ModuleStatusModel> GetModules()
        {
            return ModuleManager.Instance.Modules;
        }

        [HttpGet]
        [Route("currentUser")]
        public string GetCurrentUser()
        {
            return User.Identity.Name;
        }
    }
}