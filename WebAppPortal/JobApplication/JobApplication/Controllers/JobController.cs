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
        // non funziona JobManager.Instance.StartJob();

        [HttpGet]
        [Route("startJob")]
        [Authorize(Roles = "tutor")]
        public bool StartJob()
        {
            return JobManager.Instance.StartJob();
        }

        [HttpGet]
        [Route("getJobStatus")]
        [Authorize]
        public string GetJobStatus()
        {
            JobManager.Instance.SetJobStatus();
            return JobManager.Instance.jobStatus;
        }

        [HttpGet]
        [Route("getFullJob")]
        [Authorize]
        public JobManager GetFullJob()
        {
            JobManager.Instance.SetJobInformation();
            return JobManager.Instance;
        }

        [HttpGet]
        [Route("getCurrentStep")]
        [Authorize]
        public int GetCurrentStep()
        {
            JobManager.Instance.SetCurrentStep();
            return JobManager.Instance.currentStep;
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
