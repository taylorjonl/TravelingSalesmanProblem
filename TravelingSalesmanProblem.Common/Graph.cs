namespace TravelingSalesmanProblem.Common;

public class Graph
{
    private Dictionary<int, Vertex> vertices = new Dictionary<int, Vertex>();
    private List<Edge> edges = new List<Edge>();

    public static async Task<Graph> FromFileAsync(string fileName)
    {
        var graph = new Graph();
        using (var streamReader = new StreamReader(fileName))
        {
            var dimension = await GetDimension(streamReader);
            for (var i = 0; i < dimension; ++i)
            {
                graph.AddVertex(i);
            }
            await streamReader.ReadLineAsync();
            var line = await streamReader.ReadLineAsync();
            while (line != null)
            {
                (var id1, var id2, var weight) = ParseEdgeDefinition(line);
                graph.AddEdge(id1, id2, weight);
                line = await streamReader.ReadLineAsync();
            }
        }
        return graph;

        static async Task<int> GetDimension(StreamReader streamReader)
        {
            var line = await streamReader.ReadLineAsync();
            if (line != null)
            {
                string[] segments = line.Split(':');
                if (segments.Length == 2)
                {
                    return int.Parse(segments[1]);
                }
            }
            throw new InvalidOperationException();
        }

        static (int, int, double) ParseEdgeDefinition(string line)
        {
            string[] segments = line.Split(' ');
            if (segments.Length == 3)
            {
                return (int.Parse(segments[0]), int.Parse(segments[1]), double.Parse(segments[2]));
            }
            throw new InvalidOperationException();
        }
    }

    private void AddVertex(int id, int prize = 1)
    {
        this.vertices.Add(id, new Vertex
        {
            Id = id,
            Prize = prize
        });
    }

    private void AddEdge(int id1, int id2, double weight)
    {
        if (!this.vertices.TryGetValue(id1, out var vertex1) || !this.vertices.TryGetValue(id2, out var vertex2))
        {
            throw new InvalidOperationException();
        }

        var edge = new Edge(vertex1, vertex2, weight);
        this.edges.Add(edge);

        vertex1.AddEdge(edge);
        vertex2.AddEdge(edge);
    }
}