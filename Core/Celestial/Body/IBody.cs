using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Celestial.Body
{
    public interface IBody
    {
        float Mass { get; }
        float Size { get; }
        Position Position { get; set; }
        List<Position> Positions { get; set; }
        Velocity Velocity { get; set; }
        float Speed { get; set; }
        void Move(float stepSize);
        void AddBehaviour(Behaviour.Behaviour behaviour);
    }
}
