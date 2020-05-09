CREATE DEFINER=`kabsu`@`%.ksu.edu` PROCEDURE `DeleteRecord`(
IN ID VARCHAR(32),
IN Can VARCHAR(32),
IN Date VARCHAR(128))
BEGIN
DELETE FROM `Record` WHERE `Record`.`AnimalID` = ID AND `Record`.`CanNum` = Can AND `Record`.`CollDate` = Date;
END
