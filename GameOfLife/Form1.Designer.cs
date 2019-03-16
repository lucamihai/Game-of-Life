namespace GameOfLife
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelCellTable = new System.Windows.Forms.Panel();
            this.buttonStartSimulation = new System.Windows.Forms.Button();
            this.buttonEndSimulation = new System.Windows.Forms.Button();
            this.buttonInitializeSimulation = new System.Windows.Forms.Button();
            this.numericUpDownCellNumber = new System.Windows.Forms.NumericUpDown();
            this.labelCellNumber = new System.Windows.Forms.Label();
            this.buttonRandomizePattern = new System.Windows.Forms.Button();
            this.numericUpDownRefreshRate = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSetRefreshRate = new System.Windows.Forms.Button();
            this.buttonSavePattern = new System.Windows.Forms.Button();
            this.buttonLoadPattern = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCellNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefreshRate)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCellTable
            // 
            this.panelCellTable.Location = new System.Drawing.Point(10, 10);
            this.panelCellTable.Name = "panelCellTable";
            this.panelCellTable.Size = new System.Drawing.Size(1024, 1024);
            this.panelCellTable.TabIndex = 0;
            // 
            // buttonStartSimulation
            // 
            this.buttonStartSimulation.Location = new System.Drawing.Point(1040, 357);
            this.buttonStartSimulation.Name = "buttonStartSimulation";
            this.buttonStartSimulation.Size = new System.Drawing.Size(93, 23);
            this.buttonStartSimulation.TabIndex = 1;
            this.buttonStartSimulation.Text = "Start simulation";
            this.buttonStartSimulation.UseVisualStyleBackColor = true;
            this.buttonStartSimulation.Click += new System.EventHandler(this.buttonStartSimulation_Click);
            // 
            // buttonEndSimulation
            // 
            this.buttonEndSimulation.Location = new System.Drawing.Point(1040, 386);
            this.buttonEndSimulation.Name = "buttonEndSimulation";
            this.buttonEndSimulation.Size = new System.Drawing.Size(93, 23);
            this.buttonEndSimulation.TabIndex = 2;
            this.buttonEndSimulation.Text = "End simulation";
            this.buttonEndSimulation.UseVisualStyleBackColor = true;
            this.buttonEndSimulation.Click += new System.EventHandler(this.buttonEndSimulation_Click);
            // 
            // buttonInitializeSimulation
            // 
            this.buttonInitializeSimulation.Location = new System.Drawing.Point(1056, 193);
            this.buttonInitializeSimulation.Name = "buttonInitializeSimulation";
            this.buttonInitializeSimulation.Size = new System.Drawing.Size(107, 23);
            this.buttonInitializeSimulation.TabIndex = 3;
            this.buttonInitializeSimulation.Text = "Initialize cell table";
            this.buttonInitializeSimulation.UseVisualStyleBackColor = true;
            this.buttonInitializeSimulation.Click += new System.EventHandler(this.buttonInitializeSimulation_Click);
            // 
            // numericUpDownCellNumber
            // 
            this.numericUpDownCellNumber.Location = new System.Drawing.Point(1112, 167);
            this.numericUpDownCellNumber.Name = "numericUpDownCellNumber";
            this.numericUpDownCellNumber.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownCellNumber.TabIndex = 4;
            // 
            // labelCellNumber
            // 
            this.labelCellNumber.AutoSize = true;
            this.labelCellNumber.Location = new System.Drawing.Point(1065, 151);
            this.labelCellNumber.Name = "labelCellNumber";
            this.labelCellNumber.Size = new System.Drawing.Size(98, 13);
            this.labelCellNumber.TabIndex = 5;
            this.labelCellNumber.Text = "Cell number (8 - 64)";
            // 
            // buttonRandomizePattern
            // 
            this.buttonRandomizePattern.Location = new System.Drawing.Point(1056, 222);
            this.buttonRandomizePattern.Name = "buttonRandomizePattern";
            this.buttonRandomizePattern.Size = new System.Drawing.Size(107, 23);
            this.buttonRandomizePattern.TabIndex = 6;
            this.buttonRandomizePattern.Text = "Randomize pattern";
            this.buttonRandomizePattern.UseVisualStyleBackColor = true;
            this.buttonRandomizePattern.Click += new System.EventHandler(this.buttonRandomizePattern_Click);
            // 
            // numericUpDownRefreshRate
            // 
            this.numericUpDownRefreshRate.Location = new System.Drawing.Point(1297, 167);
            this.numericUpDownRefreshRate.Name = "numericUpDownRefreshRate";
            this.numericUpDownRefreshRate.Size = new System.Drawing.Size(62, 20);
            this.numericUpDownRefreshRate.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1218, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Refresh rate (100 - 1000 ms)";
            // 
            // buttonSetRefreshRate
            // 
            this.buttonSetRefreshRate.Location = new System.Drawing.Point(1252, 193);
            this.buttonSetRefreshRate.Name = "buttonSetRefreshRate";
            this.buttonSetRefreshRate.Size = new System.Drawing.Size(107, 23);
            this.buttonSetRefreshRate.TabIndex = 9;
            this.buttonSetRefreshRate.Text = "Set refresh rate";
            this.buttonSetRefreshRate.UseVisualStyleBackColor = true;
            this.buttonSetRefreshRate.Click += new System.EventHandler(this.buttonSetRefreshRate_Click);
            // 
            // buttonSavePattern
            // 
            this.buttonSavePattern.Location = new System.Drawing.Point(1056, 74);
            this.buttonSavePattern.Name = "buttonSavePattern";
            this.buttonSavePattern.Size = new System.Drawing.Size(77, 23);
            this.buttonSavePattern.TabIndex = 10;
            this.buttonSavePattern.Text = "Save pattern";
            this.buttonSavePattern.UseVisualStyleBackColor = true;
            this.buttonSavePattern.Click += new System.EventHandler(this.buttonSavePattern_Click);
            // 
            // buttonLoadPattern
            // 
            this.buttonLoadPattern.Location = new System.Drawing.Point(1156, 74);
            this.buttonLoadPattern.Name = "buttonLoadPattern";
            this.buttonLoadPattern.Size = new System.Drawing.Size(77, 23);
            this.buttonLoadPattern.TabIndex = 11;
            this.buttonLoadPattern.Text = "Load pattern";
            this.buttonLoadPattern.UseVisualStyleBackColor = true;
            this.buttonLoadPattern.Click += new System.EventHandler(this.buttonLoadPattern_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.buttonLoadPattern);
            this.Controls.Add(this.buttonSavePattern);
            this.Controls.Add(this.buttonSetRefreshRate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownRefreshRate);
            this.Controls.Add(this.buttonRandomizePattern);
            this.Controls.Add(this.labelCellNumber);
            this.Controls.Add(this.numericUpDownCellNumber);
            this.Controls.Add(this.buttonInitializeSimulation);
            this.Controls.Add(this.buttonEndSimulation);
            this.Controls.Add(this.buttonStartSimulation);
            this.Controls.Add(this.panelCellTable);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCellNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefreshRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelCellTable;
        private System.Windows.Forms.Button buttonStartSimulation;
        private System.Windows.Forms.Button buttonEndSimulation;
        private System.Windows.Forms.Button buttonInitializeSimulation;
        private System.Windows.Forms.NumericUpDown numericUpDownCellNumber;
        private System.Windows.Forms.Label labelCellNumber;
        private System.Windows.Forms.Button buttonRandomizePattern;
        private System.Windows.Forms.NumericUpDown numericUpDownRefreshRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSetRefreshRate;
        private System.Windows.Forms.Button buttonSavePattern;
        private System.Windows.Forms.Button buttonLoadPattern;
    }
}

