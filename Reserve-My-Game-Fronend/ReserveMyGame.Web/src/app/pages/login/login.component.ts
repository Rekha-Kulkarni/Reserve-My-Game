import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  toggleForm: boolean = false;

  registerObj: any = {
    userId: 2,
    userName: "",
    emailId: "",
    city: "",     
    mobileNo: "",
    address: "",
    password: ""
  } 

  loginObj: any = {
    emailId: "",
    password: ""
  } 

  http = inject(HttpClient);
  router = inject(Router);  
  onRegister  () {
    debugger;
    this.http.post('https://localhost:7006/api/user/AddUser', this.registerObj).subscribe((res: any) => {
      alert("Registratio success.")
    }, error => {
      debugger;
      if(error.status=400){
        alert("invalid body")
      }
    })
  }

  onLogin  () {
    debugger;
    this.http.post('https://localhost:7006/api/user/Login', this.loginObj).subscribe((res: any) => {
      alert("Logged In.")
      localStorage.setItem('userApp',JSON.stringify(res))
      this.router.navigateByUrl("home/user-list")
    }, error => {
      debugger;
      if(error.status=400){
        alert("wrong credentials")
      }
    })
  }

}
