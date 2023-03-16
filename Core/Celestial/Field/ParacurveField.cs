using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.Celestial.Behaviour;
using Core.Celestial.Body;
using Microsoft.SqlServer.Server;

namespace Core.Celestial.Field
{
    internal class ParacurveField : BaseField, IGridField, ITailField
    {
        public bool DrawGrids { get; set; } = false;
        public bool DrawBodyTail { get; set; } = true;
        public float GridSize { get; set; } = 40;

        public ParacurveField(float width, float height) : base(width, height)
        {
            Bodies = new IBody[0];
        }

        public void EjectObject()
        {
            Random rnd = new Random();
            Thread.Sleep(10);
            Random rnd2 = new Random();
            Thread.Sleep(10);

            Position position = new Position(Width / 2, Height / 2);
            float mass = 1f;
            float size = 5f;
            Velocity vel = new Velocity((float)(rnd.NextDouble() - 0.5f) * 5, (float)(rnd2.NextDouble() - 0.5f) * 5);
            Thread.Sleep(10);
            //float speed = (float)(1f + rnd.NextDouble() * 0.2f);
            float speed = 1f;

            IBody body = new Body.Body(mass: mass, size:size, position: position, vel:vel, speed: speed);

            body.AddBehaviour(new ParacurveBehaviour(this));

            Bodies = new IBody[] { body };
        }

        public void EjectObjectTo(float x, float y)
        {
            Position position = new Position(Width / 2, Height / 2);
            float mass = 1f;
            float size = 5f;

            float dx = x - position.X;
            float dy = y - position.Y;

            Velocity vel = new Velocity(dx / Width * 5, dy / Height  * 5);

            float speed = 1f;

            IBody body = new Body.Body(mass: mass, size: size, position: position, vel: vel, speed: speed);

            body.AddBehaviour(new ParacurveBehaviour(this));

            Bodies = new IBody[] { body };
        }
    }
}
