using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UczenieZeWzmacnianiem.WinForms.Models;

namespace UczenieZeWzmacnianiem.WinForms
{
    public partial class MainWindow : Form
    {
        private SimulatorSettings _simulatorSettings;
        private Cell[,] _world;

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
            List<Coordinates> bordersCoordinateses = new List<Coordinates>();
            for (int i = 0; i < _simulatorSettings.WorldSize; i++)
            {
                bordersCoordinateses.Add(new Coordinates {X = 0, Y = i});
                bordersCoordinateses.Add(new Coordinates {X = i, Y = 0});
            }

            Random rand = new Random();
            List<Coordinates> exitsCoordinateses = new List<Coordinates>();
            for (int i = 0; i < _simulatorSettings.NumberOfExits; i++)
            {
                int next = rand.Next(0, bordersCoordinateses.Count);
                exitsCoordinateses.Add(bordersCoordinateses[next]);
                bordersCoordinateses.RemoveAt(next);
            }

            _world = new Cell[_simulatorSettings.WorldSize, _simulatorSettings.WorldSize];

            for (int x = 0; x < _simulatorSettings.WorldSize; x++)
            {
                for (int y = 0; y < _simulatorSettings.WorldSize; y++)
                {
                    _world[x, y] = new Cell
                    {
                        Coordinates = new Coordinates {X = x, Y = y},
                        Type = exitsCoordinateses.Exists(c => c.X == x && c.Y == y) ? CellType.Wall : CellType.Empty,
                        Uasbility = Decimal.Zero
                    };
                }
            }
            int count = _world.Cast<Cell>().Count(x => x.Type == CellType.Wall);
            if (count != _simulatorSettings.NumberOfExits)
            {
                throw new Exception();
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
            g.DrawLine(BorderPen, 0 + BorderPen.Width/2, 0, 0 + BorderPen.Width/2, pbSize);
            for (int i = 1; i < _simulatorSettings.WorldSize; i++)
            {
                g.DrawLine(LinePen, BorderPen.Width + i*(cellSize + LinePen.Width), 0,
                    BorderPen.Width + i*(cellSize + LinePen.Width), pbSize);
            }
            g.DrawLine(BorderPen, pbSize - BorderPen.Width/2, 0, pbSize - BorderPen.Width/2, pbSize);

            // rysowanie linii poziomych
            g.DrawLine(BorderPen, 0, 0 + BorderPen.Width/2, pbSize, 0 + BorderPen.Width/2);
            for (int i = 1; i < _simulatorSettings.WorldSize; i++)
            {
                g.DrawLine(LinePen, 0, BorderPen.Width + i*(cellSize + LinePen.Width),
                    pbSize, BorderPen.Width + i*(cellSize + LinePen.Width));
            }
            g.DrawLine(BorderPen, 0, pbSize - BorderPen.Width/2, pbSize, pbSize - BorderPen.Width/2);


            pictureBox.Image = bitmap;
            g.Dispose();
        }
    }
}