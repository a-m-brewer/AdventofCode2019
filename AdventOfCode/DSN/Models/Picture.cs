using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}