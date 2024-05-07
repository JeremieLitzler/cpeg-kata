import Individual from './Individual'
import TimeSlot from './TimeSlot'

export default interface BookingRequest  {  
    Booker?: Individual
    TimeSlot?: TimeSlot
    RoomId: string
    Date?: Date
}