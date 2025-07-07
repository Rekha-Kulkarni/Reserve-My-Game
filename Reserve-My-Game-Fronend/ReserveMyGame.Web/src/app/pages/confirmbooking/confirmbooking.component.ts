import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'app-confirmbooking',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './confirmbooking.component.html',
  styleUrl: './confirmbooking.component.css'
})
export class ConfirmbookingComponent {

constructor(private router: Router) {

  const nav = this.router.getCurrentNavigation();
 
}
  

  downloadReceipt(): void { alert('Receipt downloaded successfully!'); }
}




  