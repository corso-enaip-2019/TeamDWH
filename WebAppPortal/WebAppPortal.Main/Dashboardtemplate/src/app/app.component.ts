import { Component } from '@angular/core';
import { IModuleInfo } from './models/ImoduleInfo';
import { DataService } from './services/data-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent{

  public title = 'Portale-DWH';
  public logo: string = "Dashboardtemplate/DashDemo/src/assets/Gruppo_euris.jpeg"
  public CurrentUser: string;
  public list: Array<IModuleInfo>;
  public doc : Document;

  constructor(data:DataService){

    var self: AppComponent = this;

    data.getCurrentUser(function (username: string): void{
      self.CurrentUser = username;
    });
  }
}