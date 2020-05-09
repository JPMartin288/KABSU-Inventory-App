CREATE PROCEDURE `RetrieveMorph`(
IN AnimalID VARCHAR(32),
IN Can VARCHAR(32),
IN CollDate VARCHAR(128))
BEGIN
SELECT D.Notes, D.Date, D.Vigor, D.Mot, D.Morph, D.Code, D.Units
FROM Data D
WHERE D.AnimalID = AnimalID AND D.CanNum = Can AND D.CollDate = CollDate;
END