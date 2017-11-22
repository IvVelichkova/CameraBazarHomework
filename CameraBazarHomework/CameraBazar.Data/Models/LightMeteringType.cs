using System;
using System.Collections.Generic;
using System.Text;

namespace CameraBazar.Data.Models
{
    [Flags]
    public enum LightMeteringType
    {//spot, center-weighted and evaluative
        Spot = 1,
        CenterWeight = 2,
        Evaluative = 4 
    }
}
