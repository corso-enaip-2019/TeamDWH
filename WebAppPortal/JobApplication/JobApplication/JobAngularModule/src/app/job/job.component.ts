import { Component, Injectable } from '@angular/core';
import { JobService } from '../services/job-service';
import { IJobModel } from '../models/job.model';

@Component({
  selector: 'job-view',
  templateUrl: './job.component.html',
  styleUrls: ['./job.component.css']
})

@Injectable()
export class JobComponent {

  logoEuris: string = "/JobAngularModule/src/assets/gruppo_euris.jpeg"

  private job: IJobModel;

  private interval;

  private hasJobStarted: boolean;

  private hasProgressBarStarted: boolean;

  private barValue: number;

  constructor(private data: JobService) {
    this.job = this.data.getJob();
    this.hasJobStarted = false;
    this.hasProgressBarStarted = false;
  }

  public startJob(): void {
    var self: JobComponent = this;
    this.data.startJob(function (items: boolean): void {
      self.hasJobStarted = items;
      if(self.hasJobStarted === true){
        self.startProgressBar();
      }
      else{
        self.hasProgressBarStarted = true;
      }
    });
  }

  public getJobStatus(): void {
    var self: JobComponent = this;
    this.data.getJobStatus(function (items: string): void {
      self.job.jobStatus = items;
    });
    if(this.job.jobStatus == "Idle" && this.job.currentStep >= this.job.stepsCount){
      this.barValue = this.job.currentStep;
      clearInterval(this.interval);
      this.hasProgressBarStarted = false;
    }
  }

  public startProgressBar(): void {
    if(this.hasProgressBarStarted === false){
      this.getFullJob();
      this.interval = setInterval(() => this.updateProgressBar(), 100);
      this.hasProgressBarStarted = true;
    }
  }

  public getFullJob(): void {
    var self: JobComponent = this;
    this.data.getFullJob(function (items: IJobModel): void {
      self.job = items;
      self.barValue = items.currentStep;
    });
  }

  public updateProgressBar(): void {
    if(this.job.currentStep < this.job.stepsCount){
      var self: JobComponent = this;
      this.data.getFullJob(function (items: IJobModel): void {
        self.job.jobStatus = items.jobStatus;
        self.job.currentStep = items.currentStep;
        self.job.jobStepName = items.jobStepName;
        self.barValue = items.currentStep - 1;
      });
    }
    else{
      clearInterval(this.interval);
      this.interval = setInterval(() => this.getJobStatus(), 100);
    }
  }
}