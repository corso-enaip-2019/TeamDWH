using JobApplication.DataAccess;
using JobApplication.Models;
using System;
using System.Diagnostics;
using System.Web.Http;

namespace JobApplication.Controllers
{
    [RoutePrefix("api")]
    public class JobController : ApiController, IModule
    {
        JobManager jobManager; 

        [HttpGet]
        [Route("startJob")]
        [Authorize(Roles = "tutor")]
        public bool StartJob()
        {
            jobManager = new JobManager();
            return jobManager.StartJob();
        }

        [HttpGet]
        [Route("getJobStatus")]
        [Authorize]
        public string GetJobStatus()
        {
            jobManager = new JobManager();
            jobManager.SetJobInformation();
            return jobManager.jobStatus;
        }

        [HttpGet]
        [Route("getFullJob")]
        [Authorize]
        public JobManager GetFullJob()
        {
            jobManager = new JobManager();
            jobManager.SetJobInformation();
            return jobManager;
        }

        [HttpGet]
        [Route("getInfo")]
        [Authorize]
        public ModuleInfo GetInfo()
        {
            return new ModuleInfo
            {
                Name = "Job",
                FullName = "Job Module Manager",
                Description = "This module manage the starting of the Job and let you know the progress of it"
            };
        }
    }
}
