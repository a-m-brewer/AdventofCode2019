using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode.DSN.Extensions;
using AdventOfCode.DSN.Interfaces;

namespace AdventOfCode.DSN.Models
{
    public class Picture : IPicture
    {
        public int Width { get; }
        public int Height { get; }

        public List<ILayer> Layers { get; }
        
        public Picture(IRawPicture picture)
        {
            if (picture == null) throw new ArgumentNullException(nameof(picture));
            Width = picture.Width;
            Height = picture.Height;
            var layerLength = Width * Height;
            var ints = picture.Pixels.Select(c => int.Parse(c.ToString())).ToArray();
            var rawLayers = ints.Chunk(layerLength);
            Layers = rawLayers.Select(l => (ILayer) new Layer(l, Width)).ToList();
        }

        public ILayer Decode()
        {
            var layers = Layers.Select(s => s.Rows).ToList();

            var resultLayer = Enumerable
                .Range(0, layers[0].Count)
                .Select(s =>
                    Enumerable
                        .Range(0, layers[0][0].Count)
                        .Select(_ => 2)
                        .ToList())
                .ToList();

            foreach (var layer in layers)
            {
                for (var r = 0; r < layer.Count; r++)
                {
                    var row = layer[r];
                    for (var c = 0; c < row.Count; c++)
                    {
                        var col = row[c];

                        if (resultLayer[r][c] == 2)
                        {
                            resultLayer[r][c] = col;
                        }
                    }
                }
            }

            return new Layer(resultLayer.SelectMany(s => s), resultLayer[0].Count);
        }

        public override string ToString()
        {
            var decoded = Decode();
            var sb = new StringBuilder();
            var rows = decoded.Rows.Select(
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