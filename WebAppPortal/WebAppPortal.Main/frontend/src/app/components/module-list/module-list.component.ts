import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data-service';
import { IModuleInfo } from 'src/app/models/imoduleinfo'

@Component({
  selector: 'module-list',
  templateUrl: './module-list.component.html',
  styleUrls: ['./module-list.component.css']
})
export class ModuleList implements OnInit {
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

  ngOnInit() {
    let win = (window as any);
      if(win.location.search !== '?loaded' ) {
          
          setTimeout(() => {
            window.location.reload();
            win.location.search = '?loaded';
          }, 10000); // Activate after 10 second.
          
      }
  }

}