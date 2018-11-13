import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListEmployeesComponent } from './order/list-employees.component';
import { ListPostComponent } from './post/list-post/list-post.component';


const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'order/list', component: ListEmployeesComponent },
  { path: 'post/list', component: ListPostComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
