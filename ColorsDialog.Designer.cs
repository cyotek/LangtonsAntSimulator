namespace LangontsAntSimulator
{
  partial class ColorsDialog
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
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.taggedBlockButton = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.taggedBlockLabel = new System.Windows.Forms.Label();
      this.untaggedBlockLabel = new System.Windows.Forms.Label();
      this.untaggedBlockButton = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.actorLabel = new System.Windows.Forms.Label();
      this.actorButton = new System.Windows.Forms.Button();
      this.label6 = new System.Windows.Forms.Label();
      this.colorDialog = new System.Windows.Forms.ColorDialog();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(223, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Choose the colors for displaying the simulation";
      // 
      // okButton
      // 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.Location = new System.Drawing.Point(167, 212);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 3;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.okButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(248, 212);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 4;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
      // 
      // taggedBlockButton
      // 
      this.taggedBlockButton.Location = new System.Drawing.Point(44, 48);
      this.taggedBlockButton.Name = "taggedBlockButton";
      this.taggedBlockButton.Size = new System.Drawing.Size(75, 23);
      this.taggedBlockButton.TabIndex = 6;
      this.taggedBlockButton.Text = "&Change...";
      this.taggedBlockButton.UseVisualStyleBackColor = true;
      this.taggedBlockButton.Click += new System.EventHandler(this.taggedBlockButton_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 32);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(77, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Tagged Block:";
      // 
      // taggedBlockLabel
      // 
      this.taggedBlockLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.taggedBlockLabel.Location = new System.Drawing.Point(15, 48);
      this.taggedBlockLabel.Name = "taggedBlockLabel";
      this.taggedBlockLabel.Size = new System.Drawing.Size(23, 23);
      this.taggedBlockLabel.TabIndex = 7;
      // 
      // untaggedBlockLabel
      // 
      this.untaggedBlockLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.untaggedBlockLabel.Location = new System.Drawing.Point(15, 99);
      this.untaggedBlockLabel.Name = "untaggedBlockLabel";
      this.untaggedBlockLabel.Size = new System.Drawing.Size(23, 23);
      this.untaggedBlockLabel.TabIndex = 10;
      // 
      // untaggedBlockButton
      // 
      this.untaggedBlockButton.Location = new System.Drawing.Point(44, 99);
      this.untaggedBlockButton.Name = "untaggedBlockButton";
      this.untaggedBlockButton.Size = new System.Drawing.Size(75, 23);
      this.untaggedBlockButton.TabIndex = 9;
      this.untaggedBlockButton.Text = "C&hange...";
      this.untaggedBlockButton.UseVisualStyleBackColor = true;
      this.untaggedBlockButton.Click += new System.EventHandler(this.untaggedBlockButton_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 83);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(87, 13);
      this.label4.TabIndex = 8;
      this.label4.Text = "Untagged Block:";
      // 
      // actorLabel
      // 
      this.actorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.actorLabel.Location = new System.Drawing.Point(15, 151);
      this.actorLabel.Name = "actorLabel";
      this.actorLabel.Size = new System.Drawing.Size(23, 23);
      this.actorLabel.TabIndex = 13;
      // 
      // actorButton
      // 
      this.actorButton.Location = new System.Drawing.Point(44, 151);
      this.actorButton.Name = "actorButton";
      this.actorButton.Size = new System.Drawing.Size(75, 23);
      this.actorButton.TabIndex = 12;
      this.actorButton.Text = "Ch&ange...";
      this.actorButton.UseVisualStyleBackColor = true;
      this.actorButton.Click += new System.EventHandler(this.actorButton_Click);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(12, 135);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(35, 13);
      this.label6.TabIndex = 11;
      this.label6.Text = "Actor:";
      // 
      // ColorsDialog
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(335, 247);
      this.Controls.Add(this.actorLabel);
      this.Controls.Add(this.actorButton);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.untaggedBlockLabel);
      this.Controls.Add(this.untaggedBlockButton);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.taggedBlockLabel);
      this.Controls.Add(this.taggedBlockButton);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ColorsDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Colors";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button taggedBlockButton;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label taggedBlockLabel;
    private System.Windows.Forms.Label untaggedBlockLabel;
    private System.Windows.Forms.Button untaggedBlockButton;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label actorLabel;
    private System.Windows.Forms.Button actorButton;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.ColorDialog colorDialog;
  }
}