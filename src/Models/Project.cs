using System;
using System.Collections;
using Microsoft.Data.Sqlite;
namespace src.Models;

public class Project
{
    //Attributes
    private int ID;
    private string Name;

    private string Description;
    /*
    //Team members & manager
    private Employee ProjectManager { get; set; }
    private ArrayList TeamMembers = new ArrayList();
    //Requirements and Risks
    private ArrayList FunctionalRequirements = new ArrayList();
    private ArrayList NonFunctionalRequirements = new ArrayList();
    private ArrayList RiskList = new ArrayList();
    private SqliteConnection sqliteConnection;*/
    
    public Project(int tempID, string tempName, string tempDescription)
    {
        ID = tempID;
        Name = tempName;
        Description = tempDescription;
    }

    public int GetID()
    {
        return ID;
    }

    public string GetName()
    {
        return Name;
    }

    public string GetDescription()
    {
        return Description;
    }

    public void SetID(int temp)
    {
        ID = temp;
    }

    public void SetName(string temp)
    {
        Name = temp;
    }

    public void SetDescription(string temp)
    {
        Description = temp;
    }
    
    //Fetching relevant data from database for front-end
    //SQL method to avoid redundancy for getting info from tables using project id
    ArrayList DatabaseCall(string sql)
    {
        ArrayList tempArrayList = new ArrayList();
        try
        {
            using var connection = new SqliteConnection($"Data Source=projectDB");
            connection.Open();
            
            using var command = new SqliteCommand(sql,connection);
            command.Parameters.AddWithValue("@PROJECTID",ID);
            
            using var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tempArrayList.Add(reader.GetString(0));

                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return tempArrayList;
    }
    
    //Pretty much the same method with new parameter for the relevant ID
    ArrayList DatabaseCall(string sql, int tempID)
    {
        ArrayList tempArrayList = new ArrayList();
        try
        {
            using var connection = new SqliteConnection($"Data Source=projectDB");
            connection.Open();
            
            using var command = new SqliteCommand(sql,connection);
            command.Parameters.AddWithValue("@ID",tempID);
            
            using var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tempArrayList.Add(reader.GetString(0));

                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return tempArrayList;
    }
    //Fetch one row from table, returns arraylist with 1? element, takes in an ID from the user
    public ArrayList GetTeamMember(int tempID)
    {
        string sql = "Select * from EMPLOYEE where ID = @ID";
        return DatabaseCall(sql, tempID);
    }
    
    public ArrayList GetFunctionalReq(int tempID)
    {
        string sql = "Select * from FREQUIREMENT where ID = @ID";
        return DatabaseCall(sql, tempID);
    }
    
    public ArrayList GetNonFunctionalReq(int tempID)
    {
        string sql = "Select * from NFREQUIREMENT where ID = @ID";
        return DatabaseCall(sql, tempID);
    }
    
    public ArrayList GetRisk(int tempID)
    {
        string sql = "Select * from RISK where ID = @ID";
        return DatabaseCall(sql, tempID);
    }
    //Fetch all related data
    public ArrayList GetTeamMembers()
    {
        var sql = "Select * from EMPLOYEE where PROJECTID = @PROJECTID";
        return DatabaseCall(sql);
    }
    
    public ArrayList GetFunctionalReqs()
    {
        var sql = "Select * from FREQUIREMENT where PROJECTID = @PROJECTID";
        return DatabaseCall(sql);
    }
    
    public ArrayList GetNonFunctionalReqs()
    {
        var sql = "Select * from NFRequirement where PROJECTID = @PROJECTID";
        return DatabaseCall(sql);
    }
    
    public ArrayList GetRisks()
    {
        var sql = "Select * from RISK where PROJECTID = @PROJECTID";
        return DatabaseCall(sql);
    }
    
    //Inserting values into the database
    void AddEmployee(Employee temp)
    {
        var sql = "INSERT INTO EMPLOYEE " +
                  "VALUES (@ID, @NAME, @JOB_TITLE, @PROJECTID)";
        try
        {
            using var connection = new SqliteConnection($"Data Source=projectDB");
            connection.Open();

            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@PROJECTID", ID);
            command.Parameters.AddWithValue("@ID", temp.GetID());
            command.Parameters.AddWithValue("@NAME", temp.GetName());
            command.Parameters.AddWithValue("JOB_TITLE", temp.GetJobTitle());

            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    void AddFunctionalReq(Requirement temp)
    {
        var sql = "INSERT INTO FREQUIREMENT" +
                  "VALUES (@ID,@NAME, @DESCR, @STATUS, @PRIOIRTY, @PROJECTID)";
        try
        {
            using var connection = new SqliteConnection($"Data Source=projectDB");
            connection.Open();

            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@PROJECTID", ID);
            command.Parameters.AddWithValue("@ID", temp.GetID());
            command.Parameters.AddWithValue("@NAME", temp.GetName());
            command.Parameters.AddWithValue("@DESCR", temp.GetDescription());
            command.Parameters.AddWithValue("@STATUS", temp.GetFinished());
            command.Parameters.AddWithValue("@PRIORITY", temp.GetPriority());

            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    void AddNonFunctionalReq(Requirement temp)
    {
        var sql = "INSERT INTO NFREQUIREMENT" +
                  "VALUES (@ID,@NAME, @DESCR, @STATUS, @PRIOIRTY, @PROJECTID)";
        try
        {
            using var connection = new SqliteConnection($"Data Source=projectDB");
            connection.Open();

            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@PROJECTID", ID);
            command.Parameters.AddWithValue("@ID", temp.GetID());
            command.Parameters.AddWithValue("@NAME", temp.GetName());
            command.Parameters.AddWithValue("@DESCR", temp.GetDescription());
            command.Parameters.AddWithValue("@STATUS", temp.GetFinished());
            command.Parameters.AddWithValue("@PRIORITY", temp.GetPriority());

            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    void AddRisk(Risk temp)
    {
        var sql = "INSERT INTO RISK" +
                  "VALUES (@ID,@NAME, @DESCR, @PROJECTID)";
        try
        {
            using var connection = new SqliteConnection($"Data Source=projectDB");
            connection.Open();

            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@PROJECTID", ID);
            command.Parameters.AddWithValue("@ID", temp.GetID());
            command.Parameters.AddWithValue("@NAME", temp.GetName());
            command.Parameters.AddWithValue("@DESCR", temp.GetDescription());

            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    //Updating data in tables
    
}