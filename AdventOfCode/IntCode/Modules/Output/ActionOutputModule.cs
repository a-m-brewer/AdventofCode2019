using System;
using AdventOfCode.IntCode.Interfaces;

namespace AdventOfCode.IntCode.Modules.Output
{
    public class ActionOutputModule : IOutputModule
    {
        private readonly Action<long> _callback;

        public ActionOutputModule(Action<long> callback)
        {
            _callback = callback;
        }
        
        public void OutputCallback(long val)
        {
            _callback.Invoke(val);
        }
    }
}