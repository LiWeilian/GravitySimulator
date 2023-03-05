using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.Celestial.Behaviour;
using Core.Celestial.Body;

namespace Core.Celestial.Field
{
    public class UniverseField : BaseField, IGridField, IUniverseField
    {
        public bool DrawGrids { get; set; } = false;
        public float GridSize { get; set; } = 40;
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
            /*
            //Sun
            IBody sun;
            //sun = new Body.Body(posX: _width / 2 - 50f, posY: _height / 2 - 50f, mass: 10000, size: 10, xVel: 0.1f, yVel: -0.1f, speed: 0.1f);
            //behaviours.ForEach(behaviour => sun.AddBehaviour(behaviour));
            //bodies.Add(sun);

            //sun = new Body.Body(posX: _width / 2 + 50f, posY: _height / 2 + 50f, mass: 10000, size: 10, xVel: -0.1f, yVel: 0.05f, speed: 0.15f);
            //behaviours.ForEach(behaviour => sun.AddBehaviour(behaviour));
            //bodies.Add(sun);

            sun = new Body.Body(posX: _width / 2, posY: _height / 2, mass: 10000, size: 10, xVel: 0f, yVel: 0f, speed: 0f);
            behaviours.ForEach(behaviour => sun.AddBehaviour(behaviour));
            bodies.Add(sun);

            //Planets
            Random rnd = new Random();
            int planetCount = 8;
            for (int i = 0; i < planetCount; i++)
            {
                float x = _width / 2 - 50f - (i + 1) * 20f;
                IBody planet = new Body.Body(
                    posX: x, 
                    posY: _height / 2, 
                    mass: (float)(1 + rnd.NextDouble() * 1.0f), 
                    size: (float)(2 + rnd.NextDouble() * 2.0f), 
                    xVel: 0f, 
                    yVel: 1f, 
                    speed: (float)(1f + rnd.NextDouble() * 0.2f));

                behaviours.ForEach(behaviour => planet.AddBehaviour(behaviour));

                bodies.Add(planet);

                Thread.Sleep(10);
            }
            */

            Bodies = bodies.ToArray();
        }

        public void AddSun(float x, float y)
        {
            var behaviours = new List<Behaviour.Behaviour>
            {
                new GravityBehaviour(this)
            };

            IBody sun = new Body.Body(posX: x, posY: y, mass: 10000, size: 10, xVel: 0f, yVel: 0f, speed: 0f);
            behaviours.ForEach(behaviour => sun.AddBehaviour(behaviour));
            List<IBody> bodies = Bodies.ToList();
            bodies.Add(sun);
            Bodies = bodies.ToArray();
        }

        public void AddPlanet(float x, float y)
        {
            var behaviours = new List<Behaviour.Behaviour>
            {
                new GravityBehaviour(this)
            };

            Random rnd = new Random();
            IBody planet = new Body.Body(
                    posX: x,
                    posY: y,
                    mass: (float)(1 + rnd.NextDouble() * 1.0f),
                    size: (float)(2 + rnd.NextDouble() * 2.0f),
                    xVel: 0f,
                    yVel: 1f,
                    speed: (float)(1f + rnd.NextDouble() * 0.2f));

            behaviours.ForEach(behaviour => planet.AddBehaviour(behaviour));

            List<IBody> bodies = Bodies.ToList();
            bodies.Add(planet);
            Bodies = bodies.ToArray();
        }

        public void RemoveSun(string Id)
        {
            throw new NotImplementedException();
        }

        public void RemovePlanet(string Id)
        {
            throw new NotImplementedException();
        }

        public void RemoveAllSuns()
        {
            throw new NotImplementedException();
        }

        public void RemoveAllPlanets()
        {
            throw new NotImplementedException();
        }
    }
}
