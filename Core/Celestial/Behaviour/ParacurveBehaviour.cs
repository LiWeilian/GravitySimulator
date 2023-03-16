using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Celestial.Body;
using Core.Celestial.Field;

namespace Core.Celestial.Behaviour
{
    internal class ParacurveBehaviour : Behaviour
    {
        private const float G = 0.0098f * 1f;
        public ParacurveBehaviour(IField field) : base(field)
        {
        }

        public override void CalcVelocity(IBody curBody)
        {
            Position acc = new Position(0, G);
            curBody.Velocity += acc;
        }
    }
}
