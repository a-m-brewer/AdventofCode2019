using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.IntCode.Hardware.Arcade.Models
{
    public class Screen
    {
        public Screen()
        {
            Pixels = new List<IPixel>();
        }

        public IList<IPixel> Pixels { get; }

        public void Update(IPixel p)
        {
            var pixelExists = Pixels.FirstOrDefault(f => f.X == p.X && f.Y == p.Y);
            if (pixelExists == null)
            {
                Pixels.Add(p);
            }
            else
            {
                var i = Pixels.IndexOf(pixelExists);
                Pixels[i] = p;
            }
        }

        public override string ToString()
        {
            var minX = Pixels.Min(m => m.X);
            var minY = Pixels.Min(m => m.Y);
            
            var width = Pixels.Max(m => m.X) + (Pixels.Any() ? 1 : 0) - minX;
            var height = Pixels.Max(m => m.Y) + (Pixels.Any() ? 1 : 0) - minY;

            var output = "";

            foreach (var y in Enumerable.Range((int)minY, (int)height))
            {
                foreach (var x in Enumerable.Range((int)minX, (int)width))
                {
                    var p = Pixels.FirstOrDefault(f => f.X == x && f.Y == y)?.Value ?? " ";
                    output += p;
                }

                output += "\n";
            }

            return output;
        }
    }
}