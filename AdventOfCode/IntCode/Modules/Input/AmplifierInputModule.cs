using System.Collections.Generic;

namespace AdventOfCode.IntCode.Modules.Input
{
    public class AmplifierInputModule : ListInputModule
    {
        public AmplifierInputModule(long phaseMode, long input) : base(new List<long> {phaseMode, input})
        {
        }
    }
}