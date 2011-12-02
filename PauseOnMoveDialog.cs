using System;
using System.Windows.Forms;

namespace LangontsAntSimulator
{
  public partial class PauseOnMoveDialog : BaseForm
  {
    #region  Public Constructors

    public PauseOnMoveDialog()
    {
      InitializeComponent();
    }

    #endregion  Public Constructors

    #region  Event Handlers

    private void cancelButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void okButton_Click(object sender, EventArgs e)
    {
      if (moveNumericUpDown.Value < 1 || moveNumericUpDown.Value > moveNumericUpDown.Maximum)
      {
        MessageBox.Show("Please enter a valid number.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        moveNumericUpDown.Focus();
        this.DialogResult = DialogResult.None;
      }
      else
      {
        this.DialogResult = DialogResult.OK;
      }
    }

    private void PauseOnMoveDialog_Load(object sender, EventArgs e)
    {
      moveNumericUpDown.Maximum = int.MaxValue;
    }

    #endregion  Event Handlers

    #region  Public Properties

    public int MoveNumber
    {
      get { return (int)moveNumericUpDown.Value; }
      set
      {
        if (value >= moveNumericUpDown.Minimum && value <= moveNumericUpDown.Maximum)
          moveNumericUpDown.Value = value;
      }
    }

    #endregion  Public Properties
  }
}
