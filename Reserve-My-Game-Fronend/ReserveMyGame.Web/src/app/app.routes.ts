import { Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { UserListComponent } from './pages/user-list/user-list.component';
import { BookingComponent } from './pages/booking/booking.component';
import { BookyourgroundComponent } from './pages/bookyourground/bookyourground.component';
import { ConfirmbookingComponent } from './pages/confirmbooking/confirmbooking.component';

export const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent,children:[{  path:'user-list',component:UserListComponent}, {  path:'booking',component:BookingComponent},
    {  path:'bookyourground',component:BookyourgroundComponent}, {  path:'confirmbooking',component:ConfirmbookingComponent}
  ] },
  // Wildcard route for a 404 page (optional)
  { path: '**', redirectTo: 'login' }

];
