namespace ToyRobot
{
    public class ToyRobot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Facing { get; set; }
        private const int GridSize = 5;

        public bool Place(int x, int y, Direction facing)
        {
            if (x >= 0 && x < GridSize && y >= 0 && y < GridSize)
            {
                X = x;
                Y = y;
                Facing = facing;
                return true;
            }
            return false;
        }

        public bool Move()
        {
            switch (Facing)
            {
                case Direction.NORTH:
                    if (Y < GridSize - 1)
                    {
                        Y++;
                        return true;
                    }
                    break;
                case Direction.EAST:
                    if (X < GridSize - 1)
                    {
                        X++;
                        return true;
                    }
                    break;
                case Direction.SOUTH:
                    if (Y > 0)
                    {
                        Y--;
                        return true;
                    }
                    break;
                case Direction.WEST:
                    if (X > 0)
                    {
                        X--;
                        return true;
                    }
                    break;
                default:
                    break;
            }
            return false;
        }

        public void Left()
        {
            switch (Facing)
            {
                case Direction.NORTH:
                    Facing = Direction.WEST;
                    break;
                case Direction.WEST:
                    Facing = Direction.SOUTH;
                    break;
                case Direction.SOUTH:
                    Facing = Direction.EAST;
                    break;
                case Direction.EAST:
                    Facing = Direction.NORTH;
                    break;
                default:
                    break;
            }
        }

        public void Right()
        {
            switch (Facing)
            {
                case Direction.NORTH:
                    Facing = Direction.EAST;
                    break;
                case Direction.EAST:
                    Facing = Direction.SOUTH;
                    break;
                case Direction.SOUTH:
                    Facing = Direction.WEST;
                    break;
                case Direction.WEST:
                    Facing = Direction.NORTH;
                    break;
                default:
                    break;
            }
        }

        public string Report()
        {
            return $"{X},{Y},{Facing}";
        }
    }
}