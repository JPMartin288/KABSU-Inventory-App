CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteData`(
IN ID VARCHAR(32))
BEGIN
DELETE FROM `Record` WHERE `AnimalID` = ID;
END