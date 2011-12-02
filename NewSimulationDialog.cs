using System;
using System.Windows.Forms;

namespace LangontsAntSimulator
{
  public partial class NewSimulationDialog : BaseForm
  {
  #region  Private Member Declarations  

    private ISimulation _simulation;

  #endregion  Private Member Declarations  

  #region  Public Constructors  

    public NewSimulationDialog()
    {
      InitializeComponent();
    }

    public NewSimulationDialog(ISimulation simulation)
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
        MessageBox.Show("Please enter a valid number.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        antsNumericUpDown.Focus();
        this.DialogResult = DialogResult.None;
      }
      else if (delayNumericUpDown.Value < 1 || delayNumericUpDown.Value > int.MaxValue)
      {
        MessageBox.Show("Please enter a valid delay.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        delayNumericUpDown.Focus();
        this.DialogResult = DialogResult.None;
      }
      else
      {
        this.DialogResult = DialogResult.OK;
      }
    }

  #endregion  Event Handlers  

  #region  Public Methods  

    public SimulationStartParameters GetStartParameters()
    {
      return new SimulationStartParameters()
      {
        Delay = (int)delayNumericUpDown.Value,
        InitialActors = (int)antsNumericUpDown.Value,
        StartPaused = startPausedCheckbox.Checked
      };
    }

  #endregion  Public Methods  
  }
}
