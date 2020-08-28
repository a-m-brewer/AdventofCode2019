using System;
using AdventOfCode.IntCode.Interfaces;

namespace AdventOfCode.IntCode.Modules.Input
{
    public class FuncInputModule : IInputModule
    {
        private readonly Func<long> _func;

        public FuncInputModule(Func<long> func)
        {
            _func = func;
        }
        
        public long InputCallback()
        {
            return _func.Invoke();
        }
    }
}