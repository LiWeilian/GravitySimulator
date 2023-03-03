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

            //DrawField();
            foreach (var body in field.Bodies)
            {
                DrawTailBoid(body, _boidColor);
            }
        }
    }
}
