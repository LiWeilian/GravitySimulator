using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

using SkiaSharp.Views.Desktop;

using Core.Controller;
using Core.Renderer;

namespace Paracurve
{
    public partial class FormParacurve : Form
    {
        private ParacurveController _controller;
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        public FormParacurve()
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
            _controller.CreateRenderer(new ParacurveRender(e.Surface.Canvas));
            _controller.Renderer.Render(_controller.Field);
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            _controller = new ParacurveController();
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
                    _controller.EjuectTo(e.X, e.Y);
                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Right:
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
                case Keys.E:
                    _controller.Eject();
                    break;
                default:
                    break;
            }
        }
    }
}
