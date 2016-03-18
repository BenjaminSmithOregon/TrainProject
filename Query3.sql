SELECT TrainName
FROM Train
WHERE TrainID IN 
(SELECT TrainID
FROM Route JOIN Station ON Station.StationID = Route.StationID
WHERE City = 'Salem');