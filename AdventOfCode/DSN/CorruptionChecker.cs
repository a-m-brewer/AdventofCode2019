using System.Collections.Generic;
using System.Linq;
using AdventOfCode.DSN.Interfaces;

namespace AdventOfCode.DSN
{
    public class CorruptionChecker
    {
        public int Check(IPicture picture)
        {
            var fewestDigits = picture.Layers.Select(l =>
                {
                    var rawRow = l.Rows.SelectMany(m => m);
                    var zeros = rawRow.Count(c => c == 0);
                    return new {l, zeros};
                })
                .OrderBy(o => o.zeros)
                .Select(s => s.l)
                .First();

            var ones = fewestDigits.Rows.SelectMany(s => s).Count(c => c == 1);
            var twos = fewestDigits.Rows.SelectMany(s => s).Count(c => c == 2);

            return ones * twos;
        }
    }
}