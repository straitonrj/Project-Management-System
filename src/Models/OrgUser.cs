using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace src.Models;

public class OrgUser
{
    private string username, password;
    private SqliteConnection sqliteConnection;



    public OrgUser(string username, string password)
    {
        this.username = username;
        this.password = password;
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

   
    
  
  
}