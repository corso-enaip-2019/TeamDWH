import { Component } from '@angular/core';
import { DataService } from 'src/app/services/data-service';
import { IModuleInfo } from 'src/app/models/imoduleinfo'

@Component({
  selector: 'module-list',
  templateUrl: './module-list.component.html',
  styleUrls: ['./module-list.component.css']
})
export class ModuleList {
  public list: Array<IModuleInfo>;
  public currentUser: string;

  constructor(data: DataService) {
    var self: ModuleList = this;
        
    data.getList(function(items: Array<IModuleInfo>): void {
        self.list = items;
    });

    data.getCurrentUser(function(username: string): void{
        self.currentUser = username;
    });
  }
}