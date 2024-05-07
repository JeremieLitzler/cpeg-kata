import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import Booking from '../models/Booking';
import BookingRequest from '../models/BookingRequest';
import { API_BASE } from './app.service';

@Injectable({
  providedIn: 'root'
})
export class BookingsService {

  constructor(private http: HttpClient) { }

  getBookings(): Observable<Booking[]> {
    const url = `${API_BASE}/Bookings`;
    return this.http.get<Booking[]>(url)
      .pipe(
        catchError(this.handleError)
      );
  }
  
  createBooking(request: BookingRequest): Observable<void> {
    const url = `${API_BASE}/Bookings`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<void>(url, request, { headers })
      .pipe(
        catchError(this.handleError)
      );
  }
  
  removeBooking(bookingId: string): Observable<void> {
    const url = `${API_BASE}/Bookings/${bookingId}`;
    return this.http.delete<void>(url)
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
