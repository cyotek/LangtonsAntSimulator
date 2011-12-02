using System;
using System.Windows.Forms;

namespace LangontsAntSimulator
{
  public partial class DelayDialog : BaseForm
  {
  #region  Private Member Declarations  

    private ISimulation _simulation;

  #endregion  Private Member Declarations  

  #region  Public Constructors  

    public DelayDialog()
    {
      InitializeComponent();
    }

    public DelayDialog(ISimulation simulation)
      : this()
    {
      _simulation = simulation;
    }

  #endregion  Public Constructors  

  #region  Protected Overridden Methods  

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      if (_simulation != null)
        delayNumericUpDown.Value = _simulation.Speed;
    }

  #endregion  Protected Overridden Methods  

  #region  Event Handlers  

    private void cancelButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void okButton_Click(object sender, EventArgs e)
    {
      if (delayNumericUpDown.Value < 1 || delayNumericUpDown.Value > delayNumericUpDown.Maximum)
      {
        MessageBox.Show("Please enter a valid delay.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        delayNumericUpDown.Focus();
        this.DialogResult = DialogResult.None;
      }
      else
      {
        _simulation.Speed = (int)delayNumericUpDown.Value;
        this.DialogResult = DialogResult.OK;
      }
    }

  #endregion  Event Handlers  
  }
}
