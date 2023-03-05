using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Celestial.Field
{
    public interface IUniverseField
    {
        void AddSun(float x, float y);
        void AddPlanet(float x, float y);
        void RemoveSun(string Id);
        void RemovePlanet(string Id);
        void RemoveAllSuns();
        void RemoveAllPlanets();
    }
}
