using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UczenieZeWzmacnianiem.WinForms.Models;

namespace UczenieZeWzmacnianiem.WinForms
{
    public partial class MainWindow : Form
    {
        private World _world;
        private Cell _startCell;
        private SimulatorSettings _simulatorSettings;
        private readonly Random _rand = new Random();

        private readonly Pen _linePen = new Pen(Color.Black, 3);
        private readonly Pen _borderPen = new Pen(Color.Black, 10);
        private readonly Brush _wallBrush = Brushes.DarkRed;
        private readonly Brush _startCellBrush = Brushes.Pink;
        private readonly Brush _pathBrush = Brushes.Green;
        private readonly Font _font = new Font("Arial", 12, FontStyle.Bold);

        public MainWindow()
        {
            InitializeComponent();
            InitializeComboBoxes();
            //RunTests();
        }

        private void InitializeComboBoxes()
        {
            InitializeComboBox(cbWorldSize, new List<ComboBoxItem>
            {
                new ComboBoxItem(8),
                new ComboBoxItem(10),
                new ComboBoxItem(12)
            });

            InitializeComboBox(cbNumberOfExits, new List<ComboBoxItem>
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

            InitializeComboBox(cbNumberOfWalls, Enumerable.Range(0, 10).Select(x => new ComboBoxItem(x)).ToList());
        }

        private static void InitializeComboBox(ComboBox comboBox, List<ComboBoxItem> comboBoxItems)
        {
            comboBox.DataSource = comboBoxItems;
            comboBox.DisplayMember = "Text";
            comboBox.ValueMember = "Value";
        }

        private class TestResult
        {
            public int Found { get; set; }
            public int Optimal { get; set; }

            public TestResult()
            {
                Found = 0;
                Optimal = 0;
            }
        }

        private void RunTests()
        {
            List<int> numbersOfTests = new List<int> {10, 100, 1000, 10000};
            Dictionary<int, TestResult> testResults = numbersOfTests.ToDictionary(x => x, x => new TestResult());
            _simulatorSettings = new SimulatorSettings(12, 1, 5, 0, 3);
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int testIndex = 0; testIndex < 100; testIndex++)
            {
                CreateWorld();
                var exitCoord = _world.Exits.First().Coordinates;
                foreach (int numberOfTests in numbersOfTests)
                {
                    _world.ClearCellUsabilities();
                    for (int j = 0; j < numberOfTests; j++)
                    {
                        Algorithm.ExecuteTest(_world, _simulatorSettings.MaxOfAgentSteps, _startCell, _rand);
                    }
                    bool findPathToExit = _world.FindPathToExit(_startCell);
                    if (findPathToExit)
                    {
                        testResults[numberOfTests].Found++;
                        int distance = Math.Abs(_startCell.Coordinates.X - exitCoord.X) +
                                       Math.Abs(_startCell.Coordinates.Y - exitCoord.Y);
                        if (_world.PathToExit.Count == distance)
                        {
                            testResults[numberOfTests].Optimal++;
                        }
                    }
                }
            }
            stopwatch.Stop();
            MessageBox.Show(stopwatch.Elapsed.TotalSeconds.ToString(CultureInfo.InvariantCulture));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _simulatorSettings = new SimulatorSettings(
                (int) cbWorldSize.SelectedValue, (int) cbNumberOfExits.SelectedValue,
                (int) cbMaxOfAgentsSteps.SelectedValue, Int32.Parse(tbNumberOfTests.Text),
                (int) cbNumberOfWalls.SelectedValue);

            if (!checkBoxSaveLastWorld.Checked)
            {
                CreateWorld();
            }
            checkBoxSaveLastWorld.Enabled = true;
            btnShowAgentsBehaviour.Enabled = true;
            _world.ClearCellUsabilities();

            progressBarSimulator.Maximum = _simulatorSettings.NumberOfTests;
            progressBarSimulator.Value = 0;
            for (int i = 0; i < _simulatorSettings.NumberOfTests; i++)
            {
                Algorithm.ExecuteTest(_world, _simulatorSettings.MaxOfAgentSteps, _startCell, _rand);
                progressBarSimulator.Value = i + 1;
            }

            DrawWorld(false);
        }

