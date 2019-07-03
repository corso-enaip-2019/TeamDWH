import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { ModuleList } from './components/module-list/module-list.component';
import { HttpClientModule } from '@angular/common/http';
import { DataService } from './services/data-service';

@NgModule({
  declarations: [
    AppComponent,
    ModuleList
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [
    DataService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
