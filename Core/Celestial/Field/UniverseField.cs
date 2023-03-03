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
        public UniverseField()
        {
            _width = Width;
            _height = Height;

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
            IBody sun = new Body.Body(posX:600f, posY:300f, mass:10000, size:10, xVel:0, yVel:0, speed:0);
            behaviours.ForEach(behaviour => sun.AddBehaviour(behaviour));
            bodies.Add(sun);

            //Planets
            int planetCount = 8;
            for (int i = 0; i < planetCount; i++)
            {
                float x = 600 - (i + 1) * 30f;
                IBody planet = new Body.Body(posX:x, posY:300f, mass:1, size:2, xVel:0, yVel:1, speed:1);
                behaviours.ForEach(behaviour => planet.AddBehaviour(behaviour));
                bodies.Add(planet);
            }

            Bodies = bodies.ToArray();
        }
    }
}
