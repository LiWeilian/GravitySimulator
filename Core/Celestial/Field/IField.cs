using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Celestial.Body;

namespace Core.Celestial.Field
{
    public interface IField
    {
        float Width { get; }
        float Height { get; }
        IBody[] Bodies { get; }
        //void SetFieldSize(float width, float height);
        void Advance(float stepSize = 1);
    }
}