        private void btnShowAgentsBehaviour_Click(object sender, EventArgs e)
        {
            bool findPathToExit = _world.FindPathToExit(_startCell);
            if (!findPathToExit)
            {
                MessageBox.Show(@"Nie znaleziono ścieżki");
            }
            else
            {
                DrawWorld(true);
            }
        }

        private void CreateWorld()
        {
            _world = new World(_simulatorSettings.WorldSize);
            CreateExits();
            List<Point> walls = CreateWalls();

            for (int x = 0; x < _simulatorSettings.WorldSize; x++)
            {
                for (int y = 0; y < _simulatorSettings.WorldSize; y++)
                {
                    _world.Cells[x, y] = new Cell
                    {
                        Coordinates = new Point {X = x, Y = y},
                        Type = walls.Exists(c => c.X == x && c.Y == y)
                            ? CellType.Wall
                            : CellType.Empty
                    };
                }
            }

            List<Cell> cells = _world.Cells.Cast<Cell>().ToList();
            var possibleStartCells = cells.Where(x => x.Type == CellType.Empty).ToList();
            _startCell = possibleStartCells.ElementAt(_rand.Next(0, possibleStartCells.Count));
        }

        private List<Point> CreateWalls()
        {
            List<Point> possibleWalls = new List<Point>();
            for (int x = 0; x < _simulatorSettings.WorldSize; x++)
            {
                for (int y = 0; y < _simulatorSettings.WorldSize; y++)
                {
                    possibleWalls.Add(new Point(x, y));
                }
            }
            possibleWalls.RemoveAll(point =>
            {
                int tmp = 0;
                if (point.X == 0 || point.X == _simulatorSettings.WorldSize - 1)
                {
                    tmp++;
                }
                if (point.Y == 0 || point.Y == _simulatorSettings.WorldSize - 1)
                {
                    tmp++;
                }
                return tmp == 2;
            });

            List<Point> walls = new List<Point>();
            while (walls.Count != _simulatorSettings.NumberOfWalls)
            {
                int index = _rand.Next(0, possibleWalls.Count);
                Point possibleWall = possibleWalls[index];
                possibleWalls.RemoveAt(index);
                if (!IsNeighbourOfWallOrExit(walls, possibleWall))
                {
                    walls.Add(possibleWall);
                }
            }

            return walls;
        }

        private bool IsNeighbourOfWallOrExit(List<Point> walls, Point possibleWall)
        {
            if (walls.Any(wall =>
            {
                double distance = Math.Sqrt(Math.Pow(wall.X - possibleWall.X, 2) + Math.Pow(wall.Y - possibleWall.Y, 2));
                return distance <= Math.Sqrt(2);
            }))
            {
                return true;
            }

            if (_world.Exits.Any(exit => exit.Coordinates.X == possibleWall.X && exit.Coordinates.Y == possibleWall.Y))
            {
                return true;
            }
            if (_world.Exits.Any(exit => exit.Coordinates.Y == possibleWall.Y && exit.Coordinates.X == possibleWall.X))
            {
                return true;
            }
            return false;
        }

