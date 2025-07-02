import { Component, inject } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-home',
  imports: [RouterLink,RouterOutlet],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  router=inject(Router)
  logOff(){
    localStorage.removeItem("userApp")
    this.router.navigateByUrl("Home/Login")
  }

}
