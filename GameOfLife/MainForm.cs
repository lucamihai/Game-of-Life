using System.IO;
using System.Windows.Forms;
using GameOfLife.Domain.Entities;
using GameOfLife.Logic;
using GameOfLife.Views;
using Newtonsoft.Json;

namespace GameOfLife
{
    public partial class MainForm : Form
    {
        private CellTable cellTable;

        public MainForm()
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
            const int minimumCellNumber = Constants.MinimumCellNumber;
            const int maximumCellNumber = Constants.MaximumCellNumber;
            labelCellNumber.Text = $"Cell number ({minimumCellNumber} - {maximumCellNumber})";
            numericUpDownCellNumber.Value = minimumCellNumber;
            numericUpDownCellNumber.Minimum = minimumCellNumber;
            numericUpDownCellNumber.Maximum = maximumCellNumber;
        }

        private void SetupNumericUpDownRefreshRate()
        {
            const int minimumRefreshRate = Constants.MinimumRefreshRateInMilliseconds;
            const int maximumRefreshRate = Constants.MaximumRefreshRateInMilliseconds;
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
            var jsonString = JsonConvert.SerializeObject(cellTable.Cells);

            var saveFileDialog = new SaveFileDialog
            {
                Title = "Browse json file",
                DefaultExt = "json",
                Filter = "json files (*json) | *.json"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(saveFileDialog.FileName))
                {
                    return;
                }

                var file = File.Create(saveFileDialog.FileName);
                file.Close();

                using (var streamWriter = new StreamWriter(saveFileDialog.FileName))
                {
                    streamWriter.Write(jsonString);
                }
            }
        }

        private void buttonLoadPattern_Click(object sender, System.EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Browse json file";
                openFileDialog.DefaultExt = "json";
                openFileDialog.Filter = "json files (*.json) | *.json";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileStream = openFileDialog.OpenFile();

                    using (var streamReader = new StreamReader(fileStream))
                    {
                        var jsonString = streamReader.ReadToEnd();
                        var result = JsonConvert.DeserializeObject<Cell[,]>(jsonString);

                        cellTable = new CellTable(result);

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
    }
}
