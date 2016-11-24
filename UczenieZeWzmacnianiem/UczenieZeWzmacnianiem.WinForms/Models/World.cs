using System;
using System.Collections.Generic;
using System.Linq;

namespace UczenieZeWzmacnianiem.WinForms.Models
{
    public class World
    {
        public Cell[,] Cells { get; }
        public List<ExitFromWorld> Exits { get; set; }

        public List<Cell> PathToExit { get; private set; }

        public World(int worldSize)
        {
            Cells = new Cell[worldSize, worldSize];
        }

        public bool FindPathToExit(Cell startCell)
        {
            Cell actuaCell = startCell;
            PathToExit = new List<Cell>();
            List<Cell> cells = Cells.Cast<Cell>().ToList();
            while (true)
            {
                actuaCell = FindNeighbourCellsInGivenSet(cells, actuaCell)
                    .Where(cell =>
                        !(cell.Coordinates.X == startCell.Coordinates.X &&
                          cell.Coordinates.Y == startCell.Coordinates.Y))
                    .OrderByDescending(cell => cell.Uasbility)
                    .FirstOrDefault();
                if (actuaCell == null)
                {
                    return false;
                }
                cells.Remove(actuaCell);
                PathToExit.Add(actuaCell);
                if (Exits.Exists(exit =>
                        exit.Coordinates.X == actuaCell.Coordinates.X && exit.Coordinates.Y == actuaCell.Coordinates.Y))
                {
                    return true;
                }
            }
        }

        public List<Cell> FindNeighbourCellsInGivenSet(List<Cell> cells2, Cell cell)
        {
            List<Cell> result = new List<Cell>();

            List<Cell> cells = cells2
                .Where(c => c.Type == CellType.Empty)
                .ToList();

            int x = cell.Coordinates.X;
            int y = cell.Coordinates.Y;

            // ruch w lewo 
            TryAddToPossibleNextMoveCells(cells, result, x - 1, y, Cells.GetLength(0));
            // ruch w prawo
            TryAddToPossibleNextMoveCells(cells, result, x + 1, y, Cells.GetLength(0));
            // ruch do góry
            TryAddToPossibleNextMoveCells(cells, result, x, y + 1, Cells.GetLength(0));
            // ruch do dołu
            TryAddToPossibleNextMoveCells(cells, result, x, y - 1, Cells.GetLength(0));

            return result;
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