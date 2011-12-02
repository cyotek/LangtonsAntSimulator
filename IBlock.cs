using System.Drawing;

namespace LangontsAntSimulator
{
  public interface IBlock
  {
    Point Location { get; set; }
    bool IsTagged { get; set; }
  }
}
