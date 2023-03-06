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
        private const float G = 0.00067f * 1f;
        public GravityBehaviour(IField field) : base(field)
        {
        }

        public override void CalcVelocity(IBody curBody)
        {
            Velocity retVel = new Velocity();
            foreach (var body in Field.Bodies)
            {
                float distance = curBody.Position.Distance(body.Position);
                if (distance > body.Size + curBody.Size
                    || (curBody.Mass / body.Mass < 0.001 && distance > (body.Size + curBody.Size) / 0.5f))
                {
                    float gravity = (float)(G * body.Mass / Math.Pow(distance, 2.0));
                    Position distPos = body.Position - curBody.Position;
                    distPos /= distance;
                    distPos *= gravity;
                    curBody.Velocity += distPos;

                    //curBody.Velocity += (body.Position - curBody.Position) * weight;
                }
            }
        }
    }
}
