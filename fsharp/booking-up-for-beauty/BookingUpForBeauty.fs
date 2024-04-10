module BookingUpForBeauty

// The following line is needed to use the DateTime type
open System
open System.Globalization

let schedule (appointmentDateDescription: string): DateTime =
    DateTime.Parse(appointmentDateDescription)

let hasPassed (appointmentDate: DateTime): bool =
    DateTime.Now > appointmentDate

let isAfternoonAppointment (appointmentDate: DateTime): bool =
    appointmentDate.Hour >= 12 && appointmentDate.Hour < 18

let description (appointmentDate: DateTime): string = 
    sprintf "You have an appointment on %s" (appointmentDate.ToString "M/d/yyyy h:mm:ss tt.")

let anniversaryDate(): DateTime = 
    new DateTime(DateTime.Now.Year, 9, 15, 0,0,0)
