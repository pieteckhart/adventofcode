using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Advent
{
    public class TreeCollisionDetector
    {
        private readonly char[,] grid;
        private (int x, int y) slope;
        private int width;

        public TreeCollisionDetector(string input, (int x, int y) slope)
        {
            var lines = input.Split(Environment.NewLine);
            this.width = lines[0].Length;
            var height = lines.Length;
            grid = new char[width, height];
            for (var y = 0; y < lines.Length; y++)
            {
                var line = lines[y];
                for (int x = 0; x < line.Length; x++)
                {
                    grid[x, y] = line[x];
                }
            }

            this.slope = slope;
        }

        public int Detect((int x, int y) startPosition)
        {
            var treeCount = 0;
            (int x, int y)? position = startPosition;
            
            do
            {
                if (IsTree(position.Value))
                {
                    grid[position.Value.x, position.Value.y] = '+';
                    treeCount++;
                }
                else
                {
                    grid[position.Value.x, position.Value.y] = '-';
                }
            }
            while ((position = GetNextPosition(position.Value, slope)) != default);
            
            return treeCount;
        }

        public string ViewGrid()
        {
            var stringBuilder = new StringBuilder();
            for (var index0 = 0; index0 < grid.GetLength(1); index0++)
            {
                for (var index1 = 0; index1 < grid.GetLength(0); index1++)
                {
                    var iets = grid[index1, index0];
                    stringBuilder.Append(iets);
                }
                stringBuilder.Append(Environment.NewLine);
            }

            return stringBuilder.ToString().Replace(".","⚪").Replace("#", "🟢").Replace("+", "🔴").Replace("-", "🔵");
        }

        private bool IsTree((int x, int y) position)
        {
            return grid[position.x,position.y] == '#';
        }

        private (int x, int y)? GetNextPosition((int x, int y) position, (int x, int y) slope)
        {
            var x = position.x + slope.x;
            var y = position.y + slope.y;
            var gridWidth = grid.GetLength(0);
            var gridLength = grid.GetLength(1);

            if (x >= gridWidth)
            {
                x = x - gridWidth;
            }

            if (y >= gridLength)
            {
                return null;
            }

            return (x,y);
        }
    }
}
