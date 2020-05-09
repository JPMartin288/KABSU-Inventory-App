CREATE PROCEDURE `StoreData`(
IN ToFrom VARCHAR(100),
IN Date VARCHAR(32),
IN Received INT,
IN Shipped INT,
IN Balance INT,
IN AnimalID VARCHAR(32),
IN Can VARCHAR(32),
IN CollDate VARCHAR(128))
BEGIN
INSERT kabsu.Record(ToFrom, Date, NumReceived, NumShipped, Balance, AnimalID, CanNum, CollDate)
VALUES(ToFrom, Date, Received, Shipped, Balance, AnimalID, Can, CollDate);
END
