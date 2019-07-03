export interface IJobModel{
    jobStatus: string;
    jobDescription: string;
    jobName: string;
    isEnabled: boolean;
    stepsCount: number;
    currentStep: number;
    jobStepName: string;
}