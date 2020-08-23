using System.Collections.Generic;
using System.Linq;
using AdventOfCode.IntCode.Modules.Input;
using AdventOfCode.IntCode.Modules.Output;

namespace AdventOfCode.IntCode
{
    public class Amplifier
    {
        private readonly Computer _comp;
        private readonly int[] _program;
        private AmplifierInputModule _ampModule;
        private List<int> _output;

        public bool Halted => _comp.Halted;

        public Amplifier(ICollection<int> program)
        {
            _program = new int[program.Count];
            program.CopyTo(_program, 0);
            _comp = new Computer {OutputModule = new ActionOutputModule(OutputCallback)};
            ReloadProgram();
            Reset();
        }

        public int Run(int phaseMode, int input)
        {
            if (_ampModule == null)
            {
                _ampModule =  new AmplifierInputModule(phaseMode, input);
            }
            else
            {
                _ampModule.Append(input);
            }

            _comp.InputModule = _ampModule;
            _comp.Run();
            return _output.LastOrDefault();
        }

        public void ReloadProgram()
        {
            _comp.Load(_program);
        }

        public void Reset()
        {
            _output = new List<int>();
        }

        private void OutputCallback(int val)
        {
            _comp.Running = false;
            _output.Add(val);
        }
    }
}