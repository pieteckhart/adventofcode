using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace Advent
{
    public class BoardingPassScanner
    {
        private string[] passes;

        public BoardingPassScanner(string input)
        {
            this.passes = input.Split(Environment.NewLine);
        }

        public int Scan()
        {
            var seatID = 0;
            foreach (var pass in passes)
            {
                var scanResult = ScanPass(pass);
                if (scanResult.SeatID > seatID)
                {
                    seatID = scanResult.SeatID;
                }
            }
            return seatID;
        }

        public ScanResult ScanPass(string pass)
        {
            ScanResult result = new ScanResult();
            (int lower, int upper) row = (0, 127);
            for (int i = 0; i < 6; i++)
            {
                row = ProcessRow(row, pass[i]);
            }
            result.Row = ProcessLastRow(row, pass[6]);

            (int lower, int upper) column = (0, 7);
            for (int i = 7; i < 10; i++)
            {
                column = ProcessColumn(column, pass[i]);
            }

            result.Column = ProcessLastColumn(column, pass[9]);

            result.SeatID = calculateSeatId(result.Row, result.Column);

            return result;
        }

        private (int lower, int upper) ProcessRow((int lower, int upper) startRange, char letter)
        {
            var seatsF = (startRange.upper + startRange.lower -1) / 2;
            var seatsB = (startRange.upper + startRange.lower +1) / 2;

            return letter switch
            {
                'F' => (startRange.lower, seatsF),
                'B' => (seatsB , startRange.upper),
                _ => default
            };
        }
        
        private int ProcessLastRow((int lower, int upper) row, char letter)
        {
            return letter switch
            {
                'F' => row.lower,
                'B' => row.upper,
                _ => default
            };
        }

        private (int lower, int upper) ProcessColumn((int lower, int upper) startRange, char letter)
        {
            var seats = startRange.upper - startRange.lower;

            return letter switch
            {
                'L' => (startRange.lower, (seats - 1) / 2),
                'R' => ((seats + 1) / 2, startRange.upper),
                _ => default
            };
        }
        private int ProcessLastColumn((int lower, int upper) column, char letter)
        {
            return letter switch
            {
                'L' => column.lower,
                'R' => column.upper,
                _ => default
            };
        }

        private int calculateSeatId(int row, int column)
        {
            return row * 8 + column;
        }
    }

    public class ScanResult
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int SeatID { get; set; }
    }
}
