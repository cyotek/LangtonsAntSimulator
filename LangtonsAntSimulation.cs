using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace LangontsAntSimulator
{
  class LangtonsAntSimulation : ISimulation, IDisposable
  {
    #region  Private Member Declarations

    private List<IActor> _actors;
    private List<IBlock> _blocks;
    private ISimulationHost _host;
    private bool _isPaused;
    private bool _isRunning;
    private int _move;
    private Rectangle _region;
    private bool _showOutput;
    private int _speed;
    private Timer _timer;

    #endregion  Private Member Declarations

    #region  Public Constructors

    public LangtonsAntSimulation()
    {
      this.ShowOutput = true;
      this.Speed = 25;
      this.Blocks = new IBlock[] { };
      this.Actors = new IActor[] { };
    }

    public LangtonsAntSimulation(ISimulationHost host)
      : this()
    {
      this.Host = host;
    }

    #endregion  Public Constructors

    #region  Public Properties

    public IActor[] Actors
    {
      get { return _actors.ToArray(); }
      set { _actors = new List<IActor>(value); }
    }

    public int Move
    {
      get { return _move; }
      set { _move = value; }
    }

    public bool ShowOutput
    {
      get { return _showOutput; }
      set { _showOutput = value; }
    }

    public int Speed
    {
      get { return _speed; }
      set
      {
        _speed = value;

        if (_timer != null)
          _timer.Interval = value;
      }
    }

    #endregion  Public Properties

    #region  Protected Methods

    protected virtual void OnNextMove()
    {
      if (_host != null)
        _host.OnNextMove();
    }

    protected virtual void OnPause()
    {
      if (_host != null)
        _host.OnPause();
    }

    protected virtual void OnResume()
    {
      if (_host != null)
        _host.OnResume();
    }

    protected virtual void OnStart()
    {
      if (_host != null)
        _host.OnStart();
    }

    protected virtual void OnStop()
    {
      if (_host != null)
        _host.OnStop();
    }

    #endregion  Protected Methods


    #region ISimulator Members

    public ISimulationHost Host
    {
      get { return _host; }
      set { _host = value; }
    }

    public void Start()
    {
      if (!_isPaused)
      {
        this.Stop();

        _timer = new Timer();
        _timer.Tick += TimerTickHandler;
        _timer.Interval = this.Speed;

        _isRunning = true;

        if (!_actors.Any())
          this.Actors = new IActor[] { new Ant() { Location = Point.Empty, Facing = Direction.North } };

        if (!_blocks.Any())
        {
          this.Region = new Rectangle(0, 0, 1, 1);
          this.Blocks = new IBlock[] { };
        }

        _timer.Start();

        this.OnStart();
      }
      else
      {
        _isPaused = false;
        _timer.Start();

        this.OnResume();
      }
    }

    protected virtual void TimerTickHandler(object sender, EventArgs e)
    {
      this.NextMove();
    }

    public void Stop()
    {
      if (_timer != null)
      {
        _timer.Tick -= TimerTickHandler;
        _timer.Dispose();
        _timer = null;
      }

      if (_isRunning)
      {
        _isRunning = false;
        _isPaused = false;

        this.OnStop();
      }
    }

    public void Pause()
    {
      if (!_isPaused)
      {
        _isPaused = true;

        if (_timer != null)
          _timer.Stop();

        this.OnPause();
      }
    }

    public Direction GetNextFacing(IBlock block, Direction currentFacing)
    {
      Direction result;

      if (block.IsTagged) // Tagged is black
        result = this.GetLeftTurn(currentFacing);
      else
        result = this.GetRightTurn(currentFacing);

      return result;
    }

    public void NextMove()
    {
      // increment the move count
      _move++;

      // move all the actors
      foreach (IActor actor in _actors)
      {
        IBlock currentBlock;
        IBlock newBlock;

        // get the block where our ant is located
        currentBlock = this.GetBlock(actor.Location);

        // change direction
        actor.Facing = this.GetNextFacing(currentBlock, actor.Facing);

        // reverse the current block
        currentBlock.IsTagged = !currentBlock.IsTagged;

        // move the ant
        actor.Location = this.GetNewLocation(actor.Location, actor.Facing);
        newBlock = this.GetBlock(actor.Location); // make sure we create a new block for the location if need be

        // resize the simulation if need be
        if (!this.Region.Contains(actor.Location))
        {
          int x;
          int y;
          int w;
          int h;

          x = _blocks.Min(b => b.Location.X);
          y = _blocks.Min(b => b.Location.Y);
          w = Math.Abs(x) + Math.Abs(_blocks.Max(b => b.Location.X)) + 1;
          h = Math.Abs(y) + Math.Abs(_blocks.Max(b => b.Location.Y)) + 1;

          this.Region = new Rectangle(x, y, w, h);
        }
      }

      // notify the host we did something
      this.OnNextMove();
    }

    protected virtual Direction GetLeftTurn(Direction currentDirection)
    {
      Direction result;

      switch (currentDirection)
      {
        case Direction.North:
          result = Direction.West;
          break;
        case Direction.East:
          result = Direction.North;
          break;
        case Direction.South:
          result = Direction.East;
          break;
        case Direction.West:
          result = Direction.South;
          break;
        default:
          throw new ArgumentException("currentDirection");
      }

      return result;
    }

    protected virtual Direction GetRightTurn(Direction currentDirection)
    {
      Direction result;

      switch (currentDirection)
      {
        case Direction.North:
          result = Direction.East;
          break;
        case Direction.East:
          result = Direction.South;
          break;
        case Direction.South:
          result = Direction.West;
          break;
        case Direction.West:
          result = Direction.North;
          break;
        default:
          throw new ArgumentException("currentDirection");
      }

      return result;
    }

    protected virtual Point GetNewLocation(Point point, Direction direction)
    {
      Point newLocation;

      switch (direction)
      {
        case Direction.North:
          newLocation = new Point(point.X, point.Y - 1);
          break;
        case Direction.East:
          newLocation = new Point(point.X + 1, point.Y);
          break;
        case Direction.South:
          newLocation = new Point(point.X, point.Y + 1);
          break;
        case Direction.West:
          newLocation = new Point(point.X - 1, point.Y);
          break;
        default:
          throw new ArgumentException("direction");
      }

      return newLocation;
    }

    protected virtual IBlock GetBlock(Point location)
    {
      IBlock result;

      result = _blocks.SingleOrDefault(b => b.Location == location);
      if (result == null)
      {
        result = new Block() { Location = location };
        _blocks.Add(result);
      }

      return result;
    }

    public Rectangle Region
    {
      get { return _region; }
      set { _region = value; }
    }

    public bool IsPaused
    {
      get { return _isPaused; }
    }

    public bool IsRunning
    {
      get { return _isRunning; }
    }

    public IBlock[] Blocks
    {
      get { return _blocks.ToArray(); }
      set { _blocks = new List<IBlock>(value); }
    }

    public void Save(string dataFileName)
    {
      string workFileName;

      workFileName = Path.GetTempFileName();

      using (FileStream stream = File.Create(workFileName))
      {
        XmlWriterSettings settings;

        settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.Encoding = Encoding.UTF8;

        using (XmlWriter writer = XmlWriter.Create(stream, settings))
        {
          writer.WriteStartDocument(true);

          // save the simulation settings
          writer.WriteStartElement("simulation");
          writer.WriteAttributeString("x", this.Region.X.ToString());
          writer.WriteAttributeString("y", this.Region.Y.ToString());
          writer.WriteAttributeString("w", this.Region.Width.ToString());
          writer.WriteAttributeString("h", this.Region.Height.ToString());
          writer.WriteAttributeString("delay", this.Speed.ToString());
          writer.WriteAttributeString("move", this.Move.ToString());

          // save the actors
          writer.WriteStartElement("actors");
          foreach (IActor actor in _actors)
          {
            writer.WriteStartElement("actor");
            writer.WriteAttributeString("x", actor.Location.X.ToString());
            writer.WriteAttributeString("y", actor.Location.Y.ToString());
            writer.WriteAttributeString("px", actor.PreviousLocation.X.ToString());
            writer.WriteAttributeString("py", actor.PreviousLocation.Y.ToString());
            writer.WriteAttributeString("facing", actor.Facing.ToString());
            writer.WriteEndElement();
          }
          writer.WriteEndElement();

          // save only the tagged blocks, waste of time saving the untagged ones
          writer.WriteStartElement("taggedBlocks");
          foreach (IBlock block in _blocks.Where(b => b.IsTagged))
          {
            writer.WriteStartElement("block");
            writer.WriteAttributeString("x", block.Location.X.ToString());
            writer.WriteAttributeString("y", block.Location.Y.ToString());
            writer.WriteEndElement();
          }
          writer.WriteEndElement();

          writer.WriteEndElement();

          writer.WriteEndDocument();
        }
      }

      File.Copy(workFileName, dataFileName, true);
      File.Delete(workFileName);
    }

    public void Load(string dataFileName)
    {
      XmlDocument document;
      XmlNode node;

      document = new XmlDocument();

      document.Load(dataFileName);

      // reset everything
      this.Stop();
      _blocks = new List<IBlock>();
      _actors = new List<IActor>();
      _move = 0;

      // load the simulation settings
      node = document.SelectSingleNode("//simulation");
      this.Region = new Rectangle(Convert.ToInt32(node.Attributes["x"].Value), Convert.ToInt32(node.Attributes["y"].Value), Convert.ToInt32(node.Attributes["w"].Value), Convert.ToInt32(node.Attributes["h"].Value));
      this.Speed = Convert.ToInt32(node.Attributes["delay"].Value);
      this.Move = Convert.ToInt32(node.Attributes["move"].Value);

      // load the actors
      foreach (XmlNode actorNode in document.SelectNodes("//simulation/actors/actor"))
      {
        IActor actor;

        actor = new Ant();
        actor.Location = new Point(Convert.ToInt32(actorNode.Attributes["x"].Value), Convert.ToInt32(actorNode.Attributes["y"].Value));
        actor.PreviousLocation = new Point(Convert.ToInt32(actorNode.Attributes["px"].Value), Convert.ToInt32(actorNode.Attributes["py"].Value));
        actor.Facing = (Direction)Enum.Parse(typeof(Direction), actorNode.Attributes["facing"].Value, true);

        _actors.Add(actor);
      }

      // load the tagged blocks
      foreach (XmlNode blockNode in document.SelectNodes("//simulation/taggedBlocks/block"))
      {
        IBlock block;

        block = new Block();
        block.Location = new Point(Convert.ToInt32(blockNode.Attributes["x"].Value), Convert.ToInt32(blockNode.Attributes["y"].Value));
        block.IsTagged = true;

        _blocks.Add(block);
      }

      this.Start();
      this.Pause();
    }

    #endregion

    #region IDisposable Members

    public void Dispose()
    {
      this.Stop();
    }

    #endregion
  }
}
