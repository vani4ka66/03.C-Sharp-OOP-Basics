using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private Dictionary<string, Nation> nations;
    private List<string> wars;

    public NationsBuilder()
    {
        this.nations = new Dictionary<string, Nation>()
            {
                {"Air", new Nation()},
                {"Fire", new Nation()},
                {"Water", new Nation()},
                {"Earth", new Nation()},

            };
        this.wars = new List<string>();
    }

    int counter = 1;

    public void AssignBender(List<string> benderArgs)
    {
        if (benderArgs[1] == "Air")
        {
            this.nations[benderArgs[1]].AddBender(new AirBender(benderArgs[2], int.Parse(benderArgs[3]), float.Parse(benderArgs[4])));
        }
        else if (benderArgs[1] == "Water")
        {
            this.nations[benderArgs[1]].AddBender(new WaterBender(benderArgs[2], int.Parse(benderArgs[3]), float.Parse(benderArgs[4])));
        }
        else if (benderArgs[1] == "Fire")
        {
            this.nations[benderArgs[1]].AddBender(new FireBender(benderArgs[2], int.Parse(benderArgs[3]), float.Parse(benderArgs[4])));
        }
        else if (benderArgs[1] == "Earth")
        {
            this.nations[benderArgs[1]].AddBender(new EarthBender(benderArgs[2], int.Parse(benderArgs[3]), float.Parse(benderArgs[4])));
        }
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        if (monumentArgs[1] == "Air")
        {
            this.nations[monumentArgs[1]].AddMonument(new AirMonument(monumentArgs[2], int.Parse(monumentArgs[3])));
        }
        else if (monumentArgs[1] == "Water")
        {
            this.nations[monumentArgs[1]].AddMonument(new WaterMonument(monumentArgs[2], int.Parse(monumentArgs[3])));
        }
        else if (monumentArgs[1] == "Fire")
        {
            this.nations[monumentArgs[1]].AddMonument(new FireMonument(monumentArgs[2], int.Parse(monumentArgs[3])));
        }
        else if (monumentArgs[1] == "Earth")
        {
            this.nations[monumentArgs[1]].AddMonument(new EarthMonument(monumentArgs[2], int.Parse(monumentArgs[3])));
        }
    }

    public string GetStatus(string nationsType)
    {
        return $"{nationsType} Nation" + Environment.NewLine + this.nations[nationsType].ToString();
    }

    public void IssueWar(string nationsType)
    {
        this.wars.Add(nationsType);
        var winner = nations.Max(n => n.Value.GetTotalPoints());

        foreach (var nation in nations)
        {
            if (nation.Value.GetTotalPoints() != winner)
            {
                nation.Value.KillYourself();
            }
        }

        //Console.WriteLine($"War {counter++} issued by {nationsType}");
    }
    public string GetWarsRecord()
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < wars.Count; i++)
        {
            sb.AppendLine($"War {i + 1} issued by {this.wars[i]}");

        }
        return sb.ToString().Trim();
    }

}

