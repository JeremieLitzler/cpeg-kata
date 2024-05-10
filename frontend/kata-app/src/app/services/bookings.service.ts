import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

import { WebApiRootUri } from './base.service';
import Booking from '../../models/booking';
import BookingRequest from '../../models/bookingRequest';

@Injectable({
  providedIn: 'root',
})
export class BookingsService {
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(private http: HttpClient) {}

  getBookings(): Observable<Booking[]> {
    return this.http
      .get<Booking[]>(`${WebApiRootUri}/Bookings`)
      .pipe(catchError(this.handleError<Booking[]>('getBookings', [])));
  }

  add(booking: BookingRequest): Observable<Object> {
    return this.http
      .post(`${WebApiRootUri}/Bookings`, booking)
      .pipe(catchError(this.handleError<string>('add', '')));
  }
  cancel(bookingId: string): Observable<Object> {
    return this.http.delete(`${WebApiRootUri}/Bookings/${bookingId}`);
  }
  /**
   * Handle Http operation that failed.
   * Let the app continue.
   *
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
