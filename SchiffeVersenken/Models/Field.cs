using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SchiffeVersenken.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SchiffeVersenken.Models
{
    public class Field
    {
        /* Fields/Members */

        private int posX;
        private int posY;
        private int length;
        private Color fieldColor = Color.White;
        private Color borderColor = Color.Black;
        private int borderThickness = 1;
        private FieldLifestate lifestate = FieldLifestate.Alive;

        /* Constructors */

        public Field(int posX, int posY, int length)
        {
            this.posX = posX;
            this.posY = posY;
            this.length = length;
        }
        
        /* Getter/Setter */

        public int PosX
        {
            get { return posX; }
        }

        public int PosY
        {
            get { return posY; }
        }

        public int Length
        {
            get { return length; }
        }

        public Color FieldColor
        {
            get { return fieldColor; }
            set { fieldColor = value; }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }

        public int BorderThickness
        {
            get { return borderThickness; }
            set { borderThickness = value; }
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public FieldLifestate Lifestate
        {
            get { return lifestate; }
            set { lifestate = value; }
        }

        /* Methods */

        /// <summary>
        /// Checks if a point is on the field
        /// </summary>
        /// <param name="p">Point to check</param>
        /// <returns>True if point is on field</returns>
        public bool IsPointOnField(Point p)
        {
            if (p.X >= posX && p.X <= posX+length && p.Y >= posY && p.Y <= posY+length)
                return true;
            return false;
        }

        /// <summary>
        /// Reset to default style
        /// </summary>
        public void ApplyDefaultStyle()
        {
            fieldColor = Color.White;
            borderColor = Color.Black;
            borderThickness = 1;
        }

        /// <summary>
        /// Get the ship that is on this field
        /// </summary>
        /// <param name="ships">All ships to check from</param>
        /// <returns>The ship that is on this field or null</returns>
        public Ship GetShipOnField(List<Ship> ships)
        {
            foreach (Ship s in ships)
            {
                if (s.Fields.Contains(this))
                {
                    return s;
                }
            }

            return null;
        }

        /// <summary>
        /// Get the mine that is on this field
        /// </summary>
        /// <param name="mines">All mines to check from</param>
        /// <returns>The mine that is on this field or null</returns>
        public Mine GetMineOnField(List<Mine> mines)
        {
            foreach (Mine m in mines)
            {
                if (m.Position == this)
                {
                    return m;
                }
            }

            return null;
        }

        public Field GetNeighbourFieldAbove(List<Field> fields)
        {
            return fields.FirstOrDefault(fi => fi.PosX == posX && fi.PosY == posY - length);
        }

        public Field GetNeighbourFieldRight(List<Field> fields)
        {
            return fields.FirstOrDefault(fi => fi.PosX == posX + length && fi.PosY == posY);
        }

        public Field GetNeighbourFieldBelow(List<Field> fields)
        {
            return fields.FirstOrDefault(fi => fi.PosX == posX && fi.PosY == posY + length);
        }

        public Field GetNeighbourFieldLeft(List<Field> fields)
        {
            return fields.FirstOrDefault(fi => fi.PosX == posX - length && fi.PosY == posY);
        }

        public Field GetNeighbourFieldAboveLeft(List<Field> fields)
        {
            return fields.FirstOrDefault(fi => fi.PosX == posX - length && fi.PosY == posY - length);
        }

        public Field GetNeighbourFieldAboveRight(List<Field> fields)
        {
            return fields.FirstOrDefault(fi => fi.PosX == posX + length && fi.PosY == posY - length);
        }

        public Field GetNeighbourFieldBelowLeft(List<Field> fields)
        {
            return fields.FirstOrDefault(fi => fi.PosX == posX - length && fi.PosY == posY + length);
        }

        public Field GetNeighbourFieldBelowRight(List<Field> fields)
        {
            return fields.FirstOrDefault(fi => fi.PosX == posX + length && fi.PosY == posY + length);
        }

        public override string ToString()
        {
            return "X: " + PosX.ToString() + " / " + "Y: " + PosY.ToString();
        }
    }
}
