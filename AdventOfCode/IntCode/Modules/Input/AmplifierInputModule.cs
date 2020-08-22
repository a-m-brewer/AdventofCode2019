using System.Collections.Generic;

namespace AdventOfCode.IntCode.Modules.Input
{
    public class AmplifierInputModule : ListInputModule
    {
        public AmplifierInputModule(int phaseMode, int input) : base(new List<int> {phaseMode, input})
        {
        }
    }
}