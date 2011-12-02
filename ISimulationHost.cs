
namespace LangontsAntSimulator
{
  public interface ISimulationHost
  {
    void OnStart();
    void OnStop();
    void OnPause();
    void OnResume();
    void OnNextMove();
  }
}
