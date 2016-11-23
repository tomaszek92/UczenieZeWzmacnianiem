using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                path.Add(actualCell);

                if (world.Exits.Exists(exit =>
                    exit.Coordinates.X == actualCell.Coordinates.X &&
                    exit.Coordinates.Y == actualCell.Coordinates.Y))
                {
                    reachedExit = true;
                    break;
                }

                var possibleNextMoveCells = world.FindNeighbourCells(actualCell);


                if (possibleNextMoveCells.Count == 0)
                {
                    break;
                }
                actualCell = possibleNextMoveCells.ElementAt(rand.Next(0, possibleNextMoveCells.Count));
                cells.Remove(actualCell);
            }

            decimal usability = reachedExit ? Decimal.One : Decimal.MinusOne;
            for (int i = 0; i < path.Count; i++)
            {
                path[path.Count - 1 - i].Usabilities.Add(usability - i*stepPenalty);
            }
        }

        private static void TryAddToPossibleNextMoveCells(IEnumerable<Cell> cells,
            ICollection<Cell> possibleNextMoveCells, int x, int y, int worldSize)
        {
            if (x < 0 || x >= worldSize || y < 0 || y >= worldSize)
            {
                return;
            }

            Cell possibleNextMoveCell = cells.FirstOrDefault(cell => cell.Coordinates.X == x && cell.Coordinates.Y == y);
            if (possibleNextMoveCell != null && possibleNextMoveCell.Type == CellType.Empty)
            {
                possibleNextMoveCells.Add(possibleNextMoveCell);
            }
        }
    }
}