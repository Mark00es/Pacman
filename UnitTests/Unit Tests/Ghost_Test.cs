using System;
using System.Drawing;
using System.Windows.Forms;
using NUnit.Framework;

namespace Pacman.Test
{
    [TestFixture]
    public class Ghost_Test
    {
        private Ghost ghost;
        private Form testForm;

        [SetUp]
        public void SetUp()
        {
            // Inicializa una nueva instancia de Ghost y un formulario de prueba
            ghost = new Ghost();
            testForm = new Form();
        }
        [TearDown]
        public void TearDown()
        {
            // Limpia los recursos después de cada prueba
            testForm.Dispose();
        }

        [Test]
        public void CreateGhostImageTest()
        {
            ghost.CreateGhostImage(testForm);
            for (int i = 0; i < ghost.Ghosts; i++)
            {
                Assert.IsNotNull(ghost.GhostImage[i]);
                Assert.AreEqual("GhostImage" + i, ghost.GhostImage[i].Name);
                Assert.AreEqual(PictureBoxSizeMode.AutoSize, ghost.GhostImage[i].SizeMode);
                Assert.AreSame(testForm, ghost.GhostImage[i].Parent);
            }
        }

        [Test]
        public void Set_GhostsTest()
        {
            int[,] mockMatrix = new int[30, 27];
            mockMatrix[10, 5] = 15;
            Form1.gameboard.Matrix = mockMatrix;
            ghost.Set_Ghosts();
            Assert.AreEqual(4, ghost.xStart.Length);
            Assert.AreEqual(4, ghost.yStart.Length);
            Assert.AreEqual(5, ghost.xStart[0]);
            Assert.AreEqual(10, ghost.yStart[0]);
        }

        [Test]
        public void Statetimer_Tick_Test()
        {
            Ghost ghost = new Ghost();

            for (int i = 0; i < Ghost.GhostAmount; i++)
            {
                ghost.State[i] = 1;
            }
            ghost.statetimer_Tick(null, null);
            for (int i = 0; i < Ghost.GhostAmount; i++)
            {
                Assert.AreEqual(0, ghost.State[i], $"Ghost {i} state should be 0");
            }

            Assert.IsFalse(ghost.statetimer.Enabled, "statetimer should be disabled");
        }

    }
}
