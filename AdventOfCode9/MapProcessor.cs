using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode9
{
    public class MapProcessor
    {
        private Node[,] _map;
        private List<int> _numbers = new List<int>();
        private int _columnsCount;
        private int _rowsCount = 0;

        public void ReadLine(string text)
        {
            var numbers = text.Select((x,i) => int.Parse(x.ToString())).ToArray();
            _numbers.AddRange(numbers);
            _columnsCount = numbers.Length;
            _rowsCount++;
        }

        public void CreateMap()
        {
            _map = new Node[_rowsCount, _columnsCount];

            for (int i = 0; i < _rowsCount; i++)
            {
                for (int j = 0; j < _columnsCount; j++)
                {
                    _map[i, j] = new Node(i, j, _numbers[i * _columnsCount + j]);
                }
            }

            foreach (var node in _map)
            {
                node.CreateNeighbours(_map);
            }
        }

        public int CountLowPointsResult()
        {
            var result = 0;

            foreach (var node in _map)
            {
                if (node.CheckMinimum())
                {
                    result += node.Value + 1;
                }
            }
            return result;
        }
        
        public int CountBasinResult()
        {
            var result = new List<int>();
            foreach (var node in _map)
            {
                if (node.CheckMinimum())
                {
                    result.Add(node.GetAllNeighbours().Count());
                }
            }
            
            result.Sort();

            return result.TakeLast(3).Aggregate(1, (acc, val) => acc * val);
        }
        
        public int CalculateTheBasinArea(int row, int column) => _map[row, column].GetAllNeighbours().Count();
    }
}