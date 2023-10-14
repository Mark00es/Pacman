using NUnit.Framework;
using System.Windows.Forms;

namespace Pacman
{
    [TestFixture]
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
            pacman.xCoordinate = 6;
            pacman.yCoordinate = 5;

            // Test the check_direction method for each direction
            Assert.IsTrue(pacman.check_direction(1)); // Check if Pacman can move up (direction 1)
            Assert.IsTrue(pacman.check_direction(2)); // Check if Pacman can move right (direction 2)
            Assert.IsTrue(pacman.check_direction(3)); // Check if Pacman can move down (direction 3)
            Assert.IsTrue(pacman.check_direction(4)); // Check if Pacman can move left (direction 4)

            // Check an invalid direction (should return false)
            Assert.IsFalse(pacman.check_direction(5)); // Check a direction that is not valid (should return false)
        }
        
        
        [Test]
        public void UpdatePacmanImageTest()
        {
            // Initialize Pacman's current direction and imageOn
            pacman.currentDirection = 1;
            pacman.imageOn = 0;

            // Store the original image reference
            var originalImage = pacman.PacmanImage.Image;

            // Call the method to update Pacman's image
            pacman.UpdatePacmanImage();

            // Verify that the image has been updated
            Assert.AreNotEqual(originalImage, pacman.PacmanImage.Image);

            // Verify that imageOn has been incremented and reset if necessary
            Assert.AreEqual(1, pacman.imageOn);

            // Test for multiple calls to ensure image cycling
            for (int i = 2; i < 4; i++)
            {
                originalImage = pacman.PacmanImage.Image;
                pacman.currentDirection = i;
                pacman.UpdatePacmanImage();
                Assert.AreNotEqual(originalImage, pacman.PacmanImage.Image);
                Assert.AreEqual(i , pacman.imageOn);
            }

            // Test for resetting imageOn when it reaches 3
            originalImage = pacman.PacmanImage.Image;
            pacman.currentDirection = 1;
            pacman.imageOn = 3;
            pacman.UpdatePacmanImage();
            Assert.AreNotEqual(originalImage, pacman.PacmanImage.Image);
            Assert.AreEqual(0, pacman.imageOn);
        }

        [Test]
        public void DirectionOkTest()
        {
            var form = new Form();
            pacman.xCoordinate = 10;
            pacman.PacmanImage = new PictureBox();
            pacman.PacmanImage.Left = 20;
            pacman.PacmanImage.Top= 30;

            //Caso 1: x<0
            bool result1 = pacman.direction_ok(-1, 0);
            Assert.IsTrue(result1);
            Assert.AreEqual(27,pacman.xCoordinate);
            Assert.AreEqual(429, pacman.PacmanImage.Left);

            //Caso 2: x>27
            bool result2 = pacman.direction_ok(28, 0);
            Assert.IsTrue(result2);
            Assert.AreEqual(0, pacman.xCoordinate);
            Assert.AreEqual(-5, pacman.PacmanImage.Left);

            //Caso 3: 
            bool result3 = pacman.direction_ok(5, 6);
            Assert.IsTrue(result3);
        }

    }
}
