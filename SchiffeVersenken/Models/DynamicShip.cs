using SchiffeVersenken.Enums;
using System.Collections.Generic;
using System.Linq;

namespace SchiffeVersenken.Models
{
    public class DynamicShip : Ship
    {
        /* Member/Fields */

        /* Constructors */

        public DynamicShip() : base(0) { }

        /* Getter/Setter */

        /* Methods */

        /// <summary>
        /// Add a new field to the ship
        /// </summary>
        /// <param name="newField">Field to add</param>
        public void AddField(Field newField)
        {
            int newLenght = Fields.Length + 1;

            Field[] newArray = new Field[newLenght];

            for (int i = 0; i < Fields.Length; i++)
            {
                newArray[i] = Fields[i];
            }

            newArray[newLenght - 1] = newField;

            Fields = newArray;
        }

        /// <summary>
        /// Remove a field from the ship
        /// </summary>
        /// <param name="removeField">Field to remove</param>
        public void RemoveField(Field removeField)
        {
            int newLength = Fields.Length - 1;

            // Sanity-check
            if (newLength < 0)
            {
                newLength = 0;
            }

            Field[] newArray = new Field[newLength];

            int i = 0;
            foreach (Field fi in Fields)
            {
                if (fi != removeField)
                {
                    newArray[i] = fi;
                    i++;
                }
            }

            Fields = newArray;
        }

        /// <summary>
        /// Remove multiple fields from the ship
        /// </summary>
        /// <param name="removeFields">Fields to remove</param>
        public void RemoveFields(List<Field> removeFields)
        {
            int newLength = Fields.Length - removeFields.Count;

            // Sanity-check
            if (newLength < 0)
            {
                newLength = 0;
            }

            Field[] newArray = new Field[newLength];

            int i = 0;
            foreach (Field fi in Fields)
            {
                if (!removeFields.Contains(fi))
                {
                    newArray[i] = fi;
                    i++;
                }
            }

            Fields = newArray;
        }

        /// <summary>
        /// Get the lifestate of the ship
        /// </summary>
        /// <returns>Always Alive, a dynamic ship can't be sunken.</returns>
        public override ShipLifestate GetLifestate()
        {
            return ShipLifestate.Alive;
        }

        /// <summary>
        /// Searches all fields that belong together in a ship
        /// </summary>
        /// <param name="nextField"></param>
        /// <returns>Fields that belong together</returns>
        public List<Field> GetBelongingFields(Field nextField)
        {
            Field startField = nextField;
            List<Field> fields = new List<Field>();

            while (nextField != null)
            {
                fields.Add(nextField);
                RemoveField(nextField);

                Field currentField = nextField;

                bool repeat = false;
                do
                {

                    nextField = Fields.FirstOrDefault(fi => fi.PosX == currentField.PosX && fi.PosY == currentField.PosY - currentField.Length);

                    if (nextField == null)
                        nextField = Fields.FirstOrDefault(fi => fi.PosX == currentField.PosX + currentField.Length && fi.PosY == currentField.PosY);

                    if (nextField == null)
                        nextField = Fields.FirstOrDefault(fi => fi.PosX == currentField.PosX && fi.PosY == currentField.PosY + currentField.Length);

                    if (nextField == null)
                        nextField = Fields.FirstOrDefault(fi => fi.PosX == currentField.PosX - currentField.Length && fi.PosY == currentField.PosY);

                    if (repeat == true)
                    {
                        repeat = false;
                    }
                    else if (nextField == null)
                    {
                        currentField = startField;
                        repeat = true;
                    }
                }
                while (repeat);
            }

            return fields;
        }
    }
}
