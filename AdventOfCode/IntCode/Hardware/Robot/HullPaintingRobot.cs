using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AdventOfCode.IntCode.Hardware.Robot.Models;
using AdventOfCode.IntCode.Modules.Input;
using AdventOfCode.IntCode.Modules.Output;

namespace AdventOfCode.IntCode.Hardware.Robot
{
    public class HullPaintingRobot
    {
        private readonly int _startingColor;
        private Computer _computer;

        private int _posX;
        private int _posY;
        private Direction _direction;
        private Status _lastStatus;

        private List<Panel> _panels;
        private int _currIndex;

        public HullPaintingRobot(int startingColor = 0)
        {
            _startingColor = startingColor;
            _posX = 0;
            _posY = 0;
            _direction = Direction.North;
            _lastStatus = Status.NewInput;

            _panels = new List<Panel>();
            _computer = new Computer(new FuncInputModule(InputCallback), new ActionOutputModule(OutputCallback));
        }
        
        public List<Panel> Paint()
        {
            _computer.Load(CreateProgram());
            _computer.Run();
            return _panels;
        }

        private long InputCallback()
        {
            var panel = _panels.FirstOrDefault(f => f.X == _posX && f.Y == _posY);
            if (panel == null)
            {
                panel = new Panel {VisitedCount = 0, Color = _posX == 0 && _posY == 0 ? _startingColor : 0, X = _posX, Y = _posY};
                _panels.Add(panel);
            }

            _lastStatus = Status.NewInput;

            _currIndex = _panels.IndexOf(panel);

            _panels[_currIndex].VisitedCount += 1;
            
            return panel.Color;
        }

