using System;

namespace JobApplication.Models
{
    public interface IJobModel
    {
        string jobStatus { get; }
        string jobDescription { get; }
        string jobName { get; }
        bool isEnabled { get; }
        int stepsCount { get; }
        int currentStep { get; }
        string jobStepName { get; }
        
    }
}
