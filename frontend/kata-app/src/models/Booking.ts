import BookingDetails from './bookingDetails';
import { Individual } from './individual';

export default interface Booking {
  id: string;
  booker: Individual;
  bookingDetails: BookingDetails;
}
