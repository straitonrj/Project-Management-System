using System;

namespace src.Models;

public class Employee
{
    private int ID { get; set; }
    private string Name { get; set; }
    private string JobTitle { get; set; }
    private string userName { get; set; }
    private string password { get; set; }

    public Employee(int tempID, string tempName, string tempJob, string username, string password)
    {
        ID = tempID;
        Name = tempName;
        JobTitle = tempJob;
        userName = username;
        this.password = password;
    }

    public string ToString()
    {
        return "ID: "+ID+" Name: "+Name+" Position: "+JobTitle;
    }
}