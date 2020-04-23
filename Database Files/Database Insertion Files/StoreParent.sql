CREATE PROCEDURE `StoreParent`(
IN Valid VARCHAR(8),
IN CanNum VARCHAR(32),
IN AnimalID VARCHAR(32),
IN CollDate VARCHAR(128),
IN NumUnits INT,
IN City VARCHAR(64),
IN State VARCHAR(2),
IN Country VARCHAR(3),
IN Owner VARCHAR(100),
IN AnimalName VARCHAR(128),
IN Breed VARCHAR(64),
IN Species VARCHAR(16),
IN RegNum VARCHAR(128))
BEGIN
INSERT kabsu.Animal(AnimalID, Name, Breed, Species, RegNum)
VALUES(AnimalID, AnimalName, Breed, Species, RegNum);
INSERT kabsu.Person(Name, City, State, Country)
SELECT * FROM (SELECT Owner, City, State, Country) AS tmp
WHERE NOT EXISTS (
    SELECT Name, City, State FROM Person P WHERE P.Name = Owner AND P.City = City AND P.State = State);
INSERT kabsu.Sample(Valid, CanNum, AnimalID, CollDate, NumUnits, PersonID)
VALUES(Valid, CanNum, AnimalID, CollDate, NumUnits, (SELECT P.PersonID FROM (SELECT * FROM Person) AS P WHERE P.Name = Owner AND P.City = City AND P.State = State));
END