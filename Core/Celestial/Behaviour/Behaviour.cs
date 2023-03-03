using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Celestial.Body;
using Core.Celestial.Field;

namespace Core.Celestial.Behaviour
{
    public abstract class Behaviour
    {
        public IBody[] Bodies { get { return Field.Bodies; } }
        public IField Field { get; private set; }

        protected Behaviour(IField field)
        {
            Field = field;
        }

        public abstract void CalcVelocity(IBody curBody);
    }
}
