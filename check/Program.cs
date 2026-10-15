using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace studGr;

class Program
{
    static void Main()
    {
        var stud = new Dictionary<string, List<int>>
        {
            {"anna", new List<int>{5, 4, 5, 3, 5} },
            {"Boris", new List<int>{3, 4, 4, 5, 4}},
            {"Nikitos", new List<int>{5, 5, 3, 4, 4}},
            {"Lera", new List<int>{ 5, 5, 4, 3, 3, 4}},
        };

        string bestStudent = "not found";
        double bestAvg = 0;
        int totalSum = 0;
        int totalCount = 0;
        bool hasTrip = false;

        foreach (var studs in stud)
        {
            int studSum = 0;

            foreach (int grade in studs.Value)
            {
                studSum += grade;
                totalSum += grade;
                totalCount++;
                if (grade == 3)
                {
                    hasTrip = true;
                }
            };
            double studAvg = (double)studSum / studs.Value.Count;
            Console.WriteLine($"{studs.Key}-Middle Avg: {studAvg}");

            if (studAvg > bestAvg)
            {
                bestAvg = studAvg;
                bestStudent = studs.Key;

            }
        }
        double grAvg = (double)totalSum / totalCount;
        Console.WriteLine($"middle average to group: {grAvg:F2}");

        if (hasTrip)
        {
            Console.WriteLine("There are groups of three");
        }

        Console.WriteLine($"best student:{bestStudent} with an avg grade {bestAvg}");
        Console.WriteLine($"total number of grades in the gradebook {totalCount} ");
    }
}
