using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Celestial.Field;
using Core.Renderer;

namespace Core.Controller
{
    public class GravityController
    {
        public IField Field { get; private set; }
        public IRenderer Renderer { get; private set; }

        public void CreateField()
        {
            Field = new UniverseField();
        }

        public void CreateRenderer(IRenderer renderer)
        {
            Renderer = renderer;
        }
    }
}
