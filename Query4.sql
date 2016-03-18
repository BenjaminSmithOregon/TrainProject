SELECT DISTINCT RouteDate
FROM Ticket JOIN Passenger ON Passenger.PassengerID =     Ticket.PassengerID
WHERE LastName = 'Smith';