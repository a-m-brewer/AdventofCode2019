using System;
using System.Collections.Generic;
using AdventOfCode.IntCode.Interfaces;

namespace AdventOfCode.IntCode
{
    public class Computer
    {
        private readonly IInputModule _inputModule;
        private readonly IOutputModule _outputModule;
        private IList<int> _memory;
        private int _instructionPointer;

        public Computer(IInputModule inputModule, IOutputModule outputModule)
        {
            _inputModule = inputModule;
            _outputModule = outputModule;
            Reset();
        }

        public void Load(IList<int> memory)
        {
            _memory = memory;
            Reset();
        }

        private void Reset()
        {
            _instructionPointer = 0;
        }

        public IList<int> Run()
        {
            if (_memory == null)
            {
                throw new Exception($"You must load a program first using {nameof(Computer)}.{nameof(Load)}");
            }
            
            while (_instructionPointer < _memory.Count && _memory[_instructionPointer] != (int) OpCode.Halt)
            {
                var instruction = new Instruction(_memory[_instructionPointer]);
                var parameterValues = GetParameterValues(instruction);

                int index;
                switch (instruction.Op)
                {
                    case OpCode.Add:
                        index = parameterValues[2].value;
                        _memory[index] = GetValue(parameterValues[0]) + GetValue(parameterValues[1]);
                        break;
                    case OpCode.Multiply:
                        index = parameterValues[2].value;
                        _memory[index] = GetValue(parameterValues[0]) * GetValue(parameterValues[1]);
                        break;
                    case OpCode.Save:
                        index = parameterValues[0].value;
                        _memory[index] = _inputModule.InputCallback();
                        break;
                    case OpCode.Output:
                        var outputValue = GetValue(parameterValues[0]);
                        _outputModule.OutputCallback(outputValue);
                        break;
                    case OpCode.Halt:
                        return _memory;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                _instructionPointer += instruction.ParameterModes.Count + 1;
            }

            return _memory;
        }

        private IList<(int value, Mode mode)> GetParameterValues(Instruction instruction)
        {
            var firstIndex = _instructionPointer + 1;
            var endIndex = firstIndex + instruction.ParameterModes.Count;
            
            var parameterValues = new List<(int value, Mode mode)>(instruction.ParameterModes.Count);

            for (var i = firstIndex; i < endIndex; i++)
            {
                var param = _memory[i];
                var modeIndex = i - _instructionPointer - 1;
                var mode = instruction.ParameterModes[modeIndex];
                parameterValues.Add((param, mode));
            }

            return parameterValues;
        }

        private int GetValue((int value, Mode mode) parameter)
        {
            var (val, mode) = parameter;
            return mode switch
            {
                Mode.Position => _memory[val],
                Mode.Immediate => val,
                _ => throw new Exception("Unknown mode in GetValue")
            };
        }
    }
}