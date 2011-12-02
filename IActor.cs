using System.Drawing;

namespace LangontsAntSimulator
{
  public interface IActor
  {
    Point Location { get; set; }
    Point PreviousLocation { get; set; }
    Direction Facing { get; set; }
  }
}
