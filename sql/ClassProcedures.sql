--A Procedure for creating classes
CREATE PROCEDURE Create_Class @Location VARCHAR(100), @Start_Time DATETIME, @End_Time DATETIME, @CourseID CHAR(5), @ReturnValue INT OUTPUT AS
DECLARE @ClassID INT
--IF one of the parameters is null THEN return
IF @Location IS NULL OR @Start_Time IS NULL OR @End_Time IS NULL OR @CourseID IS NULL
	BEGIN
		RAISERROR('ERROR: one or more parameters are null', 16, 1) --Trappable error
		SET @ReturnValue = -1
		RETURN @ReturnValue
	END
Else
	BEGIN
		INSERT INTO Class (location, startTime, endTime, CourseID) VALUES (@Location, @Start_Time, @End_Time, @CourseID)
		IF @@ROWCOUNT < 1
			BEGIN 
				RAISERROR('ERROR: no rows have been affected by the class insert', 16, 1) --Trappable error
				SET @ReturnValue = -1
				RETURN @ReturnValue
			END
		ELSE
			BEGIN
				SET @ReturnValue = 0
				RETURN @ReturnValue
			END
	END
GO

CREATE PROCEDURE Show_Classes @Filter INT AS
--IF the filter is set to future clases (0)
IF @Filter IS NULL OR @Filter = 0
	BEGIN 
		Select * FROM Upcoming_Classes
	END
--IF the filter is set to current classes (1)
ELSE IF @Filter = 1
	BEGIN
		Select * FROM Current_Classes
	END
--ELSE the filter is set to past classes
ELSE
	BEGIN
		Select * FROM Past_Classes
	END
GO