using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.IntCode.Hardware.Amp
{
    public class AmplifierPipeline
    {
        private readonly IList<long> _program;
        private List<Amplifier> _amps;

        public AmplifierPipeline(IList<long> program, int numberOfAmps)
        {
            _program = program;
            Init(numberOfAmps);
        }

        public void Init(int numberOfAmps)
        {
            _amps = Enumerable.Range(0, numberOfAmps).Select(s => new Amplifier(_program)).ToList();
        }

        public void Reset()
        {
            Init(_amps.Count);
        }
        
        public long Run(IList<long> phaseSequence, bool feedbackMode = false)
        {
            var input = 0L;

            if (feedbackMode)
            {
                while (!_amps.All(a => a.Halted))
                {
                    for (var i = 0; i < phaseSequence.Count; i++)
                    {
                        input = _amps[i].Run(phaseSequence[i], input);
                    }
                }
            }
            else
            {
                for (var i = 0; i < phaseSequence.Count; i++)
                {
                    input = _amps[i].Run(phaseSequence[i], input);
                }
            }

            return input;
        }
    }
}