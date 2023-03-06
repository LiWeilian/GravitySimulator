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

        public void CreateField(float width, float height)
        {
            Field = new UniverseField(width, height);
        }

        public void CreateRenderer(IRenderer renderer)
        {
            Renderer = renderer;
        }

        public void SWitchGridDrawState()
        {
            (Field as IGridField).DrawGrids = !(Field as UniverseField).DrawGrids;
        }

        public void HasTail()
        {
            (Field as ITailField).DrawBodyTail = !((Field as ITailField).DrawBodyTail);
        }

        public void AddSun(float x, float y)
        {
            (Field as UniverseField).AddSun(x, y);
        }

        public void AddPlanet(float x, float y)
        {
            (Field as UniverseField).AddPlanet(x, y);
        }
    }
}
