using JobApplication.Models;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo.Agent;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System;

namespace JobApplication.DataAccess
{
    public class JobManager : IJobModel
    {
        public string jobStatus { get; private set; }
        public string jobDescription { get; private set; }
        public string jobName { get; private set; }
        public bool isEnabled { get; private set; }
        public int stepsCount { get; private set; }
        public int currentStep { get; private set; } = 0;
        public string jobStepName { get; private set; }

        public Server server { get; private set; }
        public Job job { get; private set; }

        static readonly string SqlServer = "localhost";
        private readonly string jobStringForServer = "JobForTest";

        public JobManager()
        { 
            server = new Server(SqlServer);
            job = server.JobServer.Jobs[jobStringForServer];
        }

        public bool StartJob()
        {
            job.Start();
            job.Refresh();
            return server.JobServer.Jobs[jobStringForServer].IsEnabled;
        }

        public void SetJobInformation()
        {
            job.Refresh();
            this.jobStatus = job.CurrentRunStatus.ToString();
            this.jobDescription = job.Description;
            this.jobName = job.Name;
            this.isEnabled = job.IsEnabled;
            this.stepsCount = job.JobSteps.Count;
            this.currentStep = int.Parse(job.CurrentRunStep.Substring(0, this.stepsCount.ToString().Length));
            if (this.currentStep != 0 && this.currentStep <= job.JobSteps.Count)
                this.jobStepName = job.JobSteps[this.currentStep-1].Name;
        }
    }
}