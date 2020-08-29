using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Moons.Models;

namespace AdventOfCode.Moons
{
    public class MoonOrbitSimulator
    {
        public List<Moon> Simulate(List<Moon> moons, int steps)
        {
            if (steps == 0)
            {
                return moons;
            }

            for (var i = 0; i < steps; i++)
            {
                moons = Step(moons);
            }

            return moons;
        }

        public long GetSumOfTotalEnergy(IEnumerable<Moon> moons) => moons.Sum(s => s.TotalEnergy);

        public List<Moon> Step(List<Moon> moons)
        {
            moons.ForEach(m => m.UpdateVelocity(moons));
            moons.ForEach(m => m.UpdatePosition());

            return moons;
        }

        public long FirstRepeatOnAxis(List<Moon> moons, Func<Moon, MoonAxis> getAxis)
        {
            long step = 0;
            long period;
            
            while (true)
            {
                moons = Step(moons);
                step++;

                if (moons.Any(x => getAxis.Invoke(x).Velocity != 0)) continue;
                period = step * 2;
                
                break;
            }

            return period;
        }
    }
}