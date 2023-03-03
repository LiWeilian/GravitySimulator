using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Celestial.Field;

namespace Core.Renderer
{
    public abstract class BaseRenderer : IRenderer
    {
        public virtual void Dispose()
        {
            //throw new NotImplementedException();
        }

        public virtual void Render(IField field)
        {
            //throw new NotImplementedException();
        }
    }
}
