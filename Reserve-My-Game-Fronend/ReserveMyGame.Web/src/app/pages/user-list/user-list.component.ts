import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

export interface ImageItem {
  id: number;
  title: string;
  description: string;
  imageUrl: string;
  category: string;
}

@Component({
  selector: 'app-user-list',
  imports: [CommonModule],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css'
})
export class UserListComponent {
selectedItem: ImageItem | null = null;

  imageItems: ImageItem[] = [
    {
      id: 1,
      title: 'Cricket',
      description: ' ',
      imageUrl: 'cricket.jpg',
      category: ''
    },
    {
      id: 2,
      title: 'Football',
      description: ' ',
      imageUrl: 'football.jpg',
      category: ' '
    },
    {
      id: 3,
      title: 'Pickelball',
      description: ' ',
      imageUrl: 'pickelball.jpg',
      category: ' '
    }
  ];

  onImageClick(item: ImageItem): void {
    this.selectedItem = item;
    console.log('Image clicked:', item.title);
  }

  closeModal(): void {
    this.selectedItem = null;
  }
  
}

