using System.Drawing;

namespace LangontsAntSimulator
{
  public class Block : IBlock
  {
  #region  Public Properties  

    public bool IsTagged { get; set; }

    public Point Location { get; set; }

  #endregion  Public Properties  
  }
}
