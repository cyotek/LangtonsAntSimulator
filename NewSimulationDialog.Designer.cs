namespace LangontsAntSimulator
{
  partial class NewSimulationDialog
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
      this.label1 = new System.Windows.Forms.Label();
      this.antsNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.delayNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.startPausedCheckbox = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.antsNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.delayNumericUpDown)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(247, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Enter the starting parameters for the new simulation";
      // 
      // antsNumericUpDown
      // 
      this.antsNumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.antsNumericUpDown.Location = new System.Drawing.Point(12, 50);
      this.antsNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.antsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.antsNumericUpDown.Name = "antsNumericUpDown";
      this.antsNumericUpDown.Size = new System.Drawing.Size(120, 20);
      this.antsNumericUpDown.TabIndex = 2;
      this.antsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // okButton
      // 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.Location = new System.Drawing.Point(232, 221);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 6;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.okButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(313, 221);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 7;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(9, 34);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(108, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Number of initial &ants:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 82);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(37, 13);
      this.label3.TabIndex = 3;
      this.label3.Text = "&Delay:";
      // 
      // delayNumericUpDown
      // 
      this.delayNumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.delayNumericUpDown.Location = new System.Drawing.Point(15, 98);
      this.delayNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.delayNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.delayNumericUpDown.Name = "delayNumericUpDown";
      this.delayNumericUpDown.Size = new System.Drawing.Size(120, 20);
      this.delayNumericUpDown.TabIndex = 4;
      this.delayNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
      // 
      // startPausedCheckbox
      // 
      this.startPausedCheckbox.AutoSize = true;
      this.startPausedCheckbox.Location = new System.Drawing.Point(12, 134);
      this.startPausedCheckbox.Name = "startPausedCheckbox";
      this.startPausedCheckbox.Size = new System.Drawing.Size(86, 17);
      this.startPausedCheckbox.TabIndex = 5;
      this.startPausedCheckbox.Text = "Start &paused";
      this.startPausedCheckbox.UseVisualStyleBackColor = true;
      // 
      // NewSimulationDialog
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(400, 256);
      this.Controls.Add(this.startPausedCheckbox);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.delayNumericUpDown);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.antsNumericUpDown);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "NewSimulationDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "New Simulation";
      ((System.ComponentModel.ISupportInitialize)(this.antsNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.delayNumericUpDown)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown antsNumericUpDown;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.NumericUpDown delayNumericUpDown;
    private System.Windows.Forms.CheckBox startPausedCheckbox;
  }
}