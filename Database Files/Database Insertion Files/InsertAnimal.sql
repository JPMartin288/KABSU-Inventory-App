CREATE PROCEDURE `InsertAnimal`(
IN AnimalID VARCHAR(32),
IN Name VARCHAR(128),
IN Breed VARCHAR(64),
IN Species VARCHAR(16),
IN RegNum VARCHAR(32))
BEGIN 
REPLACE kabsu.Animal(AnimalID, Name, Breed, Species, RegNum)
VALUES(AnimalID, Name, Breed, Species, RegNum);
END
