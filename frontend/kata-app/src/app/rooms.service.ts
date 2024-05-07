import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import Room from '../types/Room';
import TimeSlot from '../types/TimeSlot';
import Booking from '../types/Booking';

const BASE_URL = process.env['API_BASE'];

@Injectable({
  providedIn: 'root'
})
export class RoomsService {

  constructor(private http: HttpClient) { }

  getRooms(): Observable<Room[]> {
    const url = `${BASE_URL}/Rooms`;
    return this.http.get<Room[]>(url)
      .pipe(
        catchError(this.handleError)
      );
  }
  
  getRoomAvailability(roomId: string, requestDate: string): Observable<TimeSlot[]> {
    const url = `${BASE_URL}/Rooms/${roomId}/availability/date=${requestDate}`;
    return this.http.get<TimeSlot[]>(url)
      .pipe(
        catchError(this.handleError)
      );
  }
  
  getRoomBookings(roomId: string): Observable<Booking[]> {
    const url = `${BASE_URL}/Rooms/${roomId}/bookings`;
    return this.http.delete<Booking[]>(url)
      .pipe(
        catchError(this.handleError)
      );
  }
  
  private handleError(errorParent: any): Observable<any> {
    console.error('An error occurred:', errorParent);
    return throwError(() => {
      const error: any = new Error(errorParent);
      error.timestamp = Date.now();
      return error;
    });
  }
}
