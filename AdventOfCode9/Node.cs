using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;

namespace AdventOfCode9
{
    public class Node
    {
        private bool _wasCounted = false;
        private readonly List<Node> _neighbours = new List<Node>();
        
        public int Row { get; }
        public int Column { get; }
        public int Value { get; }

        

        public Node(int row, int column, int value)
        {
            Row = row;
            Column = column;
            
            Value = value;
        }

        public void CreateNeighbours(Node[,] map)
        {
            if (Row != 0 && map[Row - 1, Column].Value < 9)
                 _neighbours.Add(map[Row - 1, Column]);
            
            if(Column != 0 && map[Row, Column - 1].Value < 9)
                _neighbours.Add(map[Row, Column - 1]);
            
            if(Row != map.GetLength(0) - 1 && map[Row + 1, Column].Value < 9)
                _neighbours.Add(map[Row + 1, Column]);
            
            if(Column != map.GetLength(1) - 1 && map[Row, Column + 1].Value < 9)
                _neighbours.Add(map[Row, Column +1]);
        }

        public IEnumerable<Node> GetAllNeighbours()
        {
            if (_wasCounted)
                return new List<Node>();

            _wasCounted = true;
            var result = new List<Node>{this};

            foreach (var neighbour in _neighbours)
            {
                result.AddRange(neighbour.GetAllNeighbours());
            }

            return result.Distinct();
        }

        public bool CheckMinimum() => _neighbours.All(x => x.Value > Value);
    }
}