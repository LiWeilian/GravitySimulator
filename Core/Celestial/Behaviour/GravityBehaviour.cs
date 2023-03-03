using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Celestial.Body;
using Core.Celestial.Field;

namespace Core.Celestial.Behaviour
{
    public class GravityBehaviour : Behaviour
    {
        private const float G = 0.000067f;
        public GravityBehaviour(IField field) : base(field)
        {
        }

        public override void CalcVelocity(IBody curBody)
        {
            Velocity retVel = new Velocity();
            foreach (var body in Field.Bodies)
            {
                float distance = curBody.Position.Distance(body.Position);
                if (distance > 0)
                {
                    float weight = (float)(G * body.Mass / Math.Pow(distance, 2.0)); //weight / curBody.Mass
                    curBody.Velocity += (body.Position - curBody.Position) * weight;
                }
            }
        }
    }
}
