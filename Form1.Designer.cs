namespace Audivel
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
            this.components = new System.ComponentModel.Container();
            this.audioChannelLeveler = new System.ComponentModel.BackgroundWorker();
            this.primarySource = new System.Windows.Forms.ComboBox();
            this.secondarySource = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.changeDelayBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.reductionBox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.reductionTimeBox = new System.Windows.Forms.NumericUpDown();
            this.iAudioSessionControl2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iAudioSessionControl2BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.changeDelayBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reductionBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reductionTimeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iAudioSessionControl2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iAudioSessionControl2BindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // audioChannelLeveler
            // 
            this.audioChannelLeveler.DoWork += new System.ComponentModel.DoWorkEventHandler(this.audioChannelLeveler_DoWork);
            // 
            // primarySource
            // 
            this.primarySource.FormattingEnabled = true;
            this.primarySource.Location = new System.Drawing.Point(12, 25);
            this.primarySource.Name = "primarySource";
            this.primarySource.Size = new System.Drawing.Size(260, 21);
            this.primarySource.TabIndex = 0;
            this.primarySource.DropDown += new System.EventHandler(this.updateSessionList);
            this.primarySource.SelectedIndexChanged += new System.EventHandler(this.primarySource_SelectedIndexChanged);
            // 
            // secondarySource
            // 
            this.secondarySource.FormattingEnabled = true;
            this.secondarySource.Location = new System.Drawing.Point(12, 228);
            this.secondarySource.Name = "secondarySource";
            this.secondarySource.Size = new System.Drawing.Size(260, 21);
            this.secondarySource.TabIndex = 1;
            this.secondarySource.Visible = false;
            this.secondarySource.DropDown += new System.EventHandler(this.updateSessionList);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Audio Source";
            // 
            // changeDelayBox
            // 
            this.changeDelayBox.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.changeDelayBox.Location = new System.Drawing.Point(12, 69);
            this.changeDelayBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.changeDelayBox.Name = "changeDelayBox";
            this.changeDelayBox.Size = new System.Drawing.Size(96, 20);
            this.changeDelayBox.TabIndex = 3;
            this.changeDelayBox.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Change Delay (ms)";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(197, 74);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(197, 100);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 6;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Reduction %";
            // 
            // reductionBox
            // 
            this.reductionBox.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.reductionBox.Location = new System.Drawing.Point(114, 69);
            this.reductionBox.Name = "reductionBox";
            this.reductionBox.Size = new System.Drawing.Size(73, 20);
            this.reductionBox.TabIndex = 10;
            this.reductionBox.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Reduction Time (ms)";
            // 
            // reductionTimeBox
            // 
            this.reductionTimeBox.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.reductionTimeBox.Location = new System.Drawing.Point(12, 108);
            this.reductionTimeBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.reductionTimeBox.Name = "reductionTimeBox";
            this.reductionTimeBox.Size = new System.Drawing.Size(96, 20);
            this.reductionTimeBox.TabIndex = 12;
            this.reductionTimeBox.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // iAudioSessionControl2BindingSource
            // 
            this.iAudioSessionControl2BindingSource.DataSource = typeof(Audivel.IAudioSessionControl2);
            // 
            // iAudioSessionControl2BindingSource1
            // 
            this.iAudioSessionControl2BindingSource1.DataSource = typeof(Audivel.IAudioSessionControl2);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 137);
            this.Controls.Add(this.reductionTimeBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.reductionBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.changeDelayBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.secondarySource);
            this.Controls.Add(this.primarySource);
            this.Name = "MainWindow";
            this.Text = "Audivel";
            ((System.ComponentModel.ISupportInitialize)(this.changeDelayBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reductionBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reductionTimeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iAudioSessionControl2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iAudioSessionControl2BindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker audioChannelLeveler;
        private System.Windows.Forms.ComboBox primarySource;
        private System.Windows.Forms.ComboBox secondarySource;
        private System.Windows.Forms.BindingSource iAudioSessionControl2BindingSource;
        private System.Windows.Forms.BindingSource iAudioSessionControl2BindingSource1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown changeDelayBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown reductionBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown reductionTimeBox;
    }
}

