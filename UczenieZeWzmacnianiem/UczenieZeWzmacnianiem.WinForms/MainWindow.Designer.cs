namespace UczenieZeWzmacnianiem.WinForms
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
            this.cbWorldSize = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCountOfExits = new System.Windows.Forms.ComboBox();
            this.cbMaxOfAgentsSteps = new System.Windows.Forms.ComboBox();
            this.cbCountOfTests = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnShowAgentsBehaviour = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.btnStart);
            this.groupBoxSettings.Controls.Add(this.btnShowAgentsBehaviour);
            this.groupBoxSettings.Controls.Add(this.cbCountOfTests);
            this.groupBoxSettings.Controls.Add(this.label4);
            this.groupBoxSettings.Controls.Add(this.cbMaxOfAgentsSteps);
            this.groupBoxSettings.Controls.Add(this.cbCountOfExits);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Maksymalna liczba kroków agenta:";
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
            // cbCountOfExits
            // 
            this.cbCountOfExits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountOfExits.FormattingEnabled = true;
            this.cbCountOfExits.Location = new System.Drawing.Point(6, 82);
            this.cbCountOfExits.Name = "cbCountOfExits";
            this.cbCountOfExits.Size = new System.Drawing.Size(173, 21);
            this.cbCountOfExits.TabIndex = 3;
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
            // cbCountOfTests
            // 
            this.cbCountOfTests.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountOfTests.FormattingEnabled = true;
            this.cbCountOfTests.Location = new System.Drawing.Point(6, 162);
            this.cbCountOfTests.Name = "cbCountOfTests";
            this.cbCountOfTests.Size = new System.Drawing.Size(173, 21);
            this.cbCountOfTests.TabIndex = 5;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 479);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(173, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnShowAgentsBehaviour
            // 
            this.btnShowAgentsBehaviour.Location = new System.Drawing.Point(6, 508);
            this.btnShowAgentsBehaviour.Name = "btnShowAgentsBehaviour";
            this.btnShowAgentsBehaviour.Size = new System.Drawing.Size(173, 23);
            this.btnShowAgentsBehaviour.TabIndex = 2;
            this.btnShowAgentsBehaviour.Text = "Pokaż zachowanie agenta";
            this.btnShowAgentsBehaviour.UseVisualStyleBackColor = true;
            this.btnShowAgentsBehaviour.Click += new System.EventHandler(this.btnShowAgentsBehaviour_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(250, 38);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(500, 500);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
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
        private System.Windows.Forms.ComboBox cbCountOfExits;
        private System.Windows.Forms.ComboBox cbCountOfTests;
        private System.Windows.Forms.ComboBox cbMaxOfAgentsSteps;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnShowAgentsBehaviour;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}

