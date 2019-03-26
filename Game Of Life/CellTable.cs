using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game_Of_Life
{
    public partial class CellTable : UserControl
    {
        private Timer timer;
        private const int Resolution = 1024;
        private PictureBox pictureBox;
        private Graphics graphics;

        public bool SimulationRunning { get; private set; }
        public int CellNumber { get; }
        public int CellSize { get; }
        public Cell[,] Cells { get; set; }

        private int _RefreshRateInMilliseconds;
        public int RefreshRateInMilliseconds
        {
            get => _RefreshRateInMilliseconds;
            set
            {
                _RefreshRateInMilliseconds = value;

                if (_RefreshRateInMilliseconds < Constants.MinimumRefreshRateInMilliseconds)
                {
                    _RefreshRateInMilliseconds = Constants.MinimumRefreshRateInMilliseconds;
                }

                if (_RefreshRateInMilliseconds > Constants.MaximumRefreshRateInMilliseconds)
                {
                    _RefreshRateInMilliseconds = Constants.MaximumRefreshRateInMilliseconds;
                }

                timer.Interval = _RefreshRateInMilliseconds;
            }
        }

        //public string PatternCsv
        //{
        //    get
        //    {
        //        var rows = new string[CellNumber];

        //        for (int rowNumber = 0; rowNumber < CellNumber; rowNumber++)
        //        {
        //            var row = new int[CellNumber];

        //            for (int columnNumber = 0; columnNumber < CellNumber; columnNumber++)
        //            {
        //                row[columnNumber] = CellAliveStatuses[rowNumber, columnNumber].Alive ? 1 : 0;
        //            }

        //            rows[rowNumber] = string.Join(Constants.PatternCsvSeparator.ToString(), row);
        //        }

        //        return string.Join(Environment.NewLine, rows);
        //    }
        //}

        public CellTable(int cellNumber)
        {
            InitializeComponent();

            CellNumber = ValidateCellNumber(cellNumber);
            CellSize = Resolution / CellNumber;
            
            InitializeCells();
            InitializePictureBox();
            
            panelCells.Controls.Add(pictureBox);
            graphics = Graphics.FromImage(pictureBox.Image);

            timer = new Timer();
            timer.Tick += Timer_Tick;

            RefreshRateInMilliseconds = Constants.MinimumRefreshRateInMilliseconds;

            Draw();
        }

        private void InitializePictureBox()
        {
            pictureBox = new PictureBox();
            pictureBox.Size = new Size(1024, 1024);
            pictureBox.BackColor = Color.Black;
            pictureBox.Image = new Bitmap(1024, 1024);
        }

        public CellTable(int[,] pattern)
        {
            InitializeComponent();

            ValidatePattern(pattern);
            CellNumber = pattern.GetLength(0);
            CellSize = Resolution / CellNumber;

            InitializeCells();
            SetCellsAliveStatusFromPattern(pattern);

            timer = new Timer();
            timer.Tick += Timer_Tick;

            RefreshRateInMilliseconds = Constants.MinimumRefreshRateInMilliseconds;
        }

        private void ValidatePattern(int[,] pattern)
        {
            var cellNumber = Math.Sqrt(pattern.LongLength);

            if (cellNumber < Constants.MinimumCellNumber || cellNumber > Constants.MaximumCellNumber)
            {
                throw new Exception();
            }

            if (cellNumber < Constants.MinimumCellNumber || cellNumber > Constants.MaximumCellNumber)
            {
                throw new Exception();
            }
        }

        private int ValidateCellNumber(int cellNumber)
        {
            if (cellNumber < Constants.MinimumCellNumber)
            {
                return Constants.MinimumCellNumber;
            }

            if (cellNumber > Constants.MaximumCellNumber)
            {
                return Constants.MaximumCellNumber;
            }

            return cellNumber;
        }

        private void InitializeCells()
        {
            Cells = new Cell[CellNumber, CellNumber];

            for (int row = 0; row < CellNumber; row++)
            {
                for (int column = 0; column < CellNumber; column++)
                {
                    var cell = new Cell
                    {
                        Rectangle = new Rectangle(new Point(column * CellSize, row * CellSize), new Size(CellSize, CellSize)),
                        Alive = false,
                        BorderSize = 1
                    };

                    Cells[row, column] = cell;
                    cell.Alive = false;
                }
            }
        }

        private void SetCellsAliveStatusFromPattern(int[,] pattern)
        {
            //for (int row = 0; row < CellNumber; row++)
            //{
            //    for (int column = 0; column < CellNumber; column++)
            //    {
            //        if (pattern[row, column] == Constants.PatternDeadValue)
            //        {
            //            CellAliveStatuses[row, column].Alive = false;
            //        }

            //        if (pattern[row, column] == Constants.PatternAliveValue)
            //        {
            //            CellAliveStatuses[row, column].Alive = true;
            //        }
            //    }
            //}
        }

        public void RandomizePattern()
        {
            var rng = new Random();

            for (int row = 0; row < CellNumber; row++)
            {
                for (int column = 0; column < CellNumber; column++)
                {
                    var value = rng.Next(1, 3);
                    Cells[row, column].Alive = (value == 2);
                }
            }

            Draw();
        }

        public void ResetCells()
        {
            for (int row = 0; row < CellNumber; row++)
            {
                for (int column = 0; column < CellNumber; column++)
                {
                    Cells[row, column].Alive = false;
                }
            }
        }

        public void StartSimulation()
        {
            SimulationRunning = true;
            timer.Start();
        }

        public void EndSimulation()
        {
            SimulationRunning = false;
            timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var aliveStatuses = new bool[CellNumber, CellNumber];

            for (int row = 0; row < CellNumber; row++)
            {
                for (int column = 0; column < CellNumber; column++)
                {
                    aliveStatuses[row, column] = DetermineAliveStatusForGivenCellAt(row, column);
                }
            }

            for (int row = 0; row < CellNumber; row++)
            {
                for (int column = 0; column < CellNumber; column++)
                {
                    Cells[row, column].Alive = aliveStatuses[row, column];
                }
            }

            Draw();
        }

        private void Draw()
        {
            var brush = new SolidBrush(Options.DeadColor);
            for (int row = 0; row < CellNumber; row++)
            {
                for (int column = 0; column < CellNumber; column++)
                {
                    brush.Color = Cells[row, column].Alive
                        ? Options.AliveColor
                        : Options.DeadColor;

                    graphics.FillRectangle(brush, Cells[row, column].Rectangle);
                }
            }

            Refresh();
        }


        private bool DetermineAliveStatusForGivenCellAt(int row, int column)
        {
            var isCurrentlyAlive = Cells[row, column].Alive;
            var numberOfAliveNeighbors = GetNumberOfNeighborsForGivenCellAt(row, column, true);

            if (isCurrentlyAlive)
            {
                if (numberOfAliveNeighbors < 2)
                {
                    return false;
                }

                if (numberOfAliveNeighbors >= 2 && numberOfAliveNeighbors <= 3)
                {
                    return true;
                }

                if (numberOfAliveNeighbors > 3)
                {
                    return false;
                }
            }
            else
            {
                if (numberOfAliveNeighbors == 3)
                {
                    return true;
                }
            }

            return false;
        }

        private int GetNumberOfNeighborsForGivenCellAt(int row, int column, bool aliveStatus)
        {
            var numberOfNeighbors = 0;

            Cell currentCell;

            // Check South - West
            if (row > 0 && column > 0)
            {
                currentCell = Cells[row - 1, column - 1];
                if (currentCell.Alive == aliveStatus)
                {
                    numberOfNeighbors++;
                }
            }

            // Check South
            if (row > 0)
            {
                currentCell = Cells[row - 1, column];
                if (currentCell.Alive == aliveStatus)
                {
                    numberOfNeighbors++;
                }
            }

            // Check South - East
            if (row > 0 && column < CellNumber - 1)
            {
                currentCell = Cells[row - 1, column + 1];
                if (currentCell.Alive == aliveStatus)
                {
                    numberOfNeighbors++;
                }
            }

            // Check West
            if (column > 0)
            {
                currentCell = Cells[row, column - 1];
                if (currentCell.Alive == aliveStatus)
                {
                    numberOfNeighbors++;
                }
            }

            // Check East
            if (column < CellNumber - 1)
            {
                currentCell = Cells[row, column + 1];
                if (currentCell.Alive == aliveStatus)
                {
                    numberOfNeighbors++;
                }
            }

            // Check North - West
            if (row < CellNumber - 1 && column > 0)
            {
                currentCell = Cells[row + 1, column - 1];
                if (currentCell.Alive == aliveStatus)
                {
                    numberOfNeighbors++;
                }
            }

            // Check North
            if (row < CellNumber - 1)
            {
                currentCell = Cells[row + 1, column];
                if (currentCell.Alive == aliveStatus)
                {
                    numberOfNeighbors++;
                }
            }

            // Check North - East
            if (row < CellNumber - 1 && column < CellNumber - 1)
            {
                currentCell = Cells[row + 1, column + 1];
                if (currentCell.Alive == aliveStatus)
                {
                    numberOfNeighbors++;
                }
            }

            return numberOfNeighbors;
        }
    }
}
