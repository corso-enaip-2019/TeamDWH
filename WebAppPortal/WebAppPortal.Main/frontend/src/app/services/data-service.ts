import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { IModuleInfo } from 'src/app/models/imoduleinfo'
import { AppConfig } from "../config/app.config";

@Injectable()
export class DataService {
    constructor(private http: HttpClient) {
    }

    public getList(callback: (items: Array<IModuleInfo>) => void): void {
        this.http.get<Array<IModuleInfo>>(AppConfig.apiBaseUrl + "/api/main/modules")
            .subscribe(
                data => {
                    callback(data);
                },
                error => {
                    console.log(error);
                }
            );
    }

    public getCurrentUser(callback: (username: string) => void): void {
        this.http.get<string>(AppConfig.apiBaseUrl + "/api/main/currentUser")
            .subscribe(
                data => {
                    callback(data);
                },
                error => {
                    console.log(error);
                }
            );
    }
}