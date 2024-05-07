import Individual from './Individual'
import TimeSlot from './TimeSlot'

export default interface BookingRequest  {  
    booker?: Individual
    timeSlot?: TimeSlot
    roomId: string
    date?: Date
}