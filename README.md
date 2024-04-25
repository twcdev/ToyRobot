# ToyRobot

## Overview
ToyRobot is a simple console application that simulates a robot moving on a 5x5 square tabletop. It follows specific commands to navigate the table without falling off.

## How to Use
First, make sure the robot is placed on the table using the PLACE command. All subsequent commands will be ignored until the robot is successfully placed.

### Available Commands
- `PLACE X,Y,FACING`: Sets the robot on the table in position X,Y and facing NORTH, SOUTH, EAST, or WEST. This must be the first command.
- `MOVE`: Moves the toy robot one unit forward in the direction it is currently facing.
- `LEFT`: Rotates the robot 90 degrees to the left without changing its position.
- `RIGHT`: Rotates the robot 90 degrees to the right without changing its position.
- `REPORT`: Outputs the current position (X,Y) and direction the robot is facing.
- `EXIT`: Ends the simulation.

### Notes
- The table is a 5x5 grid. Any command that would result in the robot falling off will be ignored.
- It is required that the first command to the robot is a `PLACE` command.

## Running the Simulator
After cloning the repository and navigating to the project directory, run the application using the following command:

```bash
dotnet run
