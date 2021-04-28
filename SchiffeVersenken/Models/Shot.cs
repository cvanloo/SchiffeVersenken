using SchiffeVersenken.Enums;

namespace SchiffeVersenken.Models
{
    public class Shot
    {
        /* Fields/Members */

        private Ship shooter;
        private Field targetField;
        private ShotState shotState; 

        /* Constructors */
        
        public Shot() { } // Newtonsoft.Json.JsonConvert<>() requires the default constructor

        public Shot(Field targetField)
        {
            this.targetField = targetField;
        }

        public Shot(Ship shooter, Field targetField)
        {
            this.shooter = shooter;
            this.targetField = targetField;
        }

        /* Getters/Setters */

        public Ship Shooter
        {
            get { return shooter; }
            set { shooter = value; } // Newtonsoft.Json.JsonConvert<>() needs to be able to set the value
        }

        public Field TargetField
        {
            get { return targetField; }
            set { targetField = value; } // Newtonsoft.Json.JsonConvert<>() needs to be able to set the value
        }

        public ShotState State
        {
            get { return shotState; }
            set { shotState = value; } // Newtonsoft.Json.JsonConvert<>() needs to be able to set the value
        }

        /* Methods */
    }
}
