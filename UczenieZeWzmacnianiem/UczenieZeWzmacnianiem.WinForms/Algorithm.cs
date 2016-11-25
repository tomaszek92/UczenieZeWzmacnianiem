using System;
using System.Collections.Generic;
using System.Linq;
using UczenieZeWzmacnianiem.WinForms.Models;

namespace UczenieZeWzmacnianiem.WinForms
{
    public class Algorithm
    {
        public static void ExecuteTest(World world, int maxSteps, Cell startCell, Random rand)
        {
            decimal stepPenalty = 1/(decimal) maxSteps;
            bool reachedExit = false;
            var path = new List<Cell>();
            var cells = world.Cells.Cast<Cell>().ToList();
            Cell actualCell = startCell;
            for (int i = 0; i < maxSteps; i++)
            {
                cells.Remove(actualCell);
                path.Add(actualCell);

                if (world.Exits.Exists(exit =>
                    exit.Coordinates.X == actualCell.Coordinates.X &&
                    exit.Coordinates.Y == actualCell.Coordinates.Y))
                {
                    reachedExit = true;
                    break;
                }

                var possibleNextMoveCells = world.FindNeighbourCellsInGivenSet(cells, actualCell);

                if (possibleNextMoveCells.Count == 0)
                {
                    break;
                }
                actualCell = possibleNextMoveCells.ElementAt(rand.Next(0, possibleNextMoveCells.Count));
            }

            decimal usability = reachedExit ? Decimal.One : Decimal.MinusOne;
            for (int i = 0; i < path.Count; i++)
            {
                path[path.Count - 1 - i].Usabilities.Add(usability - i*stepPenalty);
            }
        }
    }
}