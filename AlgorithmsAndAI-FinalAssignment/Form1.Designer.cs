using System.Windows.Forms.VisualStyles;

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
            WorldCanvas = new Panel();
            checkBoxStats = new CheckBox();
            checkBoxEntitySimplified = new CheckBox();
            checkBoxGraph = new CheckBox();
            checkBoxForce = new CheckBox();
            checkBoxLocationDetails = new CheckBox();
            checkBoxBehaviour = new CheckBox();
            output_titleLabel = new Label();
            titleLabel = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // WorldCanvas
            // 
            WorldCanvas.BackColor = SystemColors.Control;
            WorldCanvas.Location = new Point(6, 3);
            WorldCanvas.Name = "WorldCanvas";
            WorldCanvas.Size = new Size(1400, 1200);
            WorldCanvas.TabIndex = 0;
            WorldCanvas.Visible = false;
            WorldCanvas.MouseClick += OnClick;
            // 
            // checkBoxStats
            // 
            checkBoxStats.AutoSize = true;
            checkBoxStats.BackColor = Color.Transparent;
            checkBoxStats.Location = new Point(10, 288);
            checkBoxStats.Name = "checkBoxStats";
            checkBoxStats.Size = new Size(132, 29);
            checkBoxStats.TabIndex = 7;
            checkBoxStats.Text = "Stats Visible";
            checkBoxStats.UseVisualStyleBackColor = false;
            checkBoxStats.CheckedChanged += Outputs_CheckedChanged;
            // 
            // checkBoxEntitySimplified
            // 
            checkBoxEntitySimplified.AutoSize = true;
            checkBoxEntitySimplified.BackColor = Color.Transparent;
            checkBoxEntitySimplified.Location = new Point(10, 253);
            checkBoxEntitySimplified.Name = "checkBoxEntitySimplified";
            checkBoxEntitySimplified.Size = new Size(210, 29);
            checkBoxEntitySimplified.TabIndex = 6;
            checkBoxEntitySimplified.Text = "Entity Look Simplified";
            checkBoxEntitySimplified.UseVisualStyleBackColor = false;
            checkBoxEntitySimplified.CheckedChanged += Outputs_CheckedChanged;
            // 
            // checkBoxGraph
            // 
            checkBoxGraph.AutoSize = true;
            checkBoxGraph.BackColor = Color.Transparent;
            checkBoxGraph.Location = new Point(10, 218);
            checkBoxGraph.Name = "checkBoxGraph";
            checkBoxGraph.Size = new Size(142, 29);
            checkBoxGraph.TabIndex = 5;
            checkBoxGraph.Text = "Graph Visible";
            checkBoxGraph.UseVisualStyleBackColor = false;
            checkBoxGraph.CheckedChanged += Outputs_CheckedChanged;
            // 
            // checkBoxForce
            // 
            checkBoxForce.AutoSize = true;
            checkBoxForce.BackColor = Color.Transparent;
            checkBoxForce.Location = new Point(10, 183);
            checkBoxForce.Name = "checkBoxForce";
            checkBoxForce.Size = new Size(141, 29);
            checkBoxForce.TabIndex = 4;
            checkBoxForce.Text = "Force Visibile";
            checkBoxForce.UseVisualStyleBackColor = false;
            checkBoxForce.CheckedChanged += Outputs_CheckedChanged;
            // 
            // checkBoxLocationDetails
            // 
            checkBoxLocationDetails.AutoSize = true;
            checkBoxLocationDetails.BackColor = Color.Transparent;
            checkBoxLocationDetails.Location = new Point(10, 154);
            checkBoxLocationDetails.Name = "checkBoxLocationDetails";
            checkBoxLocationDetails.Size = new Size(219, 29);
            checkBoxLocationDetails.TabIndex = 3;
            checkBoxLocationDetails.Text = "Location Details Visible";
            checkBoxLocationDetails.UseVisualStyleBackColor = false;
            checkBoxLocationDetails.CheckedChanged += Outputs_CheckedChanged;
            // 
            // checkBoxBehaviour
            // 
            checkBoxBehaviour.AutoSize = true;
            checkBoxBehaviour.BackColor = SystemColors.Control;
            checkBoxBehaviour.ForeColor = SystemColors.ControlText;
            checkBoxBehaviour.Location = new Point(10, 119);
            checkBoxBehaviour.Name = "checkBoxBehaviour";
            checkBoxBehaviour.Size = new Size(172, 29);
            checkBoxBehaviour.TabIndex = 2;
            checkBoxBehaviour.Text = "Behaviour Visible";
            checkBoxBehaviour.UseVisualStyleBackColor = false;
            checkBoxBehaviour.CheckedChanged += Outputs_CheckedChanged;
            // 
            // output_titleLabel
            // 
            output_titleLabel.AutoSize = true;
            output_titleLabel.BackColor = Color.Transparent;
            output_titleLabel.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            output_titleLabel.Location = new Point(89, 71);
            output_titleLabel.Name = "output_titleLabel";
            output_titleLabel.Size = new Size(93, 29);
            output_titleLabel.TabIndex = 1;
            output_titleLabel.Text = "Outputs";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Font = new Font("Calibri", 16F, FontStyle.Regular, GraphicsUnit.Point);
            titleLabel.Location = new Point(10, 21);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(266, 39);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Simulation Options";
            // 
            // panel1
            // 
            panel1.Controls.Add(checkBoxStats);
            panel1.Controls.Add(titleLabel);
            panel1.Controls.Add(output_titleLabel);
            panel1.Controls.Add(checkBoxEntitySimplified);
            panel1.Controls.Add(checkBoxBehaviour);
            panel1.Controls.Add(checkBoxGraph);
            panel1.Controls.Add(checkBoxLocationDetails);
            panel1.Controls.Add(checkBoxForce);
            panel1.Location = new Point(1412, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(276, 1200);
            panel1.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1695, 1209);
            Controls.Add(panel1);
            Controls.Add(WorldCanvas);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel WorldCanvas;
        private CheckBox checkBoxForce;
        private CheckBox checkBoxLocationDetails;
        private CheckBox checkBoxBehaviour;
        private Label output_titleLabel;
        private Label titleLabel;
        private CheckBox checkBoxGraph;
        private CheckBox checkBoxEntitySimplified;
        private CheckBox checkBoxStats;
        private Panel panel1;
    }
}
