﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GalaxyConquest
{
    [Serializable]
    public class StarSystem
    {
        public string name;

        public int type; //тип звезды

        public double x;
        public double y;
        public double z;
        public SolidBrush br; //brush for stars
    }
}
