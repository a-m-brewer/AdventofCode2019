using System;
using System.Collections.Generic;

namespace AdventOfCode.DSN.Extensions
{
    public static class ArrayChunkExtensions
    {
        public static IList<IList<int>> Chunk(this int[] source, int length)
        {
            var chunked = new List<IList<int>>();
            for (var i = 0; i < source.Length; i += length)
            {
                var tmp = new int[length];
                Array.Copy(source, i, tmp, 0, length);
                chunked.Add(tmp);
            }

            return chunked;
        }
    }
}