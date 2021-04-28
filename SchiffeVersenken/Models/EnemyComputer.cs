using SchiffeVersenken.Enums;
using SchiffeVersenken.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchiffeVersenken.Models
{
    public class EnemyComputer : Player
    {
        /* Member/Fields */

        private List<Ship> ships; // Contains the computers own ships
        private List<Mine> mines; // Contains the computers own mines
        private ComputerDifficulty difficulty;
        private List<Field> aviableUserFields = new List<Field>(); // Contains fields form the user where the computer can shoot at
        
        /* Needed to determine the next shot */
        private ShotState lastShotState = ShotState.Miss;
        private List<Field> fieldsPath = new List<Field>();
        private Field lastShotField;
        private DirectionIndex directionIndex = new DirectionIndex();
        private List<Field> currentShipFields = new List<Field>();
        
        /* Stores all fields (from the enemy) that are known to contain a ship, but the ship isn't sunken yet
         * (The computer shoot at a field and gets the ShotState.Hit, so he knows that a ship is on this specific field,
         * but he doesn't know the whole ship.)
         * The dynamic ship can contain fields from multiple ships. As soon as a ship is sunken, the computer figures out which
         * of the fields contained in the dynamic ship belong together and puts them into their own ship.
         */ 
        private DynamicShip dynamicShip = new DynamicShip();

        //List<Field> inner4Fields;
        //int inner4Count = 0;

        /* Constructors */

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="difficulty">Diffictulty at which the computer will play</param>
        /// <param name="width"></param>
        public EnemyComputer(ComputerDifficulty difficulty, int width) : base (BattlefieldCreator.CreateFields(width))
        {
            // TODO: Delete parameter width
            base.Username = "Computer";
            this.difficulty = difficulty;
            this.ships = BattlefieldCreator.CreateShips();
            
            if (Properties.Settings.Default.s_Mine) this.mines = BattlefieldCreator.CreateMines(Properties.Settings.Default.s_MineNum);
            
            RandomizeShipPositions.Randomize(ships, base.Fields); // Place ships onto fields

            if (mines != null ) RandomizeShipPositions.Randomize(mines, ships, base.Fields); // Place mines onto fields

            aviableUserFields = BattlefieldCreator.CreateFields(width);
            
            KnownShips.Add(dynamicShip);
        }

        /* Getter/Setter */

        /// <summary>
        /// Get the difficulty at which the computer is playing
        /// </summary>
        public ComputerDifficulty GetDifficulty
        {
            get { return difficulty; }
        }

        /// <summary>
        /// Get the number of computer's ships that are still alive
        /// </summary>
        public override int CountShipsAlive
        {
            get { return ships.Count(s => s.GetLifestate() == ShipLifestate.Alive); }
        }

        /// <summary>
        /// Get the number of comuputer's ships that are sunken
        /// </summary>
        public override int CountShipsSunken
        {
            get { return ships.Count(s => s.GetLifestate() == ShipLifestate.Sunken); }
        }

        /* Methods */

        /// <summary>
        /// Send a shot to the enemy and wait for the enemy's response, if it was a miss, hit, sunken or mine
        /// </summary>
        /// <param name="opponent">The user</param>
        /// <returns>Returns if the shot was a hit, miss, sunken or mine</returns>
        public ShotState Shoot(Player user)
        {
            Shot shot = GetNextShot();

            lastShotState = base.Shoot(shot, user);

            if (ShotState.Mine == lastShotState)
            {
                // Sink the shooter
                foreach (Field fi in shot.Shooter.Fields)
                {
                    fi.Lifestate = FieldLifestate.Hit;
                }

                // Add ship to KnownShips
                KnownShips.Add(shot.Shooter);
            }

            return lastShotState;
        }

        /// <summary>
        /// Get a shot form the enemy and answer if it was a miss, hit, sunken or mine.
        /// </summary>
        /// <param name="shot">Shot to receive from the enemy</param>
        /// <returns>Returns if the shot was a hit, miss, sunken or mine</returns>
        public override ShotState ReceiveShot(Shot shot)
        {
            ShotState shotState = ShotState.Miss;

            // Find shot field
            Field shotField = Fields.First(fi => fi.PosX == shot.TargetField.PosX && fi.PosY == shot.TargetField.PosY);

            // Register hit
            shotField.Lifestate = FieldLifestate.Hit;

            // Check if a ship was hit
            Ship shipOnField = shotField.GetShipOnField(ships);
            
            if (null != shipOnField)
            {
                ShipLifestate shipLifestate = shipOnField.GetLifestate();

                if (shipLifestate == ShipLifestate.Alive)
                    shotState = ShotState.Hit;
                else
                    shotState = ShotState.Sunken;
            }
            else if (Properties.Settings.Default.s_Mine)
            {
                // Check if a mine was hit
                Mine mineOnField = shotField.GetMineOnField(mines);

                if (mineOnField != null)
                {
                    shotState = ShotState.Mine;
                }
            }

            /* A player doesn't know the ships of its enemy, he needs to find out the position of the ships first.
             * A Ship is created when the player has found out all fields of a ship (when the ship is sunken).
             * Until then, all located fields are stored in a dynamic ship.
             */
            if (ShotState.Hit == shotState || ShotState.Sunken == shotState)
            {
                // Add field to dynamic ship
                dynamicShip.AddField(shot.TargetField);

                if (ShotState.Sunken == shotState)
                // Construct the sunken ship from the dynamic ship
                {
                    // Find fields that belong to targetfield
                    List<Field> fields = dynamicShip.GetBelongingFields(shot.TargetField);

                    // Add fields together in a ship
                    Ship ship = new Ship(fields.Count) { Fields = fields.ToArray() };

                    // Add ship to KnownShips
                    KnownShips.Add(ship);
                }
            }
            else if (shotState == ShotState.Mine)
            {
                // Add mine
                Mine mine = new Mine(shotField);
                KnownMines.Add(mine);

                // Sink the shooter
                foreach (Field fi in shot.Shooter.Fields)
                {
                    fi.Lifestate = FieldLifestate.Hit;
                }
            }

            return shotState;
        }

        /// <summary>
        /// Get the next shot to shoot
        /// </summary>
        /// <returns>A shot</returns>
        private Shot GetNextShot()
        {
            Field nextField = null;

            if (ShotState.Mine == lastShotState) lastShotState = ShotState.Miss; // Treat Mine the same as Miss
            if (fieldsPath.Count > 0 && lastShotState == ShotState.Miss)
            // Hits before, but last shot missed
            {
                fieldsPath.RemoveAt(fieldsPath.Count - 1);
                currentShipFields.RemoveAt(currentShipFields.Count - 1);
            }
            else if (lastShotState == ShotState.Sunken)
            // Ship sunken
            {
                RemoveSurroundingFields(currentShipFields); // Remove fields surrounding ship
                currentShipFields.Clear();
                fieldsPath.Clear();
                directionIndex.Reset();
            }

            if (fieldsPath.Count == 0)
            // No hits before
            {
                switch (difficulty)
                {
                    case ComputerDifficulty.Easy:
                        nextField = GetStartFieldEasy();
                        break;
                    case ComputerDifficulty.Medium:
                        nextField = GetStartFieldMedium();
                        break;
                    case ComputerDifficulty.Hard:
                        nextField = GetStartFieldHard();
                        break;
                }
            }
            else
            // Hits before
            {
                if (lastShotState == ShotState.Miss)
                {
                    ChangeSearchDirection();
                }

                repeat:
                Field lastField = fieldsPath[fieldsPath.Count - 1];
                nextField = GetNextField(lastField);

                if (nextField == null)
                {
                    LogOutput.Output("nextField is null!", LogOutput.LogType.Warning);
                    ChangeSearchDirection();
                    goto repeat;
                }
            }

            fieldsPath.Add(nextField);
            currentShipFields.Add(nextField);
            aviableUserFields.Remove(nextField);

            return new Shot(GetShooter(), nextField);
        }

        /// <summary>
        /// Remove all except the first field from the stack and change the search direction
        /// </summary>
        private void ChangeSearchDirection()
        {
            if (fieldsPath.Count > 0)
            {
                fieldsPath.RemoveRange(1, fieldsPath.Count - 1); // Remove all except the first field
            }

            directionIndex.Next();
        }

        /// <summary>
        /// Get a shooter
        /// </summary>
        /// <returns>Returns a randomly chosen alive ship</returns>
        private Ship GetShooter()
        {
            List<Ship> aliveShips = new List<Ship>();
            
            // Get all ships that are still alive
            foreach (Ship s in ships)
            {
                if (s.GetLifestate() == ShipLifestate.Alive)
                {
                    aliveShips.Add(s);
                }
            }

            // Select a random ship
            Random random = new Random();
            return aliveShips[random.Next(0, aliveShips.Count)];
        }

        /// <summary>
        /// Get a start-field with difficulty easy
        /// </summary>
        /// <returns>Start-field</returns>
        private Field GetStartFieldEasy()
        {
            // Return a random field
            return aviableUserFields[new Random().Next(0, aviableUserFields.Count)];
        }

        /// <summary>
        /// Get a start-field with difficulty medium
        /// </summary>
        /// <returns>Start-field</returns>
        private Field GetStartFieldMedium()
        {
            if (lastShotField != null)
            {
                // Get diagonal neighbour-fields
                List<Field> neighbourFields = new List<Field>();
                
                Field f = lastShotField.GetNeighbourFieldAboveLeft(aviableUserFields);
                if (f != null) neighbourFields.Add(f);

                f = lastShotField.GetNeighbourFieldAboveRight(aviableUserFields);
                if (f != null) neighbourFields.Add(f);

                f = lastShotField.GetNeighbourFieldBelowLeft(aviableUserFields);
                if (f != null) neighbourFields.Add(f);

                f = lastShotField.GetNeighbourFieldBelowRight(aviableUserFields);
                if (f != null) neighbourFields.Add(f);

                if (neighbourFields.Count > 0)
                {
                    // Choose a random neigbour-field
                    lastShotField = neighbourFields[new Random().Next(0, neighbourFields.Count)];
                    return lastShotField;
                }
            }

            lastShotField = GetStartFieldEasy();
            return lastShotField;
        }

        /// <summary>
        /// Get a start-field with diffictulty hard
        /// </summary>
        /// <returns>Start-field</returns>
        private Field GetStartFieldHard()
        {
            // Get inner 4x4 (16) fields
            List<Field> inner4Fields = aviableUserFields.Where(fi => fi.PosX >= (3 * fi.Length) && fi.PosX <= (6 * fi.Length) && fi.PosY >= (3 * fi.Length) && fi.PosY <= (6 * fi.Length)).ToList();

            if (inner4Fields.Count > 0)
            {
                // Choose field random
                return inner4Fields[new Random().Next(0, inner4Fields.Count)];
            }

            // Continue as in diffictulty medium
            return GetStartFieldMedium();
        }

        private Field GetNextField(Field lastField)
        {
            Field nextField = null;

            switch (directionIndex.Direction)
            {
                case DirectionIndex.DirectionEnum.Above:
                    nextField = lastField.GetNeighbourFieldAbove(aviableUserFields);
                    break;
                case DirectionIndex.DirectionEnum.Below:
                    nextField = lastField.GetNeighbourFieldBelow(aviableUserFields);
                    break;
                case DirectionIndex.DirectionEnum.Right:
                    nextField = lastField.GetNeighbourFieldRight(aviableUserFields);
                    break;
                case DirectionIndex.DirectionEnum.Left:
                    nextField = lastField.GetNeighbourFieldLeft(aviableUserFields);
                    break;
            }

            return nextField;
        }

        /// <summary>
        /// Remove all fields that surround the fileds from the list
        /// </summary>
        /// <param name="currentShip">List with fields</param>
        private void RemoveSurroundingFields(List<Field> currentShip)
        {
            foreach (Field fi in currentShip)
            {
                // It is possible to pass null as an argument to Remove() 
                aviableUserFields.Remove(fi.GetNeighbourFieldAbove(aviableUserFields));
                aviableUserFields.Remove(fi.GetNeighbourFieldRight(aviableUserFields));
                aviableUserFields.Remove(fi.GetNeighbourFieldBelow(aviableUserFields));
                aviableUserFields.Remove(fi.GetNeighbourFieldLeft(aviableUserFields));
                aviableUserFields.Remove(fi.GetNeighbourFieldAboveLeft(aviableUserFields));
                aviableUserFields.Remove(fi.GetNeighbourFieldAboveRight(aviableUserFields));
                aviableUserFields.Remove(fi.GetNeighbourFieldBelowLeft(aviableUserFields));
                aviableUserFields.Remove(fi.GetNeighbourFieldBelowRight(aviableUserFields));
            }
        }
    }
}
