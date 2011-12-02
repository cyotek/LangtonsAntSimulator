using System.Drawing;

namespace LangontsAntSimulator
{
  public interface ISimulation
  {
    void Start();
    void Stop();
    void Pause();
    void NextMove();
    Rectangle Region { get; set; }
    IBlock[] Blocks { get; set; }
    void Load(string fileName);
    void Save(string fileName);
    bool IsRunning { get;  }
    bool IsPaused { get; }
    ISimulationHost Host { get; set; }
    int Speed { get; set; }
    IActor[] Actors { get; set; }
    int Move { get; set; }
    bool ShowOutput { get; set; }
  }
}
