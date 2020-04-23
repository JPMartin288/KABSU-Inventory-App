CREATE PROCEDURE `RetrieveMorph`(
IN AnimalID VARCHAR(32))
BEGIN
SELECT D.Notes, D.Date, D.Vigor, D.Mot, D.Morph, D.Code, D.Units
FROM Data D
WHERE D.AnimalID = AnimalID;
END