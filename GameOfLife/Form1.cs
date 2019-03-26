using System;
using System.IO;
using System.Windows.Forms;
using Game_Of_Life;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        private CellTable cellTable;

        public Form1()
        {
            InitializeComponent();

            buttonStartSimulation.Enabled = false;
            buttonEndSimulation.Enabled = false;
            buttonRandomizePattern.Enabled = false;
            buttonSetRefreshRate.Enabled = false;
            buttonSavePattern.Enabled = false;

            SetupNumericUpDownCellNumber();
            SetupNumericUpDownRefreshRate();
        }

        private void SetupNumericUpDownCellNumber()
        {
            const int minimumCellNumber = Game_Of_Life.Constants.MinimumCellNumber;
            const int maximumCellNumber = Game_Of_Life.Constants.MaximumCellNumber;
            labelCellNumber.Text = $"Cell number ({minimumCellNumber} - {maximumCellNumber})";
            numericUpDownCellNumber.Value = minimumCellNumber;
            numericUpDownCellNumber.Minimum = minimumCellNumber;
            numericUpDownCellNumber.Maximum = maximumCellNumber;
        }

        private void SetupNumericUpDownRefreshRate()
        {
            const int minimumRefreshRate = Game_Of_Life.Constants.MinimumRefreshRateInMilliseconds;
            const int maximumRefreshRate = Game_Of_Life.Constants.MaximumRefreshRateInMilliseconds;
            labelRefreshRate.Text = $"Refresh rate in ms ({minimumRefreshRate} - {maximumRefreshRate})";
            numericUpDownRefreshRate.Value = minimumRefreshRate;
            numericUpDownRefreshRate.Minimum = minimumRefreshRate;
            numericUpDownRefreshRate.Maximum = maximumRefreshRate;
        }

        private void buttonStartSimulation_Click(object sender, System.EventArgs e)
        {
            cellTable.StartSimulation();

            buttonInitializeSimulation.Enabled = false;
            buttonStartSimulation.Enabled = false;
            buttonEndSimulation.Enabled = true;
            buttonRandomizePattern.Enabled = false;
            buttonSetRefreshRate.Enabled = false;
            buttonSavePattern.Enabled = false;
            buttonLoadPattern.Enabled = false;
        }

        private void buttonEndSimulation_Click(object sender, System.EventArgs e)
        {
            cellTable.EndSimulation();

            buttonInitializeSimulation.Enabled = true;
            buttonStartSimulation.Enabled = true;
            buttonEndSimulation.Enabled = false;
            buttonRandomizePattern.Enabled = true;
            buttonSetRefreshRate.Enabled = true;
            buttonSavePattern.Enabled = true;
            buttonLoadPattern.Enabled = true;
        }

        private void buttonInitializeSimulation_Click(object sender, System.EventArgs e)
        {
            var numberOfCells = (int)numericUpDownCellNumber.Value;
            if (cellTable != null && cellTable.CellNumber == numberOfCells)
            {
                cellTable.ResetCells();
                return;
            }

            cellTable = new CellTable(numberOfCells);

            panelCellTable.Controls.Clear();
            panelCellTable.Controls.Add(cellTable);

            buttonStartSimulation.Enabled = true;
            buttonRandomizePattern.Enabled = true;
            buttonSetRefreshRate.Enabled = true;
            buttonSavePattern.Enabled = true;
        }

        private void buttonRandomizePattern_Click(object sender, System.EventArgs e)
        {
            cellTable.RandomizePattern();
        }

        private void buttonSetRefreshRate_Click(object sender, System.EventArgs e)
        {
            var refreshRateInMilliseconds = (int) numericUpDownRefreshRate.Value;
            cellTable.RefreshRateInMilliseconds = refreshRateInMilliseconds;
        }

        private void buttonSavePattern_Click(object sender, System.EventArgs e)
        {
            //var patternCsv = cellTable.PatternCsv;
            //var saveFileDialog = new SaveFileDialog
            //{
            //    Title = "Browse csv file",
            //    DefaultExt = "csv",
            //    Filter = "csv files (*.csv) | *.csv"
            //};

            //if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    if (File.Exists(saveFileDialog.FileName))
            //    {
            //        return;
            //    }

            //    var file = File.Create(saveFileDialog.FileName);
            //    file.Close();

            //    using (var streamWriter = new StreamWriter(saveFileDialog.FileName))
            //    {
            //        streamWriter.Write(patternCsv);
            //    }
            //}
        }

        private void buttonLoadPattern_Click(object sender, System.EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Browse csv file";
                openFileDialog.DefaultExt = "csv";
                openFileDialog.Filter = "csv files (*.csv) | *.csv";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileStream = openFileDialog.OpenFile();

                    using (var streamReader = new StreamReader(fileStream))
                    {
                        var csvString = streamReader.ReadToEnd();
                        ValidatePatternCsvString(csvString);
                        var pattern = GetPatternFromCsvString(csvString);

                        cellTable = new CellTable(pattern);

                        panelCellTable.Controls.Clear();
                        panelCellTable.Controls.Add(cellTable);

                        buttonStartSimulation.Enabled = true;
                        buttonRandomizePattern.Enabled = true;
                        buttonSetRefreshRate.Enabled = true;
                        buttonSavePattern.Enabled = true;
                    }
                }
            }
        }

        private void ValidatePatternCsvString(string csvString)
        {
            var rows = csvString.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None
            );
            var cellNumber = rows.Length;

            foreach (var row in rows)
            {
                var columns = row.Split(Game_Of_Life.Constants.PatternCsvSeparator);
                if (columns.Length != cellNumber)
                {
                    throw new Exception("Csv string is not valid. Number of rows should be equal to the number of columns for each row.");
                }
            }
        }

        private int[,] GetPatternFromCsvString(string csvString)
        {
            var rows = csvString.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None
            );
            var cellNumber = rows.Length;

            var pattern = new int[cellNumber, cellNumber];

            for (int rowNumber = 0; rowNumber < cellNumber; rowNumber++)
            {
                var row = rows[rowNumber];
                var columns = row.Split(Game_Of_Life.Constants.PatternCsvSeparator);

                for (int columnNumber = 0; columnNumber < cellNumber; columnNumber++)
                {
                    pattern[rowNumber, columnNumber] = Convert.ToInt32(columns[columnNumber]);
                }
            }

            return pattern;
        }
    }
}
