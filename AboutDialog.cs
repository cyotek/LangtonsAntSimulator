using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace LangontsAntSimulator
{
  public partial class AboutDialog : BaseForm
  {
  #region  Public Constructors  

    public AboutDialog()
    {
      InitializeComponent();
    }

  #endregion  Public Constructors  

  #region  Protected Overridden Methods  

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      Assembly assembly;
      FileVersionInfo versionInfo;

      assembly = typeof(Program).Assembly;
      versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

      productNameLabel.Text = versionInfo.ProductName;
      productVersionLabel.Text = string.Format("Version {0}", versionInfo.FileVersion);
      copyrightLabel.Text = versionInfo.LegalCopyright;
      this.Text = string.Format(this.Text, versionInfo.ProductName);

      productNameLabel.Font = new Font(this.Font, FontStyle.Bold);
      productVersionLabel.Font = new Font(this.Font, FontStyle.Bold);
    }

  #endregion  Protected Overridden Methods  

  #region  Event Handlers  

    private void antLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      this.RunUrl("http://www.iconarchive.com/show/animal-icons-by-martin-berube/ant-icon.html");
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void cyotekLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      this.RunUrl("http://cyotek.com");
    }

    private void iconsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      this.RunUrl("http://p.yusukekamiyamane.com/");
    }

  #endregion  Event Handlers  

  #region  Private Methods  

    private void RunUrl(string url)
    {
      try
      {
        Process.Start(url);
      }
      catch (Exception)
      {
        MessageBox.Show(string.Format("Fail to start '{0}'", url), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

  #endregion  Private Methods  
  }
}
