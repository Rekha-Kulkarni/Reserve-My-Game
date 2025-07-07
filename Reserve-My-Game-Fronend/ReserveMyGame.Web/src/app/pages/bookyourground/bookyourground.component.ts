import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

interface Playground {
  id: number;
  name: string;
  imageUrl: string;
  description: string;
  facilities: string[];
}

interface TimeSlot {
  id: number;
  time: string;
  available: boolean;
  price: number;
}

interface Booking {
  playgroundId: number;
  playgroundName: string;
  date: string;
  timeSlot: string;
  price: number;
}

@Component({
  selector: 'app-bookyourground',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './bookyourground.component.html',
  styleUrl: './bookyourground.component.css'
})


export class BookyourgroundComponent {
  /* ——— state & sample data ——— */
  currentPage: 'finder' | 'booking' | 'confirmation' = 'finder';
  selectedCityId = '';
  selectedSubAreaId = '';
  displayedPlaygrounds: Playground[] = [];
  selectedPlayground: Playground | null = null;

  playgroundToBook: Playground | null = null;
  selectedDate = '';
  selectedTimeSlot: TimeSlot | null = null;
  confirmedBooking: Booking | null = null;
  minDate = '';
  maxDate = '';

  timeSlots: TimeSlot[] = [
    { id: 1,  time: '9:00 AM – 10:00 AM',  available: true,  price: 25 },
    { id: 2,  time: '10:00 AM – 11:00 AM', available: true,  price: 25 },
    { id: 3,  time: '11:00 AM – 12:00 PM', available: false, price: 25 },
    { id: 4,  time: '12:00 PM – 1:00 PM',  available: true,  price: 30 },
    { id: 5,  time: '1:00 PM – 2:00 PM',   available: true,  price: 30 },
    { id: 6,  time: '2:00 PM – 3:00 PM',   available: false, price: 30 },
    { id: 7,  time: '3:00 PM – 4:00 PM',   available: true,  price: 35 },
    { id: 8,  time: '4:00 PM – 5:00 PM',   available: true,  price: 35 },
    { id: 9,  time: '5:00 PM – 6:00 PM',   available: true,  price: 40 },
    { id:10,  time: '6:00 PM – 7:00 PM',   available: false, price: 40 },
  ];

  constructor(private router: Router) {
  this.setDateLimits();

  const nav = this.router.getCurrentNavigation();
  const state = nav?.extras?.state as { playground: Playground };
  if (state?.playground) {
    this.playgroundToBook = state.playground;
    this.currentPage = 'booking'; // Or whatever logic you want
  }
}
  /* ——— helper / UI handlers ——— */
  setDateLimits(): void {
    const today = new Date();
    const max = new Date();
    max.setDate(today.getDate() + 30);

    this.minDate = today.toISOString().split('T')[0];
    this.maxDate = max.toISOString().split('T')[0];
  }

  onPlaygroundClick(pg: Playground): void {
    this.selectedPlayground = pg;
  }
  closeModal(): void { this.selectedPlayground = null; }

 
  goBack(): void { this.currentPage = 'finder';  this.resetBookingForm(); }
  goToFinder(): void { this.currentPage = 'finder'; this.confirmedBooking = null; }

  resetBookingForm(): void { this.selectedDate = ''; this.selectedTimeSlot = null; }

  onDateChange(): void { this.selectedTimeSlot = null; }

  selectTimeSlot(slot: TimeSlot): void { if (slot.available) this.selectedTimeSlot = slot; }

  confirmBooking(): void {
    if (!this.playgroundToBook || !this.selectedDate || !this.selectedTimeSlot) return;
    this.confirmedBooking = {
      playgroundId:  this.playgroundToBook.id,
      playgroundName:this.playgroundToBook.name,
      date:          this.formatDate(this.selectedDate),
      timeSlot:      this.selectedTimeSlot.time,
      price:         this.selectedTimeSlot.price
    };
    this.currentPage = 'confirmation';
  }

  formatDate(iso: string): string {
    const d = new Date(iso);
    return d.toLocaleDateString('en-US', {
      weekday:'long', year:'numeric', month:'long', day:'numeric'
    });
  }

  downloadReceipt(): void { alert('Receipt downloaded successfully!'); }
}

