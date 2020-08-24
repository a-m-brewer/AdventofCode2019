using System;
using System.Collections.Generic;
using AdventOfCode.DSN.Interfaces;

namespace AdventOfCode.DSN.Models
{
    public class RawPicture : IRawPicture
    {
        public int Width { get; }
        public int Height { get; }
        public string Pixels { get; }

        public RawPicture(int width, int height, string pixels)
        {
            if (width <= 0) throw new ArgumentOutOfRangeException(nameof(width));
            if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height));
            Width = width;
            Height = height;
            Pixels = pixels ?? throw new ArgumentNullException(nameof(pixels));
        }
    }
}