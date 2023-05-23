namespace AlgorithmsAndAI_FinalAssignment
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            WorldCanvas = new ImprovedPanel();
            checkBoxStats = new CheckBox();
            checkBoxGraph = new CheckBox();
            checkBoxForce = new CheckBox();
            checkBoxLocationDetails = new CheckBox();
            checkBoxBehaviour = new CheckBox();
            output_titleLabel = new Label();
            titleLabel = new Label();
            SettingsPanel = new Panel();
            simulationStatusText = new Label();
            simulationStatusTitle = new Label();
            SettingsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // WorldCanvas
            // 
            WorldCanvas.BackColor = SystemColors.Control;
            WorldCanvas.Location = new Point(1, 2);
            WorldCanvas.Margin = new Padding(2);
            WorldCanvas.Name = "WorldCanvas";
            WorldCanvas.Size = new Size(1700, 1050);
            WorldCanvas.TabIndex = 0;
            WorldCanvas.MouseClick += OnClick;
            // 
            // checkBoxStats
            // 
            checkBoxStats.AutoSize = true;
            checkBoxStats.BackColor = Color.Transparent;
            checkBoxStats.Location = new Point(7, 155);
            checkBoxStats.Margin = new Padding(2);
            checkBoxStats.Name = "checkBoxStats";
            checkBoxStats.Size = new Size(51, 19);
            checkBoxStats.TabIndex = 7;
            checkBoxStats.Text = "Stats";
            checkBoxStats.UseVisualStyleBackColor = false;
            checkBoxStats.CheckedChanged += Outputs_CheckedChanged;
            // 
            // checkBoxGraph
            // 
            checkBoxGraph.AutoSize = true;
            checkBoxGraph.BackColor = Color.Transparent;
            checkBoxGraph.Location = new Point(7, 134);
            checkBoxGraph.Margin = new Padding(2);
            checkBoxGraph.Name = "checkBoxGraph";
            checkBoxGraph.Size = new Size(58, 19);
            checkBoxGraph.TabIndex = 5;
            checkBoxGraph.Text = "Graph";
            checkBoxGraph.UseVisualStyleBackColor = false;
            checkBoxGraph.CheckedChanged += Outputs_CheckedChanged;
            // 
            // checkBoxForce
            // 
            checkBoxForce.AutoSize = true;
            checkBoxForce.BackColor = Color.Transparent;
            checkBoxForce.Location = new Point(7, 113);
            checkBoxForce.Margin = new Padding(2);
            checkBoxForce.Name = "checkBoxForce";
            checkBoxForce.Size = new Size(55, 19);
            checkBoxForce.TabIndex = 4;
            checkBoxForce.Text = "Force";
            checkBoxForce.UseVisualStyleBackColor = false;
            checkBoxForce.CheckedChanged += Outputs_CheckedChanged;
            // 
            // checkBoxLocationDetails
            // 
            checkBoxLocationDetails.AutoSize = true;
            checkBoxLocationDetails.BackColor = Color.Transparent;
            checkBoxLocationDetails.Location = new Point(7, 92);
            checkBoxLocationDetails.Margin = new Padding(2);
            checkBoxLocationDetails.Name = "checkBoxLocationDetails";
            checkBoxLocationDetails.Size = new Size(110, 19);
            checkBoxLocationDetails.TabIndex = 3;
            checkBoxLocationDetails.Text = "Location Details";
            checkBoxLocationDetails.UseVisualStyleBackColor = false;
            checkBoxLocationDetails.CheckedChanged += Outputs_CheckedChanged;
            // 
            // checkBoxBehaviour
            // 
            checkBoxBehaviour.AutoSize = true;
            checkBoxBehaviour.BackColor = SystemColors.Control;
            checkBoxBehaviour.ForeColor = SystemColors.ControlText;
            checkBoxBehaviour.Location = new Point(7, 71);
            checkBoxBehaviour.Margin = new Padding(2);
            checkBoxBehaviour.Name = "checkBoxBehaviour";
            checkBoxBehaviour.Size = new Size(79, 19);
            checkBoxBehaviour.TabIndex = 2;
            checkBoxBehaviour.Text = "Behaviour";
            checkBoxBehaviour.UseVisualStyleBackColor = false;
            checkBoxBehaviour.CheckedChanged += Outputs_CheckedChanged;
            // 
            // output_titleLabel
            // 
            output_titleLabel.AutoSize = true;
            output_titleLabel.BackColor = Color.Transparent;
            output_titleLabel.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            output_titleLabel.Location = new Point(62, 43);
            output_titleLabel.Margin = new Padding(2, 0, 2, 0);
            output_titleLabel.Name = "output_titleLabel";
            output_titleLabel.Size = new Size(59, 19);
            output_titleLabel.TabIndex = 1;
            output_titleLabel.Text = "Toggles";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Font = new Font("Calibri", 16F, FontStyle.Regular, GraphicsUnit.Point);
            titleLabel.Location = new Point(7, 13);
            titleLabel.Margin = new Padding(2, 0, 2, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(186, 27);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Simulation Options";
            // 
            // SettingsPanel
            // 
            SettingsPanel.Controls.Add(simulationStatusText);
            SettingsPanel.Controls.Add(simulationStatusTitle);
            SettingsPanel.Controls.Add(checkBoxStats);
            SettingsPanel.Controls.Add(titleLabel);
            SettingsPanel.Controls.Add(output_titleLabel);
            SettingsPanel.Controls.Add(checkBoxBehaviour);
            SettingsPanel.Controls.Add(checkBoxGraph);
            SettingsPanel.Controls.Add(checkBoxLocationDetails);
            SettingsPanel.Controls.Add(checkBoxForce);
            SettingsPanel.Location = new Point(1705, 2);
            SettingsPanel.Margin = new Padding(2);
            SettingsPanel.Name = "SettingsPanel";
            SettingsPanel.Size = new Size(200, 1038);
            SettingsPanel.TabIndex = 8;
            // 
            // simulationStatusText
            // 
            simulationStatusText.Location = new Point(7, 213);
            simulationStatusText.Margin = new Padding(2, 0, 2, 0);
            simulationStatusText.Name = "simulationStatusText";
            simulationStatusText.Size = new Size(169, 76);
            simulationStatusText.TabIndex = 9;
            // 
            // simulationStatusTitle
            // 
            simulationStatusTitle.AutoSize = true;
            simulationStatusTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            simulationStatusTitle.Location = new Point(7, 185);
            simulationStatusTitle.Margin = new Padding(2, 0, 2, 0);
            simulationStatusTitle.Name = "simulationStatusTitle";
            simulationStatusTitle.Size = new Size(69, 28);
            simulationStatusTitle.TabIndex = 8;
            simulationStatusTitle.Text = "Status:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(SettingsPanel);
            Controls.Add(WorldCanvas);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2);
            Name = "Form1";
            Text = "SpaceSimulation";
            Load += Form1_Load;
            SettingsPanel.ResumeLayout(false);
            SettingsPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ImprovedPanel WorldCanvas;
        private CheckBox checkBoxForce;
        private CheckBox checkBoxLocationDetails;
        private CheckBox checkBoxBehaviour;
        private Label output_titleLabel;
        private Label titleLabel;
        private CheckBox checkBoxGraph;
        private CheckBox checkBoxStats;
        private Panel SettingsPanel;
        private Label simulationStatusTitle;
        private Label simulationStatusText;
    }
}
