import IWithId from './IWithId';
import Individual from './Individual';
import BookingDetails from './BookingDetails';

 export default interface Booking extends IWithId {
    booker?: Individual;
    bookingDetails?: BookingDetails;
}