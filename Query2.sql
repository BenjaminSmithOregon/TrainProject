SELECT DISTINCT City
FROM Station JOIN Route ON Station.StationID = Route.StationID
WHERE TrainID IN 
(SELECT TrainID 
FROM Train 
WHERE TrainModel = 'BulletTrain');