        private void CreateExits()
        {
            List<ExitFromWorld> possibleExits = new List<ExitFromWorld>
            {
                new ExitFromWorld(new Point {X = 0, Y = 0}, Direction.West),
                new ExitFromWorld(new Point {X = 0, Y = 0}, Direction.South),
                new ExitFromWorld(new Point {X = _simulatorSettings.WorldSize - 1, Y = 0}, Direction.East),
                new ExitFromWorld(new Point {X = _simulatorSettings.WorldSize - 1, Y = 0}, Direction.South),
                new ExitFromWorld(new Point {X = 0, Y = _simulatorSettings.WorldSize - 1}, Direction.West),
                new ExitFromWorld(new Point {X = 0, Y = _simulatorSettings.WorldSize - 1}, Direction.North),
                new ExitFromWorld(
                    new Point {X = _simulatorSettings.WorldSize - 1, Y = _simulatorSettings.WorldSize - 1},
                    Direction.East),
                new ExitFromWorld(
                    new Point {X = _simulatorSettings.WorldSize - 1, Y = _simulatorSettings.WorldSize - 1},
                    Direction.North)
            };

            for (int i = 1; i < _simulatorSettings.WorldSize - 1; i++)
            {
                possibleExits.Add(new ExitFromWorld(new Point {X = 0, Y = i}, _simulatorSettings.WorldSize));
                possibleExits.Add(new ExitFromWorld(new Point {X = _simulatorSettings.WorldSize - 1, Y = i},
                    _simulatorSettings.WorldSize));
                possibleExits.Add(new ExitFromWorld(new Point {X = i, Y = _simulatorSettings.WorldSize - 1},
                    _simulatorSettings.WorldSize));
                possibleExits.Add(new ExitFromWorld(new Point {X = i, Y = 0}, _simulatorSettings.WorldSize));
            }

            _world.Exits = new List<ExitFromWorld>();
            for (int i = 0; i < _simulatorSettings.NumberOfExits; i++)
            {
                int next = _rand.Next(0, possibleExits.Count);
                _world.Exits.Add(possibleExits[next]);
                possibleExits.RemoveAt(next);
            }
        }

        private void DrawWorld(bool drawPathToExit)
        {
            int cellSize = (int) (pictureBox.Size.Width - (_simulatorSettings.WorldSize - 1)*_linePen.Width -
                                  2*_borderPen.Width)/_simulatorSettings.WorldSize;

            int pbSize = pictureBox.Width;

            Bitmap bitmap = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);

            // rysowanie linii pionowych
            for (int y = 0; y < _simulatorSettings.WorldSize; y++)
            {
                if (!_world.Exits
                    .Any(exit =>
                        exit.Coordinates.X == 0 &&
                        exit.Coordinates.Y == y &&
                        exit.Direction == Direction.West))
                {
                    g.DrawLine(_borderPen,
                        x1: 0 + _borderPen.Width/2,
                        y1: _borderPen.Width + y*(cellSize + _linePen.Width),
                        x2: 0 + _borderPen.Width/2,
                        y2: _borderPen.Width + (y + 1)*(cellSize + _linePen.Width));
                }
            }
            for (int i = 1; i < _simulatorSettings.WorldSize; i++)
            {
                g.DrawLine(_linePen, _borderPen.Width + i*(cellSize + _linePen.Width), 0,
                    _borderPen.Width + i*(cellSize + _linePen.Width), pbSize);
            }
            for (int y = 0; y < _simulatorSettings.WorldSize; y++)
            {
                if (!_world.Exits
                    .Any(exit =>
                        exit.Coordinates.X == _simulatorSettings.WorldSize - 1 &&
                        exit.Coordinates.Y == y &&
                        exit.Direction == Direction.East))
                {
                    g.DrawLine(_borderPen,
                        x1: pbSize - _borderPen.Width/2,
                        y1: _borderPen.Width + y*(cellSize + _linePen.Width),
                        x2: pbSize - _borderPen.Width/2,
                        y2: _borderPen.Width + (y + 1)*(cellSize + _linePen.Width));
                }
            }

            // rysowanie linii poziomych
            for (int x = 0; x < _simulatorSettings.WorldSize; x++)
            {
                if (!_world.Exits
                    .Any(exit =>
                        exit.Coordinates.X == x &&
                        exit.Coordinates.Y == 0 &&
                        exit.Direction == Direction.South))
                {
                    g.DrawLine(_borderPen,
                        x1: _borderPen.Width + x*(cellSize + _linePen.Width),
                        y1: 0 + _borderPen.Width/2,
                        x2: _borderPen.Width + (x + 1)*(cellSize + _linePen.Width),
                        y2: 0 + _borderPen.Width/2);
                }
            }
            for (int i = 1; i < _simulatorSettings.WorldSize; i++)
            {
                g.DrawLine(_linePen, 0, _borderPen.Width + i*(cellSize + _linePen.Width),
                    pbSize, _borderPen.Width + i*(cellSize + _linePen.Width));
            }
            for (int x = 0; x < _simulatorSettings.WorldSize; x++)
            {
                if (!_world.Exits
                    .Any(exit =>
                        exit.Coordinates.X == x &&
                        exit.Coordinates.Y == _simulatorSettings.WorldSize - 1 &&
                        exit.Direction == Direction.North))
                {
                    g.DrawLine(_borderPen,
                        x1: _borderPen.Width + x*(cellSize + _linePen.Width),
                        y1: pbSize - _borderPen.Width/2,
                        x2: _borderPen.Width + (x + 1)*(cellSize + _linePen.Width),
                        y2: pbSize - _borderPen.Width/2);
                }
            }

