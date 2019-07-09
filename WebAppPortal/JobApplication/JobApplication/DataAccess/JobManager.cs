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
        public Server server { get; private set; }
        public Job job { get; private set; }

        static readonly string SqlServer = "localhost";
        private readonly string jobStringForServer = "JobForTest";


        public string jobStatus { get; private set; }

        public string jobDescription { get; private set; }
        public string jobName { get; private set; }
        public bool isEnabled { get; private set; }
        public int stepsCount { get; private set; }
        public int currentStep { get; private set; } = 0;
        public string jobStepName { get; private set; }



        private static JobManager instance;
        public static JobManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new JobManager();

                return instance;
            }
        }

        private JobManager()
        {
            server = new Server(SqlServer);
            job = server.JobServer.Jobs[jobStringForServer];
        }



        public bool StartJob()
        {
            job.Start();
            return server.JobServer.Jobs[jobStringForServer].IsEnabled;
        }

        public void SetJobStatus()
        {
            //enum property: 
            // BetweenRetries	3	
            // Executing	1	
            // Idle	4	
            // PerformingCompletionAction	7	
            // Suspended	5	
            // WaitingForStepToFinish	6	
            // WaitingForWorkerThread	2
            this.jobStatus = job.CurrentRunStatus.ToString();
        }

        public void SetJobInformation()
        {
            job.Refresh();
            this.jobStatus = job.CurrentRunStatus.ToString();
            this.jobDescription = job.Description;
            this.jobName = job.Name;
            this.isEnabled = job.IsEnabled;
            this.stepsCount = job.JobSteps.Count;
            this.currentStep = job.StartStepID-1;
            this.jobStepName = job.JobSteps[this.currentStep].Name;

        }

        public void SetCurrentStep()
        {
            job.Refresh();
            if (int.TryParse(job.CurrentRunStep.Substring(0, 1), out int a))
                if (this.currentStep != a)
                {
                    this.currentStep++;
                    this.jobStepName = server.JobServer.Jobs[jobStringForServer].JobSteps[this.currentStep].Name;
                }

            jobStatus = job.CurrentRunStatus.ToString();
        }
    }
}