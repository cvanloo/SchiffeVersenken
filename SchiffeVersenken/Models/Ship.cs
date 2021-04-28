using SchiffeVersenken.Enums;
using System;
using System.Drawing;
using System.Linq;

namespace SchiffeVersenken.Models
{
    public class Ship : IComparable<Ship>
    {
        /* Fields/Members */

        private Color color = Color.Black; // TODO: Determine color in here, and not in DrawGraphics
        private Field[] fields;

        /* Constructors */

        public Ship(int fieldCount)
        {
            this.fields = new Field[fieldCount];
        }

        /* Getter/Setter */

        public int FieldCount
        {
            get { return fields.Count(); }
        }

        public Color ShipColor
        {
            get { return color; }
            set { color = value; }
        }

        public Field[] Fields
        {
            get { return fields; }
            set { fields = value; }
        }

        public bool IsHorizontal
        {
            get
            {
                if (fields[0].PosX != fields[1].PosX)
                {
                    return true;
                }

                return false;
            }
        }

        /* Methods */

        public void ClearFields()
        {
            fields = new Field[FieldCount];
        }

        public int CompareTo(Ship other)
        {
            if (this == other)
                return 0;
            return -1;
        }

        public virtual ShipLifestate GetLifestate()
        {
            foreach (Field fi in fields)
            {
                if (fi != null)
                {
                    if (fi.Lifestate == FieldLifestate.Alive)
                    {
                        return ShipLifestate.Alive;
                    }
                }
            }

            return ShipLifestate.Sunken;
        }
    }
}
