using System;
using System.Collections;
using Microsoft.Data.Sqlite;
namespace src.Models;

public class Project
{
    //Attributes
    private int ID { get; set; }
    private string Name { get; set; }
    private string Description { get; set; }
    //Team members & manager
    private Employee ProjectManager { get; set; }
    private ArrayList TeamMembers = new ArrayList();
    //Requirements and Risks
    private ArrayList FunctionalRequirements = new ArrayList();
    private ArrayList NonFunctionalRequirements = new ArrayList();
    private ArrayList RiskList = new ArrayList();
    private SqliteConnection sqliteConnection;

    public Project(int tempID, string tempName, string tempDescription)
    {
        ID = tempID;
        Name = tempName;
        Description = tempDescription;
    }

    public void AddEmployee(Employee tempEmployee)
    {
        TeamMembers.Add(tempEmployee);
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
    public ArrayList GetRisk()
    {
        var sql = "Select * from RISK where PROJECTID = @PROJECTID";
        return DatabaseCall(sql);
    }
    
    //Inserting values into the database
    //SQL method to Query the database
}