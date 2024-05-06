import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

const BASE_URL = process.env['API_BASE'];

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  constructor(private http: HttpClient) { }

  getBookings(): Observable<any[]> {
    const url = `${BASE_URL}/Bookings`;
    return this.http.get<any[]>(url)
      .pipe(
        catchError(this.handleError)
      );
  }
  
  createBooking(booking: any): Observable<any> {
    const url = `${BASE_URL}/Bookings`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<any>(url, booking, { headers })
      .pipe(
        catchError(this.handleError)
      );
  }
  
  removeBooking(bookingId: number): Observable<any> {
    const url = `${BASE_URL}/Bookings/${bookingId}`;
    return this.http.delete<any>(url)
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
