using System;
using SchiffeVersenken.Enums;

namespace SchiffeVersenken.Models
{
    public class Mine : IComparable<Mine>
    {
        /* Field/Members */

        Field field;
        

        /* Constructors */

        /// <summary>
        /// Constructor
        /// </summary>
        public Mine() { } // Needed for Newtonsoft.Json!

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="field">Position of the mine</param>
        public Mine(Field field) 
        {
            this.field = field;
        }
        

        /* Getter/Setter */

        /// <summary>
        /// Get or Set the position of the mine
        /// </summary>
        public Field Position
        {
            get { return field; }
            set { field = value; }
        }


        /* Methods */

        /// <summary>
        /// Get the lifestate of the mine
        /// </summary>
        /// <returns>Lifestate of the mine</returns>
        public ShipLifestate GetLifestate()
        {
            if (field.Lifestate == FieldLifestate.Alive)
                return ShipLifestate.Alive;
            else
                return ShipLifestate.Sunken;
        }

        /// <summary>
        /// Clear the field
        /// </summary>
        public void ClearField()
        {
            field = null;
        }

        public int CompareTo(Mine other)
        {
            if (this == other)
                return 0;
            return -1;
        }
    }
}
