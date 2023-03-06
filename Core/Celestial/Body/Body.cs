using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Celestial.Body
{
    public class Body : IBody
    {
        private const int PositionsToRemember = 1000;
        private readonly List<Behaviour.Behaviour> _behaviours;
        public string Id { get; }
        public float Mass { get; }
        public float Size { get; }
        public Position Position { get; set; }
        public List<Position> Positions { get; set; } = new List<Position>();
        public Velocity Velocity { get; set; }
        public float Speed { get { return Velocity.GetCurrentSpeed(); } }

        public Body(float mass, float size, Position position, Velocity vel, float speed)
        {
            Id = Guid.NewGuid().ToString();
            Position = position;
            Velocity = vel;
            Velocity *= speed;
            Mass = mass;
            Size = size;
            
            _behaviours = new List<Behaviour.Behaviour>();
        }
        public void AddBehaviour(Behaviour.Behaviour behaviour)
        {
            _behaviours.Add(behaviour);
        }

        public void Move(float stepSize)
        {
            _behaviours.ForEach(behaviour => behaviour.CalcVelocity(this));
            Position.Move(Velocity, stepSize);

            Positions.Add(new Position(Position));
            while (Positions.Count > PositionsToRemember)
                Positions.RemoveAt(0);
        }
    }
}
