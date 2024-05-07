import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import Room from '../models/Room';
import TimeSlot from '../models/TimeSlot';
import Booking from '../models/Booking';
import { API_BASE } from './app.service';

@Injectable({
  providedIn: 'root'
})
export class RoomsService {

  constructor(private http: HttpClient) { }

  getRooms(): Observable<Room[]> {
    const url = `${API_BASE}/Rooms`;
    return this.http.get<Room[]>(url)
      .pipe(
        catchError(this.handleError)
      );
  }
  
  getRoomAvailability(roomId: string, requestDate: string): Observable<TimeSlot[]> {
    const url = `${API_BASE}/Rooms/${roomId}/availability/date=${requestDate}`;
    return this.http.get<TimeSlot[]>(url)
      .pipe(
        catchError(this.handleError)
      );
  }
  
  getRoomBookings(roomId: string): Observable<Booking[]> {
    const url = `${API_BASE}/Rooms/${roomId}/bookings`;
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
