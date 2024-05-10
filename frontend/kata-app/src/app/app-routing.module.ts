import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MakeBookingComponent } from './make-booking/make-booking.component';
import { ListBookingsComponent } from './list-bookings/list-bookings.component';

const routes: Routes = [
  // Default route
  { path: '', redirectTo: '/bookings', pathMatch: 'full' },
  // Specific routes
  { path: 'make-booking', component: MakeBookingComponent },
  { path: 'bookings', component: ListBookingsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
