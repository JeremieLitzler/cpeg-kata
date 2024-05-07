import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import Booking from '../models/Booking';

@Component({
  selector: 'app-root',
  // standalone: true,
  // imports: [RouterOutlet, RouterLink],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  items: Booking[] = [
    {
      id: 'booking1', 
      booker: {
        lastname: 'Doe', 
        firstname: 'John'
      }, 
      bookingDetails: {
        roomId: 'room1', date: new Date('2024-05-07'), startTime: '09:00', endTime: '09:30'
      }
    },
    {
      id: 'booking2', 
      booker: {
        lastname: 'Doe', 
        firstname: 'John'
      }, 
      bookingDetails: {
        roomId: 'room1', date: new Date('2024-05-07'), startTime: '09:30', endTime: '10:00'
      }
    },
    {
      id: 'booking3', 
      booker: {
        lastname: 'Doe', 
        firstname: 'John'
      }, 
      bookingDetails: {
        roomId: 'room2', date: new Date('2024-05-08'), startTime: '09:00', endTime: '09:00'
      }
    },
  ]
  title = 'CPEG Kata booking';
}
