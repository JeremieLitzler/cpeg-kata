import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

import { WebApiRootUri } from './base.service';
import { Room } from '../../models/room';
import { TimeSlot } from '../../models/timeSlot';

@Injectable({
  providedIn: 'root',
})
export class RoomsService {
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(private http: HttpClient) {}

  getRooms(): Observable<Room[]> {
    return this.http
      .get<Room[]>(`${WebApiRootUri}/Rooms`)
      .pipe(catchError(this.handleError<Room[]>('getRooms', [])));
  }
  getRoomAvaibility(
    roomId?: string,
    requestDate?: string
  ): Observable<TimeSlot[]> {
    return this.http
      .get<TimeSlot[]>(
        `${WebApiRootUri}/Rooms/${roomId}/availability/date=${requestDate}`
      )
      .pipe(catchError(this.handleError<TimeSlot[]>('getRoomAvaibility', [])));
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
