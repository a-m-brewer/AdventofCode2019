using System.Collections.Generic;
using System.Linq;
using AdventOfCode.DSN.Extensions;
using AdventOfCode.DSN.Interfaces;

namespace AdventOfCode.DSN.Models
{
    public class Layer : ILayer
    {
        public Layer(IEnumerable<int> layerRaw, int rowLength)
        {
            var layerArray = layerRaw.ToArray();
            Rows = layerArray.Chunk(rowLength);
        }
        
        public IList<IList<int>> Rows { get; set; }
    }
}