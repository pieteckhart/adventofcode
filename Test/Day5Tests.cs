using System;
using System.IO;
using System.Net;
using System.Net.WebSockets;
using System.Security.Cryptography;
using Advent;
using Xunit;


namespace Test
{
    public class Day5Tests
    {
        [Fact]
        public void FTakesFirstHalf()
        {
            var input = "FFFFFFFLLL";
            BoardingPassScanner scanner = new BoardingPassScanner(input);
            int highestSeatId = scanner.Scan();
            Assert.Equal(0, highestSeatId);
        }

        [Fact]
        public void BFFFBBFRRR_makes_567()
        {
            var input = "BFFFBBFRRR";
            BoardingPassScanner scanner = new BoardingPassScanner(input);
            int highestSeatId = scanner.Scan();
            Assert.Equal(567, highestSeatId);
        }

        [Fact]
        public void FFFBBBFRRR_makes_119()
        {
            var input = "FFFBBBFRRR";
            BoardingPassScanner scanner = new BoardingPassScanner(input);
            int highestSeatId = scanner.Scan();
            Assert.Equal(119, highestSeatId);
        }

        [Fact]
        public void BBFFBBFRLL_makes_820()
        {
            var input = "BBFFBBFRLL";
            BoardingPassScanner scanner = new BoardingPassScanner(input);
            int highestSeatId = scanner.Scan();
            Assert.Equal(820, highestSeatId);
        }

        [Fact]
        public void HighestSeatID()
        {
            var input = File.ReadAllText(@"inputs\day05.txt");
            BoardingPassScanner scanner = new BoardingPassScanner(input);
            int highestSeatId = scanner.Scan();
            Assert.Equal(880, highestSeatId);
        }
    }
}
