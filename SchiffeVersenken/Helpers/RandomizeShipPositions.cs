using SchiffeVersenken.Models;
using System;
using System.Collections.Generic;

namespace SchiffeVersenken.Helpers
{
    public static class RandomizeShipPositions
    {
        /* Member/Fields */

        /* Constructors */

        /* Getter/Setter */

        /* Methods */

        public static void Randomize(List<Mine> mines, List<Ship> ships, List<Field> fields)
        {
            List<Field> availableFields = ListOperations.CopyList(fields);
            Random random = new Random();
            Field currField;

            foreach (Mine m in mines)
            {
                while (true)
                {
                    currField = availableFields[random.Next(0, availableFields.Count)];

                    if (currField.GetShipOnField(ships) == null && currField.GetMineOnField(mines) == null)
                    {
                        m.Position = currField;
                        availableFields.Remove(currField);
                        break;
                    }

                    availableFields.Remove(currField);
                }
            }
        }

        /// <summary>
        /// Place ships on a random position on the battlefield
        /// </summary>
        /// <param name="ships">Ships to place</param>
        /// <param name="fields">The battlefield</param>
        public static void Randomize(List<Ship> ships, List<Field> fields)
        {
            int triesNeeded = 0;
            int totalTriesNeeded = 0;

            Random random = new Random();

            // Copy fields to aviableFields
            List<Field> aviableFields = ListOperations.CopyList(fields);

            foreach (Ship s in ships)
            {
                LogOutput.Output("On ship: " + s.FieldCount + "\t", LogOutput.LogType.Info);

                // Search for a place for the ship
                List<Field> shipFields;

                bool repeat;
                do
                {
                    // Two is the size of the smallest ship, means we don't even need to try anymore if there are less than two fields left.
                    if (triesNeeded > 50 || aviableFields.Count < 2)
                    {
                        // Begin from new to avoid retrying for eternity
                        LogOutput.Output("No more options left, restarting.\n", LogOutput.LogType.Warning);
                        Randomize(ships, fields);
                        return;
                    }

                    triesNeeded++;

                    repeat = false;

                    shipFields = new List<Field>();
                    Field currField = null;
                    bool isHorizontal = false;

                    for (int i = s.FieldCount; i > 0; i--)
                    {
                        if (i == s.FieldCount)
                        {
                            // Take a random field and orientation
                            currField = aviableFields[random.Next(0, aviableFields.Count)];
                            isHorizontal = random.Next(0, 2) > 0;
                        }
                        else
                        {
                            if (isHorizontal)
                            {
                                currField = currField.GetNeighbourFieldRight(aviableFields);
                            }
                            else
                            {
                                currField = currField.GetNeighbourFieldBelow(aviableFields);
                            }
                        }

                        if (currField != null)
                        {
                            shipFields.Add(currField);
                        }
                        else
                        {
                            /* If a ship doesn't fit at the position, start over and find another place.
                             * It is possible to place the ships in a way, that not all will fit onto the battlefield.
                             * In that case the method would retry forever, without finding a place.
                             * To avoid that, after a max. amount of retries (50), the program begins from new. To do that,
                             * the method calls itself recursivly.
                             */
                            repeat = true;
                            break;
                        }
                    }
                }
                while (repeat);

                // Place ship and remove fields from aviableFields
                PlaceShip(s, shipFields);

                // Remove ship- and surrounding fields
                RemoveSurroundingFields(aviableFields, shipFields);

                foreach (Field fi in shipFields)
                {
                    aviableFields.Remove(fi);
                }

                LogOutput.Output("Took " + triesNeeded + " tries.", LogOutput.LogType.Info);
                
                totalTriesNeeded += triesNeeded;
                triesNeeded = 0; // Reset to zero
            }

            for (int i = 0; i < 30 + totalTriesNeeded.ToString().Length; i++) { Console.Out.Write("-"); }
            Console.Out.WriteLine("\nAll ships placed. Took " + totalTriesNeeded + " tries.");
            for (int i = 0; i < 30 + totalTriesNeeded.ToString().Length; i++) { Console.Out.Write("-"); }
            Console.Out.WriteLine();
        }

        /// <summary>
        /// Place a ship onto specific fields
        /// </summary>
        /// <param name="ship">Ship to place</param>
        /// <param name="shipFields">Fields to place the ship onto</param>
        private static void PlaceShip(Ship ship, List<Field> shipFields)
        {
            int i = 0;
            foreach (Field fi in shipFields)
            {
                ship.Fields[i] = fi;
                i++;
            }
        }

        /// <summary>
        /// Remove all fields surrounding other fields
        /// </summary>
        /// <param name="fields">List to remove fields from</param>
        /// <param name="currentShip">Fields surrounding this fields will be removed</param>
        private static void RemoveSurroundingFields(List<Field> fields, List<Field> currentShip)
        {
            foreach (Field fi in currentShip)
            {
                // It is possible to pass null as an argument to Remove() 
                fields.Remove(fi.GetNeighbourFieldAbove(fields));
                fields.Remove(fi.GetNeighbourFieldRight(fields));
                fields.Remove(fi.GetNeighbourFieldBelow(fields));
                fields.Remove(fi.GetNeighbourFieldLeft(fields));
                fields.Remove(fi.GetNeighbourFieldAboveLeft(fields));
                fields.Remove(fi.GetNeighbourFieldAboveRight(fields));
                fields.Remove(fi.GetNeighbourFieldBelowLeft(fields));
                fields.Remove(fi.GetNeighbourFieldBelowRight(fields));
            }
        }
    }
}