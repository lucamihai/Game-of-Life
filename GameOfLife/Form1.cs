using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Game_Of_Life;
using Newtonsoft.Json;


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

            numericUpDownCellNumber.Value = Game_Of_Life.Constants.MinimumCellNumber;
            numericUpDownCellNumber.Minimum = Game_Of_Life.Constants.MinimumCellNumber;
            numericUpDownCellNumber.Maximum = Game_Of_Life.Constants.MaximumCellNumber;

            numericUpDownRefreshRate.Value = Game_Of_Life.Constants.MinimumRefreshRateInMilliseconds;
            numericUpDownRefreshRate.Minimum = Game_Of_Life.Constants.MinimumRefreshRateInMilliseconds;
            numericUpDownRefreshRate.Maximum = Game_Of_Life.Constants.MaximumRefreshRateInMilliseconds;
        }

        private void buttonStartSimulation_Click(object sender, System.EventArgs e)
        {
            cellTable.StartSimulation();

            buttonInitializeSimulation.Enabled = false;
            buttonStartSimulation.Enabled = false;
            buttonEndSimulation.Enabled = true;
            buttonRandomizePattern.Enabled = false;
            buttonSetRefreshRate.Enabled = false;
        }

        private void buttonEndSimulation_Click(object sender, System.EventArgs e)
        {
            cellTable.EndSimulation();

            buttonInitializeSimulation.Enabled = true;
            buttonStartSimulation.Enabled = true;
            buttonEndSimulation.Enabled = false;
            buttonRandomizePattern.Enabled = true;
            buttonSetRefreshRate.Enabled = true;
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
            var json = cellTable.GetPatternJson();
        }

        private void buttonLoadPattern_Click(object sender, System.EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        var contents = reader.ReadToEnd();
                        var pattern = (bool[,])JsonConvert.DeserializeObject(contents);
                    }
                }
            }
        }
    }
}
