using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Celestial.Field;
using Core.Renderer;

namespace Core.Controller
{
    public class ParacurveController
    {
        public IField Field { get; private set; }
        public IRenderer Renderer { get; private set; }

        public void CreateField(float width, float height)
        {
            Field = new ParacurveField(width, height);
        }

        public void CreateRenderer(IRenderer renderer)
        {
            Renderer = renderer;
        }

        public void SWitchGridDrawState()
        {
            (Field as IGridField).DrawGrids = !(Field as IGridField).DrawGrids;
        }

        public void HasTail()
        {
            (Field as ITailField).DrawBodyTail = !((Field as ITailField).DrawBodyTail);
        }

        public void Eject()
        {
            (Field as ParacurveField).EjectObject();
        }

        public void EjuectTo(float x, float y)
        {
            (Field as ParacurveField).EjectObjectTo(x, y);
        }
    }
}
