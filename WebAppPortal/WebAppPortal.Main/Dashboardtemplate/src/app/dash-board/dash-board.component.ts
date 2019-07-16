import { Component } from '@angular/core';
import { IModuleInfo } from '../models/ImoduleInfo';
import { DataService } from 'src/app/services/data-service';

@Component({
  selector: 'app-dash-board',
  templateUrl: './dash-board.component.html',
  styleUrls: ['./dash-board.component.css']
})
export class DashBoardComponent {

  public list: Array<IModuleInfo>;

  constructor(data:DataService) {
    var self: DashBoardComponent = this;

    data.getList(function(items: Array<IModuleInfo>) : void {
      self.list = items;
    });
  }
}
