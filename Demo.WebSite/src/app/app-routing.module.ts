import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListOrderComponent } from './order/list-order/list-order.component';
import { ListPostComponent } from './post/list-post/list-post.component';
import { ListCustomerComponent } from "./customer/list-customer/list-customer.component";


const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'order/list', component: ListOrderComponent },
  { path: 'post/list', component: ListPostComponent },
  { path: 'customer/list', component: ListCustomerComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
