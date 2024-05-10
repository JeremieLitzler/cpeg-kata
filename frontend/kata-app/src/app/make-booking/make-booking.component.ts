import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { RoomsService } from '../services/rooms.service';
import { Room } from '../../models/room';
import { TimeSlot } from '../../models/timeSlot';
import { Individual } from '../../models/individual';
import { BookingsService } from '../services/bookings.service';
import BookingDetails from '../../models/bookingDetails';

@Component({
  selector: 'app-make-booking',
  templateUrl: './make-booking.component.html',
  styleUrl: './make-booking.component.css',
})
export class MakeBookingComponent implements OnInit {
  errorMessage?: string;
  rooms: Room[] = [];
  timeSlots: TimeSlot[] = [];
  dateOfBooking?: string;
  selectedRoom?: Room;
  selectedSlot?: TimeSlot;
  bookerLastName?: string;
  bookerFirstName?: string;
  bookerBirthDate?: string;
  bookerEmail?: string;

  constructor(
    private router: Router,
    private roomsService: RoomsService,
    private bookingService: BookingsService
  ) {}

  ngOnInit(): void {
    this.getRooms();
  }
  getRooms(): void {
    this.roomsService.getRooms().subscribe((rooms) => (this.rooms = rooms));
  }
  onRoomSelect(room: Room) {
    this.selectedRoom = room;
  }

  getAvailableSlots() {
    console.log('getAvailableSlots', this.dateOfBooking);
    console.log('getAvailableSlots', typeof this.dateOfBooking);

    this.roomsService
      .getRoomAvaibility(this.selectedRoom?.id, this.dateOfBooking)
      .subscribe(
        (timeSlots) => (this.timeSlots = timeSlots),
        (err) => {
          this.errorMessage = err;
        }
      );
  }
  onTimeSlotSelect(slot: TimeSlot) {
    this.selectedSlot = slot;
  }

  validate(): string[] {
    const errors: string[] = [];
    if (this.dateOfBooking == undefined) {
      errors.push('Missing booking date');
    }
    if (this.selectedRoom == undefined) {
      errors.push('Missing room');
    }
    if (this.selectedSlot == undefined) {
      errors.push('Missing booking time');
    }
    if (this.bookerLastName == undefined) {
      errors.push('Missing lastname');
    }
    if (this.bookerFirstName == undefined) {
      errors.push('Missing firstname');
    }
    if (this.bookerBirthDate == undefined) {
      errors.push('Missing birth date');
    }
    if (this.bookerEmail == undefined) {
      errors.push('Missing email');
    }

    return errors;
  }
  submitNewBooking() {
    console.log('start submit...');

    const errors = this.validate();
    if (errors.length > 0) {
      this.errorMessage = errors.join('\n\r');
      return;
    }
    const booker: Individual = {
      lastname: this.bookerLastName,
      firstname: this.bookerFirstName,
      birthDate: this.bookerBirthDate,
      email: this.bookerEmail,
    };
    const bookingDetails: BookingDetails = {
      date: this.dateOfBooking,
      roomId: this.selectedRoom?.id,
      startTime: this.selectedSlot?.startTime,
      endTime: this.selectedSlot?.endTime,
    };
    const bookingId = this.bookingService
      .add({
        booker,
        timeSlot: this.selectedSlot,
        date: this.dateOfBooking,
        roomId: this.selectedRoom?.id,
      })
      .subscribe(
        (id) => this.router.navigate(['/bookings']),
        (err) => {
          this.errorMessage = err;
        }
      );

    console.log('MakeBookingComponent>submit>bookingId', bookingId);
  }
}