        private void OutputCallback(long val)
        {
            switch (_lastStatus)
            {
                case Status.NewInput:
                    _panels[_currIndex].Color = val;
                    _lastStatus = Status.Painting;
                    break;
                case Status.Painting:
                    var (moveX, moveY) = GetNextMove(val);
                    _posX += moveX;
                    _posY += moveY;
                    _lastStatus = Status.Moving;
                    break;
                case Status.Moving:
                    throw new ArgumentOutOfRangeException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private (int moveX, int moveY) GetNextMove(in long val)
        {
            _direction = _direction switch
            {
                Direction.North => val == 0 ? Direction.West : Direction.East,
                Direction.East => val == 0 ? Direction.North : Direction.South,
                Direction.South => val == 0 ? Direction.East : Direction.West,
                Direction.West => val == 0 ? Direction.South : Direction.North,
                _ => throw new ArgumentOutOfRangeException()
            };

            return _direction switch
            {
                Direction.North => (0, -1),
                Direction.East => (1, 0),
                Direction.South => (0, 1),
                Direction.West => (-1, 0),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private static IEnumerable<long> CreateProgram() => new[]
        {
            3, 8, 1005, 8, 299, 1106, 0, 11, 0, 0, 0, 104, 1, 104, 0, 3, 8, 102, -1, 8, 10, 101, 1, 10, 10, 4, 10, 1008,
            8, 0, 10, 4, 10, 1002, 8, 1, 29, 1, 1007, 14, 10, 2, 1106, 8, 10, 3, 8, 1002, 8, -1, 10, 1001, 10, 1, 10, 4,
            10, 108, 1, 8, 10, 4, 10, 1002, 8, 1, 58, 3, 8, 1002, 8, -1, 10, 101, 1, 10, 10, 4, 10, 108, 0, 8, 10, 4,
            10, 1002, 8, 1, 80, 3, 8, 1002, 8, -1, 10, 1001, 10, 1, 10, 4, 10, 1008, 8, 0, 10, 4, 10, 102, 1, 8, 103, 1,
            5, 6, 10, 3, 8, 102, -1, 8, 10, 101, 1, 10, 10, 4, 10, 108, 1, 8, 10, 4, 10, 101, 0, 8, 128, 1, 106, 18, 10,
            1, 7, 20, 10, 1006, 0, 72, 1006, 0, 31, 3, 8, 1002, 8, -1, 10, 1001, 10, 1, 10, 4, 10, 108, 0, 8, 10, 4, 10,
            1002, 8, 1, 164, 3, 8, 1002, 8, -1, 10, 1001, 10, 1, 10, 4, 10, 108, 1, 8, 10, 4, 10, 102, 1, 8, 186, 1,
            1007, 8, 10, 1006, 0, 98, 3, 8, 1002, 8, -1, 10, 1001, 10, 1, 10, 4, 10, 1008, 8, 0, 10, 4, 10, 101, 0, 8,
            216, 2, 102, 8, 10, 1, 1008, 18, 10, 1, 1108, 8, 10, 1006, 0, 68, 3, 8, 1002, 8, -1, 10, 1001, 10, 1, 10, 4,
            10, 1008, 8, 1, 10, 4, 10, 1001, 8, 0, 253, 3, 8, 102, -1, 8, 10, 1001, 10, 1, 10, 4, 10, 108, 1, 8, 10, 4,
            10, 1002, 8, 1, 274, 1, 1105, 7, 10, 101, 1, 9, 9, 1007, 9, 1060, 10, 1005, 10, 15, 99, 109, 621, 104, 0,
            104, 1, 21102, 936995738520, 1, 1, 21102, 316, 1, 0, 1106, 0, 420, 21101, 0, 936995824276, 1, 21102, 1, 327,
            0, 1106, 0, 420, 3, 10, 104, 0, 104, 1, 3, 10, 104, 0, 104, 0, 3, 10, 104, 0, 104, 1, 3, 10, 104, 0, 104, 1,
            3, 10, 104, 0, 104, 0, 3, 10, 104, 0, 104, 1, 21102, 248129784923, 1, 1, 21102, 1, 374, 0, 1105, 1, 420,
            21102, 29015149735, 1, 1, 21101, 385, 0, 0, 1106, 0, 420, 3, 10, 104, 0, 104, 0, 3, 10, 104, 0, 104, 0,
            21101, 983925826304, 0, 1, 21101, 0, 408, 0, 1105, 1, 420, 21102, 825012036364, 1, 1, 21101, 0, 419, 0,
            1105, 1, 420, 99, 109, 2, 22101, 0, -1, 1, 21101, 0, 40, 2, 21101, 0, 451, 3, 21102, 441, 1, 0, 1105, 1,
            484, 109, -2, 2105, 1, 0, 0, 1, 0, 0, 1, 109, 2, 3, 10, 204, -1, 1001, 446, 447, 462, 4, 0, 1001, 446, 1,
            446, 108, 4, 446, 10, 1006, 10, 478, 1101, 0, 0, 446, 109, -2, 2105, 1, 0, 0, 109, 4, 2102, 1, -1, 483,
            1207, -3, 0, 10, 1006, 10, 501, 21102, 0, 1, -3, 21201, -3, 0, 1, 22102, 1, -2, 2, 21102, 1, 1, 3, 21101,
            520, 0, 0, 1106, 0, 525, 109, -4, 2105, 1, 0, 109, 5, 1207, -3, 1, 10, 1006, 10, 548, 2207, -4, -2, 10,
            1006, 10, 548, 21201, -4, 0, -4, 1105, 1, 616, 21201, -4, 0, 1, 21201, -3, -1, 2, 21202, -2, 2, 3, 21102, 1,
            567, 0, 1105, 1, 525, 21202, 1, 1, -4, 21102, 1, 1, -1, 2207, -4, -2, 10, 1006, 10, 586, 21102, 0, 1, -1,
            22202, -2, -1, -2, 2107, 0, -3, 10, 1006, 10, 608, 21201, -1, 0, 1, 21102, 1, 608, 0, 106, 0, 483, 21202,
            -2, -1, -2, 22201, -4, -2, -4, 109, -5, 2106, 0, 0
        };
    }
}