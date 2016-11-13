using System.Drawing;

namespace UczenieZeWzmacnianiem.WinForms.Models
{
    public class ExitFromWorld
    {
        public Point Coordinates { get; private set; }
        public Direction Direction { get; private set; }

        public ExitFromWorld(Point coordinates, int worldSize)
        {
            Coordinates = coordinates;
            if (coordinates.X == 0)
            {
                Direction = Direction.West;
            }
            else if (coordinates.X == worldSize - 1)
            {
                Direction = Direction.East;
            }
            else if (coordinates.Y == 0)
            {
                Direction = Direction.South;
            }
            else if (coordinates.Y == worldSize - 1)
            {
                Direction = Direction.North;
            }
        }

        public ExitFromWorld(Point coordinates, Direction direction)
        {
            Coordinates = coordinates;
            Direction = direction;
        }
    }
}