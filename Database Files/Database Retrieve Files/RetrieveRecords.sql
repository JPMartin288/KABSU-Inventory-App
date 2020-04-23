CREATE PROCEDURE `RetrieveRecords`(
IN AnimalID VARCHAR(32))
BEGIN
SELECT R.ToFrom, R.Date, R.NumReceived, R.NumShipped, R.Balance
FROM Record R
WHERE R.AnimalID = AnimalID;
END