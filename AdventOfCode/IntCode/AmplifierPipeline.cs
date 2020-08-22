using System.Collections.Generic;

namespace AdventOfCode.IntCode
{
    public class AmplifierPipeline
    {
        private readonly IList<int> _program;

        public AmplifierPipeline(IList<int> program)
        {
            _program = program;
        }
        
        public int Run(IEnumerable<int> phaseSequence)
        {
            var input = 0;

            foreach (var phase in phaseSequence)
            {
                var amp = new Amplifier(_program);
                input = amp.Run(phase, input);
            }

            return input;
        }
    }
}