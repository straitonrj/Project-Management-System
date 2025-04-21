using System;
using System.Collections;

namespace src.Models;

public class Requirement
{
    //Might need to be string to do ID's like '1.1.1'?
    private int ID;
    private int Priority;
    private string Name;
    private string Description;
    private bool Finished;
    //Arraylist of sub-requirements attached to existing requirement
    private ArrayList Children;

    public Requirement(int tempID, string tempName, string tempDescription, int tempPriority)
    {
        ID = tempID;
        Name = tempName;
        Description = tempDescription;
        Finished = false;
        if (ValidPriority(tempPriority))
        {
            Priority = tempPriority;
        }
    }
    
    //Method to validate that requirement priority is no less than 1 and no greater than 4 (0<x<5)
    public bool ValidPriority(int tempPriority)
    {
        if (tempPriority < 5 && tempPriority > 0)
        {
            return true;
        }
        Console.WriteLine("Invalid Priority Value");
        return false;
    }
    
    //Getters and Setters for the attributes
    public int GetID()
    {
        return ID;
    }

    public int GetPriority()
    {
        return Priority;
    }

    public string GetName()
    {
        return Name;
    }

    public string GetDescription()
    {
        return Description;
    }

    public bool GetFinished()
    {
        return Finished;
    }

    public void SetID(int tempID)
    {
        ID = tempID;
    }

    public void SetPriority(int tempPriority)
    {
        if (ValidPriority(tempPriority))
        {
            Priority = tempPriority;
        }
    }

    public void SetName(string tempName)
    {
        Name = tempName;
    }

    public void SetDescription(string tempDescription)
    {
        Description = tempDescription;
    }
    
    //ToString to return Requirement values
    public string ToString()
    {
        //If statement so printing the boolean does not print out a '0' or '1'
        string status;
        if (Finished)
        {
            status = "Finished";
        }
        else
        {
            status = "Unfinished";
        }
        return ID +" : "+ Name +"\n"+Description+"\nPriority # : "+Priority+"Status: "+status;
    }
    
}