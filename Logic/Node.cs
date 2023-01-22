namespace ConsoleApp1.Logic
{


    internal class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int G { get; set; }
        public int H { get; set; }
        public int F { get; set; }
        public Node Parent { get; set; }

        public Node(int x, int y, Node parent)
        {
            X = x;
            Y = y;
            Parent = parent;
        }

        public string ToString()
        {
            return string.Format($"({X}, {Y}) [G={G}, H={H}, F={F}]");
        }

        public int CompareTo(Node other)
        {
            return F - other.F;
        }
    }
}