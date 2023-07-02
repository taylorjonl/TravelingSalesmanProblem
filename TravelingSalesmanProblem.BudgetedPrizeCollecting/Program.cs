using System;
using System.Threading.Tasks;
using TravelingSalesmanProblem.Common;

namespace TravelingSalesmanProblem.BudgetedPrizeCollecting;

internal class Program
{
    static async Task Main(string[] args)
    {
        var graph = await Graph.FromFileAsync("graph.tsp");

        Console.WriteLine("Hello, World!");
    }
}