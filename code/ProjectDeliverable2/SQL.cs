using ProjectDeliverable2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Configuration;

public class SQL{

    private static SQL SQLInstance = null;
    private static readonly object lockObject = new object();

    //variables for database connection     
    private SqlConnection con;
    private SqlCommand cmd;
    private SqlDataReader read;

    /// <summary>
    /// CONSTRUCTOR: Implements the singleton pattern
    /// </summary>
    private SQL(){
    }

    /// <summary>
    /// Gets the class instance and returns it
    /// </summary>
    /// <returns></returns>
    public static SQL Instance{
        get
        {
            if(SQLInstance == null)
            {
                lock (lockObject)
                {
                    if(SQLInstance == null)
                    {
                        SQLInstance = new SQL();
                    }
                }
            }
            return SQLInstance;
        }
    }

    /// <summary>
    /// Establish database connection to the University Of Waikato SQL Server using the string inside the Connection.config file
    /// </summary>
    /// <returns> The SQL connection to the University Of Waikato SQL Server </returns>
    private SqlConnection getSqlConnection()
    {
        String connectionString = ConfigurationManager.ConnectionStrings["UOWSqlServer"].ConnectionString;
        con = new SqlConnection(connectionString);
        con.Open();
        return con;
    }

    /// <summary>
    /// Return the data from the table as a List of string arrays.
    /// Each list item represents a row in the form of a string array seperted by columns.
    /// </summary>
    /// <param name="table">The table to select all values from</param>
    /// <returns></returns>
    public List<String[]> selectAll(int selectedFiler)
    {
        //Make sure input is valid
        if(selectedFiler < 0 || selectedFiler > 2)
        {
            Console.Error.WriteLine("SQL.selectQuery(table): filter index is invalid, must be 0, 1, or 2");
            return null;
        }
        

        try
        {
            // Establish database connection
            SqlConnection con = getSqlConnection();

            // create parameterised query for a procedure
            cmd = new SqlCommand("Show_Classes", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Create the parameterised query
            cmd.Parameters.AddWithValue("@Filter", selectedFiler);

            read = cmd.ExecuteReader();

            // Read the data while there are more rows of data
            List<String[]> rowList = new List<String[]>();
            while (read.Read())
            {
                // Add the row of data as a String array to rowList
                IDataRecord dataRecord = (IDataRecord)read;
                String[] row = new string[dataRecord.FieldCount];
                for (int i = 0; i < dataRecord.FieldCount; i++)
                {
                    row[i] = dataRecord[i].ToString();
                }
                rowList.Add(row);
            }

            read.Close();
            return rowList;
        }
        catch (SqlException e)
        {
            Console.Error.WriteLine("SQL.selectQuery(table): SqlException thrown becuase " + e.Message);
            return null;
        }
        finally { 
            con.Close();
            con.Dispose();
        }
    }

    /// <summary>
    /// Create a parameterised query for a procedure that will insert a class
    /// </summary>
    /// <param name="location">Location of the class</param>
    /// <param name="startTime">Class start time</param>
    /// <param name="endTime">Class end time</param>
    /// <param name="courseID">ID of the course the class is on</param>
    /// <returns>Returns -1 if failed, else returns 0</returns>
    public int createClass(String location, String startTime, String endTime, String courseID)
    {
        //verify input
        courseID = courseID.Trim();
        location = location.Trim();
        startTime = startTime.Trim();
        endTime = endTime.Trim();

        if (verifyDateTime(startTime) == false || verifyDateTime(endTime) == false || 
            verifyAlphaNumberic(location) == false || verifyCourseID(courseID) == false)
        {
            Console.Error.WriteLine("SQL.createClass(...): ERROR input parameters are invalid");
            return -1;
        }   

        int returnValue = -1;
        try
        {
            // Establish database connection
            SqlConnection con = getSqlConnection();

            // create parameterised query for a procedure
            cmd = new SqlCommand("Create_Class", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Add the parameters
            cmd.Parameters.AddWithValue("@Location", location);
            cmd.Parameters.AddWithValue("@Start_Time", startTime);
            cmd.Parameters.AddWithValue("@End_Time", endTime);
            cmd.Parameters.AddWithValue("@CourseID", courseID);

            // Add the output parameter
            SqlParameter returnValueParam = new SqlParameter("@ReturnValue", SqlDbType.Int);
            returnValueParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(returnValueParam);

            cmd.ExecuteNonQuery();

            //Get the value returned
            returnValue = (int)cmd.Parameters["@ReturnValue"].Value;
            Console.WriteLine("createClass(...): Return value: " + returnValue);
            
        }
        catch (SqlException)
        {
            Console.Error.WriteLine("SQL.createClass(...): ERROR inserting the class, potentially invalid CourseID");
            returnValue = -1;
        }
        finally 
        { 
            //properly close the connection even if an error occurs
            con.Close();
            con.Dispose();
        }
        return returnValue;
    }

    public int insertTeaches(String iEmail, int ClassID)
    {
        //verify input
        if(verifyEamil(iEmail) == false || ClassID < 1)
        {
            return -1;
        }
        int returnValue = -1;
        try
        {
            // Establish database connection
            SqlConnection con = getSqlConnection();

            // create parameterised query for a procedure
            cmd = new SqlCommand("Assign_Instructor", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Add the parameters
            cmd.Parameters.AddWithValue("@iEmail", iEmail);
            cmd.Parameters.AddWithValue("@ClassID", ClassID);

            // Add the output parameter
            SqlParameter returnValueParam = new SqlParameter("@ReturnValue", SqlDbType.Int);
            returnValueParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(returnValueParam);

            returnValue = cmd.ExecuteNonQuery();

            returnValue = (int)cmd.Parameters["@ReturnValue"].Value;
            Console.WriteLine("insertTeaches(...): Return value: " + returnValue);
        }
        catch (SqlException)
        {
            Console.Error.WriteLine("SQL.insertTeaches(...): ERROR inserting the instructor, potentially invalid ClassID or Email");
            returnValue = -1;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        return returnValue;
    }

    /// <summary>
    /// Queries the procedure which obtains the students information from the customer table
    /// </summary>
    /// <param name="iEmail"></param>
    /// <returns></returns>
    public String[] getStudentDetails(String sEmail)
    {
        //validate input
        if(verifyEamil(sEmail) == false)
        {
            Console.Error.WriteLine("getStudentDetails(...): Invalid email");
            return null;
        }
        String[] detailsArray = null;
        try
        {
            // Establish database connection
            SqlConnection con = getSqlConnection();

            // create parameterised query for a procedure
            cmd = new SqlCommand("Student_Search", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Add the parameters
            cmd.Parameters.AddWithValue("@sEmail", sEmail);

            // Add the output parameters for first name, last name, and phone number of the student
            SqlParameter returnValueParam = new SqlParameter("@fname", SqlDbType.VarChar, 50);
            returnValueParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(returnValueParam);

            returnValueParam = new SqlParameter("@sname", SqlDbType.VarChar, 50);
            returnValueParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(returnValueParam);

            returnValueParam = new SqlParameter("@phone", SqlDbType.VarChar, 50);
            returnValueParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(returnValueParam);

            // Execute and Get teh output parameters to return
            cmd.ExecuteNonQuery();
            detailsArray = new string[3];
            try
            {
                detailsArray[0] = (String)cmd.Parameters["@fname"].Value;
                detailsArray[1] = (String)cmd.Parameters["@sname"].Value;
                detailsArray[2] = (String)cmd.Parameters["@phone"].Value;
            }
            catch(InvalidCastException)
            {
                Console.Error.WriteLine("SQL.getStudentDetails(...): Search return null values");
                return null;
            }
        }
        catch (SqlException)
        {
            Console.Error.WriteLine("SQL.getStudentDetails(...): ERROR searching for student");
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        return detailsArray;
    }

    public int registerStudent(String email, String fname, String lname, String phone)
    {
        //verify input
        //validate input
        if (verifyEamil(email) == false || verifyName(fname) == false ||
            verifyName(lname) == false || verifyPhone(phone) == false)
        {
            MessageBox.Show("Invalid details have been entered");
            return -1;
        }

        int returnValue = -1;
        try
        {
            // Establish database connection
            SqlConnection con = getSqlConnection();

            // create parameterised query for a procedure
            cmd = new SqlCommand("Register_Student", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Add the parameters
            cmd.Parameters.AddWithValue("@sEmail", email);
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@sname", lname);
            cmd.Parameters.AddWithValue("@phone", phone);


            // Add the output parameter
            SqlParameter returnValueParam = new SqlParameter("@ReturnResult", SqlDbType.Int);
            returnValueParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(returnValueParam);

            returnValue = cmd.ExecuteNonQuery();

            returnValue = (int)cmd.Parameters["@ReturnResult"].Value;
        }
        catch (SqlException e)
        {
            Console.Error.WriteLine("SQL.registerStudent(...): ERROR registering the student becuase: " + e.Message);
            returnValue = -1;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        return returnValue;
    }

    public int recordAttendance(String cEmail, int classID, decimal mark)
    {
        //verify input
        if (verifyEamil(cEmail) == false || verifyMark(mark) == false || classID < 1)
        {
            MessageBox.Show("Invalid details have been entered");
            return -1;
        }

        int returnValue = -1;
        try
        {
            // Establish database connection
            SqlConnection con = getSqlConnection();

            // create parameterised query for a procedure
            cmd = new SqlCommand("Record_Attendance", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Add the parameters
            cmd.Parameters.AddWithValue("@cEmail", cEmail);
            cmd.Parameters.AddWithValue("@ClassID", classID);
            cmd.Parameters.AddWithValue("@Mark", mark);


            // Add the output parameter
            SqlParameter returnValueParam = new SqlParameter("@ReturnResult", SqlDbType.Int);
            returnValueParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(returnValueParam);

            returnValue = cmd.ExecuteNonQuery();

            returnValue = (int)cmd.Parameters["@ReturnResult"].Value;
        }
        catch (SqlException e)
        {
            Console.Error.WriteLine("SQL.recordAttendance(...): ERROR recording student attendance becuase: " + e.Message);
            returnValue = -1;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        return returnValue;
    }

    /// <summary>
    /// Return true if dateTime is a in the format YYYY-MM-DD HH:MI:SS, else return false
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static Boolean verifyDateTime(String dateTime)
    {
        if(dateTime != null)
        {
            if (dateTime.Length == 19)
            {   
                //Make sure the regex validates the string so it can be converted to SQL DATETIME type
                //@ allows '\' to be treated as escape characters, d{n} allows us to specify digits 0-9 reapeting n times
                if (Regex.IsMatch(dateTime, @"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}$"))
                {
                    Console.WriteLine("Return true for date");
                    return true;
                }
                if (Regex.IsMatch(dateTime, @"^\d{4}-\d{2}-\d{2} \d{1}:\d{2}:\d{2}$"))
                {
                    Console.WriteLine("Return true for date");
                    return true;
                }
            }
        }
        Console.WriteLine("Return true for date");
        return false;
    }

    /// <summary>
    /// Return true if verify location is a valid sting only containing letters
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    public static Boolean verifyAlphaNumberic(String input)
    {
        if (input != null)
        {
            if (input.Length > 0)
            {
                //Make sure location only contains letters and spaces
                if (Regex.IsMatch(input, "^[0-9a-zA-Z ]+$"))
                {
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Return true if courseID is a valid SQL VARCHAR(5) type, else False
    /// </summary>
    /// <param name="courseID"></param>
    /// <returns></returns>
    public static Boolean verifyCourseID(String courseID)
    {
        if (courseID != null)
        {
            if(Regex.IsMatch(courseID, "^[0-9a-zA-Z]+$"))
            {
                if(courseID.Length == 5)
                {
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Return true if the Email meets basic requirements
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static Boolean verifyEamil(String input)
    {
        if (input != null)
        {
            if (Regex.IsMatch(input, @"^[0-9a-zA-Z.]+@[0-9a-zA-Z]+\.[0-9a-zA-Z]+$"))
            {
                return true;
            }
        }
        return false;
    }

    public static Boolean verifyName(String input)
    {
        if(input != null && input.Length > 0)
        {
            if(Regex.IsMatch(input, "^[a-zA-Z]+$"))
            {
                return true;
            }
        }
        return false;
    }

    public static Boolean verifyPhone(String input)
    {
        if(input != null && input.Length > 0)
        {
            if (Regex.IsMatch(input, "^[0-9-]+$"))
            {
                return true;
            }
        }
        return false;
    }

    public static Boolean verifyMark(decimal input)
    {
        if(input >= 0 && input <= 100)
        {
            return true;
        }
        return false;
    }
}