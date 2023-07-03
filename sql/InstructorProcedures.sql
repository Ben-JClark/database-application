CREATE PROCEDURE Assign_Instructor @iEmail VARCHAR(255), @ClassID INT, @ReturnValue INT OUTPUT AS
SET @ReturnValue = -1
--Check the input isn't null
IF @iEmail IS NULL OR @ClassID IS NULL
	BEGIN		
		RETURN @ReturnValue
	END
ELSE
	BEGIN
		--Check the Email and class exist
		IF (1 > (SELECT COUNT(*) FROM Class WHERE ClassID = @ClassID)) OR (1 > (SELECT COUNT(*) FROM Instructor WHERE email = @iEmail))
			BEGIN
				RETURN @ReturnValue
			END

		--Check the instructor is qualified to teach the course
		DECLARE @iCourse VARCHAR(5), @Class_Start DATETIME, @Class_End DATETIME
		SET @iCourse = (SELECT CourseID FROM Class WHERE ClassID = @ClassID);
		IF 1 <= (SELECT COUNT(*) FROM Qualified WHERE iEmail = @iEmail AND CourseID = @iCourse)
			BEGIN
				--Check the instructor is avaliable at that time
				SET @Class_Start = (SELECT startTime FROM Class WHERE ClassID = @ClassID);
				SET @Class_End = (SELECT endTime FROM Class WHERE ClassID = @ClassID);
				IF (0 = (SELECT COUNT(*) FROM Class WHERE startTime < @Class_Start AND endTime > @Class_Start)) AND (0 = (SELECT COUNT(*) FROM Class WHERE endTime < @Class_End AND endTime > @Class_End))
					BEGIN
						--Create a new teaching row
						INSERT INTO Teaches (iEmail, ClassID) VALUES (@iEmail, @ClassID)
						SET @ReturnValue = 0
					END
			END
	END
RETURN @ReturnValue