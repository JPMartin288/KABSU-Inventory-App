CREATE PROCEDURE `StoreMorph`(
IN Notes VARCHAR(256),
IN Date VARCHAR(32),
IN Vigor INT,
IN Mot INT,
IN Morph INT,
IN Code INT,
IN Units INT,
IN ID VARCHAR(32),
IN Can VARCHAR(32),
IN CollDate VARCHAR(128))
BEGIN
DELETE FROM `Data` WHERE `Data`.`AnimalID` = ID AND `Data`.`CanNum` = Can AND `Data`.`CollDate` = CollDate;
INSERT kabsu.Data(Notes, Date, Vigor, Mot, Morph, Code, Units, AnimalID, CanNum, CollDate)
VALUES(Notes, Date, Vigor, Mot, Morph, Code, Units, ID, Can, CollDate);
END
