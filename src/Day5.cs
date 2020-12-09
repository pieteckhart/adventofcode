using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Xsl;

namespace Advent
{
    public class BoardingPassScanner
    {
        private readonly string[] passes;

        public BoardingPassScanner(string input)
        {
            passes = input.Split(Environment.NewLine);
        }

        public int Scan() => passes.Select(ScanPass).Max(s => s.SeatID);

        public int FindMySeat()
        {
            var seatIDs = new List<int>();
            foreach (var pass in passes)
            {
                seatIDs.Add(ScanPass(pass).SeatID);
            }

            for (int i = 0; i < 1024; i++)
            {
                if    (seatIDs.Any(s => s == i - 1)
                    && seatIDs.Any(s => s == i + 1)
                    && !seatIDs.Exists(s => s == i))
                {
                    return i;
                }
            }
            return 0;
        }
        
        private ScanResult ScanPass(string pass)
        {
            var rowCoding = pass.Take(7).Select(ParseRowCoding);
            var columnCoding = pass.Skip(7).Take(3).Select(ParseColumnCoding);

            return new ScanResult
            {
                Row = GetRowResult(rowCoding),
                Column = GetColumnResult(columnCoding)
            };
        }

        private static ColumnCoding ParseColumnCoding(char c) 
            => c switch
            {
                'L' => ColumnCoding.Left,
                'R' => ColumnCoding.Right
            };

        private static RowCoding ParseRowCoding(char c)
            => c switch
            {
                'F' => RowCoding.Front,
                'B' => RowCoding.Back
            };

        private int GetRowResult(IEnumerable<RowCoding> rowCoding)
        {
            var rowRange = (lower: 0, upper: 127);
            var list = rowCoding.ToList();
            foreach (var code in list)
            {
                rowRange = ReduceRowRange(rowRange, code);
            }
            return SelectRow(rowRange, list.Last());
        }

        private int GetColumnResult(IEnumerable<ColumnCoding> columnCoding)
        {
            var column = (lower: 0, upper: 7);
            var list = columnCoding.ToList();
            foreach (var code in list)
            {
                column = ReduceColumnRange(column, code);
            }
            return SelectColumn(column, list.Last());
        }
        
        private static (int lower, int upper) ReduceRowRange((int lower, int upper) startRange, RowCoding letter)
        {
            var seatsF = (startRange.upper + startRange.lower -1) / 2;
            var seatsB = (startRange.upper + startRange.lower +1) / 2;

            return letter switch
            {
                RowCoding.Front => (startRange.lower, seatsF),
                RowCoding.Back => (seatsB , startRange.upper),
            };
        }
        
        private static int SelectRow((int lower, int upper) row, RowCoding letter) =>
            letter switch
            {
                RowCoding.Front => row.lower,
                RowCoding.Back => row.upper,
            };

        private static (int lower, int upper) ReduceColumnRange((int lower, int upper) startRange, ColumnCoding letter)
        {
            var seats = startRange.upper - startRange.lower;

            return letter switch
            {
                ColumnCoding.Left => (startRange.lower, (seats - 1) / 2),
                ColumnCoding.Right => ((seats + 1) / 2, startRange.upper),
            };
        }

        private static int SelectColumn((int lower, int upper) column, ColumnCoding letter)
        {
            return letter switch
            {
                ColumnCoding.Left => column.lower,
                ColumnCoding.Right => column.upper,
            };
        }
    }

    public class ScanResult
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int SeatID => Row * 8 + Column;
    }

    public enum RowCoding
    {
        Front,
        Back
    }

    public enum ColumnCoding
    {
        Left,
        Right
    }
}
