namespace src.Models;

public class Risk
{
    private int ID;
    private string Name;
    private string Description;

    public Risk(int tempID, string tempName, string tempDescription)
    {
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

}