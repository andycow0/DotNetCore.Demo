import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
// import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { MatButtonModule, MatIconModule } from '@angular/material'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './/app-routing.module';
import { HttpClientModule } from '@angular/common/http';

import { IPostService } from "./post/ipost.interface";
import { PostService } from "./post/post.service";
import { FormsModule } from '@angular/forms';
import { ListPostComponent } from './post/list-post/list-post.component';
import { ListOrderComponent } from './order/list-order/list-order.component';
import { ListCustomerComponent } from './customer/list-customer/list-customer.component';
import { ICustomerService } from './customer/icustomer.interface';
import { CustomerService } from './customer/customer.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ListPostComponent,
    ListOrderComponent,
    ListCustomerComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatIconModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  exports: [],
  providers: [
    { provide: IPostService, useClass: PostService },
    { provide: ICustomerService, useClass: CustomerService }
  ],
  bootstrap: [AppComponent]
  // entryComponents: [AppComponent]
})
export class AppModule { }
