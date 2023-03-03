using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Celestial.Behaviour;
using Core.Celestial.Body;

namespace Core.Celestial.Field
{
    public class UniverseField : BaseField
    {
        public UniverseField(float width, float height) : base(width, height)
        {
            GenerateBodies();
        }

        private void GenerateBodies()
        {
            var behaviours = new List<Behaviour.Behaviour>
            {
                new GravityBehaviour(this)
            };
            List<IBody> bodies = new List<IBody>();
            //Sun
            IBody sun = new Body.Body(posX: _width / 2 - 200f, posY: _height / 2 - 100f, mass: 10000, size: 10, xVel: 0.1f, yVel: -0.1f, speed: 0.1f);
            behaviours.ForEach(behaviour => sun.AddBehaviour(behaviour));
            bodies.Add(sun);

            sun = new Body.Body(posX: _width / 2 + 200f, posY: _height / 2 + 100f, mass: 10000, size: 10, xVel: -0.1f, yVel: 0.05f, speed: 0.1f);
            behaviours.ForEach(behaviour => sun.AddBehaviour(behaviour));
            bodies.Add(sun);

            //sun = new Body.Body(posX: 1200f, posY: 900f, mass: 10000, size: 10, xVel: -0.1f, yVel: 0.1f, speed: 0.1f);
            //behaviours.ForEach(behaviour => sun.AddBehaviour(behaviour));
            //bodies.Add(sun);

            //Planets
            int planetCount = 8;
            for (int i = 0; i < planetCount; i++)
            {
                float x = _width / 2 + 100f - (i + 1) * 30f;
                IBody planet = new Body.Body(posX: x, posY: _height / 2 - 200f, mass: 1, size: 2, xVel: 0, yVel: 1, speed: 1);
                behaviours.ForEach(behaviour => planet.AddBehaviour(behaviour));
                bodies.Add(planet);
            }

            Bodies = bodies.ToArray();
        }
    }
}
