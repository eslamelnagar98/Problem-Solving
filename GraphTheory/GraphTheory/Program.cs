using System.Text.Json;

namespace GraphTheory;

internal class Program
{
    private static void Main(string[] args)
    {
        var traingleMatrix = new List<List<int>>(new List<int>[5])
            .Select(list => new List<int>(new int[5]))
            .ToList();
        traingleMatrix[0].Add(0);

        Console.WriteLine(JsonSerializer.Serialize(traingleMatrix));
    }
}

///Economy Best Buy :15268   - 1350 unless 24 before , change 1100
///f
///

