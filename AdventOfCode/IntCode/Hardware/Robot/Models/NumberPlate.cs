using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.IntCode.Hardware.Robot.Models
{
    public class NumberPlate
    {
        public List<Panel> Panels { get; set; }

        public override string ToString()
        {
            var t = new long[6][];
            for (int y = 0; y < t.Length; y++)
            {
                t[y] = new long[41];
            }

            for (var y = 0; y < t.Length; y++)
            {
                for (var x = 0; x < t[y].Length; x++)
                {
                    t[y][x] = Panels.FirstOrDefault(f => f.X == x && f.Y == y)?.Color ?? 0;
                }
            }
            
            var sb = new StringBuilder();
            
            var rows = t.Select(
                r => 
                    string.Join("", 
                        r.Select(s => s == 1 ? s.ToString() : " "))).ToList();

            foreach (var row in rows)
            {
                sb.AppendLine(row);
            }

            return sb.ToString();
        }
    }
}