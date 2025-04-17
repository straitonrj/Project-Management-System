namespace src.Models;

public class Risk
{
    private string Name { get; set;}
    private string Description { get; set;}
    private string Status { get; set;}
    private int Priority { get; set; }

    public Risk(string tempName, string tempDescription, string tempStatus, int tempPriority)
    {
        Name = tempName;
        Description = tempDescription;
        Status = tempStatus;
        Priority = tempPriority;
    }

}