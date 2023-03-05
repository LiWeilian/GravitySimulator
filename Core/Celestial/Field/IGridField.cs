using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Celestial.Field
{
    interface IGridField
    {
        bool DrawGrids { get; set; }
        float GridSize { get; set; }
    }
}
