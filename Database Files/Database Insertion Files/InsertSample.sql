CREATE DEFINER=`kabsu`@`%.ksu.edu` PROCEDURE `InsertSample`(
IN Valid VARCHAR(8),
IN CanNum VARCHAR(32),
IN Code VARCHAR(100),
IN CollDate VARCHAR(128),
IN NumUnits INT,
IN PersonName VARCHAR(100),
IN City VARCHAR(64),
IN State VARCHAR(2))
BEGIN
SET foreign_key_checks = 0;
REPLACE kabsu.Sample(Valid, CanNum, AnimalID, CollDate, NumUnits, PersonID)
VALUES(Valid, CanNum, Code, CollDate, NumUnits, (SELECT PersonID FROM kabsu.Person WHERE Name = PersonName AND City = City AND State = State));
SET foreign_key_checks = 1;
END
