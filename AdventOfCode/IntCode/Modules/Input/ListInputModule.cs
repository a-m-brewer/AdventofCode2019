using System.Collections.Generic;
using AdventOfCode.IntCode.Interfaces;

namespace AdventOfCode.IntCode.Modules.Input
{
    public class ListInputModule : IInputModule
    {
        private readonly List<int> _inputs;
        private int _index;

        public ListInputModule(List<int> inputs)
        {
            _inputs = inputs;
            Reset();
        }
        
        public void Reset()
        {
            _index = 0;
        }

        public int InputCallback()
        {
            var input = _inputs[_index];
            _index++;
            return input;
        }
    }
}