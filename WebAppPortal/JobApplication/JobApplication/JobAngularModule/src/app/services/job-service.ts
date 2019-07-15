import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { IJobModel } from '../models/job.model';
import { JobConfig } from '../config/job.config';

@Injectable()
export class JobService {
  constructor(private http: HttpClient) {
  }

  public startJob(callback: (items: boolean) => void): void {
    var item = this.http.get<boolean>(JobConfig.apiDefaultUri + "/api/startJob")
    .subscribe(
      data => {
        callback(data);
      },
      error => {

      }
    );
  }

  public getJobStatus(callback: (items: string) => void): void {
    var item = this.http.get<string>(JobConfig.apiDefaultUri + "/api/getJobStatus")
    .subscribe(
      data => {
        callback(data);
      },
      error => {

      }
    );
  }

  public getFullJob(callback: (items: IJobModel) => void): void {
    var item = this.http.get<IJobModel>(JobConfig.apiDefaultUri + "/api/getFullJob")
      .subscribe(
        data => {
          callback(data);
        },
        error => {

        }
      );
  }

  public getJob() : IJobModel {
    return {
      jobStatus: "Not started",
      jobDescription: "Not started",
      jobName: "Not started",
      isEnabled: false,
      stepsCount: 0,
      currentStep: 0,
      jobStepName: "Not started"
    };
  }
}