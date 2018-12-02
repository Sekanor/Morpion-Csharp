using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion_métier
{
    public class Position
    {

        public Position(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
        }

        private int x;
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        private int y;
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public override bool Equals(object obj)
        {
            var position = obj as Position;
            return position != null &&
                   x == position.x &&
                   y == position.y;
        }

        public override string ToString()
        {

            return "("+X+" , "+Y+")";
        }
    }
}
