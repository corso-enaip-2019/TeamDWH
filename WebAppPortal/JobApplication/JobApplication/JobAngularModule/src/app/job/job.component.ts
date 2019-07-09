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

  private isButtonDisabled: boolean;
  private hasProgressBarStarted: boolean;

  constructor(private data: JobService) {
    this.job = this.data.getJob();
    this.isButtonDisabled = true;
    this.hasJobStarted = false;
    this.hasProgressBarStarted = false;
  }

  public startJob(): void {
    var self: JobComponent = this;
    this.data.startJob(function (items: boolean): void {
      self.hasJobStarted = items;
      if(self.hasJobStarted === true){
        self.startProgressBar();
        self.isButtonDisabled = false;
      }
      else{
        alert("Job couldn't start");
      }
    });

  }

  public getJobStatus(): void {
    var self: JobComponent = this;
    this.data.getJobStatus(function (items: string): void {
      self.job.jobStatus = items;
    });
  }

  public startProgressBar(): void {
    if(this.hasProgressBarStarted === false){
      this.getFullJob();
      this.interval = setInterval(() => this.updateProgressBar(), 5000);
      this.hasProgressBarStarted = true;
    }
  }

  public getFullJob(): void {
    var self: JobComponent = this;
    this.data.getFullJob(function (items: IJobModel): void {
      self.job = items;
    });
  }

  public updateProgressBar(): void {
    var self: JobComponent = this;
    this.data.getJobCurrentStep(function (items: number): void {
      self.job.currentStep = items;
    });
  }

}