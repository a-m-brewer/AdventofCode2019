using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.IntCode.Hardware.Robot.Models;

namespace AdventOfCode.IntCode.Hardware.Robot.Algorithms
{
    public class AStarPathfinder
    {
        public List<OxygenNode> FindPath(OxygenRepairDroidResult repairDroidResult)
        {
            var startNode = repairDroidResult.Nodes.First(f =>
                f.X == repairDroidResult.Start.X && f.Y == repairDroidResult.Start.Y);
            var targetNode = repairDroidResult.Nodes.First(f =>
                f.X == repairDroidResult.End.X && f.Y == repairDroidResult.End.Y);
            
            var openSet = new List<OxygenNode>{startNode};
            var closedSet = new HashSet<OxygenNode>();

            while (openSet.Any())
            {
                var currentNode = openSet.First();

                for (var i = 1; i < openSet.Count; i++)
                {
                    if (openSet[i].FCost < currentNode.FCost ||
                        openSet[i].FCost == currentNode.FCost && openSet[i].HCost < currentNode.HCost)
                    {
                        currentNode = openSet[i];
                    }
                }

                openSet.Remove(currentNode);
                closedSet.Add(currentNode);

                if (currentNode == targetNode)
                {
                    return RetracePath(startNode, targetNode);
                }

                foreach (var neighbour in repairDroidResult.GetNeighbours(currentNode))
                {
                    if (!neighbour.Walkable || closedSet.Contains(neighbour))
                    {
                        continue;
                    }

                    var newMovementCostToNeighbour = currentNode.GCost + GetDistance(currentNode, neighbour);

                    if (newMovementCostToNeighbour < neighbour.GCost ||
                        !openSet.Contains(neighbour))
                    {
                        neighbour.GCost = newMovementCostToNeighbour;
                        neighbour.HCost = GetDistance(neighbour, targetNode);
                        neighbour.Parent = currentNode;

                        if (!openSet.Contains(neighbour))
                        {
                            openSet.Add(neighbour);
                        }
                    }
                }
            }
            
            return null;
        }

        private List<OxygenNode> RetracePath(OxygenNode start, OxygenNode end)
        {
            var path = new List<OxygenNode>();
            var currentNode = end;

            while (currentNode != start)
            {
                path.Add(currentNode);
                currentNode = currentNode.Parent;
            }

            path.Reverse();

            return path;
        }

        private long GetDistance(OxygenNode from, OxygenNode to)
        {
            var xDist = Math.Abs(to.X - from.X);
            var yDist = Math.Abs(to.Y - from.Y);
            return xDist + yDist;
        }
    }
}