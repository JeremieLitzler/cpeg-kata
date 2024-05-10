import { Component, OnInit } from '@angular/core';
import Booking from '../../models/booking';
import { BookingsService } from '../services/bookings.service';
import { RoomsService } from '../services/rooms.service';
import { Room } from '../../models/room';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-list-bookings',
  templateUrl: './list-bookings.component.html',
  styleUrl: './list-bookings.component.css',
})
export class ListBookingsComponent implements OnInit {
  bookings: Booking[] = [];
  constructor(
    private roomsService: RoomsService,
    private bookingService: BookingsService
  ) {}

  ngOnInit(): void {
    this.getBookings();
  }
  getBookings(): void {
    this.bookingService.getBookings().subscribe((bookings) => {
      this.bookings = bookings.sort((current, next) =>
        this.orderBy(['date', 'startTime'], current, next)
      );
    });
  }

  /**
   * Compare current booking and next booking's prop to order them.
   *
   * TODO > Refractor : solve TS issue when using `current[prop]`.
   *
   * @param props the props to order by from (ASCENDING)
   * @param current current booking
   * @param next next booking
   * @returns 1 or -1
   */
  orderBy(props: string[], current: Booking, next: Booking) {
    let currentValConcat = '';
    let nextValConcat = '';

    props.forEach((prop) => {
      if (prop === 'date') {
        currentValConcat = `${currentValConcat}#${current.bookingDetails.date!.toString()}`;
        nextValConcat = `${nextValConcat}#${next.bookingDetails.date!.toString()}`;
      }
      if (prop === 'startTime') {
        currentValConcat = `${currentValConcat}#${current.bookingDetails.startTime!.toString()}`;
        nextValConcat = `${nextValConcat}#${next.bookingDetails.startTime!.toString()}`;
      }
    });

    return currentValConcat > nextValConcat ? 1 : -1;
  }
  remove(bookingId: string): void {
    this.bookingService.cancel(bookingId).subscribe(() => this.getBookings());
  }
}
