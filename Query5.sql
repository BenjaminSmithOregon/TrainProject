SELECT COUNT (*) AS BagCount
FROM Passenger 
WHERE Baggage = 'true' AND EXISTS
         (SELECT *
FROM Ticket
WHERE RouteDate = '12/15/2014'
        AND PassengerID = PassengerID);