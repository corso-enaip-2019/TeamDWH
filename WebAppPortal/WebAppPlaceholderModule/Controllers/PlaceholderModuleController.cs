using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAppPortal.Contracts;

namespace WebAppPlaceholderModule.Controllers
{
    [RoutePrefix("api")]
    [Authorize]
    public class PlaceholderModuleController : ApiController, IModule
    {
        [HttpGet]
        [Route("GetInfo")]
        public ModuleInfo GetInfo()
        {
            return new ModuleInfo
            {
                Name = "PlaceholderModule",
                FullName = "Placeholder Module",
                Description = "Views mock data from jsonplaceholder.typicode.com"
            };
        }
    }
}