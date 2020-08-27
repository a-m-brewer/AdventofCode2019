using System.Collections.Generic;
using AdventOfCode.IntCode.Interfaces;

namespace AdventOfCode.IntCode.Modules.Input
{
    public class ListInputModule : IInputModule
    {
        private readonly List<long> _inputs;
        private int _index;

        public ListInputModule(List<long> inputs)
        {
            _inputs = inputs;
            Reset();
        }
        
        public void Reset()
        {
            _index = 0;
        }

        public void Append(long input)
        {
            _inputs.Add(input);
        }

        public long InputCallback()
        {
            var input = _inputs[_index];
            _index++;
            return input;
        }
    }
}