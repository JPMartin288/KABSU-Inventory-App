CREATE PROCEDURE `DeleteData`(
IN CanNum VARCHAR(32),
IN CollDate VARCHAR(32),
IN AnimalID VARCHAR(100),
IN Name VARCHAR(100),
IN City VARCHAR(64),
IN State VARCHAR(2))
BEGIN
DELETE FROM `Record` WHERE `Record`.`AnimalID` = AnimalID AND `Record`.`CanNum` = CanNum AND `Record`.`CollDate` = CollDate;
DELETE FROM `Data` WHERE `Data`.`AnimalID` = AnimalID AND `Data`.`CanNum` = CanNum AND `Data`.`CollDate` = CollDate;
DELETE FROM `Sample` WHERE `Sample`.`CanNum` = CanNum AND `Sample`.`AnimalID` = AnimalID AND `Sample`.`CollDate` = CollDate;
SET foreign_key_checks = 0;
DELETE FROM `Person` WHERE `Person`.`Name` = Name AND `Person`.`City` = City AND `Person`.`State` = State AND NOT EXISTS (
SELECT PS.PersonID FROM (SELECT S.PersonID, P.Name, P.City, P.State FROM Person P INNER JOIN Sample S ON S.PersonID = P.PersonID) AS PS WHERE PS.Name = Name AND PS.City = City AND PS.State = State);
SET foreign_key_checks = 1;
DELETE FROM `Animal` WHERE `Animal`.`AnimalID` = AnimalID AND NOT EXISTS (SELECT * FROM kabsu.Sample S WHERE S.AnimalID = AnimalID);
END
