CREATE PROCEDURE `StoreMorph`(
IN Notes VARCHAR(256),
IN Date VARCHAR(32),
IN Vigor INT,
IN Mot INT,
IN Morph INT,
IN Code INT,
IN Units INT,
IN ID VARCHAR(32))
BEGIN
DELETE FROM `Data` WHERE `AnimalID` = ID;
INSERT kabsu.Data(Notes, Date, Vigor, Mot, Morph, Code, Units, AnimalID)
VALUES(Notes, Date, Vigor, Mot, Morph, Code, Units, ID);
END
