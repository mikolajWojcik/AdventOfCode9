using System;
using System.Collections.Generic;
using AdventOfCode9;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        private readonly MapProcessor _processor;

        public UnitTest1()
        {
            var map = new List<string>
            {
                "2199943210",
                "3987894921",
                "9856789892",
                "8767896789",
                "9899965678"
            };
            
            _processor = new MapProcessor();
            foreach (var row in map)
            {
                _processor.ReadLine(row);
            }
            _processor.CreateMap();
        }
        
        [Fact]
        public void Test1()
        {
            var result = _processor.CountLowPointsResult();
            
            Assert.Equal(15, result);
        }
        
        [Theory]
        [InlineData(0,1, 3)]
        [InlineData(0,9, 9)]
        [InlineData(2,2, 14)]
        [InlineData(4,6, 9)]
        public void Test2(int row, int column, int expected)
        {
            var result = _processor.CalculateTheBasinArea(row, column);
            
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Test3()
        {
            var result = _processor.CountBasinResult();
            
            Assert.Equal(1134, result);
        }
    }
}