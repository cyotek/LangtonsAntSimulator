using System.Linq;
using System.Windows.Forms;

namespace LangontsAntSimulator
{
  public partial class ActorViewer : UserControl
  {
  #region  Private Member Declarations  

    private IActor _actor;
    private ISimulation _simulation;

  #endregion  Private Member Declarations  

  #region  Public Constructors  

    public ActorViewer()
    {
      InitializeComponent();
    }

  #endregion  Public Constructors  

  #region  Public Methods  

    public void UpdateUi()
    {
      string location;
      string facing;
      string nextMove;

              location = string.Empty;
        facing = string.Empty;
        nextMove = string.Empty;

      if (this.Simulation != null && this.Actor != null)
      {
        LangtonsAntSimulation simulation;
        IBlock currentBlock;
        Direction nextFacing;

        location = string.Format("X:{0}, Y:{1}", this.Actor.Location.X, this.Actor.Location.Y);
        currentBlock = this.Simulation.Blocks.FirstOrDefault(b => b.Location == this.Actor.Location);

        if (currentBlock != null)
        {
          facing = string.Format("{0} ({1})", this.Actor.Facing.ToString(), currentBlock.IsTagged ? "Black" : "White");

          simulation = (LangtonsAntSimulation)this.Simulation;
          nextFacing = simulation.GetNextFacing(currentBlock, this.Actor.Facing);
          nextMove = nextFacing.ToString();
        }
      }

      locationTextBox.Text = location;
      facingTextBox.Text = facing;
      nextMoveTextBox.Text = nextMove;
    }

  #endregion  Public Methods  

  #region  Public Properties  

    public IActor Actor
    {
      get { return _actor; }
      set
      {
        _actor = value;
        this.UpdateUi();
      }
    }

    public ISimulation Simulation
    {
      get { return _simulation; }
      set
      {
        _simulation = value;
        this.UpdateUi();
      }
    }

  #endregion  Public Properties  
  }
}
