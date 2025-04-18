using System;
using System.Collections;

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
    //Print out TeamMembers and relevant info
    public string[] GetTeamMembers()
    {
        string[] TeamList;
        //Only run if TeamMembers has any elements
        if (TeamMembers.Count != 0)
        {
            TeamList = new string[TeamMembers.Count];
            for (int i = 0; i < TeamMembers.Count; i++)
            {
                TeamList[i] = TeamMembers[i].ToString();
            }

            return TeamList;
        }

        //Don't know what else to return, maybe checking if the Arraylist is empty should happen before the method gets called
        TeamList = new string[] { "No Team members" };
        return TeamList;
    }
}