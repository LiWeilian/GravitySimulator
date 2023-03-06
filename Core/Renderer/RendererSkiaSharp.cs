using System;
using SkiaSharp;

using Core.Celestial;
using Core.Celestial.Field;
using Core.Celestial.Body;
using Core.Celestial.Behaviour;

namespace Core.Renderer
{
    public abstract class RendererSkiaSharp : BaseRenderer
    {
        protected const float bodyRadius = 4f;
        protected readonly Color _backgroundColor = new Color(0, 0, 50);
        protected readonly Color _wallColor = new Color(255, 255, 255);
        protected readonly Color _planetColor = new Color(250, 250, 227);
        protected readonly Color _sunColor = new Color(247, 175, 49);
        protected readonly Color _gridColor = new Color(255, 255, 0);
        protected readonly SKCanvas _canvas;
        protected readonly SKPaint _paint;

        public RendererSkiaSharp(SKCanvas canvas)
        {
            _canvas = canvas;
            _paint = new SKPaint
            {
                IsAntialias = true
            };
        }

        public override void Render(IField field)
        {
            Clear(_backgroundColor);
        }

        protected void Clear(Color color)
        {
            _canvas.Clear(ConvertColor(color));
        }

        public void Dispose()
        {
            _paint.Dispose();
        }

        //protected void DrawField()
        //{
        //    Point pt1 = new Point(0, 0);
        //    Point pt2 = new Point(0, BaseField.Height);
        //    Point pt3 = new Point(BaseField.Width, BaseField.Height);
        //    Point pt4 = new Point(BaseField.Width, 0);
        //    DrawLine(pt1, pt2, 2, _wallColor);
        //    DrawLine(pt2, pt3, 2, _wallColor);
        //    DrawLine(pt3, pt4, 2, _wallColor);
        //    DrawLine(pt4, pt1, 2, _wallColor);
        //}

        protected void DrawText(string text, float x, float y, Color color)
        {
            _paint.Color = ConvertColor(color);
            SKTextBlob textBlob = SKTextBlob.Create(text, new SKFont());
            _canvas.DrawText(textBlob, x, y, _paint);
        }

        protected void DrawLine(Point pt1, Point pt2, float lineWidth, Color color)
        {
            _paint.Color = ConvertColor(color);
            _canvas.DrawLine(ConvertPoint(pt1), ConvertPoint(pt2), _paint);
        }

        protected void FillCircle(Point center, float radius, Color color)
        {
            _paint.Color = ConvertColor(color);
            _canvas.DrawCircle(ConvertPoint(center), radius, _paint);
        }

        protected void DrawTriangle(Point center, float direction, float speed, float size, Color color)
        {
            _paint.Color = ConvertColor(color);
            Point p1 = new Point(center.X + size * Math.Cos(direction / 180 * Math.PI), center.Y + size * Math.Sin(direction / 180 * Math.PI));
            Point p2 = new Point(center.X - size * Math.Cos(direction / 180 * Math.PI), center.Y - size * Math.Sin(direction / 180 * Math.PI));
            //速率越大，头部越尖
            Point p3 = new Point(center.X - size * Math.Sin(direction / 180 * Math.PI) * 2 * speed, center.Y + size * Math.Cos(direction / 180 * Math.PI) * 2 * speed);
            DrawLine(p1, p2, size, color);
            DrawLine(p1, p3, size, color);
            DrawLine(p2, p3, size, color);
        }

        protected void DrawTailBody(IBody body, Color color)
        {
            for (var i = 0; i < body.Positions.Count; i++)
            {
                var frac = (i + 1f) / body.Positions.Count;
                var alpha = (byte)(255 * frac * .5);
                FillCircle(new Point(body.Positions[i].X, body.Positions[i].Y),
                    body.Size / 2.5f,
                    new Color(color.R, color.G, color.B, alpha));
            }

            FillCircle(new Point(body.Position.X, body.Position.Y), body.Size, color);
            //if (boidDispBySpeed)
            //{
            //    DrawTriangle(new Point(body.Position.X, body.Position.Y), body.Velocity.GetAngle(), body.Velocity.GetCurrentSpeed(), body.Size, color);
            //} else
            //{
            //    DrawTriangle(new Point(body.Position.X, body.Position.Y), body.Velocity.GetAngle(), 1.5f, body.Size, color);
            //}
        }

        protected void DrawBody(IBody body, Color color)
        {
            FillCircle(new Point(body.Position.X, body.Position.Y), body.Size, color);
        }

        protected SKColor ConvertColor(Color color)
        {
            return new SKColor(color.R, color.G, color.B, color.A);
        }

        protected SKPoint ConvertPoint(Point pt)
        {
            return new SKPoint((float)pt.X, (float)pt.Y);
        }
    }
}
