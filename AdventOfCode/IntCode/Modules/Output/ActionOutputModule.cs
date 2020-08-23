using System;
using AdventOfCode.IntCode.Interfaces;

namespace AdventOfCode.IntCode.Modules.Output
{
    public class ActionOutputModule : IOutputModule
    {
        private readonly Action<int> _callback;

        public ActionOutputModule(Action<int> callback)
        {
            _callback = callback;
        }
        
        public void OutputCallback(int val)
        {
            _callback.Invoke(val);
        }
    }
}