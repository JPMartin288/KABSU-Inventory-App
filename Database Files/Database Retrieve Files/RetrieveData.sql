CREATE PROCEDURE `RetrieveData`(
IN Owner VARCHAR(128),
IN Breed VARCHAR(128),
IN AnimalName VARCHAR(128),
IN Code VARCHAR(128),
IN CanNum VARCHAR(128),
IN Town VARCHAR(128),
IN State VARCHAR(128)
)
BEGIN

SELECT S.Valid, S.CanNum, A.AnimalID, S.CollDate, S.NumUnits, A.Name AS AnimalName, A.Breed, A.RegNum, P.Name AS PersonName, P.City, P.State, P.Country, A.Species
FROM Sample S 
INNER JOIN Person P ON P.PersonID = S.PersonID
INNER JOIN Animal A ON A.AnimalID = S.AnimalID
WHERE P.Name LIKE CASE Owner
			WHEN '*'
			THEN 
				P.Name
			ELSE
				Owner
			END
AND A.Breed LIKE CASE Breed
			WHEN '*'
			THEN
				A.Breed
			ELSE
				Breed
			END
AND A.Name LIKE CASE AnimalName
			WHEN '*'
			THEN
				A.Name
			ELSE
				AnimalName
			END
AND A.AnimalID LIKE CASE Code
			WHEN '*'
			THEN
				A.AnimalID
			ELSE
				Code
			END
AND S.CanNum LIKE CASE CanNum
			WHEN N'*'
			THEN
				S.CanNum
			ELSE
				CanNum
			END
AND P.City LIKE CASE Town
			WHEN '*'
			THEN
				P.City
			ELSE
				Town
			END
AND P.State LIKE CASE State
			WHEN '*'
			THEN
				P.State
			ELSE
				State
			END;
END
