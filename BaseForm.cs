using System;
using System.Drawing;
using System.Windows.Forms;

namespace LangontsAntSimulator
{
  public partial class BaseForm : Form
  {
  #region  Public Constructors  

    public BaseForm()
    {
      InitializeComponent();
    }

  #endregion  Public Constructors  

  #region  Protected Overridden Methods  

    protected override void OnLoad(EventArgs e)
    {
      if (!this.DesignMode)
        this.Font = SystemFonts.DialogFont;

      base.OnLoad(e);
    }

  #endregion  Protected Overridden Methods  
  }
}
