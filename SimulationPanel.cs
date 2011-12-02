using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LangontsAntSimulator
{
  public partial class SimulationPanel : Panel
  {
  #region  Private Member Declarations  

    private Color _actorColor;
    private Bitmap _canvas;
    private Size _previousSimulationSize;
    private Point _scale;
    private ISimulation _simulation;
    private Color _taggedColor;
    private Color _untaggedColor;

  #endregion  Private Member Declarations  

  #region  Public Constructors  

    public SimulationPanel()
      : this(null)
    { }

    public SimulationPanel(IContainer container)
    {
      this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
      this.UpdateStyles();

      if (container != null)
        container.Add(this);

      this.InitializeComponent();

      this.TaggedColor = Color.Black;
      this.UntaggedColor = Color.White;
      this.ActorColor = Color.Red;
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
        if (components != null)
          components.Dispose();

        this.Cleanup();
      }
      base.Dispose(disposing);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      if (this.Simulation != null)
      {
        if (this.Simulation.ShowOutput || this.Simulation.IsPaused)
        {
          if (_canvas != null)
            e.Graphics.DrawImageUnscaled(_canvas, Point.Empty);
        }
        else
        {
          using (StringFormat format = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
          {
            e.Graphics.DrawString("Output disabled. Please renable output to view the simulation.", this.Font, SystemBrushes.WindowText, this.ClientRectangle, format);
          }
        }
      }
    }

    protected override void OnResize(EventArgs eventargs)
    {
      base.OnResize(eventargs);

      this.RecreateCanvas();
    }

  #endregion  Protected Overridden Methods  

  #region  Public Methods  

    public void RedrawSimulation()
    {
      using (Graphics g = Graphics.FromImage(_canvas))
      {
        // draw the blocks
        g.Clear(this.UntaggedColor);
        foreach (IBlock block in _simulation.Blocks.Where(b => b.IsTagged))
          this.DrawBlock(g, block);

        // draw the actors
        foreach (IActor actor in _simulation.Actors)
          this.DrawActor(g, actor);
      }
    }

    public void UpdateActors()
    {
      if (_previousSimulationSize != _simulation.Region.Size)
      {
        // simulation size has changed, need to recreate the whole tihng
        this.RecreateCanvas();
      }
      else
      {
        // just redraw the actors        
        using (Graphics g = Graphics.FromImage(_canvas))
        {
          foreach (IActor actor in _simulation.Actors)
          {
            IBlock previousPosition;
            IBlock position;

            previousPosition = _simulation.Blocks.SingleOrDefault(b => b.Location == actor.PreviousLocation);
            position = _simulation.Blocks.SingleOrDefault(b => b.Location == actor.Location);

            if (previousPosition != null)
              this.DrawBlock(g, previousPosition);

            if (position != null)
              this.DrawBlock(g, position);

            this.DrawActor(g, actor);
          }
        }
        this.Invalidate();
      }
    }

  #endregion  Public Methods  

  #region  Public Properties  

    [DefaultValue(typeof(Color), "Red")]
    public Color ActorColor
    {
      get { return _actorColor; }
      set { _actorColor = value; }
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ISimulation Simulation
    {
      get { return _simulation; }
      set
      {
        _simulation = value;
        this.RecreateCanvas();
        this.Invalidate();
      }
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Bitmap SimulationOutput
    { get { return _canvas; } }

    [DefaultValue(typeof(Color), "Black")]
    public Color TaggedColor
    {
      get { return _taggedColor; }
      set { _taggedColor = value; }
    }

    [DefaultValue(typeof(Color), "White")]
    public Color UntaggedColor
    {
      get { return _untaggedColor; }
      set { _untaggedColor = value; }
    }

  #endregion  Public Properties  

  #region  Private Methods  

    private void Cleanup()
    {
      if (_canvas != null)
        _canvas.Dispose();
    }

    private void DrawActor(Graphics g, IActor actor)
    {
      using (Brush brush = new SolidBrush(this.ActorColor))
        g.FillEllipse(brush, this.GetBlockRegion(actor.Location));
    }

    private void DrawBlock(Graphics g, IBlock block)
    {
      Color color;

      color = block.IsTagged ? this.TaggedColor : this.UntaggedColor;

      using (Brush brush = new SolidBrush(color))
        g.FillRectangle(brush, this.GetBlockRegion(block.Location));
    }

    private Rectangle GetBlockRegion(Point point)
    {
      int x;
      int y;

      // Maths is still not my strong point - hopefully this works

      x = point.X + Math.Abs(_simulation.Region.X);
      y = point.Y + Math.Abs(_simulation.Region.Y);

      return new Rectangle(x * _scale.X, y * _scale.Y, _scale.X, _scale.Y);
    }

    public void RecreateCanvas()
    {
      if (!this.DesignMode && _simulation != null)
      {
        int scaleX;
        int scaleY;

        // store the size for future compares
        _previousSimulationSize = _simulation.Region.Size;

        // get the new scale
        scaleX = _previousSimulationSize.Width > 0 && this.ClientSize.Width > 0 ? this.ClientSize.Width / _previousSimulationSize.Width : 1;
        if (scaleX < 1)
          scaleX = 1;

        scaleY = _previousSimulationSize.Height > 0 && this.ClientSize.Height > 0 ? this.ClientSize.Height / _previousSimulationSize.Height : 1;
        if (scaleY < 1)
          scaleY = 1;

        _scale = new Point(scaleX, scaleY);

        // create the bitmap that will be used for drawing
        this.Cleanup();
        _canvas = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);

        this.RedrawSimulation();
      }
    }

  #endregion  Private Methods  
  }
}
