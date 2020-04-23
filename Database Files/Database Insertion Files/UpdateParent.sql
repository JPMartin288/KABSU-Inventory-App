CREATE PROCEDURE `UpdateParent`(
IN SValid VARCHAR(8),
IN SCanNum VARCHAR(32),
IN OldAnimalID VARCHAR(32),
IN AAnimalID VARCHAR(32),
IN SCollDate VARCHAR(128),
IN SNumUnits INT,
IN PCity VARCHAR(64),
IN OldCity VARCHAR(64),
IN PState VARCHAR(2),
IN OldState VARCHAR(2),
IN PCountry VARCHAR(3),
IN POwner VARCHAR(100),
IN OldOwner VARCHAR(100),
IN AAnimalName VARCHAR(128),
IN ABreed VARCHAR(64),
IN ASpecies VARCHAR(16),
IN ARegNum VARCHAR(128))
BEGIN
SET foreign_key_checks = 0;
UPDATE kabsu.Animal
SET AnimalID = AAnimalID,
Name = AAnimalName,
Breed = ABreed,
Species = ASpecies,
RegNum = ARegNum
WHERE AnimalID = OldAnimalID;
UPDATE kabsu.Person
SET Name = POwner,
City = PCity,
State = PState,
Country = PCountry
WHERE PersonID IN (SELECT P.PersonID FROM (SELECT * FROM Person) AS P WHERE P.Name = OldOwner AND P.City = OldCity AND P.State = OldState);
UPDATE kabsu.Sample
SET Valid = SValid,
CanNum = SCanNum,
AnimalID = AAnimalID,
CollDate = SCollDate,
NumUnits = SNumUnits
WHERE AnimalID = OldAnimalID;
SET foreign_key_checks = 1;
END