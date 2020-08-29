using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Moons.Models
{
    public class Moon
    {
        public Moon(string startingState)
        {
            var coordinates = ParseCoordinateList(startingState);
            X = new MoonAxis {Pos = coordinates["x"], Velocity = 0};
            Y = new MoonAxis {Pos = coordinates["y"], Velocity = 0};
            Z = new MoonAxis {Pos = coordinates["z"], Velocity = 0};
        }
        
        private Moon()
        {
            
        }

        public static Moon InitWithVelocity(string startingState)
        {
            var split = startingState.Split(">, ");
            var pos = split[0].Replace("pos=", "");
            var vel = split[1].Replace("vel=", "");

            var posD = ParseCoordinateList(pos);
            var velD = ParseCoordinateList(vel);
            
            return new Moon
            {
                X = new MoonAxis {Pos = posD["x"], Velocity = velD["x"]},
                Y = new MoonAxis {Pos = posD["y"], Velocity = velD["y"]},
                Z = new MoonAxis {Pos = posD["z"], Velocity = velD["z"]},
            };
        }
        
        public MoonAxis X { get; set; }
        public MoonAxis Y { get; set; }
        public MoonAxis Z { get; set; }

        public long PotentialEnergy => Math.Abs(X.Pos) + Math.Abs(Y.Pos) + Math.Abs(Z.Pos);
        public long KineticEnergy => Math.Abs(X.Velocity) + Math.Abs(Y.Velocity) + Math.Abs(Z.Velocity);
        public long TotalEnergy => PotentialEnergy * KineticEnergy;

        public void UpdateVelocity(Moon o)
        {
            X.Velocity += Compare(X.Pos, o.X.Pos);
            Y.Velocity += Compare(Y.Pos, o.Y.Pos);
            Z.Velocity += Compare(Z.Pos, o.Z.Pos);
        }

        public void UpdateVelocity(IEnumerable<Moon> moons)
        {
            var mList = moons.Where(m => !m.Equals(this));

            foreach (var m in mList)
            {
                UpdateVelocity(m);
            }
        }

        public void UpdatePosition()
        {
            X.Pos += X.Velocity;
            Y.Pos += Y.Velocity;
            Z.Pos += Z.Velocity;
        }

        public override string ToString()
        {
            return $"pos=<x={X.Pos}, y={Y.Pos}, z={Z.Pos}>, vel=<x={X.Velocity}, y={Y.Velocity}, z={Z.Velocity}>";
        }

        private static Dictionary<string, long> ParseCoordinateList(string list)
        {
            return list
                .Replace("<", "")
                .Replace(">", "")
                .Replace(" ", "")
                .Split(",")
                .Select(eq => eq.Split("="))
                .ToDictionary(k => k[0].ToLower(), v => long.Parse(v[1]));
        }

        private static int Compare(long a, long b)
        {
            if (a == b)
            {
                return 0;
            }

            return a < b ? 1 : -1;
        }
    }
}