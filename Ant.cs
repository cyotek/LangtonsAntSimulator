using System.Drawing;

namespace LangontsAntSimulator
{
  public class Ant : IActor
  {
  #region  Private Member Declarations  

    private Direction _facing;
    private Point _location;
    private Point _previousL;

  #endregion  Private Member Declarations  

  #region  Public Properties  

    public Direction Facing
    {
      get { return _facing; }
      set { _facing = value; }
    }

    public Point Location
    {
      get { return _location; }
      set
      {
        this.PreviousLocation = this.Location;
        _location = value;
      }
    }

    public Point PreviousLocation
    {
      get { return _previousL; }
      set { _previousL = value; }
    }

  #endregion  Public Properties  
  }
}
