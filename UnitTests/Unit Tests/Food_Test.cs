using NUnit.Framework;

namespace Pacman
{
    [TestFixture]
    public class Food_Test
    {
        public Food Food = new Food();

        public Food_Test()
        {
            Food.CreateFoodImages(new Form1());
        }

        [Test]
        public void NewFoodTest()
        {
            // Check default Food image has been created
            Assert.AreNotEqual(null, Food.FoodImage[1, 1].Image);
            Assert.AreEqual("FoodImage0", Food.FoodImage[1, 1].Name);
        }

        [Test]
        public void AmountOfFoodTest()
        {
            // Check amount of food
            Assert.AreEqual(240, Food.Amount);
        }

        [Test]
        public void EatFoodTest()
        {
            // Eat food
            Food.EatFood(1, 1);
            Assert.AreEqual(false, Food.FoodImage[1, 1].Visible);
        }
        [Test]
        public void TestEatSuperFood()
        {
            // Arrange
            int x = 1; // Coordenada X de la súper comida a comer (ajusta esto según tu caso)
            int y = 2; // Coordenada Y de la súper comida a comer (ajusta esto según tu caso)
            int initialScore = Form1.player.Score;
            int initialMatrixValue = Form1.gameboard.Matrix[x, y];
            bool initialFoodVisibility = Food.FoodImage[x, y].Visible;

            // Act
            Food.EatSuperFood(x, y);

            // Assert
            Assert.IsFalse(Food.FoodImage[x, y].Visible); // Asegurarse de que la comida se hace invisible
            Assert.AreEqual(0, Form1.gameboard.Matrix[x, y]); // Asegurarse de que el valor de la matriz se actualiza a 0
        }
    }
}