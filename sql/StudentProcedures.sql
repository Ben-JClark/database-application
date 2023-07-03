--Create a procedure to return student information from the customer table
CREATE PROCEDURE Student_Search @sEmail VARCHAR(255), @fname VARCHAR(50) OUTPUT, @sname VARCHAR(50) OUTPUT, @phone VARCHAR(20) OUTPUT AS
--IF email cannot be found in the customer database return null
	IF 0 = (SELECT COUNT(*) FROM Customer WHERE email = @sEmail)
		BEGIN
			SET @fname = NULL
			SET @sname = NULL
			SET @phone = NULL
			RETURN
		END
--ELSE email can be found
	ELSE
		BEGIN
			SELECT @fname = fname, @sname = sname, @phone = phone FROM Customer WHERE email = @sEmail
		END
GO


--Create a procedure to insert a new student into the customer table
CREATE PROCEDURE Register_Student @sEmail VARCHAR(255), @fname VARCHAR(50), @sname VARCHAR(50), @phone VARCHAR(20), @ReturnResult INT OUTPUT AS
--IF any input is null return false
SET @ReturnResult = -1
	IF @sEmail IS NULL OR @fname IS NULL OR @sname IS NULL OR @phone IS NULL
		BEGIN
			RETURN @ReturnResult;
		END
--Insert a new customer
	ELSE
		BEGIN
			INSERT INTO Customer (email, fname, sname, phone) VALUES (@sEmail, @fname, @sname, @phone)
			--IF One row has been changed return success
			IF @@ROWCOUNT >= 1
				BEGIN
					SET @ReturnResult = 0
					RETURN @ReturnResult
				END
		END
GO


--Create a procedure to insret a customer into the attends table and assign them a mark
CREATE PROCEDURE Record_Attendance @cEmail VARCHAR(255), @ClassID INT, @Mark DECIMAL(5,2), @ReturnResult INT OUTPUT AS
SET @ReturnResult = -1
--Make sure input isn't null
	IF @cEmail IS NULL OR @Mark IS NULL OR @ReturnResult IS NULL
		BEGIN
			RETURN @ReturnResult
		END
--IF the customer and class ID isn't in the Attends Table return insert the customer
	IF 0 = (SELECT COUNT(*) FROM Attends WHERE cEmail = @cEmail AND ClassID = @ClassID)
		BEGIN
			INSERT INTO Attends (cEmail, ClassID, mark) VALUES (@cEmail, @ClassID, @Mark) 
			SET @ReturnResult = 0
		END
	RETURN @ReturnResult
GO