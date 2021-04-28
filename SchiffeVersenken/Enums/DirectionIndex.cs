namespace SchiffeVersenken.Enums
{
    public class DirectionIndex
    {
        public DirectionEnum Direction { get; set; }

        public enum DirectionEnum
        {
            Above,
            Below,
            Right,
            Left
        };

        public DirectionIndex()
        {
            this.Direction = DirectionEnum.Above;
        }

        public DirectionIndex(DirectionEnum direction)
        {
            this.Direction = direction;
        }

        public DirectionEnum Reset()
        {
            Direction = DirectionEnum.Above;
            return Direction;
        }

        public DirectionEnum Next()
        {
            SetNextDirection();
            return Direction;
        }

        private void SetNextDirection()
        {
            switch (Direction)
            {
                case DirectionEnum.Above:
                    Direction = DirectionEnum.Below;
                    break;
                case DirectionEnum.Below:
                    Direction = DirectionEnum.Right;
                    break;
                case DirectionEnum.Right:
                    Direction = DirectionEnum.Left;
                    break;
                case DirectionEnum.Left:
                    Direction = DirectionEnum.Above;
                    break;
            }
        }
    }
}
