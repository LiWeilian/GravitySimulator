using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Celestial.Field;
using SkiaSharp;

namespace Core.Renderer
{
    public class GravityRenderer : RendererSkiaSharp
    {
        public GravityRenderer(SKCanvas canvas) : base(canvas)
        {
        }

        public override void Render(IField field)
        {
            base.Render(field);

            DrawGrids(field);
            if (field.Bodies.Length == 0)
            {
                return;
            }
            foreach (var body in field.Bodies)
            {
                if (body.Mass > 1000)
                {
                    DrawTailBoid(body, _sunColor);
                } else
                {
                    DrawTailBoid(body, _planetColor);
                }
            }
        }

        private void DrawGrids(IField field)
        {
            if (field is IGridField && (field as IGridField).DrawGrids)
            {
                float size = (field as IGridField).GridSize;
                int rowCount = (int)(field.Height / size);
                int colCount = (int)(field.Width / size);

                for (int i = 1; i < rowCount; i++)
                {
                    DrawLine(new Point(0, i * size), new Point(field.Width, i * size), 1.0f, _gridColor);
                }

                for (int i = 1; i < colCount; i++)
                {

                    DrawLine(new Point(i * size, 0), new Point(i * size, field.Height), 1.0f, _gridColor);
                }
            }
            
        }
    }
}
