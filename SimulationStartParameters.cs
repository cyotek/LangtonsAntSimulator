
namespace LangontsAntSimulator
{
  public class SimulationStartParameters
  {
  #region  Public Constructors  

    public SimulationStartParameters()
    {
      this.Delay = 25;
      this.InitialActors = 1;
    }

  #endregion  Public Constructors  

  #region  Public Properties  

    public int Delay { get; set; }

    public int InitialActors { get; set; }

    public bool StartPaused { get; set; }

  #endregion  Public Properties  
  }
}
