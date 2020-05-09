CREATE DEFINER=`kabsu`@`%.ksu.edu` PROCEDURE `RetrieveRecords`(
IN AnimalID VARCHAR(32),
IN Can VARCHAR(32),
IN CollDate VARCHAR(128))
BEGIN
SELECT R.ToFrom, R.Date, R.NumReceived, R.NumShipped, R.Balance
FROM Record R
WHERE R.AnimalID = AnimalID AND R.CanNum = Can AND R.CollDate = CollDate;
END