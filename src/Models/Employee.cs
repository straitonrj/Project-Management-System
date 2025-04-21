using System;
using Microsoft.Data.Sqlite;
namespace src.Models;

public class Employee
{
    private int ID;
    private string Name;
    private string JobTitle;
    private SqliteConnection sqliteConnection;

    public Employee(int tempID, string tempName, string tempJob)
    {
        ID = tempID;
        Name = tempName;
        JobTitle = tempJob;
    }

    public int GetID()
    {
        return ID;
    }

    public string GetName()
    {
        return Name;
    }

    public string GetJobTitle()
    {
        return JobTitle;
    }

    public void SetID(int temp)
    {
        ID = temp;
    }

    public void SetName(string temp)
    {
        Name = temp;
    }

    public void SetJobTitle(string temp)
    {
        JobTitle = temp;
    }
    public string ToString()
    {
        return "ID: "+ID+" Name: "+Name+" Position: "+JobTitle;
    }


}