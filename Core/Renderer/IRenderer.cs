using System;
using Core.Celestial;
using Core.Celestial.Field;
using Core.Celestial.Body;

namespace Core.Renderer
{
    public interface IRenderer : IDisposable
    {
        void Render(IField field);
    }
}
