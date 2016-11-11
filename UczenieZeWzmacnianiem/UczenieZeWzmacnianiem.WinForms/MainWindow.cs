using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UczenieZeWzmacnianiem.WinForms.Models;

namespace UczenieZeWzmacnianiem.WinForms
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

    public partial class MainWindow : Form
    {
        private SimulatorSettings _simulatorSettings;
        private Cell[,] _world;
        private List<ExitFromWorld> _exits;

        private static readonly Pen LinePen = new Pen(Color.Black, 2);
        private static readonly Pen BorderPen = new Pen(Color.Black, 10);

        public MainWindow()
        {
            InitializeComponent();

            InitializeComboBoxes();
        }

        private void InitializeComboBoxes()
        {
            InitializeComboBox(cbWorldSize, new List<ComboBoxItem>
            {
                new ComboBoxItem(8),
                new ComboBoxItem(10),
                new ComboBoxItem(12)
            });

            InitializeComboBox(cbCountOfExits, new List<ComboBoxItem>
            {
                new ComboBoxItem(1),
                new ComboBoxItem(3),
                new ComboBoxItem(5)
            });

            InitializeComboBox(cbMaxOfAgentsSteps, new List<ComboBoxItem>
            {
                new ComboBoxItem(5),
                new ComboBoxItem(7),
                new ComboBoxItem(9),
            });

            var countOfTestComboBoxItems = Enumerable
                .Range(1, 10)
                .Select(x => new ComboBoxItem(x))
                .ToList();

            InitializeComboBox(cbCountOfTests, countOfTestComboBoxItems);
        }

        private static void InitializeComboBox(ComboBox comboBox, List<ComboBoxItem> comboBoxItems)
        {
            comboBox.DataSource = comboBoxItems;
            comboBox.DisplayMember = "Text";
            comboBox.ValueMember = "Value";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _simulatorSettings = new SimulatorSettings(
                (int) cbWorldSize.SelectedValue, (int) cbCountOfExits.SelectedValue,
                (int) cbMaxOfAgentsSteps.SelectedValue, (int) cbCountOfTests.SelectedValue);

            CreateWorld();
            DrawWorld();
        }


        private void btnShowAgentsBehaviour_Click(object sender, EventArgs e)
        {
        }

        private void CreateWorld()
        {
            List<ExitFromWorld> possibleExits = new List<ExitFromWorld>();
            possibleExits.Add(new ExitFromWorld(new Point {X = 0, Y = 0}, Direction.West));
            possibleExits.Add(new ExitFromWorld(new Point {X = 0, Y = 0}, Direction.South));
            possibleExits.Add(new ExitFromWorld(new Point {X = _simulatorSettings.WorldSize - 1, Y = 0}, Direction.East));
            possibleExits.Add(new ExitFromWorld(new Point {X = _simulatorSettings.WorldSize - 1, Y = 0}, Direction.South));
            possibleExits.Add(new ExitFromWorld(new Point {X = 0, Y = _simulatorSettings.WorldSize - 1}, Direction.West));
            possibleExits.Add(new ExitFromWorld(new Point {X = 0, Y = _simulatorSettings.WorldSize - 1}, Direction.North));
            possibleExits.Add(new ExitFromWorld(
                new Point {X = _simulatorSettings.WorldSize - 1, Y = _simulatorSettings.WorldSize - 1},
                Direction.East));
            possibleExits.Add(new ExitFromWorld(
                new Point {X = _simulatorSettings.WorldSize - 1, Y = _simulatorSettings.WorldSize - 1},
                Direction.North));

            for (int i = 1; i < _simulatorSettings.WorldSize - 1; i++)
            {
                possibleExits.Add(new ExitFromWorld(new Point {X = 0, Y = i}, _simulatorSettings.WorldSize));
                possibleExits.Add(new ExitFromWorld(new Point {X = _simulatorSettings.WorldSize - 1, Y = i},
                    _simulatorSettings.WorldSize));
                possibleExits.Add(new ExitFromWorld(new Point {X = i, Y = _simulatorSettings.WorldSize - 1},
                    _simulatorSettings.WorldSize));
                possibleExits.Add(new ExitFromWorld(new Point {X = i, Y = 0}, _simulatorSettings.WorldSize));
            }

            Random rand = new Random();
            _exits = new List<ExitFromWorld>();
            for (int i = 0; i < _simulatorSettings.NumberOfExits; i++)
            {
                int next = rand.Next(0, possibleExits.Count);
                _exits.Add(possibleExits[next]);
                possibleExits.RemoveAt(next);
            }

            _world = new Cell[_simulatorSettings.WorldSize, _simulatorSettings.WorldSize];

            for (int x = 0; x < _simulatorSettings.WorldSize; x++)
            {
                for (int y = 0; y < _simulatorSettings.WorldSize; y++)
                {
                    _world[x, y] = new Cell
                    {
                        Coordinates = new Point {X = x, Y = y},
                        Type = _exits.Exists(c => c.Coordinates.X == x && c.Coordinates.Y == y)
                            ? CellType.Wall
                            : CellType.Empty,
                        Uasbility = Decimal.Zero
                    };
                }
            }
        }

        private void DrawWorld()
        {
            int cellSize = (int) (pictureBox.Size.Width - (_simulatorSettings.WorldSize - 1)*LinePen.Width -
                                  2*BorderPen.Width)/_simulatorSettings.WorldSize;

            int pbSize = pictureBox.Width;

            Bitmap bitmap = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);

            // rysowanie linii pionowych
            for (int y = 0; y < _simulatorSettings.WorldSize; y++)
            {
                if (!_exits
                    .Any(exit =>
                        exit.Coordinates.X == 0 &&
                        exit.Coordinates.Y == y &&
                        exit.Direction == Direction.West))
                {
                    g.DrawLine(BorderPen,
                        x1: 0 + BorderPen.Width/2,
                        y1: BorderPen.Width + y*(cellSize + LinePen.Width),
                        x2: 0 + BorderPen.Width/2,
                        y2: BorderPen.Width + (y + 1)*(cellSize + LinePen.Width));
                }
            }
            for (int i = 1; i < _simulatorSettings.WorldSize; i++)
            {
                g.DrawLine(LinePen, BorderPen.Width + i*(cellSize + LinePen.Width), 0,
                    BorderPen.Width + i*(cellSize + LinePen.Width), pbSize);
            }
            for (int y = 0; y < _simulatorSettings.WorldSize; y++)
            {
                if (!_exits
                    .Any(exit =>
                        exit.Coordinates.X == _simulatorSettings.WorldSize - 1 &&
                        exit.Coordinates.Y == y &&
                        exit.Direction == Direction.East))
                {
                    g.DrawLine(BorderPen,
                        x1: pbSize - BorderPen.Width/2,
                        y1: BorderPen.Width + y*(cellSize + LinePen.Width),
                        x2: pbSize - BorderPen.Width/2,
                        y2: BorderPen.Width + (y + 1)*(cellSize + LinePen.Width));
                }
            }

            // rysowanie linii poziomych
            for (int x = 0; x < _simulatorSettings.WorldSize; x++)
            {
                if (!_exits
                    .Any(exit =>
                        exit.Coordinates.X == x &&
                        exit.Coordinates.Y == 0 &&
                        exit.Direction == Direction.South))
                {
                    g.DrawLine(BorderPen,
                        x1: BorderPen.Width + x*(cellSize + LinePen.Width),
                        y1: 0 + BorderPen.Width/2,
                        x2: BorderPen.Width + (x + 1)*(cellSize + LinePen.Width),
                        y2: 0 + BorderPen.Width/2);
                }
            }
            for (int i = 1; i < _simulatorSettings.WorldSize; i++)
            {
                g.DrawLine(LinePen, 0, BorderPen.Width + i*(cellSize + LinePen.Width),
                    pbSize, BorderPen.Width + i*(cellSize + LinePen.Width));
            }
            for (int x = 0; x < _simulatorSettings.WorldSize; x++)
            {
                if (!_exits
                    .Any(exit =>
                        exit.Coordinates.X == x &&
                        exit.Coordinates.Y == _simulatorSettings.WorldSize - 1 &&
                        exit.Direction == Direction.North))
                {
                    g.DrawLine(BorderPen,
                        x1: BorderPen.Width + x*(cellSize + LinePen.Width),
                        y1: pbSize - BorderPen.Width/2,
                        x2: BorderPen.Width + (x + 1)*(cellSize + LinePen.Width),
                        y2: pbSize - BorderPen.Width/2);
                }
            }
            pictureBox.Image = bitmap;
            g.Dispose();
        }
    }
}