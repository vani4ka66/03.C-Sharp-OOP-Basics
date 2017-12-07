using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private string input;
    private NationsBuilder builder;


    public Engine()
    {
        this.builder = new NationsBuilder();
    }

    public void Run()
    {

        var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        while (input[0] != "Quit")
        {
            switch (input[0])
            {
                case "Bender":
                    builder.AssignBender(input);
                    break;

                case "Monument":
                    builder.AssignMonument(input);
                    break;

                case "Status":
                    Console.WriteLine(builder.GetStatus(input[1]));
                    break;

                case "War":
                    builder.IssueWar(input[1]);
                    break;
            }

            input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        }
        Console.WriteLine(builder.GetWarsRecord());
       
    }
}

