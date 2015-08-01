using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TerroGUI
{
    public static class Util
    {
        public static bool Intersects(this MouseState m, Rectangle OtherRect)
        {
            if (new Rectangle(m.X, m.Y, 1, 1).Intersects(OtherRect))
                return true;

            else
                return false;
        }
    }
}