            // rysowanie kątków
            g.FillRectangle(Brushes.Black, 0, 0, _borderPen.Width, _borderPen.Width);
            g.FillRectangle(Brushes.Black, pbSize - _borderPen.Width, 0, _borderPen.Width, _borderPen.Width);
            g.FillRectangle(Brushes.Black, 0, pbSize - _borderPen.Width, _borderPen.Width, _borderPen.Width);
            g.FillRectangle(Brushes.Black, pbSize - _borderPen.Width, pbSize - _borderPen.Width, _borderPen.Width,
                _borderPen.Width);

            // rysowanie ścian
            for (int x = 0; x < _simulatorSettings.WorldSize; x++)
            {
                for (int y = 0; y < _simulatorSettings.WorldSize; y++)
                {
                    if (_world.Cells[x, y].Type == CellType.Wall)
                    {
                        FillCell(g, _wallBrush, x, y, cellSize);
                    }
                }
            }

            if (drawPathToExit)
            {
                for (int step = 0; step < _world.PathToExit.Count; step++)
                {
                    Cell cell = _world.PathToExit[step];
                    FillCell(g, _pathBrush, cell.Coordinates.X, cell.Coordinates.Y, cellSize);
                    DrawStepString(g, cell.Coordinates.X, cell.Coordinates.Y, cellSize, step);
                }
            }

            // rysowanie początkowej komórki
            FillCell(g, _startCellBrush, _startCell.Coordinates.X, _startCell.Coordinates.Y, cellSize);

            // rysowanie wyników
            for (int x = 0; x < _simulatorSettings.WorldSize; x++)
            {
                for (int y = 0; y < _simulatorSettings.WorldSize; y++)
                {
                    if (_world.Cells[x, y].Type == CellType.Empty &&
                        !(_startCell.Coordinates.X == x &&
                          _startCell.Coordinates.Y == y))
                    {
                        g.DrawString(_world.Cells[x, y].Uasbility.ToString("F", CultureInfo.CurrentCulture),
                            _font, Brushes.DodgerBlue,
                            x: _borderPen.Width + x*(cellSize + _linePen.Width),
                            y: _borderPen.Width + y*(cellSize + _linePen.Width));
                    }
                }
            }

            pictureBox.Image = bitmap;
            g.Dispose();
        }

        private void FillCell(Graphics g, Brush brush, int x, int y, int cellSize)
        {
            g.FillRectangle(brush,
                x: _borderPen.Width + x*(cellSize + _linePen.Width) + (x == 0 ? 0 : _linePen.Width/2),
                y: _borderPen.Width + y*(cellSize + _linePen.Width) + (y == 0 ? 0 : _linePen.Width/2),
                width: cellSize + (x == 0 || x == _simulatorSettings.WorldSize - 1 ? _linePen.Width/2 : 0),
                height: cellSize + (y == 0 || y == _simulatorSettings.WorldSize - 1 ? _linePen.Width/2 : 0));
        }

        private void DrawStepString(Graphics g, int x, int y, int cellSize, int step)
        {
            g.DrawString((step + 1).ToString(), _font, Brushes.OrangeRed,
                x: _borderPen.Width + x*(cellSize + _linePen.Width) + (x == 0 ? 0 : _linePen.Width/2) + cellSize/2,
                y: _borderPen.Width + y*(cellSize + _linePen.Width) + (y == 0 ? 0 : _linePen.Width/2) + cellSize/2);
        }
    }
}