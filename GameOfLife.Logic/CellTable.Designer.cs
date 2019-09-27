namespace GameOfLife.Logic
{
    partial class CellTable
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelCells = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelCells
            // 
            this.panelCells.Location = new System.Drawing.Point(0, 0);
            this.panelCells.Name = "panelCells";
            this.panelCells.Size = new System.Drawing.Size(1024, 1024);
            this.panelCells.TabIndex = 0;
            // 
            // CellTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCells);
            this.Name = "CellTable";
            this.Size = new System.Drawing.Size(1024, 1024);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCells;
    }
}
