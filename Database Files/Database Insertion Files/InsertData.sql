CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertPerson`(
IN PersonID INT,
IN Name VARCHAR(100),
IN City VARCHAR(64),
IN State VARCHAR(2),
IN Country VARCHAR(3))
BEGIN
INSERT kabsu.person(PersonID, Name, City, State, Country)
VALUES(PersonID, Name, City, State, Country);
END

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertAnimal`(
IN AnimalID VARCHAR(32),
IN Name VARCHAR(128),
IN Breed VARCHAR(64),
IN Species VARCHAR(16),
IN RegNum VARCHAR(32))
BEGIN 
INSERT kabsu.animal(AnimalID, Name, Breed, Species, RegNum)
VALUES(AnimalID, Name, Breed, Species, RegNum);
END

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertSample`(
IN Valid VARCHAR(8),
IN CanNum VARCHAR(32),
IN Code VARCHAR(100),
IN CollDate VARCHAR(128),
IN NumUnits INT,
IN Notes VARCHAR(1000),
IN PersonName VARCHAR(100),
IN City VARCHAR(64),
IN State VARCHAR(2))
BEGIN
INSERT kabsu.sample(Valid, CanNum, AnimalID, CollDate, NumUnits, PersonID, Notes)
VALUES(Valid, CanNum, Code, CollDate, NumUnits, (SELECT PersonID FROM kabsu.person WHERE Name = PersonName AND City = City AND State = State), Notes);
END
