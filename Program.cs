using System;

namespace ToyRobot
{
    public class Program
    {
        static void Main(string[] args)
        {
            var robot = new ToyRobot();
            bool isPlaced = false;

            Console.WriteLine("Toy Robot Simulator");
            Console.WriteLine("The table is a 5x5 grid. It is required that the first command to the robot is a PLACE command.");
            Console.WriteLine("Available commands:");
            Console.WriteLine("PLACE X,Y,FACING | MOVE | LEFT | RIGHT | REPORT | EXIT");
            Console.WriteLine("Commands:");
            Console.WriteLine(" - PLACE will put the robot on the table in position X,Y and facing NORTH, SOUTH, EAST, or WEST.");
            Console.WriteLine(" - MOVE will move the toy robot one unit forward in the direction it is currently facing.");
            Console.WriteLine(" - LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot.");
            Console.WriteLine(" - REPORT will announce the X,Y and FACING of the robot.");
            Console.WriteLine("Please note that the robot will not move to a position that causes it to fall off the table.");
            Console.WriteLine("Type 'EXIT' to end the simulation.");

            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine().ToUpper();
                if (string.IsNullOrEmpty(input)) continue;

                if (input == "EXIT")
                {
                    break;
                }

                string[] parts = input.Split(' ');

                if (!isPlaced && parts[0] != "PLACE")
                {
                    Console.WriteLine("The first command must be PLACE to set the robot on the table.");
                    continue;
                }

                try
                {
                    switch (parts[0])
                    {
                        case "PLACE":
                            string[] parameters = parts[1].Split(',');
                            if (parameters.Length == 3 &&
                                int.TryParse(parameters[0], out int x) &&
                                int.TryParse(parameters[1], out int y) &&
                                Enum.TryParse(parameters[2], out Direction facing))
                            {
                                isPlaced = robot.Place(x, y, facing);
                                if (!isPlaced)
                                {
                                    Console.WriteLine("Invalid PLACE command. Please use valid coordinates and facing (NORTH, EAST, SOUTH, WEST).");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid PLACE command format. Usage: PLACE X,Y,FACING");
                            }
                            break;
                        case "MOVE":
                            if (robot.Move() == false)
                            {
                                Console.WriteLine("Move blocked. Robot would fall off.");
                            }
                            break;
                        case "LEFT":
                            robot.Left();
                            break;
                        case "RIGHT":
                            robot.Right();
                            break;
                        case "REPORT":
                            Console.WriteLine(robot.Report());
                            break;
                        default:
                            Console.WriteLine("Invalid command. Please enter a valid command.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}