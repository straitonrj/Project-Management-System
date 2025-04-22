using System;
using System.IO;
using System.Collections;
using Microsoft.Data.Sqlite;

namespace src.Models;

public class OrgUser
{
    private int UserID;
    private string username, password;
    private SqliteConnection sqliteConnection;



    public OrgUser(string username, string password)
    {
        this.username = username;
        this.password = password;
    }

    public int GetUserID()
    {
        return UserID;
    }

    public string GetUsername()
    {
        return username;
    }

    public string GetPassword()
    {
        return password;
    }

    public void SetUserID(int tempID)
    {
        UserID = tempID;
    }

    public void SetUsername(string tempUsername)
    {
        username = tempUsername;
    }

    public void SetPassword(string tempPassword)
    {
        password = tempPassword;
    }

    //if valid return true
    public bool Login(String dataBasePassword)
    {
        return password.Equals(dataBasePassword);
    } 
    
    public String GetDatabasePassword()
    {
        string dataBasePassword = "";
        var sql = "select PASSWORD from ORGUSER where USERNAME = @USERNAME";
        try
        {
            using var connection = new SqliteConnection($"Data Source=projectDB");
            connection.Open();
           

            using var command = new SqliteCommand(sql,connection);
            command.Parameters.AddWithValue("@USERNAME", username);

            using var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    dataBasePassword = reader.GetString(0);
                    
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return dataBasePassword;
    }

    public ArrayList ViewProjects()
    {
        ArrayList tempArrayList = new ArrayList();
        var sql = "select * from PROJECT where USERID = @USERID";
        try
        {
            using var connection = new SqliteConnection($"Data Source=projectDB");
            connection.Open();
           

            using var command = new SqliteCommand(sql,connection);
            command.Parameters.AddWithValue("@USERID", UserID);

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
    
    //Add a new project to the database
    public void AddProject(Project temp)
    {
        var sql = "INSERT INTO PROJECT" +
                  "VALUES (@ID,@NAME, @DESCR, @USERID)";
        try
        {
            using var connection = new SqliteConnection($"Data Source=projectDB");
            connection.Open();

            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@ID", temp.GetID());
            command.Parameters.AddWithValue("@NAME", temp.GetName());
            command.Parameters.AddWithValue("@DESCR", temp.GetDescription());
            command.Parameters.AddWithValue("@USERID", UserID);

            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    //Add a new user to data after user creates an account
    public void AddNewUser()
    {
        var sql = "INSERT INTO ORGUSER" +
                  "VALUES (@ID, @USERNAME, @PASSWORD)";
        try
        {
            using var connection = new SqliteConnection($"Data Source=projectDB");
            connection.Open();

            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@ID", UserID);
            command.Parameters.AddWithValue("@USERNAME", username);
            command.Parameters.AddWithValue("@PASSWORD", password);

            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
  
  
}