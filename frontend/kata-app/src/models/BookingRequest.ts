import { Individual } from './individual';
import { TimeSlot } from './timeSlot';

export default interface BookingRequest {
  booker: Individual;
  timeSlot?: TimeSlot;
  roomId?: string;
  date?: string;
}
