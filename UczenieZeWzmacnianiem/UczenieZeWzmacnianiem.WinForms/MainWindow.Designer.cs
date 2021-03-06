﻿namespace UczenieZeWzmacnianiem.WinForms
{
    partial class MainWindow
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
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxSaveLastWorld = new System.Windows.Forms.CheckBox();
            this.tbNumberOfTests = new System.Windows.Forms.TextBox();
            this.cbNumberOfWalls = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnShowAgentsBehaviour = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMaxOfAgentsSteps = new System.Windows.Forms.ComboBox();
            this.cbNumberOfExits = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbWorldSize = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.progressBarSimulator = new System.Windows.Forms.ProgressBar();
            this.groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.progressBarSimulator);
            this.groupBoxSettings.Controls.Add(this.checkBoxSaveLastWorld);
            this.groupBoxSettings.Controls.Add(this.tbNumberOfTests);
            this.groupBoxSettings.Controls.Add(this.cbNumberOfWalls);
            this.groupBoxSettings.Controls.Add(this.label5);
            this.groupBoxSettings.Controls.Add(this.btnStart);
            this.groupBoxSettings.Controls.Add(this.btnShowAgentsBehaviour);
            this.groupBoxSettings.Controls.Add(this.label4);
            this.groupBoxSettings.Controls.Add(this.cbMaxOfAgentsSteps);
            this.groupBoxSettings.Controls.Add(this.cbNumberOfExits);
            this.groupBoxSettings.Controls.Add(this.label3);
            this.groupBoxSettings.Controls.Add(this.cbWorldSize);
            this.groupBoxSettings.Controls.Add(this.label1);
            this.groupBoxSettings.Controls.Add(this.label2);
            this.groupBoxSettings.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(191, 537);
            this.groupBoxSettings.TabIndex = 0;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Ustawienia";
            // 
            // checkBoxSaveLastWorld
            // 
            this.checkBoxSaveLastWorld.AutoSize = true;
            this.checkBoxSaveLastWorld.Enabled = false;
            this.checkBoxSaveLastWorld.Location = new System.Drawing.Point(6, 230);
            this.checkBoxSaveLastWorld.Name = "checkBoxSaveLastWorld";
            this.checkBoxSaveLastWorld.Size = new System.Drawing.Size(154, 17);
            this.checkBoxSaveLastWorld.TabIndex = 9;
            this.checkBoxSaveLastWorld.Text = "Zapamiętaj poprzedni świat";
            this.checkBoxSaveLastWorld.UseVisualStyleBackColor = true;
            // 
            // tbNumberOfTests
            // 
            this.tbNumberOfTests.Location = new System.Drawing.Point(6, 163);
            this.tbNumberOfTests.Name = "tbNumberOfTests";
            this.tbNumberOfTests.Size = new System.Drawing.Size(173, 20);
            this.tbNumberOfTests.TabIndex = 8;
            this.tbNumberOfTests.Text = "10";
            // 
            // cbNumberOfWalls
            // 
            this.cbNumberOfWalls.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNumberOfWalls.FormattingEnabled = true;
            this.cbNumberOfWalls.Location = new System.Drawing.Point(6, 202);
            this.cbNumberOfWalls.Name = "cbNumberOfWalls";
            this.cbNumberOfWalls.Size = new System.Drawing.Size(173, 21);
            this.cbNumberOfWalls.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Liczba ścian:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 450);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(173, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnShowAgentsBehaviour
            // 
            this.btnShowAgentsBehaviour.Enabled = false;
            this.btnShowAgentsBehaviour.Location = new System.Drawing.Point(6, 508);
            this.btnShowAgentsBehaviour.Name = "btnShowAgentsBehaviour";
            this.btnShowAgentsBehaviour.Size = new System.Drawing.Size(173, 23);
            this.btnShowAgentsBehaviour.TabIndex = 2;
            this.btnShowAgentsBehaviour.Text = "Pokaż zachowanie agenta";
            this.btnShowAgentsBehaviour.UseVisualStyleBackColor = true;
            this.btnShowAgentsBehaviour.Click += new System.EventHandler(this.btnShowAgentsBehaviour_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Liczba prób:";
            // 
            // cbMaxOfAgentsSteps
            // 
            this.cbMaxOfAgentsSteps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaxOfAgentsSteps.FormattingEnabled = true;
            this.cbMaxOfAgentsSteps.Location = new System.Drawing.Point(6, 122);
            this.cbMaxOfAgentsSteps.Name = "cbMaxOfAgentsSteps";
            this.cbMaxOfAgentsSteps.Size = new System.Drawing.Size(173, 21);
            this.cbMaxOfAgentsSteps.TabIndex = 4;
            // 
            // cbNumberOfExits
            // 
            this.cbNumberOfExits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNumberOfExits.FormattingEnabled = true;
            this.cbNumberOfExits.Location = new System.Drawing.Point(6, 82);
            this.cbNumberOfExits.Name = "cbNumberOfExits";
            this.cbNumberOfExits.Size = new System.Drawing.Size(173, 21);
            this.cbNumberOfExits.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Maksymalna liczba kroków agenta:";
            // 
            // cbWorldSize
            // 
            this.cbWorldSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWorldSize.FormattingEnabled = true;
            this.cbWorldSize.Location = new System.Drawing.Point(6, 42);
            this.cbWorldSize.Name = "cbWorldSize";
            this.cbWorldSize.Size = new System.Drawing.Size(173, 21);
            this.cbWorldSize.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Wielkość świata:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Liczba wyjść:";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(250, 38);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(500, 500);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // progressBarSimulator
            // 
            this.progressBarSimulator.Location = new System.Drawing.Point(6, 479);
            this.progressBarSimulator.Name = "progressBarSimulator";
            this.progressBarSimulator.Size = new System.Drawing.Size(173, 23);
            this.progressBarSimulator.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.groupBoxSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainWindow";
            this.Text = "Uczenie ze wzmacnianiem";
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.ComboBox cbWorldSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbNumberOfExits;
        private System.Windows.Forms.ComboBox cbMaxOfAgentsSteps;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnShowAgentsBehaviour;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ComboBox cbNumberOfWalls;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbNumberOfTests;
        private System.Windows.Forms.CheckBox checkBoxSaveLastWorld;
        private System.Windows.Forms.ProgressBar progressBarSimulator;
    }
}

