using NUnit.Framework;
using System.Windows.Forms;

namespace Pacman
{
    [TestMethod]
    public class Pacman_Test
    {
        private Pacman pacman = new Pacman();

        [Test]
        public void NewPacmanTest()
        {
            // Check default Pacman values
            Assert.AreEqual(0, pacman.xCoordinate);
            Assert.AreEqual(0, pacman.yCoordinate);
            Assert.AreEqual(0, pacman.currentDirection);
            Assert.AreEqual(0, pacman.nextDirection);
        }

        [Test]
        public void CreatePacmanTest()
        {
            // Check default Pacman image has been created
            pacman.CreatePacmanImage(new Form(),0,0);
            Assert.AreNotEqual(null, pacman.PacmanImage.Image);
            Assert.AreEqual(-3, pacman.PacmanImage.Left);
            Assert.AreEqual(43, pacman.PacmanImage.Top);
            Assert.AreEqual("PacmanImage", pacman.PacmanImage.Name);
        }
          [Test]
        public void CheckDirectionTest()
        {
            // Initialize Pacman's position
            pacman.xCoordinate = 5;
            pacman.yCoordinate = 6;

            // Test the check_direction method for each direction
            Assert.IsTrue(pacman.check_direction(1)); // Check if Pacman can move up (direction 1)
            Assert.IsTrue(pacman.check_direction(2)); // Check if Pacman can move right (direction 2)
            Assert.IsFalse(pacman.check_direction(3)); // Check if Pacman cant move down (direction 3)
            Assert.IsFalse(pacman.check_direction(4)); // Check if Pacman cant move left (direction 4)

            // Check an invalid direction (should return false)
            Assert.IsFalse(pacman.check_direction(5)); // Check a direction that is not valid (should return false)
        }
    }
}
