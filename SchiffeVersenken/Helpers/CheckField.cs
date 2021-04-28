using SchiffeVersenken.Models;
using System.Collections.Generic;

namespace SchiffeVersenken.Helpers
{
    public class CheckField
    {
        /* Member/Fields */

        private List<Field> allFields;
        private List<Ship> allShips;
        private List<Mine> allMines;

        /* Constructors */

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="allFields">List with fields</param>
        /// <param name="allShips">List with ships</param>
        /// <param name="allMines">List with mines</param>
        public CheckField(List<Field> allFields, List<Ship> allShips, List<Mine> allMines)
        {
            this.allFields = allFields;
            this.allShips = allShips;
            this.allMines = allMines;
        }

        /* Getter/Setter */ 

        /* Methods */

        /// <summary>
        /// Check if the field is a valid place to set a mine
        /// </summary>
        /// <param name="field">Field to check</param>
        /// <returns>True if the field is valid</returns>
        public bool IsMineValid(Field field)
        {
            if (field == null) return false;

            if (field.GetShipOnField(allShips) != null) return false;

            if (allMines != null && field.GetMineOnField(allMines) != null) return false;

            return true;
        }

        /// <summary>
        /// Check if the field is a valid place to set a ship
        /// </summary>
        /// <param name="field">Field to be checked</param>
        /// <param name="directionHorizontal">Is the ship horizontal?</param>
        /// <param name="isFieldFirst">Is it the first field of the ship?</param>
        /// <returns>True if the field is valid</returns>
        public bool IsShipValid(Field field, bool directionHorizontal, bool isFieldFirst)
        {
            if (field == null)
                return false;

            if (field.GetShipOnField(allShips) != null)
                return false;

            if (allMines != null && field.GetMineOnField(allMines) != null)
                return false;

            Field testField = null;

            if (directionHorizontal)
            {
                /* The ship is horizontal */

                // Is a ship located...

                if (isFieldFirst)
                {
                    // ..left?
                    testField = field.GetNeighbourFieldLeft(allFields);
                    if (testField != null && testField.GetShipOnField(allShips) != null)
                        return false;
                }

                // ..above?
                testField = field.GetNeighbourFieldAbove(allFields);
                if (testField != null && testField.GetShipOnField(allShips) != null)
                    return false;
            }
            else
            {
                /* The ship is vertical */

                // Is a ship located...

                if (isFieldFirst)
                {
                    // ..above?
                    testField = field.GetNeighbourFieldAbove(allFields);
                    if (testField != null && testField.GetShipOnField(allShips) != null)
                        return false;
                }

                // ..left?
                testField = field.GetNeighbourFieldLeft(allFields);
                if (testField != null && testField.GetShipOnField(allShips) != null)
                    return false;
            }

            // Is a ship located...

            // ..underneath?
            testField = field.GetNeighbourFieldBelow(allFields);
            if (testField != null && testField.GetShipOnField(allShips) != null)
                return false;

            // ..rigth?
            testField = field.GetNeighbourFieldRight(allFields);
            if (testField != null && testField.GetShipOnField(allShips) != null)
                return false;

            // ..above-left?
            testField = field.GetNeighbourFieldAboveLeft(allFields);
            if (testField != null && testField.GetShipOnField(allShips) != null)
                return false;

            // ..above-right
            testField = field.GetNeighbourFieldAboveRight(allFields);
            if (testField != null && testField.GetShipOnField(allShips) != null)
                return false;

            // ..underneath-left?
            testField = field.GetNeighbourFieldBelowLeft(allFields);
            if (testField != null && testField.GetShipOnField(allShips) != null)
                return false;

            // ..underneath-right?
            testField = field.GetNeighbourFieldBelowRight(allFields);
            if (testField != null && testField.GetShipOnField(allShips) != null)
                return false;

            return true;
        }
    }
}
