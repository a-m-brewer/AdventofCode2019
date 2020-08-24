using System.Collections.Generic;
using AdventOfCode.DSN;
using AdventOfCode.DSN.Interfaces;
using AdventOfCode.DSN.Models;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tests.DSN.Models
{
    public class PictureTests
    {
        [Test]
        public void Day8Part1Example1()
        {
            var raw = new RawPicture(3, 2, "123456789012");
            var picture = new Picture(raw);
            picture.Should().BeEquivalentTo(new FakePicture
            {
                Width = 3,
                Height = 2,
                Layers = new List<ILayer>
                {
                    new FakeLayer
                    {
                        Rows = new List<IList<int>>
                        {
                            new List<int> {1, 2, 3},
                            new List<int> {4, 5, 6}
                        }
                    },
                    new FakeLayer
                    {
                        Rows = new List<IList<int>>
                        {
                            new List<int> {7, 8, 9},
                            new List<int> {0, 1, 2}
                        }
                    }
                }
            });
        }
        
        [Test]
        public void Day8Part1Exercise()
        {
            var raw = new RawPicture(25, 6, RawData.Day8);
            var picture = new Picture(raw);
            var sut = new CorruptionChecker();
            var res = sut.Check(picture);
            res.Should().Be(1088);
        }
    }
    
    public class FakePicture : IPicture
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<ILayer> Layers { get; set; }
    }
    
    public class FakeLayer : ILayer
    {
        public IList<IList<int>> Rows { get; set; }
    }
}