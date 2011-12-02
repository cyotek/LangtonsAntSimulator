using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LangontsAntSimulator
{
  public partial class AddAntsDialog : BaseForm
  {
  #region  Private Member Declarations  

    private ISimulation _simulation;

  #endregion  Private Member Declarations  

  #region  Public Constructors  

    public AddAntsDialog()
    {
      InitializeComponent();
    }

    public AddAntsDialog(ISimulation simulation)
      : this()
    {
      _simulation = simulation;
    }

  #endregion  Public Constructors  

  #region  Event Handlers  

    private void cancelButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void okButton_Click(object sender, EventArgs e)
    {
      if (antsNumericUpDown.Value < 1 || antsNumericUpDown.Value > antsNumericUpDown.Maximum)
      {
        MessageBox.Show("Please enter a valid NUMBER.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        antsNumericUpDown.Focus();
        this.DialogResult = DialogResult.None;
      }
      else
      {
        List<IActor> actors;

        actors = new List<IActor>(_simulation.Actors);
        
        for (int i = 0; i < (int)antsNumericUpDown.Value; i++)
          actors.Add(new Ant());

        _simulation.Actors = actors.ToArray();

        this.DialogResult = DialogResult.OK;
      }
    }

  #endregion  Event Handlers  
  }
}
