using System;
using System.Windows.Forms;

namespace LangontsAntSimulator
{
  public partial class ColorsDialog : BaseForm
  {
  #region  Public Constructors  

    public ColorsDialog()
    {
      InitializeComponent();
    }

    public ColorsDialog(ColorParameters parameters)
      : this()
    {
      taggedBlockLabel.BackColor = parameters.TaggedBlockColor;
      untaggedBlockLabel.BackColor = parameters.UntaggedBlockColor;
      actorLabel.BackColor = parameters.ActorColor;
    }

  #endregion  Public Constructors  

  #region  Event Handlers  

    private void actorButton_Click(object sender, EventArgs e)
    {
      this.ChooseColor(actorLabel);
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void okButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
    }

    private void taggedBlockButton_Click(object sender, EventArgs e)
    {
      this.ChooseColor(taggedBlockLabel);
    }

    private void untaggedBlockButton_Click(object sender, EventArgs e)
    {
      this.ChooseColor(untaggedBlockLabel);
    }

  #endregion  Event Handlers  

  #region  Public Methods  

    public ColorParameters GetColorParameters()
    {
      return new ColorParameters()
      {
        ActorColor = actorLabel.BackColor,
        UntaggedBlockColor = untaggedBlockLabel.BackColor,
        TaggedBlockColor = taggedBlockLabel.BackColor
      };
    }

  #endregion  Public Methods  

  #region  Private Methods  

    private void ChooseColor(Label preview)
    {
      colorDialog.Color = preview.BackColor;
      if (colorDialog.ShowDialog(this) == DialogResult.OK)
        preview.BackColor = colorDialog.Color;
    }

  #endregion  Private Methods  
  }
}
