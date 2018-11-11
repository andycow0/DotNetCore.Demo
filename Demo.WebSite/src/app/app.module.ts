import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ListEmployeesComponent } from './order/list-employees.component'

import { MatButtonModule, MatIconModule } from '@angular/material'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
//import { AppRoutingModule } from './/app-routing.module';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'order/list', component: ListEmployeesComponent }
];


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ListEmployeesComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    BrowserAnimationsModule,
    MatButtonModule,
    MatIconModule,
    //AppRoutingModule
  ],
  exports: [RouterModule],
  providers: [],
  bootstrap: [AppComponent]
  // entryComponents: [AppComponent]
})
export class AppModule { }
