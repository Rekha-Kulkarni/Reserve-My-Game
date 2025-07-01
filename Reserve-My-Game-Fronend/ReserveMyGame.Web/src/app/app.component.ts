import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { provideHttpClient } from '@angular/common/http';
import { NgModule } from '@angular/core';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'ReserveMyGame.Web';

  data: any;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.fetchData(); // ✅ Call fetchData() when the component loads
  }

  fetchData() {
    this.http.get<string>('https://localhost:7006/WeatherForecast/Test').subscribe(response => {
      this.data = response;
      console.log(this.data);
    }); 
  }
}