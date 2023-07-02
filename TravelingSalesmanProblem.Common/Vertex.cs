namespace TravelingSalesmanProblem.Common;

public class Vertex
{
    private List<Edge> edges = new List<Edge>();

    public int Id { get; init; }
    public int Prize { get; init; }
    public int Degree { get; set; }
    public List<Edge> Edges { get; } = new List<Edge>();

    public void AddEdge(Edge edge)
    {
        this.edges.Add(edge);
    }
}