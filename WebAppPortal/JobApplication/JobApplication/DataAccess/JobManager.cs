using JobApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SqlServer;
using Microsoft.SqlServer.Management.Smo.Agent;
using Microsoft.SqlServer.Management.Smo;

namespace JobApplication.DataAccess
{
    public class JobManager : IJobModel
    {
        public string jobStatus { get; private set; }

        public string jobDescription { get; private set; }
        public string jobName { get; private set; }
        public bool isEnabled { get; private set; }
        public int stepsCount { get; private set; }
        public int currentStep { get; private set; }
        public string jobStepName { get; private set; }


        //static JobManager()
        //{
        //    Instance = new JobManager();
        //}

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

        private JobManager() { }

        private Server server = new Server("");
        private string jobStringForServer = "";
        

        public bool StartJob()
        { 
            server.JobServer.Jobs[jobStringForServer].Start();
            return true;
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

            this.jobStatus = server.JobServer.Jobs[jobStringForServer].CurrentRunStatus.ToString();
        }

        public void SetJobInformation()
        {
            var job = server.JobServer.Jobs[jobStringForServer];
            this.jobDescription = job.Description; // = job.Description;
            this.jobName = job.Name; // = job.Name;
            this.isEnabled = job.IsEnabled; // = job.isEnabled;
            this.stepsCount = job.JobSteps.Count; // = job.JobSteps.Count;
            this.currentStep = job.JobSteps[0].OnSuccessStep;
            this.jobStepName = job.CurrentRunStep; // = job.CurrentStepName;
            
        }

        public void SetCurrentStep()
        {

            if (server.JobServer.Jobs[jobStringForServer].JobSteps[this.currentStep].OnSuccessStep < this.stepsCount)
                this.currentStep++; // = jobStep.OnSuccessStep;
        }

    }
}