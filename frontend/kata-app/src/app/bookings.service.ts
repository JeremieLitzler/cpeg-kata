import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import Booking from '../types/Booking';

const BASE_URL = process.env['API_BASE'];

@Injectable({
  providedIn: 'root'
})
export class BookingsService {

  constructor(private http: HttpClient) { }

  getBookings(): Observable<Booking[]> {
    const url = `${BASE_URL}/Bookings`;
    return this.http.get<Booking[]>(url)
      .pipe(
        catchError(this.handleError)
      );
  }
  
  createBooking(booking: any): Observable<void> {
    const url = `${BASE_URL}/Bookings`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<void>(url, booking, { headers })
      .pipe(
        catchError(this.handleError)
      );
  }
  
  removeBooking(bookingId: string): Observable<void> {
    const url = `${BASE_URL}/Bookings/${bookingId}`;
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
