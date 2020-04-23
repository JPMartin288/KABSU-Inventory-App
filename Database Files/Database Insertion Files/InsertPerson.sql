CREATE PROCEDURE `InsertPerson`(
IN Name VARCHAR(100),
IN City VARCHAR(64),
IN State VARCHAR(2),
IN Country VARCHAR(3))
BEGIN
REPLACE kabsu.Person(Name, City, State, Country)
VALUES(Name, City, State, Country);
END
