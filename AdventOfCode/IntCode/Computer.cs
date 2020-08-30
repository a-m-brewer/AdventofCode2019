using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.IntCode.Enums;
using AdventOfCode.IntCode.Interfaces;

namespace AdventOfCode.IntCode
{
    public class Computer
    {
        public IInputModule InputModule { get; set; }
        public IOutputModule OutputModule { get; set; }
        private IList<long> _memory;
        private long _instructionPointer;
        private long _rbo = 0;

        public bool Running { get; set; }
        public bool Halted { get; private set; }

        public Computer(IInputModule inputModule, IOutputModule outputModule)
        {
            InputModule = inputModule;
            OutputModule = outputModule;
            Reset();
        }

        public Computer()
        {
            Reset();
        }

        public void Load(IEnumerable<long> memory)
        {
            _memory = memory.ToList();
            Reset();
        }

        private void Reset()
        {
            _instructionPointer = 0;
        }

        public IList<long> Run()
        {
            if (_memory == null)
            {
                throw new Exception($"You must load a program first using {nameof(Computer)}.{nameof(Load)}");
            }

            Running = true;
            
            while (Running && _instructionPointer < _memory.Count)
            {
                var instruction = new Instruction(_memory[(int)_instructionPointer]);
                var parameterValues = GetParameterValues(instruction);

                long index;
                var jmp = false;
                switch (instruction.Op)
                {
                    case OpCode.Add:
                        index = GetIndex(parameterValues[2]);
                        ExtendMemoryIfRequired(index);
                        _memory[(int)index] = GetValue(parameterValues[0]) + GetValue(parameterValues[1]);
                        break;
                    case OpCode.Multiply:
                        index = GetIndex(parameterValues[2]);
                        ExtendMemoryIfRequired(index);
                        _memory[(int)index] = GetValue(parameterValues[0]) * GetValue(parameterValues[1]);
                        break;
                    case OpCode.Save:
                        index = GetIndex(parameterValues[0]);
                        ExtendMemoryIfRequired(index);
                        var input = InputModule.InputCallback();
                        _memory[(int)index] = input;
                        break;
                    case OpCode.Output:
                        var outputValue = GetValue(parameterValues[0]);
                        OutputModule.OutputCallback(outputValue);
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
                        index = GetIndex(parameterValues[2]);
                        ExtendMemoryIfRequired(index);
                        _memory[(int)index] = lt ? 1 : 0;;
                        break;
                    case OpCode.Eql:
                        var eql = GetValue(parameterValues[0]) == GetValue(parameterValues[1]);
                        index = GetIndex(parameterValues[2]);
                        ExtendMemoryIfRequired(index);
                        var toStore = eql ? 1 : 0;
                        _memory[(int)index] = toStore;
                        break;
                    case OpCode.Halt:
                        Halted = true;
                        return _memory;
                    case OpCode.SetRbo:
                        _rbo += GetValue(parameterValues[0]);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                if (!jmp) _instructionPointer += instruction.ParameterModes.Count + 1;
            }

            return _memory;
        }

        public void Stop()
        {
            Running = false;
        }

        private IList<(long value, Mode mode)> GetParameterValues(Instruction instruction)
        {
            var firstIndex = _instructionPointer + 1;
            var endIndex = firstIndex + instruction.ParameterModes.Count;
            
            var parameterValues = new List<(long value, Mode mode)>(instruction.ParameterModes.Count);

            for (var i = firstIndex; i < endIndex; i++)
            {
                var param = _memory[(int)i];
                var modeIndex = i - _instructionPointer - 1;
                var mode = instruction.ParameterModes[(int)modeIndex];
                parameterValues.Add((param, mode));
            }

            return parameterValues;
        }

        private long GetValue((long value, Mode mode) parameter)
        {
            var (val, mode) = parameter;

            var i = mode == Mode.Relative ? _rbo + val : val;

            if (mode != Mode.Immediate)
            {
                ExtendMemoryIfRequired(i);
            }
            
            return mode switch
            {
                Mode.Position => _memory[(int)i],
                Mode.Immediate => i,
                Mode.Relative => _memory[(int)i],
                _ => throw new Exception("Unknown mode in GetValue")
            };
        }
        
        private long GetIndex((long value, Mode mode) parameter)
        {
            var (val, mode) = parameter;

            var i = mode == Mode.Relative ? _rbo + val : val;

            if (mode != Mode.Immediate)
            {
                ExtendMemoryIfRequired(i);
            }

            return i;
        }

        private void ExtendMemoryIfRequired(long index)
        {
            if (_memory.Count <= index)
            {
                var extendAmount = index + 1 - _memory.Count;
                for (int j = 0; j < extendAmount; j++)
                {
                    _memory.Add(0);
                }
            }
        }
    }
}