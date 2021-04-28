using SchiffeVersenken.Enums;
using System.Collections.Generic;
using System.Linq;

namespace SchiffeVersenken.Models
{
    public class Player
    {
        /* Member/Fields */

        private string username;
        private List<Field> fields = new List<Field>();
        private List<Ship> knownShips = new List<Ship>();
        private List<Mine> knownMines = new List<Mine>();
        private List<Shot> shots = new List<Shot>();
        
        /// <summary>
        /// Get the selected ship, returns null if no ship is selected
        /// </summary>
        public Ship SelectedShip { get; set; }

        /* Constructors */

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fields">Player's fileds</param>
        public Player(List<Field> fields) 
        {
            this.fields = fields;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="username">Name of the player</param>
        public Player(string username)
        {
            this.username = username;
        }

        /* Getter/Setter */

        /// <summary>
        /// Get or Set the username of the player
        /// </summary>
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        /// <summary>
        /// Get or Set the fields from the player
        /// </summary>
        public List<Field> Fields
        {
            get { return fields; }
            set { fields = value; }
        }

        /// <summary>
        /// Get or Set the ships from the player
        /// </summary>
        public List<Ship> KnownShips
        {
            get { return knownShips; }
            set { knownShips = value; }
        }

        /// <summary>
        /// Get or Set the mines from the player
        /// </summary>
        public List<Mine> KnownMines
        {
            get { return knownMines; }
            set { knownMines = value; }
        }

        /// <summary>
        /// Get the shots from the player
        /// </summary>
        public List<Shot> Shots
        {
            get { return shots; }
        }

        /// <summary>
        /// Get the number of ships that are still alive
        /// </summary>
        public virtual int CountShipsAlive
        {
            get { return knownShips.Count(s => s.GetLifestate() == ShipLifestate.Alive); }
        }

        /// <summary>
        /// Get the number of ships that are sunken
        /// </summary>
        public virtual int CountShipsSunken
        {
            get { return knownShips.Count(s => s.GetLifestate() == ShipLifestate.Sunken); }
        }

        /// <summary>
        /// Get the number of hits the player has made (to the enemy)
        /// </summary>
        public int CountHits
        {
            get { return shots.Count(s => s.State == ShotState.Hit || s.State == ShotState.Sunken); }
        }


        /* Methods */

        /// <summary>
        /// Send a shot to the enemy and wait for the enemy's response, if it was a miss, hit, sunken or mine
        /// </summary>
        /// <param name="shot">The shot to shoot</param>
        /// <param name="opponent">The enemy to shoot at</param>
        /// <returns>Returns if the shot was a hit, miss, sunken or mine</returns>
        public ShotState Shoot(Shot shot, Player opponent)
        {
            // EnemyNetwork and EnemyComputer overwrite the method "ReceiveShot()" !
            ShotState shotState = opponent.ReceiveShot(shot);
            
            shot.State = shotState;
            
            shots.Add(shot);

            return shotState;
        }

        /// <summary>
        /// Get a shot form the enemy and answer if it was a miss, hit or sunken.
        /// </summary>
        /// <param name="shot">Shot to receive from the enemy</param>
        /// <returns>Returns if the shot was a hit, miss, sunken or mine</returns>
        public virtual ShotState ReceiveShot(Shot shot)
        {
            // Find shot field
            Field shotField = fields.First(fi => fi.PosX == shot.TargetField.PosX && fi.PosY == shot.TargetField.PosY);
            //Field shotField = shot.TargetField;
            
            // Register hit
            shotField.Lifestate = FieldLifestate.Hit;

            // Check if a ship was hit
            Ship shipOnField = shotField.GetShipOnField(knownShips);

            if (null != shipOnField)
            {
                ShipLifestate shipLifestate = shipOnField.GetLifestate();

                if (shipLifestate == ShipLifestate.Alive)
                    return ShotState.Hit;
                return ShotState.Sunken;
            }
            
            if (Properties.Settings.Default.s_Mine)
            {
                // Check if a mine was hit
                Mine mineOnField = shotField.GetMineOnField(knownMines);

                if (mineOnField != null)
                    return ShotState.Mine;
            }

            return ShotState.Miss;
        }
    }
}
