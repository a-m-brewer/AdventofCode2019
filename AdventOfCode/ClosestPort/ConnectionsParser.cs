using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.ClosestPort.Interfaces;
using AdventOfCode.ClosestPort.Models;

namespace AdventOfCode.ClosestPort
{
    public class ConnectionsParser : IConnectionsParser
    {
        public IList<Connection> Parse(IEnumerable<string> connections)
        {
            return connections.Select(ToConnection).ToList();
        }

        private static Connection ToConnection(string connection)
        {
            var dir = connection[0];
            var distChars = connection.Skip(1).ToArray();
            var isInt = int.TryParse(distChars, out var dist);

            if (!isInt)
            {
                throw new Exception($"{distChars} is not an int");
            }
            
            return new Connection
            {
                Distance = dist,
                Direction = ToDirection(dir)
            };
        }

        private static Direction ToDirection(char dir)
        {
            return dir switch
            {
                'U' => Direction.Up,
                'D' => Direction.Down,
                'L' => Direction.Left,
                'R' => Direction.Right,
                _ => throw new Exception("Unrecognised Direction")
            };
        }
    }
}