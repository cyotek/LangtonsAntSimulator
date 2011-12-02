using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LangontsAntSimulator
{

  // http://blog.csharphelper.com/2011/02/26/contest-langtons-ant-simulation.aspx

  public partial class MainForm : BaseForm, ISimulationHost
  {
    #region  Private Member Declarations

    private int _pauseOnMoveNumber;
    private ISimulation _simulation;
    private string _simulationFileName;
    private readonly string _textPattern = "{2} - {0} [{1}]";

    #endregion  Private Member Declarations

    #region  Public Constructors

    public MainForm()
    {
      InitializeComponent();
    }

    #endregion  Public Constructors

    #region  Protected Overridden Methods

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        this.ClearSimulation();

        if (components != null)
          components.Dispose();
      }
      base.Dispose(disposing);
    }

    private void ClearSimulation()
    {
      if (_simulation != null)
        _simulation.Stop(); // Clean up
    }

    #endregion  Protected Overridden Methods

    #region  Event Handlers

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (AboutDialog dialog = new AboutDialog())
        dialog.ShowDialog(this);
    }

    private void actorsComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (actorsComboBox.SelectedIndex >= 0 && actorsComboBox.SelectedIndex < actorsComboBox.Items.Count)
        actorViewer.Actor = _simulation.Actors[actorsComboBox.SelectedIndex];
      else
        actorViewer.Actor = null;
    }

    private void addAntToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (AddAntsDialog dialog = new AddAntsDialog(_simulation))
      {
        if (dialog.ShowDialog(this) == DialogResult.OK)
          this.InitializeActorsPane();
      }
    }

    private void blackAndWhiteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.SetColors(new ColorParameters()
      {
        ActorColor = Color.Red,
        TaggedBlockColor = Color.Black,
        UntaggedBlockColor = Color.White
      });
    }

    private void coloursToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (ColorsDialog dialog = new ColorsDialog(new ColorParameters()
      {
        ActorColor = simulationPanel.ActorColor,
        TaggedBlockColor = simulationPanel.TaggedColor,
        UntaggedBlockColor = simulationPanel.UntaggedColor
      }))
      {
        if (dialog.ShowDialog(this) == DialogResult.OK)
          this.SetColors(dialog.GetColorParameters());
      }
    }

    private void delayToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (DelayDialog dialog = new DelayDialog(_simulation))
        dialog.ShowDialog(this);
    }

    private void drawOutputToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _simulation.ShowOutput = !_simulation.ShowOutput;
      this.UpdateOutputIndicators();
    }

    private void earthyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.SetColors(new ColorParameters()
      {
        ActorColor = Color.Firebrick,
        TaggedBlockColor = Color.DarkKhaki,
        UntaggedBlockColor = Color.DarkOliveGreen
      });
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void exportImageToolStripMenuItem_Click(object sender, EventArgs e)
    {
      bool isPausedRequired;

      isPausedRequired = !_simulation.IsPaused;
      if (isPausedRequired)
        _simulation.Pause();

      if (saveImageFileDialog.ShowDialog(this) == DialogResult.OK)
      {
        try
        {
          this.SetStatus("Exporting image...");
          simulationPanel.SimulationOutput.Save(saveImageFileDialog.FileName, ImageFormat.Png);
          MessageBox.Show("Image export complete.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
          MessageBox.Show(string.Format("Failed to export image. {0}", ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        finally
        {
          this.SetStatus(string.Empty);
        }
      }

      if (isPausedRequired)
        _simulation.Start();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      this.Font = SystemFonts.DialogFont;
      this.InitializeSimulation(new SimulationStartParameters());
    }

    private void newToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (NewSimulationDialog dialog = new NewSimulationDialog())
      {
        if (dialog.ShowDialog(this) == DialogResult.OK)
          this.InitializeSimulation(dialog.GetStartParameters());
      }
    }

    private void nextMoveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _simulation.NextMove();
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.FileOpen(string.Empty);
    }

    private void pauseOnMoveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (PauseOnMoveDialog dialog = new PauseOnMoveDialog() { MoveNumber = _pauseOnMoveNumber })
      {
        if (dialog.ShowDialog(this) == DialogResult.OK)
          _pauseOnMoveNumber = dialog.MoveNumber;
      }
    }

    private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (_simulation.IsPaused)
        _simulation.Start();
      else
        _simulation.Pause();
    }

    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.FileSave(string.Empty);
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.FileSave(_simulationFileName);
    }

    private void startToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _simulation.Start();
    }

    private void stopToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _simulation.Stop();
    }

    #endregion  Event Handlers

    #region  Private Methods

    private void FileOpen(string fileName)
    {
      if (string.IsNullOrEmpty(fileName))
      {
        openSimulationFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

        if (openSimulationFileDialog.ShowDialog(this) == DialogResult.OK)
          fileName = openSimulationFileDialog.FileName;
      }

      if (!string.IsNullOrEmpty(fileName))
      {
        this.ClearSimulation();
        _simulation = new LangtonsAntSimulation(this);

        try
        {
          this.SetStatus("Loading simulation...");
          _simulation.Load(fileName);
          _simulationFileName = fileName;

          this.InitializeSimulation(_simulation);
        }
        catch (Exception ex)
        {
          MessageBox.Show(string.Format("Failed to open simulation. {0}", ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        finally
        {
          this.SetStatus(string.Empty);
        }
      }
    }

    private void FileSave(string fileName)
    {
      bool isPausedRequired;

      isPausedRequired = !_simulation.IsPaused;
      if (isPausedRequired)
        _simulation.Pause();

      if (string.IsNullOrEmpty(fileName))
      {
        saveSimulationFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
        saveSimulationFileDialog.FileName = _simulationFileName;

        if (saveSimulationFileDialog.ShowDialog(this) == DialogResult.OK)
          fileName = saveSimulationFileDialog.FileName;
      }

      if (!string.IsNullOrEmpty(fileName))
      {
        try
        {
          this.SetStatus("Saving simulation...");
          _simulation.Save(fileName);
          _simulationFileName = fileName;
        }
        catch (Exception ex)
        {
          MessageBox.Show(string.Format("Failed to save simulation. {0}", ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        finally
        {
          this.SetStatus(string.Empty);
        }
      }

      if (isPausedRequired)
        _simulation.Start();
    }

    private void InitializeActorsPane()
    {
      actorsComboBox.Items.Clear();
      for (int i = 0; i < _simulation.Actors.Count(); i++)
        actorsComboBox.Items.Add(string.Format("Ant {0}", i + 1));

      if (actorsComboBox.Items.Count != 0)
        actorsComboBox.SelectedIndex = 0;
    }

    private void InitializeSimulation(SimulationStartParameters simulationStartParameters)
    {
      List<IActor> actors;

      _simulationFileName = string.Empty;

      // destroy the old simulation or it will keep running with unintended consque
      this.ClearSimulation();

      _simulation = new LangtonsAntSimulation(this);
      _simulation.Speed = simulationStartParameters.Delay;

      actors = new List<IActor>();
      for (int i = 0; i < simulationStartParameters.InitialActors; i++)
        actors.Add(new Ant());
      _simulation.Actors = actors.ToArray();

      this.InitializeSimulation(_simulation);

      _simulation.Start();
      if (simulationStartParameters.StartPaused)
        _simulation.Pause();
    }

    private void InitializeSimulation(ISimulation _simulation)
    {
      simulationPanel.Simulation = _simulation;
      actorViewer.Simulation = _simulation;
      this.InitializeActorsPane();
      this.UpdateStatusPanel();
      this.UpdateText(_simulation.IsPaused ? "Paused" : "Running");
    }

    private void SetColors(ColorParameters colorParameters)
    {
      simulationPanel.ActorColor = colorParameters.ActorColor;
      simulationPanel.TaggedColor = colorParameters.TaggedBlockColor;
      simulationPanel.UntaggedColor = colorParameters.UntaggedBlockColor;

      simulationPanel.RedrawSimulation(); // need a full redraw if changing colors
      simulationPanel.Invalidate();
    }

    private void SetStatus(string text)
    {
      statusToolStripStatusLabel.Text = text;
      Application.DoEvents(); // force the status to appear
    }

    private void UpdateOutputIndicators()
    {
      drawOutputToolStripMenuItem.Checked = _simulation.ShowOutput;
      simulationPanel.Invalidate(); // force a repaint
    }

    private void UpdateStatusPanel()
    {
      // show the simulation status
      sizeToolStripStatusLabel.Text = string.Format("Arena: W:{0}, H:{1}", _simulation.Region.Width, _simulation.Region.Height);
      moveToolStripStatusLabel.Text = string.Format("Move: {0}", _simulation.Move);
    }

    private void UpdateText(string action)
    {
      this.Text = string.Format(_textPattern, Application.ProductName, action, string.IsNullOrEmpty(_simulationFileName) ? "Untitled" : Path.GetFileName(_simulationFileName));
    }

    private void UpdateUi()
    {
      // menu items
      startToolStripMenuItem.Enabled = !_simulation.IsRunning;
      stopToolStripMenuItem.Enabled = _simulation.IsRunning;
      pauseToolStripMenuItem.Enabled = _simulation.IsRunning;
      pauseToolStripMenuItem.Checked = _simulation.IsPaused;
      nextMoveToolStripMenuItem.Enabled = _simulation.IsPaused;

      // toolbar buttons
      startSimulationToolStripButton.Enabled = !_simulation.IsRunning;
      stopSimulationToolStripButton.Enabled = _simulation.IsRunning;
      pauseSimulationToolStripButton.Enabled = _simulation.IsRunning;
      pauseSimulationToolStripButton.Checked = _simulation.IsPaused;
      nextMoveToolStripButton.Enabled = _simulation.IsPaused;
    }

    #endregion  Private Methods



    #region ISimulationHost Members

    void ISimulationHost.OnStart()
    {
      this.UpdateText("Running");
      this.UpdateUi();
    }

    void ISimulationHost.OnStop()
    {
      this.UpdateText("Stopped");
      this.UpdateUi();
    }

    void ISimulationHost.OnPause()
    {
      this.UpdateText("Paused");
      this.UpdateUi();
    }

    void ISimulationHost.OnResume()
    {
      ((ISimulationHost)this).OnStart();
    }

    void ISimulationHost.OnNextMove()
    {
      //System.Diagnostics.Debug.WriteLine("{0} Move {1}", DateTime.Now, _simulation.Move);

      this.UpdateStatusPanel();

      if (_simulation.ShowOutput || _simulation.IsPaused)
      {
        // redraw changed squares
        simulationPanel.UpdateActors();

        // show new information on the selected actor
        actorViewer.UpdateUi();
      }

      // auto pause
      if (_pauseOnMoveNumber > 0 && _simulation.Move == _pauseOnMoveNumber)
      {
        _simulation.Pause();
        _simulation.ShowOutput = true;
        this.UpdateOutputIndicators();
        simulationPanel.RecreateCanvas();

        MessageBox.Show(string.Format("Automatically paused due to reaching move {0}", _pauseOnMoveNumber), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }

    #endregion
  }
}
