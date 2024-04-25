using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToyRobot.Tests
{
    [TestClass()]
    public class ToyRobotTests
    {
        [DataTestMethod]
        [DataRow(0, 0, Direction.NORTH, true)]
        [DataRow(1, 1, Direction.EAST, true)]
        [DataRow(2, 2, Direction.SOUTH, true)]
        [DataRow(3, 3, Direction.WEST, true)]
        [DataRow(4, 4, Direction.NORTH, true)]
        [DataRow(5, 4, Direction.EAST, false)] // Invalid x, Robot fall off the table
        [DataRow(4, 5, Direction.SOUTH, false)] // Invalid y, Robot fall off the table
        [DataRow(-1, 0, Direction.NORTH, false)] // Invalid x, Robot fall off the table
        [DataRow(0, -1, Direction.EAST, false)] // Invalid y, Robot fall off the table
        public void Place_ShouldReturnCorrectResult(int x, int y, Direction facing, bool expectedResult)
        {
            // Arrange
            var robot = new ToyRobot();

            // Act
            bool result = robot.Place(x, y, facing);

            // Assert
            Assert.AreEqual(expectedResult, result);
            if (expectedResult)
            {
                Assert.AreEqual(x, robot.X);
                Assert.AreEqual(y, robot.Y);
                Assert.AreEqual(facing, robot.Facing);
            }
        }

        [DataTestMethod]
        [DataRow(2, 2, Direction.NORTH, true, 2, 3)]
        [DataRow(2, 2, Direction.EAST, true, 3, 2)]
        [DataRow(2, 2, Direction.SOUTH, true, 2, 1)]
        [DataRow(2, 2, Direction.WEST, true, 1, 2)]
        [DataRow(3, 4, Direction.NORTH, false, 3, 4)] // Should not move, Robot will fall off the table
        [DataRow(4, 3, Direction.EAST, false, 4, 3)] // Should not move, Robot will fall off the table
        [DataRow(1, 0, Direction.SOUTH, false, 1, 0)] // Should not move, Robot will fall off the table
        [DataRow(0, 1, Direction.WEST, false, 0, 1)] // Should not move, Robot will fall off the table
        public void Move_ShouldMoveCorrectlyOrStay(int initialX, int initialY, Direction initialFacing, bool expectedResult, int expectedX, int expectedY)
        {
            // Arrange
            var robot = new ToyRobot();
            robot.Place(initialX, initialY, initialFacing);

            // Act
            bool result = robot.Move();

            // Assert
            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedX, robot.X);
            Assert.AreEqual(expectedY, robot.Y);
        }

        [DataTestMethod]
        [DataRow(Direction.NORTH, Direction.WEST)]
        [DataRow(Direction.WEST, Direction.SOUTH)]
        [DataRow(Direction.SOUTH, Direction.EAST)]
        [DataRow(Direction.EAST, Direction.NORTH)]
        public void Left_ShouldRotateCorrectly(Direction initialFacing, Direction expectedFacing)
        {
            // Arrange
            var robot = new ToyRobot();
            robot.Place(0, 0, initialFacing);

            // Act
            robot.Left();

            // Assert
            Assert.AreEqual(expectedFacing, robot.Facing);
        }

        [DataTestMethod]
        [DataRow(Direction.NORTH, Direction.EAST)]
        [DataRow(Direction.EAST, Direction.SOUTH)]
        [DataRow(Direction.SOUTH, Direction.WEST)]
        [DataRow(Direction.WEST, Direction.NORTH)]
        public void Right_ShouldRotateCorrectly(Direction initialFacing, Direction expectedFacing)
        {
            // Arrange
            var robot = new ToyRobot();
            robot.Place(0, 0, initialFacing);

            // Act
            robot.Right();

            // Assert
            Assert.AreEqual(expectedFacing, robot.Facing);
        }

        [DataTestMethod]
        [DataRow(0, 0, Direction.NORTH, "0,0,NORTH")]
        [DataRow(0, 4, Direction.EAST, "0,4,EAST")]
        [DataRow(4, 4, Direction.SOUTH, "4,4,SOUTH")]
        [DataRow(4, 0, Direction.WEST, "4,0,WEST")]
        public void Report_ShouldCorrectlyReportVariousPositionsAndDirections(int x, int y, Direction direction, string expectedReport)
        {
            // Arrange
            var robot = new ToyRobot();
            robot.Place(x, y, direction);

            // Act
            string report = robot.Report();

            // Assert
            Assert.AreEqual(expectedReport, report);
        }
    }
}