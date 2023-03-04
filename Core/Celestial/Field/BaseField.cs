using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Celestial.Body;

namespace Core.Celestial.Field
{
    public class BaseField : IField
    {
        public float Width { get { return _width; } }
        public float Height { get { return _height; } }
        public virtual IBody[] Bodies { get; protected set; }
        public bool BoidDisplayBySpeed { get; protected set; } = true;

        protected float _width, _height;
        public BaseField(float width, float height)
        {
            this._width = width;
            this._height = height;
        }

        public virtual void Advance(float stepSize = 1)
        {
            Parallel.ForEach(Bodies, body => body.Move(stepSize));
            //foreach (var body in Bodies)
            //{
            //    body.Move(stepSize);
            //}
        }

        //public virtual void SetFieldSize(float width, float height)
        //{
        //    if (width <= 0 || height <= 0)
        //        throw new Exception(
        //            "Wrong size of field");
        //    (_width, _height) = (width, height);
        //}
    }
}
