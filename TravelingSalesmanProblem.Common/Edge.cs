namespace TravelingSalesmanProblem.Common
{
    public class Edge
    {
        public Edge(Vertex vertex1, Vertex vertex2, double weight)
        {
            this.Vertex1 = vertex1;
            this.Vertex2 = vertex2;
            this.Weight = weight;
        }

        public Vertex Vertex1 { get; }
        public Vertex Vertex2 { get; }
        public double Weight { get; }
    }
}