using System;
using System.Collections.Generic;
using AdventOfCode.IntCode.Factories;
using AdventOfCode.IntCode.Interfaces;

namespace AdventOfCode.IntCode
{
    public class Computer
    {
        private readonly IInputModule _inputModule;
        private readonly IOutputModule _outputModule;
        private readonly IInstructionFactory _instructionFactory;
        private IList<int> _memory;
        private int _instructionPointer;

        public Computer(IInputModule inputModule, IOutputModule outputModule, IInstructionFactory instructionFactory)
        {
            _inputModule = inputModule;
            _outputModule = outputModule;
            _instructionFactory = instructionFactory;
            Reset();
        }

        public Computer(IInputModule inputModule, IOutputModule outputModule) : this(inputModule, outputModule, new Day5InstructionFactory())
        {
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
                var instruction = _instructionFactory.Parse(_memory[_instructionPointer]);

                var parameterValues = GetParameterValues(instruction);

                switch (instruction.Op)
                {
                    case OpCode.Add:
                        _memory[parameterValues[2]] = parameterValues[0] + parameterValues[1];
                        _instructionPointer += 4;
                        break;
                    case OpCode.Multiply:
                        _memory[parameterValues[2]] = parameterValues[0] * parameterValues[1];
                        _instructionPointer += 4;
                        break;
                    case OpCode.Save:
                        _memory[parameterValues[0]] = _inputModule.InputCallback();
                        _instructionPointer += 2;
                        break;
                    case OpCode.Output:
                        _outputModule.OutputCallback(_memory[parameterValues[0]]);
                        _instructionPointer += 2;
                        break;
                    case OpCode.Halt:
                        return _memory;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(instruction.Op));
                }
            }

            return _memory;
        }

        private IList<int> GetParameterValues(IInstruction instruction)
        {
            var values = new int[instruction.ParameterModes.Count];
            var parameterStart = _instructionPointer + 1;
            var parameterEnd = parameterStart + instruction.ParameterModes.Count;
            for (var i = parameterStart; i < parameterEnd; i++)
            {
                var modeIndex = i - _instructionPointer - 1;
                var mode = instruction.ParameterModes[modeIndex];

                values[modeIndex] = mode switch
                {
                    Mode.Position => i,
                    Mode.Immediate => _memory[i],
                    _ => throw new Exception("Unknown mode")
                };
            }

            return values;
        }
    }
}