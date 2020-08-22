using System.Collections.Generic;
using System.Linq;
using AdventOfCode.IntCode.Modules.Input;
using AdventOfCode.IntCode.Modules.Output;

namespace AdventOfCode.IntCode
{
    public class Amplifier
    {
        private readonly Computer _comp;
        private readonly ListOutputModule _out;
        private readonly int[] _program;

        public Amplifier(ICollection<int> program)
        {
            _program = new int[program.Count];
            program.CopyTo(_program, 0);
            _comp = new Computer();
            _out = new ListOutputModule();
            _comp.OutputModule = _out;
        }

        public int Run(int phaseMode, int input)
        {
            Reset();
            _comp.InputModule = new AmplifierInputModule(phaseMode, input);
            _comp.Load(_program);
            _comp.Run();
            return _out.Output.LastOrDefault();
        }

        private void Reset()
        {
            _out.Output = new List<int>();
        }
    }
}