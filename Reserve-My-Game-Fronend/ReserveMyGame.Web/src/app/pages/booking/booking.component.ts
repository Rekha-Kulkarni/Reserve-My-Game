import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink, RouterOutlet } from '@angular/router';

interface Playground {
  id: number;
  name: string;
  imageUrl: string;
  description: string;
  facilities: string[];
}

interface SubArea {
  id: number;
  name: string;
  playgrounds: Playground[];
}

interface City {
  id: number;
  name: string;
  subAreas: SubArea[];
}

@Component({
  selector: 'app-booking',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink,RouterOutlet],
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css'] // Optional: Add styles here
})


export class BookingComponent {
  selectedCityId: string = '';
  selectedSubAreaId: string = '';
  selectedCity: City | null = null;
  selectedSubArea: SubArea | null = null;
  displayedPlaygrounds: Playground[] = [];
  selectedPlayground: Playground | null = null;

  cities: City[] = [
    {
      id: 1,
      name: 'New York',
      subAreas: [
        {
          id: 1,
          name: 'Manhattan',
          playgrounds: [
            {
              id: 1,
              name: 'Central Park Playground',
              imageUrl: 'https://images.pexels.com/photos/1108099/pexels-photo-1108099.jpeg?auto=compress&cs=tinysrgb&w=800',
              description: 'Large playground with swings, slides, and climbing structures in the heart of Manhattan.',
              facilities: ['Swings', 'Slides', 'Climbing Frame', 'Sandbox']
            },
            {
              id: 2,
              name: 'Riverside Park Adventure',
              imageUrl: 'https://images.pexels.com/photos/1108117/pexels-photo-1108117.jpeg?auto=compress&cs=tinysrgb&w=800',
              description: 'Waterfront playground with modern equipment and beautiful river views.',
              facilities: ['Modern Equipment', 'Water Features', 'Picnic Area']
            }
          ]
        },
        {
          id: 2,
          name: 'Brooklyn',
          playgrounds: [
            {
              id: 3,
              name: 'Prospect Park Playground',
              imageUrl: 'https://images.pexels.com/photos/1108101/pexels-photo-1108101.jpeg?auto=compress&cs=tinysrgb&w=800',
              description: 'Family-friendly playground with diverse play equipment for all ages.',
              facilities: ['Age-Specific Areas', 'Basketball Court', 'Restrooms']
            }
          ]
        }
      ]
    },
    {
      id: 2,
      name: 'Los Angeles',
      subAreas: [
        {
          id: 3,
          name: 'Santa Monica',
          playgrounds: [
            {
              id: 4,
              name: 'Beach Playground',
              imageUrl: 'https://images.pexels.com/photos/1108103/pexels-photo-1108103.jpeg?auto=compress&cs=tinysrgb&w=800',
              description: 'Beachside playground with ocean views and sand play areas.',
              facilities: ['Beach Access', 'Sand Play', 'Volleyball Court']
            }
          ]
        },
        {
          id: 4,
          name: 'Hollywood',
          playgrounds: [
            {
              id: 5,
              name: 'Griffith Park Playground',
              imageUrl: 'https://images.pexels.com/photos/1108105/pexels-photo-1108105.jpeg?auto=compress&cs=tinysrgb&w=800',
              description: 'Mountain playground with hiking trails and nature exploration.',
              facilities: ['Nature Trails', 'Observatory Views', 'Picnic Tables']
            },
            {
              id: 6,
              name: 'Hollywood Recreation Center',
              imageUrl: 'https://images.pexels.com/photos/1108107/pexels-photo-1108107.jpeg?auto=compress&cs=tinysrgb&w=800',
              description: 'Community playground with sports facilities and group activities.',
              facilities: ['Sports Courts', 'Group Areas', 'Parking']
            }
          ]
        }
      ]
    },
    {
      id: 3,
      name: 'Chicago',
      subAreas: [
        {
          id: 5,
          name: 'Downtown',
          playgrounds: [
            {
              id: 7,
              name: 'Millennium Park Play Area',
              imageUrl: 'https://images.pexels.com/photos/1108109/pexels-photo-1108109.jpeg?auto=compress&cs=tinysrgb&w=800',
              description: 'Urban playground in the heart of downtown with city skyline views.',
              facilities: ['City Views', 'Art Installations', 'Food Nearby']
            }
          ]
        },
        {
          id: 6,
          name: 'Lincoln Park',
          playgrounds: [
            {
              id: 8,
              name: 'Lincoln Park Zoo Playground',
              imageUrl: 'https://images.pexels.com/photos/1108111/pexels-photo-1108111.jpeg?auto=compress&cs=tinysrgb&w=800',
              description: 'Zoo-themed playground with animal-inspired play structures.',
              facilities: ['Zoo Access', 'Animal Themes', 'Educational Elements']
            }
          ]
        }
      ]
    }
  ];

  onCityChange(): void {
    this.selectedCity = this.cities.find(city => city.id === Number(this.selectedCityId)) || null;
    this.selectedSubAreaId = '';
    this.selectedSubArea = null;
    this.displayedPlaygrounds = [];
  }
  router = inject(Router);  

  onSubAreaChange(): void {
    if (this.selectedCity) {
      this.selectedSubArea = this.selectedCity.subAreas.find(subArea => subArea.id === Number(this.selectedSubAreaId)) || null;
      this.displayedPlaygrounds = this.selectedSubArea ? this.selectedSubArea.playgrounds : [];
    }
  }

  onPlaygroundClick(playground: Playground): void {
    debugger;
    this.selectedPlayground = playground;
  }

  goToBooking(pg: Playground,  event?: Event) {
  event?.stopPropagation()
    debugger;
    this.selectedPlayground = pg;
    this.router.navigate(['home/bookyourground'], {
    state: { playground: pg }
});

  } 
  closeModal(): void {
    this.selectedPlayground = null;
  }
}
