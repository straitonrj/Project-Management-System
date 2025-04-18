using System;

namespace src.Models;

public class Employee
{
    private int ID { get; set; }
    private string Name { get; set; }
    private string JobTitle { get; set; }

    public Employee(int tempID, string tempName, string tempJob)
    {
        ID = tempID;
        Name = tempName;
        JobTitle = tempJob;
    }
    
    public string ToString()
    {
        return "ID: "+ID+" Name: "+Name+" Position: "+JobTitle;
    }
}