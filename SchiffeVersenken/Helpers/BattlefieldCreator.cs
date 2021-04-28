using SchiffeVersenken.Models;
using System.Collections.Generic;

namespace SchiffeVersenken.Helpers
{
    public static class BattlefieldCreator
    {
        /* Member/Fields */

        /* Constructors */

        /* Getter/Setter */

        /* Methods */

        /// <summary>
        /// Create fields
        /// </summary>
        /// <returns>List containing the fields</returns>
        public static List<Field> CreateFields(int fieldLength)
        {
            // TODO: Different varieties (with artillerie, etc...), different battlefields (sizes, etch...)
            List<Field> fields = new List<Field>();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Field newField = new Field(i * fieldLength, j * fieldLength, fieldLength);
                    fields.Add(newField);
                }
            }

            return fields;
        }

        /// <summary>
        /// Create ships
        /// </summary>
        /// <returns>List containing the ships</returns>
        public static List<Ship> CreateShips()
        {
            List<Ship> ships = new List<Ship>();

            // TODO: Different varieties (with artillerie, etc...)
            ships = InitializeShips(1, 5);
            ships.AddRange(InitializeShips(2, 4));
            ships.AddRange(InitializeShips(3, 3));
            ships.AddRange(InitializeShips(4, 2));

            return ships;
        }

        public static List<Mine> CreateMines(int num)
        {
            List<Mine> mines = new List<Mine>();

            for (int i = 0; i < num; i++) mines.Add(new Mine());

            return mines;
        }

        /// <summary>
        /// Initialize ships
        /// </summary>
        /// <param name="count">Number of ships to initialize</param>
        /// <param name="length">Length of these ships</param>
        /// <returns></returns>
        private static List<Ship> InitializeShips(int count, int length)
        {
            List<Ship> ships = new List<Ship>();

            for (int i = 0; i < count; i++)
            {
                Ship ship = new Ship(length);
                ships.Add(ship);
            }

            return ships;
        }
    }
}
