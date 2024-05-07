import { Routes } from '@angular/router';
import { ListBookingsComponent } from './list-bookings/list-bookings.component'; // Assuming your component's path
import { MakeBookingComponent } from './make-booking/make-booking.component';
export const routes: Routes = [
      { path: 'bookings', component: ListBookingsComponent },
      { path: 'make-booking', component: MakeBookingComponent }

];
