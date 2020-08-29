using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.IntCode.Hardware.Arcade.Models
{
    public class Screen
    {
        public Screen()
        {
            Pixels = new List<Pixel>();
        }

        public IList<Pixel> Pixels { get; }

        public void Update(Pixel p)
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
            var width = Pixels.Max(m => m.X);
            var height = Pixels.Max(m => m.Y);

            var output = "";

            foreach (var y in Enumerable.Range(0, (int)height))
            {
                foreach (var x in Enumerable.Range(0, (int)width))
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