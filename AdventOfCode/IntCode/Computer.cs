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
                var jmp = false;
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
                        var input = _inputModule.InputCallback();
                        _memory[index] = input;
                        break;
                    case OpCode.Output:
                        var outputValue = GetValue(parameterValues[0]);
                        _outputModule.OutputCallback(outputValue);
                        break;
                    case OpCode.JmpT:
                        jmp = GetValue(parameterValues[0]) > 0;
                        if (jmp) _instructionPointer = GetValue(parameterValues[1]);
                        break;
                    case OpCode.JmpF:
                        jmp = GetValue(parameterValues[0]) == 0;
                        if (jmp) _instructionPointer = GetValue(parameterValues[1]);
                        break;
                    case OpCode.LessThan:
                        var lt = GetValue(parameterValues[0]) < GetValue(parameterValues[1]);
                        index = parameterValues[2].value;
                        _memory[index] = lt ? 1 : 0;;
                        break;
                    case OpCode.Eql:
                        var eql = GetValue(parameterValues[0]) == GetValue(parameterValues[1]);
                        index = parameterValues[2].value;
                        var toStore = eql ? 1 : 0;
                        _memory[index] = toStore;
                        break;
                    case OpCode.Halt:
                        return _memory;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                if (!jmp) _instructionPointer += instruction.ParameterModes.Count + 1;
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