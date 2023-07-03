--View for upcoming classes
CREATE VIEW Upcoming_Classes AS
SELECT cl.ClassID, co.CourseID, co.name, cl.startTime, cl.endTime, cl.location, i.fname, i.sname FROM 
((Class cl left outer join Course co on cl.CourseID = co.CourseID) left outer join Teaches te on cl.ClassID = te.ClassID) left outer join Instructor i on te.iEmail = i.email  
WHERE cl.startTime > CURRENT_TIMESTAMP

--View for currently running classes
CREATE VIEW Current_Classes AS
SELECT cl.ClassID, co.CourseID, co.name, cl.startTime, cl.endTime, cl.location, i.fname, i.sname FROM 
((Class cl left outer join Course co on cl.CourseID = co.CourseID) left outer join Teaches te on cl.ClassID = te.ClassID) left outer join Instructor i on te.iEmail = i.email  
WHERE cl.endTime >= CURRENT_TIMESTAMP AND cl.startTime <= CURRENT_TIMESTAMP

--View for past classes
CREATE VIEW Past_Classes AS
SELECT cl.ClassID, co.CourseID, co.name, cl.startTime, cl.endTime, cl.location, i.fname, i.sname FROM 
((Class cl left outer join Course co on cl.CourseID = co.CourseID) left outer join Teaches te on cl.ClassID = te.ClassID) left outer join Instructor i on te.iEmail = i.email  
WHERE cl.endTime < CURRENT_TIMESTAMP