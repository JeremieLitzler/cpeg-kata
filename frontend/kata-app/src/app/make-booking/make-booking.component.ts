import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { RoomsService } from '../../services/rooms.service';
import { BookingsService } from '../../services/bookings.service';
import TimeSlot from '../../models/TimeSlot';
import Room from '../../models/Room';
import BookingRequest from '../../models/BookingRequest';

@Component({
  selector: 'app-make-booking',
  templateUrl: './make-booking.component.html',
  styleUrls: ['./make-booking.component.css'],
  })
export class MakeBookingComponent implements OnInit {

  rooms: Room[] = [];
  selectedRoomId: string | null = null;
  date: Date | null = null;
  selectedTimeSlot: TimeSlot | null = null;
  user: any = {}; // Object to hold user information

  constructor(private roomsService: RoomsService, private bookingsService: BookingsService) { }

  ngOnInit() {
    this.getRooms();
  }

  getRooms() {
    this.roomsService.getRooms()
      .subscribe(rooms => this.rooms = rooms);
  }

  // Function to handle room selection
  onRoomSelect(roomId: string) {
    this.selectedRoomId = roomId;
    this.selectedTimeSlot = null; // Reset time slot on room change
    this.getTimeSlotAvailability();
  }

  getTimeSlotAvailability() {
    if (this.selectedRoomId) {
      // Assuming you have a date input in your template
      const selectedDate = new Date().getDate().toLocaleString();
      this.roomsService.getRoomAvailability(this.selectedRoomId, selectedDate)
        .subscribe(timeSlots => console.log('Time slots:', timeSlots));
    }
  }

  onTimeSlotSelect(timeSlot: TimeSlot) {
    this.selectedTimeSlot = timeSlot;
  }

  // Function to handle booking submission
  onSubmitBooking() {
    const bookingData: BookingRequest = {
      //Read from the date input in template
      date: new Date(),
      roomId: this.selectedRoomId || '',
      timeSlot: this.selectedTimeSlot || {},
      // Add user information from your form to bookingData
      booker: this.user,
    };
    this.bookingsService.createBooking(bookingData)
      .subscribe(() => {
        // Handle successful booking, e.g., clear form or show confirmation message
      }, error => {
        // Handle booking error
        console.error('Error creating booking:', error);
      });
  }

  // ... other component logic
}
