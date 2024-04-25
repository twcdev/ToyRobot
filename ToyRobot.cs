using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    public class ToyRobot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Facing { get; set; }
        private const int GridSize = 5;
        private readonly string[] ValidDirections = new string[] { "NORTH", "EAST", "SOUTH", "WEST" };

        public bool Place(int x, int y, string facing)
        {
            if (x >= 0 && x < GridSize && y >= 0 && y < GridSize && ValidDirections.Contains(facing.ToUpper()))
            {
                X = x;
                Y = y;
                Facing = facing.ToUpper();
                return true;
            }
            return false;
        }

        public bool Move()
        {
            switch (Facing)
            {
                case "NORTH":
                    if (Y < GridSize - 1)
                    {
                        Y++;
                        return true;
                    }
                    break;
                case "EAST":
                    if (X < GridSize - 1)
                    {
                        X++;
                        return true;
                    }
                    break;
                case "SOUTH":
                    if (Y > 0)
                    {
                        Y--;
                        return true;
                    }
                    break;
                case "WEST":
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
                case "NORTH":
                    Facing = "WEST";
                    break;
                case "WEST":
                    Facing = "SOUTH";
                    break;
                case "SOUTH":
                    Facing = "EAST";
                    break;
                case "EAST":
                    Facing = "NORTH";
                    break;
                default:
                    break;
            }
        }

        public void Right()
        {
            switch (Facing)
            {
                case "NORTH":
                    Facing = "EAST";
                    break;
                case "EAST":
                    Facing = "SOUTH";
                    break;
                case "SOUTH":
                    Facing = "WEST";
                    break;
                case "WEST":
                    Facing = "NORTH";
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