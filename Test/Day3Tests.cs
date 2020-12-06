using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using Advent;
using Xunit;


namespace Test
{
    public class Day3Tests
    {
        [Fact]
        public void EvaluateExample()
        {
            var input = 
@"..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#";
            
            var startPosition = (0, 0);

            var detector = new TreeCollisionDetector(input, (3, 1));

            var collisionCount = detector.Detect(startPosition);

            Assert.Equal(7, collisionCount);
        }

        
        [Fact]
        public void GetSolution1()
        {
            var input = File.ReadAllText(@"inputs\day03.txt");

            var startPosition = (0, 0);

            var detector = new TreeCollisionDetector(input, (3,1));

            var collisionCount = detector.Detect(startPosition);

            Assert.Equal(234, collisionCount);
        }

        [Fact]
        public void EvaluateExample2()
        {
            var input =
                @"..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#";

            var startPosition = (0, 0);
            var result = 1;
            var gridResult = string.Empty;
            (int, int)[] slopes = new[] { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) };
            foreach (var slope in slopes)
            {
                var detector = new TreeCollisionDetector(input, slope);
                var collisionCount = detector.Detect(startPosition);
                gridResult += Environment.NewLine  + collisionCount + Environment.NewLine + Environment.NewLine + detector.ViewGrid();
                result *= collisionCount;
            }

            Assert.Equal(336, result);
        }

        [Fact]
        public void GetSolution2()
        {
            var input = File.ReadAllText(@"inputs\day03.txt");

            var startPosition = (0, 0);
            long result = 1;
            var gridResult = string.Empty;
            (int, int)[] slopes = new[]{(1, 1),(3, 1),(5, 1),(7, 1),(1, 2)};
            foreach (var slope in slopes)
            {
                var detector = new TreeCollisionDetector(input, slope);
                var collisionCount = detector.Detect(startPosition);
                gridResult += Environment.NewLine + collisionCount + Environment.NewLine + Environment.NewLine + detector.ViewGrid();
                result *= collisionCount;
            }
            
            Assert.Equal(5813773056, result);
        }
    }
}
