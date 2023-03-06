using System;
using System.Windows.Forms;
using SkiaSharp.Views.Desktop;
using Core.Controller;
using Core.Celestial.Field;
using Core.Renderer;
using System.Windows.Threading;

namespace Main
{
    public partial class FormMain : Form
    {
        private GravityController _controller;
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        public FormMain()
        {
            InitializeComponent();
        }
        private void TimerTick(object sender, EventArgs e)
        {
            _controller.Field.Advance();
            ResultField.Invalidate();
        }

        private void SKElement_PaintSurface(object sender,
            SKPaintSurfaceEventArgs e)
        {
            _controller.CreateRenderer(new GravityRenderer(e.Surface.Canvas));
            _controller.Renderer.Render(_controller.Field);
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            _controller = new GravityController();
            _controller.CreateField(ResultField.Width, ResultField.Height);

            _timer.Interval = TimeSpan.FromMilliseconds(10);
            _timer.Tick += TimerTick;
            _timer.Start();
        }

        private void ResultField_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    //add one sun
                    _controller.AddSun(e.X, e.Y);
                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Right:
                    //add one planet
                    _controller.AddPlanet(e.X, e.Y);
                    break;
                case MouseButtons.Middle:
                    break;
                case MouseButtons.XButton1:
                    break;
                case MouseButtons.XButton2:
                    break;
                default:
                    break;
            }
        }

        private void ResultField_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.R:
                    _controller.CreateField(ResultField.Width, ResultField.Height);
                    break;
                case Keys.G:
                    _controller.SWitchGridDrawState();
                    break;
                case Keys.T:
                    _controller.HasTail();
                    break;
                default:
                    break;
            }
        }
    }
}
